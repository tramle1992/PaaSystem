using Core.Application.Data.ExploreApps;
using CreditReport.Application.Command;
using CreditReport.Application.Converter;
using CreditReport.Domain.Model;
using CreditReport.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
#if PRODUCTION_DEPLOY
using TuStd = MicrobiltPortAdapter.ProductionTuStd;
#else
using TuStd = MicrobiltPortAdapter.StagingTuStd;
#endif
namespace CreditReport.Application
{
    public class CreditReportApplicationService
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Get the credit report with input from the GetReportCommand
        /// </summary>
        /// <param name="getReportCommand">The information of the applicant</param>
        /// <returns></returns>
        public static TuStd.TuStdRs_Type GetTuReport(GetReportCommand getReportCommand)
        {
            var request = new TuStd.TuStdRq_Type()
            {
                MsgRqHdr = new TuStd.MsgRqHdr_Type
                {
                    MemberId = getReportCommand.AccountId,
                    MemberPwd = getReportCommand.AccountPassword,
                    ReasonCode = getReportCommand.PermissiblePurposes,
                    UserName = getReportCommand.EndUser
                },
                PersonInfo = new TuStd.PersonInfo_Type
                {
                    PersonName = new TuStd.PersonName_Type
                    {
                        ItemsElementName = new[] { TuStd.ItemsChoiceType.FirstName, TuStd.ItemsChoiceType.LastName, TuStd.ItemsChoiceType.MiddleName },
                        Items = new[] { getReportCommand.FirstName.ToUpper(), getReportCommand.LastName.ToUpper(), getReportCommand.MiddleName.ToUpper() },
                    },
                    ContactInfo = new[]
                    {
                        new TuStd.ContactInfo_Type
                        {
                            PostAddr = new TuStd.PostAddr_Type
                            {
                                ItemsElementName = new[]
                                {
                                    TuStd.ItemsChoiceType1.StreetNum,
                                    TuStd.ItemsChoiceType1.StreetName,
                                },
                                Items = new[]
                                {
                                    Regex.Replace(getReportCommand.StreetNum, @"[^\w\s]", ""),
                                    Regex.Replace(getReportCommand.StreetName, @"[^\w\s]", ""),
                                    },
                                    City = getReportCommand.City,
                                    StateProv = getReportCommand.State,
                                    PostalCode = getReportCommand.Zipcode
                            },
                        },
                    },
                    TINInfo = new TuStd.TINInfo_Type
                    {
                        TINType = "SSN",
                        TaxId = Regex.Replace(getReportCommand.Ssn, @"[^\d]", "")
                    },
                }
            };

            XmlSerializer xmlSerializer = new XmlSerializer(request.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, request);
                _logger.Debug("Start pull credit with request object");
                _logger.Debug(textWriter.ToString());
            }

            return MicrobiltPortAdapter.MicrobiltService.GetReport(request);
        }


        public string NewReport(NewReportCommand command)
        {
            Report reportData = command.Report;
            Report report = new Report(reportData.ReportId, reportData.ApplicationId);

            try
            {
                report.Type = reportData.Type;
                report.DataBlob = reportData.DataBlob;
                report.CreatedAt = DateTime.UtcNow;
                report.UpdatedAt = DateTime.UtcNow;
                report.EndUser = reportData.EndUser;
                report.StatusCode = reportData.StatusCode;
                report.PulledBy = reportData.PulledBy;

                ReportRepository reportRepo = new ReportRepository();
                reportRepo.Add(report);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return report.ReportId;
        }
    }
}
