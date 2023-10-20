using Common.Infrastructure.UI;
using Core.Application.Data.ClientInfo;
using Core.Application.Data.ExploreApps;
using Core.Infrastructure.ClientInfo;
using IdentityAccess.Domain.Model.Identity;
using PaaApplication.Forms.AppExplore;
using PaaApplication.Models.AppExplore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.Helper
{
    public class Utils
    {
        public static bool IsFutureDate(string inputString, DateTime curDate)
        {
            inputString = inputString.Replace("\\", "/");
            Regex regex1 = new Regex("[0-9][0-9]-[0-9][0-9]");
            Regex regex2 = new Regex("[0-9][0-9]/[0-9][0-9]");
            Regex regex3 = new Regex("[0-9]-[0-9][0-9]");
            Regex regex4 = new Regex("[0-9]/[0-9][0-9]");
            if (regex1.IsMatch(inputString) ||
                regex2.IsMatch(inputString) ||
                regex3.IsMatch(inputString) ||
                regex4.IsMatch(inputString))
            {
                string inputDateString = string.Format("##/[0]1/##", OnlyNums(inputString));
                DateTime inputDate;
                if (DateTime.TryParse(inputDateString, out inputDate))
                {
                    if (inputDate > curDate)
                        return true;
                }
            }
            return false;
        }

        public static string OnlyNums(string input)
        {
            string justNumbers = new String(input.Where(Char.IsDigit).ToArray());
            return justNumbers.Trim();
        }

        public static string GetApplicantName(AppData app, ReportTypeData reportType)
        {
            string currentReportType = (reportType != null && !string.IsNullOrEmpty(reportType.TypeName)) ? reportType.TypeName : "";
            string bufferName = "";
            if (currentReportType == "Comm")
            {
                bufferName = app.Company;
            }
            else
            {
                bufferName = app.LastName.Trim();
                string firstName = app.FirstName.Trim();
                if (!string.IsNullOrEmpty(firstName))
                {
                    if (!string.IsNullOrEmpty(bufferName))
                    {
                        bufferName += ", " + firstName;
                    }
                    else
                    {
                        bufferName = firstName;
                    }
                }
            }
            return bufferName;
        }

        public static string GetClientName(AppData app)
        {
            if (string.IsNullOrEmpty(app.ClientAppliedName))
            {
                return app.ClientName;
            }
            return app.ClientAppliedName;
        }

        public static string StringText(string val, int count, string delim)
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result = result + val;
                if (i < count - 1)
                {
                    result = result + delim;
                }
            }
            return result;
        }

        public static void MoveAppToNewLocation(AppData app, LocationData newLocation, string currUserName = "")
        {
            if (app == null)
                return;

            Core.Domain.Model.ExploreApps.Location newAppsLocation = Core.Domain.Model.ExploreApps.Location.NewApps;
            Core.Domain.Model.ExploreApps.Location pickupLocation = Core.Domain.Model.ExploreApps.Location.Pickup;
            Core.Domain.Model.ExploreApps.Location review1Location = Core.Domain.Model.ExploreApps.Location.Review1;
            Core.Domain.Model.ExploreApps.Location review2Location = Core.Domain.Model.ExploreApps.Location.Review2;
            Core.Domain.Model.ExploreApps.Location review3Location = Core.Domain.Model.ExploreApps.Location.Review3;
            Core.Domain.Model.ExploreApps.Location archiveLocation = Core.Domain.Model.ExploreApps.Location.Archive;

            bool keepScreener = true;

            if (newLocation.LocationId != newAppsLocation.LocationId &&
                newLocation.LocationId != pickupLocation.LocationId &&
                newLocation.LocationId != review1Location.LocationId &&
                newLocation.LocationId != review2Location.LocationId &&
                newLocation.LocationId != review3Location.LocationId &&
                newLocation.LocationId != archiveLocation.LocationId &&
                app.CompletedDate == null)
            {
                keepScreener = false;
            }

            app.LocationId = newLocation.LocationId;
            app.LocationName = newLocation.LocationName;
            if (!keepScreener)
            {
                app.ScreenerId = newLocation.LocationId;
                if (newLocation.LocationName.ToUpper() == "My Desk".ToUpper())
                {
                    app.ScreenerName = currUserName;
                }
                else
                {
                    app.ScreenerName = newLocation.LocationName;
                }
            }
        }

        public static DialogResult ConfirmMoveAppToNewLocation(AppData contextApp, List<AppData> apps, User currentUser, LocationData contextLocation, ref LocationData newLocation, List<LocationData> locations, bool calcNewLocation)
        {
            int applicantNum = apps.Count;
            string confirmText = "";
            locations.Clear();
            Core.Domain.Model.ExploreApps.Location newAppsLocation = Core.Domain.Model.ExploreApps.Location.NewApps;
            Core.Domain.Model.ExploreApps.Location pickupLocation = Core.Domain.Model.ExploreApps.Location.Pickup;
            Core.Domain.Model.ExploreApps.Location review1Location = Core.Domain.Model.ExploreApps.Location.Review1;
            Core.Domain.Model.ExploreApps.Location review2Location = Core.Domain.Model.ExploreApps.Location.Review2;
            Core.Domain.Model.ExploreApps.Location review3Location = Core.Domain.Model.ExploreApps.Location.Review3;
            Core.Domain.Model.ExploreApps.Location archiveLocation = Core.Domain.Model.ExploreApps.Location.Archive;
            bool returnToScreener = false;

            if (calcNewLocation)
            {
                if (contextLocation.LocationId == newAppsLocation.LocationId)
                {
                    if (applicantNum > 1)
                    {
                        confirmText = string.Format("Move these {0} Applications to Pickup Table? ", applicantNum);
                    }
                    else
                    {
                        confirmText = "Move this Application to Pickup Table?";
                    }
                    newLocation.LocationId = pickupLocation.LocationId;
                    newLocation.LocationName = pickupLocation.LocationName;
                }
                else if (contextLocation.LocationId == pickupLocation.LocationId)
                {
                    if (applicantNum > 1)
                    {
                        confirmText = string.Format("Pickup these {0} Applications? ", applicantNum);
                    }
                    else
                    {
                        confirmText = "Pickup this Application?";
                    }
                    newLocation.LocationId = currentUser.UserId.Id;
                    newLocation.LocationName = currentUser.UserName;
                }
                else if (contextLocation.LocationId == review1Location.LocationId ||
                    contextLocation.LocationId == review2Location.LocationId ||
                    contextLocation.LocationId == review3Location.LocationId)
                {
                    if (applicantNum > 1)
                    {
                        confirmText = string.Format("Return these {0} Applications? ", applicantNum);
                    }
                    else
                    {
                        confirmText = "Return this Application?";
                    }
                    returnToScreener = true;
                }
                else if (contextLocation.LocationId == currentUser.UserId.Id)
                {
                    if (applicantNum > 1)
                    {
                        confirmText = string.Format("Move these {0} Applications to which Review location? ", applicantNum);
                    }
                    else
                    {
                        confirmText = "Move this Application to which Review location?";
                    }
                    // Assign newLocation to review1Location (we does not need to determine type of review location here)
                    // The actual review location will be choose by user and assign back later
                    newLocation.LocationId = review1Location.LocationId;
                    newLocation.LocationName = review1Location.LocationName;
                }
                else
                {
                    if (applicantNum > 1)
                    {
                        confirmText = string.Format("Move these {0} Applications to which Review location? ", applicantNum);
                    }
                    else
                    {
                        confirmText = "Move this Application to which Review location";
                    }
                    newLocation.LocationId = review1Location.LocationId;
                    newLocation.LocationName = review1Location.LocationName;
                }
            }
            else
            {
                if (newLocation.LocationId == pickupLocation.LocationId)
                {
                    if (applicantNum > 1)
                    {
                        confirmText = string.Format("Move these {0} Applications to Pickup Table? ", applicantNum);
                    }
                    else
                    {
                        confirmText = "Move this Application to Pickup Table";
                    }
                }
                else if (newLocation.LocationId == newAppsLocation.LocationId)
                {
                    if (applicantNum > 1)
                    {
                        confirmText = string.Format("Move these {0} Applications to New Apps? ", applicantNum);
                    }
                    else
                    {
                        confirmText = "Move this Applications to New Apps?";
                    }
                }
                else if (newLocation.LocationId == archiveLocation.LocationId)
                {
                    if (applicantNum > 1)
                    {
                        confirmText = string.Format("Move these {0} Applications to Archive? ", applicantNum);
                    }
                    else
                    {
                        confirmText = "Move this Application to Archive?";
                    }
                }
                else if (newLocation.LocationId == review1Location.LocationId ||
                    newLocation.LocationId == review2Location.LocationId ||
                    newLocation.LocationId == review3Location.LocationId)
                {
                    if (applicantNum > 1)
                    {
                        confirmText = string.Format("Move these {0} Applications to which Review location? ", applicantNum);
                    }
                    else
                    {
                        confirmText = "Move this Application to which Review location";
                    }
                }
                else if (newLocation.LocationId == currentUser.UserId.Id)
                {
                    if (applicantNum > 1)
                    {
                        confirmText = string.Format("Move these {0} Applications to my Desk?", applicantNum, newLocation.LocationName);
                    }
                    else
                    {
                        confirmText = string.Format("Move this Application to my Desk", newLocation.LocationName);
                    }
                }
                else
                {
                    if (applicantNum > 1)
                    {
                        confirmText = string.Format("Move these {0} Applications to {1}'s Desk?", applicantNum, newLocation.LocationName);
                    }
                    else
                    {
                        confirmText = string.Format("Move this Application to {0}'s Desk", newLocation.LocationName);
                    }
                }
            }

            List<ClientData> clients;
            List<ReportTypeData> reportTypes;
            FormMoveApps formMoveApps = null;
            DialogResult moveResult = DialogResult.No;

            ClientCachedApiQuery clientQuery = ClientCachedApiQuery.Instance;
            ReportTypeCachedApiQuery reportTypeQuery = ReportTypeCachedApiQuery.Instance;
            clients = clientQuery.GetAllClients();
            reportTypes = reportTypeQuery.GetAllReportTypes();
            if (contextApp != null && !string.IsNullOrEmpty(contextApp.ApplicationId))
            {
                List<string> applicantNames = new List<string>();
                foreach (AppData app in apps)
                {
                    
                    ReportTypeData reportType = reportTypes.Find(r => r.ReportTypeId == app.ReportTypeId);
                    applicantNames.Add(Utils.GetApplicantName(app, reportType));
                }

                formMoveApps = new FormMoveApps(applicantNames, newLocation, confirmText);
                formMoveApps.StartPosition = FormStartPosition.CenterScreen;
                moveResult = formMoveApps.ShowDialog();
                if (moveResult == DialogResult.Yes)
                {
                    //  Assign back the newLocation (for review locations)
                    newLocation = formMoveApps.NewLocation;
                }

                foreach (AppData app in apps)
                {
                    ClientData client = clients.Find(c => c.ClientId == app.ClientApplied);
                    if (returnToScreener == true)
                    {
                        // return to owner
                        newLocation = new LocationData(app.ScreenerId, app.ScreenerName);
                    }
                    locations.Add(newLocation);
                    if (newLocation.LocationId != archiveLocation.LocationId)
                        continue;
                    if (client != null && !string.IsNullOrEmpty(client.BillingInfo))
                    {
                        FormImportantInformation form = new FormImportantInformation();
                        form.StartPosition = FormStartPosition.CenterParent;
                        form.ClientName = client.ClientName;
                        form.BillingInfo = client.BillingInfo;
                        if (form.ShowDialog() != DialogResult.OK)
                            return form.DialogResult;
                    }
                }
            }

            if (formMoveApps != null)
            {
                
                formMoveApps.Close();
                return moveResult;
            }
            return DialogResult.No;
        }

        public static DialogResult ConfirmMoveAppToNewScreener()
        {
            return MessageBox.Show("Are you sure you want to change the screener for this application?", "Change Screener", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static bool IsValidEmail(string input)
        {
            if (string.IsNullOrEmpty(input.Trim()) ||
                !Regex.IsMatch(input.Trim(),
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
            {
                return false;
            }
            return true;
        }

        public static bool ValidEmailAddresses(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            string[] arrEmail = input.Split(';');

            foreach (string email in arrEmail)
            {
                if (!IsValidEmail(email))
                {
                    return false;
                }
            }
            return true;

        }

        public static SendMethod GetSendMethod(string dest)
        {
            dest = dest.Trim().ToLower();
            if (!(dest == "printer"))
            {
                if (dest == "website")
                {
                    return SendMethod.ViaWebsite;
                }
                else if (IsValidEmail(dest))
                {
                    return SendMethod.ViaEmail;
                }
                else
                {
                    int len = OnlyNums(dest).Length;
                    if (len == 7 || len == 10 || len == 11)
                        return SendMethod.ViaFax;
                }
            }
            return SendMethod.ViaPrinter;
        }

        public static bool IsRichText(string testString)
        {
            if ((testString != null) &&
                (testString.Trim().StartsWith("{\\rtf")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string RtfToText(string rtfString)
        {
            string result = rtfString;

            try
            {
                if (IsRichText(rtfString))
                {
                    // Put body into a RichTextBox so we can strip RTF
                    using (System.Windows.Forms.RichTextBox rtfTemp = new System.Windows.Forms.RichTextBox())
                    {
                        rtfTemp.Rtf = rtfString;
                        result = rtfTemp.Text;
                    }
                }
                else
                {
                    result = rtfString;
                }
            }
            catch
            {
                throw;
            }

            return result.Trim();
        }
        
        private static IEnumerable<string> Wrap(IEnumerable<string> words,
                                                int lineWidth)
        {
            var currentWidth = 0;
            foreach (var word in words)
            {
                if (currentWidth != 0)
                {
                    if (currentWidth + word.Length < lineWidth)
                    {
                        currentWidth++;
                        yield return " ";
                    }
                    else
                    {
                        currentWidth = 0;
                        yield return Environment.NewLine;
                    }
                }
                currentWidth += word.Length;
                yield return word;
            }
        }

        public static IEnumerable<string> Wrap(string text, int lineWidth)
        {
            string[] newLineArray = { Environment.NewLine, "\n" };
            string[] textArray = text.Split(newLineArray, StringSplitOptions.None);

            foreach(string line in textArray)
            {
                IEnumerable<string> linesWrap = Wrap(line.Split(new char[0], StringSplitOptions.None), lineWidth);
                string result = string.Join(string.Empty, linesWrap);
                string[] linewraps = result.Split(newLineArray, StringSplitOptions.None);
                foreach (string linewrap in linewraps)
                    yield return linewrap;
            }
        }

        public static bool IsValidApp(AppData app, ClientData client, out List<string> messages)
        {
            messages = new List<string>();

            if (app == null || client == null)
                return false;
            Regex regStr = new Regex(@"\d{3}-\d{2}-\d{4}");
            if (!regStr.IsMatch(app.AppSSN) &&
                !string.IsNullOrEmpty(app.AppSSN) &&
                (app.AppSSN != "   -  -"))
            {
                messages.Add("Unable to save! SSN is not correct.");
                return false;
            }
                
            if (string.IsNullOrEmpty(app.ClientApplied))
            {
                messages.Add("Unable to save! Client Applied is blank or empty");
                return false;
            }
                
            if (client.ClientRevoked)
            {
                messages.Add("Unable to save! Client is revoked.");
                return false;
            }

            if (!IsValidDateOfBirth(app.BirthDate))
            {
                messages.Add("Unable to save! Birthday is not corrrect.");
                return false;
            }

            return true;
        }

        public static bool IsValidPhoneNumer(string phoneNumber)
        {
            const string expression = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";

            if (string.IsNullOrEmpty(phoneNumber)) return false;

            return Regex.IsMatch(phoneNumber, expression);
        }

        private static bool IsValidDateOfBirth(DateTime? birthday)
        {
            var minAge = 0;
            var maxAge = 150;

            if (birthday == null)
                return true;
            
            if (birthday.Value.AddYears(minAge) > DateTime.Now)
                return false;

            return (birthday.Value.AddYears(maxAge) > DateTime.Now);
        }
    }
}
