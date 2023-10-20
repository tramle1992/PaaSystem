using Administration.Domain.Model.Microbilt;
using Core.Application.Data.ExploreApps;
using Core.Domain.Model.ClientInfo;
using CreditReport.Application.Command;
using CreditReport.Application.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
#if PRODUCTION_DEPLOY
using TuStd = MicrobiltPortAdapter.ProductionTuStd;
#else
using TuStd = MicrobiltPortAdapter.StagingTuStd;
#endif
namespace PaaApplication.Helper
{
    public class CreditReportHelper
    {
        /// <summary>
        /// Generate the GetReportCommand to use with Microbilt service
        /// </summary>
        /// <param name="app">The AppData value object which contains the address of applicant</param>
        /// <param name="acc">The Microbilt account, using on request</param>
        /// <returns></returns>
        public static GetReportCommand BuildGetReportCommand(AppData app, AccountInfo acc)
        {
            var result = new GetReportCommand();

            result.AccountId = acc.MemberId;
            result.AccountPassword = acc.Password;
            result.AccountCreditType = acc.CreditType;
            result.StreetNum = app.HouseNumber;
            result.StreetName = app.StreetAddress;
            result.City = app.City;
            result.State = app.State;
            result.Zipcode = app.PostalCode;
            result.Ssn = app.AppSSN;
            result.FirstName = app.FirstName;
            result.MiddleName = app.MiddleName;
            result.LastName = app.LastName;
            if (!string.IsNullOrEmpty(app.ReportManagement) && !app.ReportManagement.Trim().ToLower().Equals("ind"))
            {
                result.EndUser = app.ReportManagement;
            }
            else
            {
                result.EndUser = app.ClientAppliedName;
            }
#if PRODUCTION_DEPLOY
            result.PermissiblePurposes = "TS";
#else
            result.PermissiblePurposes = "";
#endif
            return result;
        }

        public static AppData MergeReportInfo(AppData app, TuStd.TuStdRs_Type response, GetReportCommand command)
        {
            if (app == null || response == null)
                throw new ArgumentException("Invalid argument");

            if (response.Subject == null && response.Subject.Length < 1)
                throw new ArgumentException("Invalid TuStd.TuStdRs_Type response");

            var subject = response.Subject[0];

            // Do the name, SSN and Date of Birth match application
            bool match = true;
            if (new string(app.AppSSN.Where( char.IsDigit).ToArray()).Trim() != subject.PersonInfo.TINInfo.TaxId.Trim())
            {
                match = false;
            }
            var dateBirth = app.BirthDate.HasValue ? app.BirthDate.Value.ToString("MM-dd-yyyy") : "";
            if (app.BirthDate == null || subject.PersonInfo.BirthDt == null || dateBirth != subject.PersonInfo.BirthDt.ToString("MM-dd-yyyy"))
            {
                match = false;
            }
            var subjectFirstNameIndex = subject.PersonInfo.PersonName.ItemsElementName.ToList().FindIndex(c => c == TuStd.ItemsChoiceType.FirstName);
            var subjectLastNameIndex = subject.PersonInfo.PersonName.ItemsElementName.ToList().FindIndex(c => c == TuStd.ItemsChoiceType.LastName);
            var subjectFirstName = subject.PersonInfo.PersonName.Items[subjectFirstNameIndex] ?? "";
            var subjectLastName = subject.PersonInfo.PersonName.Items[subjectLastNameIndex] ?? "";
            if (app.FirstName.ToLower() != subjectFirstName.ToLower() || app.LastName.ToLower() != subjectLastName.ToLower())
            {
                match = false;
            }
            app.CreditInfo.CreditMatched = match;

            // Rental Ref            
            if (subject.PersonInfo != null && subject.PersonInfo.ContactInfo != null && subject.PersonInfo.ContactInfo.Length > 1)
            {
                for (var i = subject.PersonInfo.ContactInfo.Length - 1; i >= 0; i--)
                {                    
                    var rentalRef = AppConverter.FromPostAddr(subject.PersonInfo.ContactInfo[i].PostAddr);
                    if (rentalRef != null)
                    {
                        app.RentalRefs.Add(rentalRef);
                    }
                }
            }

            // Score for with score
            if (subject.Score != null && subject.Score.Length > 0 && command.AccountCreditType == CreditType.CreditAndFICOScore.Value)
            {
                if (Utils.IsRichText(app.FinalComments))
                {
                    using (System.Windows.Forms.RichTextBox rtfTemp = new System.Windows.Forms.RichTextBox())
                    {
                        var oldText = Utils.RtfToText(app.FinalComments);
                        var listOldText = oldText.Split(Environment.NewLine.ToCharArray()).ToList();
                        listOldText.RemoveAll(s => s.Trim().StartsWith("FICO Score"));
                        for (var i = 0; i < listOldText.Count; i++)
                        {
                            if (i == listOldText.Count - 1)                                
                            {
                                rtfTemp.AppendText(listOldText[i]);
                            }
                            else
                            {
                                rtfTemp.AppendText(listOldText[i]);
                                rtfTemp.AppendText(Environment.NewLine);
                            }
                        }
                        rtfTemp.AppendText(Environment.NewLine);
                        rtfTemp.AppendText(AppConverter.ScoreToFinalInfoComment(subject.Score[0]));
                        app.FinalComments = rtfTemp.Rtf;
                    }
                }
                else
                {
                    using (System.Windows.Forms.RichTextBox rtfTemp = new System.Windows.Forms.RichTextBox())
                    {
                        // Default format from txtFinComment
                        rtfTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
                        rtfTemp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                        rtfTemp.AppendText(AppConverter.ScoreToFinalInfoComment(subject.Score[0]));
                        app.FinalComments = rtfTemp.Rtf;
                    }
                }
            }

            // Collection
            app.CreditInfo.Collections = 0m;
            if (subject.Collection != null && subject.Collection.Length > 0)
            {
                foreach (var item in subject.Collection)
                {
                    if (item == null) continue;

                    if (item != null && item.CurrentAmt != null)
                        app.CreditInfo.Collections += item.CurrentAmt.Amt;
                }
            }

            // Past due amount
            int acctType;
            app.CreditInfo.ChildSupport = 0m;
            app.CreditInfo.PastDueAmounts = 0m;
            if (subject.Liability != null && subject.Liability.Length > 0)
            {
                foreach (var item in subject.Liability)
                {
                    if (item == null) continue;

                    if (int.TryParse(item.AcctType, out acctType))
                    {
                        if (acctType == 27 && item.PastDueAmt != null)
                        {
                            // Past due child support
                            app.CreditInfo.ChildSupport += item.PastDueAmt.Amt;
                        }
                        else if (acctType > 0 && item.PastDueAmt != null)
                        {
                            // Add the past due if it's not Child support (code 27 - refer to document)
                            app.CreditInfo.PastDueAmounts += item.PastDueAmt.Amt;
                        }
                    }

                    // For charged-off debt
                    if (item.CurrentRating != null && 
                        item.CurrentRating.Code == "09" && 
                        item.BalanceAmt != null &&
                        item.BalanceAmt.TotalAmt != null)
                    {
                        app.CreditInfo.PastDueAmounts += item.BalanceAmt.TotalAmt.Amt;
                        app.CreditInfo.PastDueAmounts -= item.PastDueAmt.Amt;
                    }
                }
            }
            

            // Public Record
            int prType;
            bool isBankruptcy = false;
            List<string> bankcrupcyDates = new List<string>();
            app.CreditInfo.Liens = 0m;
            app.CreditInfo.Judgements = 0m;
            if (subject.PublicRecord != null && subject.PublicRecord.Length > 0)
            {
                foreach (var item in subject.PublicRecord)
                {
                    if (item == null) continue;

                    if (int.TryParse(item.PRType, out prType))
                    {
                        // Calculate liens
                        if (AppConverter.IsLienPublicRecord(prType) && !AppConverter.IsPaidOrReleasedLienPublicRecord(prType) && item.UnpaidBalanceAmt != null)
                        {
                            app.CreditInfo.Liens += item.UnpaidBalanceAmt.Amt;
                        }
                        else if (AppConverter.IsJudgmentPublicRecord(prType) && !AppConverter.IsPaidOrReleasedLienPublicRecord(prType) && item.UnpaidBalanceAmt != null)
                        {
                            app.CreditInfo.Judgements += item.UnpaidBalanceAmt.Amt;
                        }
                        else if (AppConverter.IsBankcruptcyPublicRecord(prType))
                        {
                            isBankruptcy = true;
                            bankcrupcyDates.Add(item.ReportedDt.ToShortDateString());
                        }
                    }
                }
                if (isBankruptcy)
                {
                    app.CreditInfo.CreditHistoryBankrupted = true;
                    if (bankcrupcyDates.Count == 1)
                    {
                        app.CreditInfo.Dates = bankcrupcyDates[0];
                    }
                    else if (bankcrupcyDates.Count > 1)
                    {
                        app.CreditInfo.Dates = string.Join(", ", bankcrupcyDates);
                    }
                }
            }

            return app;
        }
    }
}
