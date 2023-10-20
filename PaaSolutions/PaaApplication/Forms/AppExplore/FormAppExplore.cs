using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using PaaApplication.UserControls.AppExplore;
using Common.Infrastructure.OLV;
using Core.Application.Data.ExploreApps;
using Core.Application.Data.ClientInfo;
using IdentityAccess.Application.Data;
using Common.Infrastructure.ApiClient;
using Core.Infrastructure.ExploreApps;
using Core.Domain.Model.ExploreApps;
using Core.Application.Command.ExploreApps;
using Core.Infrastructure.ClientInfo;
using Common.Infrastructure.UI;
using Common.Application;
using IdentityAccess.Domain.Model.Identity;
using PaaApplication.Models.AppExplore;
using BrightIdeasSoftware;
using Common.Infrastructure.Office;
using Word = NetOffice.WordApi;
using PaaApplication.Models.Common;
using PaaApplication.Helper;
using System.IO;
using IdentityAccess.Infrastructure.Identity;
using IdentityAccess.CommonType;
using IdentityAccess.Domain.Model.Access;
using IdentityAccess.Infrastructure.Authorization;
using Common.Infrastructure.AppEnvironment;
using Common.Infrastructure.FTPService;
using Common.Infrastructure.CheckSpelling;
using Common.Infrastructure.CheckSpelling.Dictionary;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using SystemConfiguration.Infrastructure;
using SystemConfiguration.Application.Data;
using OpenXmlPowerTools;
using Common.Infrastructure.Helper;
using PaaApplication.Forms.Common;
using DocumentFormat.OpenXml.Packaging;
using PaaApplication.Models.ClientInfo;
using PaaApplication.Models;
using PaaApplication.Helper.Comparer;
using CreditReport.Application;
using CreditReport.Application.Command;
using Administration.Infrastructure.Microbilt;
#if PRODUCTION_DEPLOY
using TuStd = MicrobiltPortAdapter.ProductionTuStd;
#else
using TuStd = MicrobiltPortAdapter.StagingTuStd;
#endif

namespace PaaApplication.Forms.AppExplore
{
    public partial class FormAppExplore : BaseForm
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private FormMaster formMaster;
        private FormEportCredit formEportCredit;
        private FormPullCredit formPullCredit;
        private FormClientInfo frmClientInfo;

        private AppApiRepository appApiRepository;
        private AppCachedApiQuery appCachedApiQuery;
        private ReportTypeCachedApiQuery reportTypeCachedApiQuery;
        private ClientCachedApiQuery clientCachedApiQuery;

        private Spelling spellChecker;
        private Control currentCheckSpellingControl;
        private int currentActiveTabIndex = 0;
        private bool checkSpellingCurrentTextBox = true;
        private Pen checkSpellingPen;
        private Dictionary<string, Graphics> checkSpellingGraphics;

        private AppData _contextApp = null;                 // context app is the app of current context menu - use in case select multiple app but want to have a context
        private string _originalClientApplied = null;
        public AppData currentLoadedApp = null;

        private bool loadCompleted = false;
        private List<AppData> selectedObjects = new List<AppData>();

        public EventHandler<ClientUpdatedEventArgs> ClientUpdated;

        public FormAppExplore()
        {
        }

        public FormAppExplore(FormMaster formMaster)
        {
            InitializeComponent();
            this.formMaster = formMaster;

            this.partOneControl1.ClientAppliedChanged += OnClientAppliedChanged;
            this.partOneControl1.ViewClientInformation += ViewClientInformationHandler;
            this.partTwoControl1.InvoiceDivisionChanged += InvoiceDivisionChangedHandler;
            this.appMenuControl1.PrintAppReports += PrintAppReportHandler;
            this.appMenuControl1.MoveLocation += MoveLocationUsingComboBoxHandler;
            this.appMenuControl1.MoveScreener += MoveScreenerUsingComboBoxHandler;
            this.appMenuControl1.ReviewComment += ReviewCommentHandler;
            this.appMenuControl1.GotoAppClick += GotoAppClickHandler;
            this.appMenuControl1.MarkCompleteClick += MarkCompleteClickHandler;
            this.appMenuControl1.MarkInProcessClick += MarkInProcessClickHandler;
            this.appMenuControl1.CompleteAppClick += CompleteAppClickHandler;
            // this.appMenuControl1.InvoiceDivisionChanged += InvoiceDivisionChangedHandler;
            this.rentalControl1.BeforeSetTemplateRentalRef += BeforeSetTemplateRentalRefHandler;
            this.finalInfoControl1.BeforeSetTemplateRentalRef += BeforeSetTemplateRentalRefHandler;
            this.empTypeOne1.BeforeSetTemplateRentalRef += BeforeSetTemplateRentalRefHandler;
            this.empTypeTwo1.BeforeSetTemplateRentalRef += BeforeSetTemplateRentalRefHandler;

            InitializeSpellChecker();

            appApiRepository = new AppApiRepository();
            appCachedApiQuery = new AppCachedApiQuery();
            reportTypeCachedApiQuery = new ReportTypeCachedApiQuery();
            clientCachedApiQuery = new ClientCachedApiQuery();

            changeLocationToolStripMenuItem.Click += new EventHandler(delegate (object s, EventArgs ev)
            {
                GotoAppClickHandler(s, ev);
            });

            this.appMenuControl1.FormMaster = formMaster;
            this.partOneControl1.FormMaster = formMaster;

            this.ClientUpdated += formMaster.ClientUpdatedHandler;
        }

        private void InitializeSpellChecker()
        {
            spellChecker = new Spelling();
            WordDictionary wordDictionary = new WordDictionary(this.components);
            AppSettingsReader configurationAppSettings = new AppSettingsReader();
            wordDictionary.DictionaryFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)
                + @"\" + ((string)(configurationAppSettings.GetValue("AppDataFolder", typeof(string)))) + @"Dic" + @"\";
            wordDictionary.DictionaryFile = "en-US.dic";
            wordDictionary.DownloadUri = ((string)(configurationAppSettings.GetValue("Dic.DownloadUri", typeof(string))));

            spellChecker.Dictionary = wordDictionary;
            spellChecker.ShowDialog = true;

            spellChecker.ReplacedWord += new Spelling.ReplacedWordEventHandler(this.spellChecker_ReplacedWord);
            spellChecker.DeletedWord += new Spelling.DeletedWordEventHandler(this.spellChecker_DeletedWord);
            spellChecker.EndOfText += new Spelling.EndOfTextEventHandler(this.spellChecker_EndOfText);

            spellChecker.OnCancelSuggestionForm += spellChecker_OnCancelSuggestionForm;

            checkSpellingPen = new Pen(System.Drawing.Color.Red);
            checkSpellingGraphics = new Dictionary<string, Graphics>();
        }

        private void FormAppExplore_LoadCompleted(object sender, EventArgs e)
        {
            using (new HourGlass())
            {
                //formEportCredit = new FormEportCredit(this);
                formPullCredit = new FormPullCredit(this.formMaster, this);

                this.partOneControl1.InitializeSettings();
                this.netToolControl1.LoadInternetToolData();

                LoadAppExplore();
                txtSearch.Focus();

                this.loadCompleted = true;
            }
        }

        private void LoadControlsByType(string rType)
        {
            // Initial Forms Load...
            partSixControl1.HideLabelAndTextBox(rType);
            partSixControl2.HideLabelAndTextBox(rType);
            ciTypeOne1.Show();

            criEvControl1.Show();
            finalInfoControl1.Show();
            finalInfoControl1.IsResidentialReport(rType);
            appMenuControl1.Show();
            netToolControl1.Show();
            partFiveControl1.Show();

            switch (rType)
            {
                case ("Commercial"):
                    // Applicant Info - Group #2
                    partTwoControl1.Hide();
                    partThreeControl1.Show();
                    partSixControl1.Show();
                    partSixControl2.Hide();
                    criEvControl1.Hide();
                    // Only Commercial Credit Info has difference view from others
                    ciTypeOne1.Hide();
                    ciTypeTwo1.Show();
                    // No Employment Info
                    // Same Rental Info
                    rentalControl1.Show();
                    // No Criminal / Eviction Info
                    // Final Info - Group #2
                    empTypeTwo1.Hide();
                    empTypeOne1.Hide();
                    break;
                case ("Employment"):
                    // Applicant Info - Group #3
                    ciTypeTwo1.Hide();
                    empTypeOne1.Hide();
                    partTwoControl1.Show();
                    partSixControl1.Hide();
                    partSixControl2.Show();
                    partFiveControl1.Hide();
                    // Same Credit Info
                    // Employment Info - Group #1
                    empTypeTwo1.Show();
                    // Same Rental Info
                    rentalControl1.Show();
                    // Same Criminal / Eviction
                    // Final Info - Group #2
                    break;
                case ("Residential"):
                    // Applicant Info - Group #4
                    ciTypeTwo1.Hide();
                    partTwoControl1.Show();
                    partThreeControl1.Hide();
                    partSixControl1.Show();
                    partSixControl2.Hide();
                    // Same Credit Info
                    // Employment Info - Group #2
                    empTypeOne1.Show();
                    // Same Rental Info                    
                    rentalControl1.Show();
                    // Same Criminal / Eviction
                    // Final Info - Group #1
                    empTypeTwo1.Hide();
                    break;
                case ("Credit"):
                    // Applicant Info - Group #1
                    ciTypeTwo1.Hide();
                    partTwoControl1.Show();
                    partThreeControl1.Hide();
                    partSixControl1.Show();
                    partSixControl2.Hide();
                    // Same Credit Info
                    // No Employment Info
                    // No Rental Info
                    // Same Criminal / Eviction
                    // Final Info - Group #2
                    rentalControl1.Hide();
                    empTypeTwo1.Hide();
                    empTypeOne1.Hide();
                    break;
                case ("Credit/Criminal"):
                    // Applicant Info - Group #1
                    ciTypeTwo1.Hide();
                    partTwoControl1.Show();
                    partThreeControl1.Hide();
                    partSixControl1.Show();
                    partSixControl2.Hide();
                    // Same Credit Info
                    // No Employment Info
                    // No Rental Info
                    // Same Criminal / Eviction
                    // Final Info - Group #2
                    rentalControl1.Hide();
                    empTypeTwo1.Hide();
                    empTypeOne1.Hide();
                    break;
                case ("Criminal"):
                    // Applicant Info - Group #1
                    ciTypeTwo1.Hide();
                    partTwoControl1.Show();
                    partThreeControl1.Hide();
                    partSixControl1.Show();
                    partSixControl2.Hide();
                    // Same Credit Info
                    // No Employment Info
                    // No Rental Info
                    // Same Criminal / Eviction
                    // Final Info - Group #2
                    rentalControl1.Hide();
                    empTypeTwo1.Hide();
                    empTypeOne1.Hide();
                    break;
                default:
                    MessageBox.Show("Undefined Report Type!");
                    break;
            }
        }

        private void InitializeSettings()
        {
            this.olvcolAppName.AspectGetter = delegate (object row)
            {
                AppData app = row as AppData;
                if (app != null)
                {
                    ReportTypeData reportType = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);
                    return Utils.GetApplicantName(app, reportType);
                }
                return "";
            };

            this.olvcolClient.AspectGetter = delegate (object row)
            {
                AppData app = row as AppData;
                if (app != null)
                {
                    return Utils.GetClientName(app);
                }
                return "";
            };

            this.olvcolReceived.AspectGetter = delegate (object row)
            {
                AppData appplication = row as AppData;
                if (appplication != null)
                {
                    if (appplication.ReceivedDate != null)
                    {
                        return ((DateTime)appplication.ReceivedDate).ToLocalTime();
                    }
                }
                return "";
            };

            this.olvcolCompleted.AspectGetter = delegate (object row)
            {
                AppData appplication = row as AppData;
                if (appplication != null)
                {
                    if (appplication.CompletedDate != null)
                    {
                        return ((DateTime)appplication.CompletedDate).ToLocalTime().ToString("MM/dd/yyyy hh:mm tt");
                    }
                    else
                    {
                        return "In-Process";
                    }
                }
                return "";
            };

            this.olvAppExplore.CustomSorter = delegate (OLVColumn column, SortOrder sortOrder)
            {
                if (column == olvcolCompleted)
                {
                    this.olvAppExplore.ListViewItemSorter = new CompletedDateComparer(sortOrder);
                }
                else
                {
                    this.olvAppExplore.ListViewItemSorter = new ColumnComparer(column, sortOrder);
                }
            };
        }

        private List<LocationData> GetAvailableMoveToOptions(LocationData contextLocation)
        {
            User user = formMaster.CURRENT_USER;
            List<LocationData> locations = new List<LocationData>();
            Core.Domain.Model.ExploreApps.Location pickup = Core.Domain.Model.ExploreApps.Location.Pickup;
            Core.Domain.Model.ExploreApps.Location review1 = Core.Domain.Model.ExploreApps.Location.Review1;
            Core.Domain.Model.ExploreApps.Location review2 = Core.Domain.Model.ExploreApps.Location.Review2;
            Core.Domain.Model.ExploreApps.Location review3 = Core.Domain.Model.ExploreApps.Location.Review3;
            Core.Domain.Model.ExploreApps.Location newApps = Core.Domain.Model.ExploreApps.Location.NewApps;
            Core.Domain.Model.ExploreApps.Location archive = Core.Domain.Model.ExploreApps.Location.Archive;

            LocationData userLocation = AutoMapper.Mapper.Map<Core.Domain.Model.ExploreApps.Location, LocationData>(Core.Domain.Model.ExploreApps.Location.FromUser(user));
            locations.Add(new LocationData(userLocation.LocationId, userLocation.LocationName));
            locations.Add(new LocationData(pickup.LocationId, pickup.LocationName));
            locations.Add(new LocationData(review1.LocationId, review1.LocationName));
            locations.Add(new LocationData(review2.LocationId, review2.LocationName));
            locations.Add(new LocationData(review3.LocationId, review3.LocationName));
            locations.Add(new LocationData(newApps.LocationId, newApps.LocationName));
            locations.Add(new LocationData(archive.LocationId, archive.LocationName));

            if (contextLocation != null)
            {
                if (contextLocation.LocationId == Core.Domain.Model.ExploreApps.Location.Review1.LocationId)
                {
                    return locations;
                }
                else
                {
                    return locations.FindAll(l => l.LocationId != contextLocation.LocationId);
                }
            }
            else
            {
                return locations;
            }
        }

        private List<LocationData> GetAvailableLocationFromUsers(LocationData contextLocation)
        {
            UserCachedApiQuery userCachedApiQuery = UserCachedApiQuery.Instance;
            List<LocationData> locations = new List<LocationData>();
            List<User> _users = userCachedApiQuery.GetAllUsers().FindAll(u => u.Status == UserStatus.Active);
            foreach (User user in _users)
            {
                LocationData location = new LocationData(user.UserId.Id, user.UserName);
                locations.Add(location);
            }

            if (contextLocation != null)
            {
                return locations.FindAll(l => l.LocationId != contextLocation.LocationId);
            }
            else
            {
                return locations;
            }
        }

        private void LoadAppExplore()
        {
            InitializeSettings();
            User user = formMaster.CURRENT_USER;
            if (user != null)
            {
                string locationId = user.UserId.Id;
                this.ChangeLocation(locationId);
                formMaster.CurrentLocation = new LocationData(locationId, user.UserName);
            }
            LoadControlsByType("Residential");
        }

        public void ChangeLocation(string locationId, AppData appToSelect = null)
        {
            try
            {
                using (new HourGlass())
                {
                    List<AppData> apps = appApiRepository.FindByLocation(locationId);

                    if (apps != null && apps.Count > 0)
                    {
                        this.olvAppExplore.SetObjects(apps);
                        // this.olvAppExplore.SelectedIndex = 0;
                    }
                    else
                    {
                        this.ResetControls();
                        this.olvAppExplore.ClearObjects();
                    }

                    if (appToSelect == null)
                    {
                        this.olvAppExplore.SelectedIndex = 0;
                    }
                    else
                    {
                        for (int i = 0; i < this.olvAppExplore.Items.Count; i++)
                        {
                            AppData item = (AppData)this.olvAppExplore.GetModelObject(i);
                            if (item != null && !string.IsNullOrEmpty(item.ApplicationId) &&
                                item.ApplicationId.Equals(appToSelect.ApplicationId))
                            {
                                this.olvAppExplore.SelectedIndex = i;
                                this.olvAppExplore.EnsureVisible(i);
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreateNewApp()
        {
            try
            {
                AppData app = new AppData();
                app.ApplicationId = Guid.NewGuid().ToString();
                app.ReceivedDate = DateTime.UtcNow;

                if ((formMaster.CurrentLocation != null) &&
                    (formMaster.CurrentLocation.LocationId != Core.Domain.Model.ExploreApps.Location.Search.LocationId) &&
                    (formMaster.CurrentLocation.LocationId != Core.Domain.Model.ExploreApps.Location.Archive.LocationId))
                {
                    app.LocationId = formMaster.CurrentLocation.LocationId;
                    app.LocationName = formMaster.CurrentLocation.LocationName;
                }
                else if (formMaster.CurrentLocation.LocationId == Core.Domain.Model.ExploreApps.Location.Search.LocationId ||
                    formMaster.CurrentLocation.LocationId == Core.Domain.Model.ExploreApps.Location.Archive.LocationId)
                {
                    User user = formMaster.CURRENT_USER;
                    app.LocationId = user.UserId.Id;
                    app.LocationName = user.UserName;
                }

                var reportTypes = reportTypeCachedApiQuery.GetAllReportTypes();


                CreditInfoData creditInfoData = new CreditInfoData();

                // Get first Client which has Block Activity = false

                ClientCachedApiQuery clientQuery = new ClientCachedApiQuery();
                List<ClientData> listAllClients = clientQuery.GetAllClients();

                if (listAllClients != null && listAllClients.Count > 0)
                {
                    foreach (ClientData client in listAllClients)
                    {
                        if (!client.ClientRevoked)
                        {
                            app.ClientApplied = client.ClientId;
                            app.ReportManagement = client.ManagementCompany != null ? client.ManagementCompany.Name : "";
                            if (!string.IsNullOrEmpty(client.DefaultReportTypeId))
                            {
                                foreach (ReportTypeData reportType in reportTypes)
                                {
                                    if (reportType.ReportTypeId == client.DefaultReportTypeId)
                                    {
                                        app.ReportTypeId = reportType.ReportTypeId;
                                        app.ReportTypeName = reportType.TypeName;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                ReportTypeData res1ReportType = reportTypes.Find(r => r.TypeName == GlobalConstants.DefaultReportTypeName);
                                app.ReportTypeId = res1ReportType.ReportTypeId;
                                app.ReportTypeName = res1ReportType.TypeName;

                            }
                            break;
                        }
                    }
                }

                app.CreditInfo = creditInfoData;
                app.PagesReceived = 1;
                app.State = "OR";

                if (formMaster.CURRENT_USER != null)
                {
                    Screener screener = Screener.FromUser(formMaster.CURRENT_USER);
                    app.ScreenerId = screener.ScreenerId;
                    app.ScreenerName = screener.ScreenerName;
                }

                // Employement Info

                app.EmpVer = new EmpVerData();

                app.EmpVer.Pos = "N/A";
                app.EmpVer.Hire = "N/A";
                app.EmpVer.Salary = "N/A";
                app.EmpVer.SW = "N/A";
                app.EmpVer.FullTime = "N/A";

                app.EmpVer.Pos2 = "N/A";
                app.EmpVer.Hire2 = "N/A";
                app.EmpVer.Salary2 = "N/A";
                app.EmpVer.SW2 = "N/A";
                app.EmpVer.FullTime2 = "N/A";

                app.Evictions = new List<EvictionRefData>();

                EvictionRefData evictionData = new EvictionRefData();
                evictionData.State = "Oregon";
                evictionData.County = "N/A";
                evictionData.Owners = "N/A";
                evictionData.Date = "N/A";

                app.Evictions.Add(evictionData);

                ChargeRefData chargeData = new ChargeRefData();
                chargeData.State = "Oregon";
                chargeData.County = "N/A";
                chargeData.Charge = "N/A";
                chargeData.Date = "N/A";
                chargeData.Sentence = "N/A";

                app.EmpVer = new EmpVerData();
                app.EmpVer.Heading = "Current";
                app.EmpVer.Heading2 = "Previous";

                app.Charges = new List<ChargeRefData>();
                app.Charges.Add(chargeData);

                string newId = appApiRepository.Add(app);
                if (!string.IsNullOrEmpty(newId))
                {
                    List<AppData> lst = new List<AppData>();
                    AppData newApp = appCachedApiQuery.GetApp(newId);
                    newApp.ReceivedDate = ((DateTime)newApp.ReceivedDate).ToLocalTime();

                    lst.Add(newApp);
                    this.olvAppExplore.InsertObjects(0, lst);
                    this.olvAppExplore.SelectedIndex = 0;

                    UpdateControlsFromApp(newApp);
                    SaveSelectedApp();

                    appCachedApiQuery.RemoveAllAppsForCheckDuplicate();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteSelectedApp()
        {
            try
            {
                Core.Domain.Model.ExploreApps.Location archiveLocation = Core.Domain.Model.ExploreApps.Location.Archive;

                List<AppData> lstSelectedApps = new List<AppData>();
                foreach (AppData appdata in this.olvAppExplore.SelectedObjects)
                {
                    lstSelectedApps.Add(appdata);
                }

                if (lstSelectedApps == null || lstSelectedApps.Count == 0)
                {
                    MessageBox.Show("Please select application to delete.", "No app selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                AppData app = lstSelectedApps.Count > 0 ? lstSelectedApps.ElementAt(lstSelectedApps.Count - 1) : null;
                if (app != null && !string.IsNullOrEmpty(app.ApplicationId))
                {
                    if (!CurrentUserHasArchivePermission() && app.LocationId == archiveLocation.LocationId)
                    {
                        MessageBox.Show("You don't have permission to delete Archived Application.", "Action Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    ReportTypeData reportType = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);
                    string applicantName = Utils.GetApplicantName(app, reportType);
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the application of " + applicantName + " and all its associated credit reports?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        using (new HourGlass())
                        {
                            appApiRepository.Remove(app);
                            appCachedApiQuery.Remove(app.ApplicationId);
                            int index = this.olvAppExplore.IndexOf(app);
                            this.olvAppExplore.RemoveObject(app);
                            if (this.olvAppExplore.Items.Count > 0)
                            {
                                index = index.Equals(this.olvAppExplore.Items.Count) ? index - 1 : index;
                                this.olvAppExplore.SelectedIndex = index;
                                this.olvAppExplore.EnsureVisible(index);
                            }
                            appCachedApiQuery.RemoveAllAppsForCheckDuplicate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RemoveAppFromOtherForm(AppData app)
        {
            using (new HourGlass())
            {
                appApiRepository.Remove(app);
                appCachedApiQuery.Remove(app.ApplicationId);
                appCachedApiQuery.RemoveAllAppsForCheckDuplicate();
            }
        }

        public void CopySelectedApp()
        {
            try
            {
                AppData app = this.olvAppExplore.SelectedObject as AppData;
                if (app != null)
                {
                    AppData copiedApp = new AppData();
                    AutoMapper.Mapper.Map<AppData, AppData>(app, copiedApp);
                    copiedApp.ApplicationId = Guid.NewGuid().ToString();
                    copiedApp.ReceivedDate = DateTime.UtcNow;
                    string newId = appApiRepository.Add(copiedApp);
                    if (!string.IsNullOrEmpty(newId))
                    {
                        List<AppData> lst = new List<AppData>();
                        AppData newApp = appCachedApiQuery.GetApp(newId);
                        lst.Add(newApp);
                        this.olvAppExplore.InsertObjects(0, lst);
                        this.olvAppExplore.SelectedIndex = 0;

                        appCachedApiQuery.RemoveAllAppsForCheckDuplicate();
                    }
                    this.olvAppExplore.RefreshSelectedObjects();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void MarkAsRoommates()
        {
            try
            {
                List<string> lstRoommateIds = new List<string>();
                foreach (AppData app in this.olvAppExplore.SelectedObjects)
                {
                    if (!string.IsNullOrEmpty(app.ApplicationId))
                    {
                        lstRoommateIds.Add(app.ApplicationId);
                    }
                }
                MarkAsRoommatesCommand command = new MarkAsRoommatesCommand(lstRoommateIds);
                appApiRepository.MarkAsRoommates(command);
                this.olvAppExplore.RefreshSelectedObjects();
                RefreshDisplayedApps();

                olvAppExplore.SelectedIndex = 0;

                appCachedApiQuery.RemoveAllAppsForCheckDuplicate();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void SaveApp(AppData app)
        {
            ClientData client = ClientCachedApiQuery.Instance.GetClient(app.ClientApplied);

            UpdateAppFromControls(app, out var errorMessages);

            // if there's any error when update app from Controls, stop auto Save
            if (errorMessages.Any())
            {
                return;
            }

            GlobalVars.IsIgnoreAutoSave = true;
            var lstInvoiceDivisionInApp = partTwoControl1.GetListInvoiceDivision();

            bool hasInvoiceDivisionChanged = false;
            if (client != null)
            {
                List<InvoiceDivisionData> lstInvoiceDivisionInClient = client.InvoiceDivisions.ToList();

                if (lstInvoiceDivisionInClient.Count > 0)
                {
                    foreach (InvoiceDivisionData inv in lstInvoiceDivisionInApp)
                    {
                        var division = lstInvoiceDivisionInClient.Find(a => a.DivisionName.Equals(inv.DivisionName));

                        if (division == null)
                        {
                            client.InvoiceDivisions.Add(inv);
                            hasInvoiceDivisionChanged = true;
                        }
                    }
                }
                else
                {
                    foreach (InvoiceDivisionData inv in lstInvoiceDivisionInApp)
                    {
                        client.InvoiceDivisions.Add(inv);
                        hasInvoiceDivisionChanged = true;
                    }
                }
            }
            GlobalVars.IsIgnoreAutoSave = false;

            bool result = await SaveAppAsync(app, client);

            if (!result)
                return;

            if (string.IsNullOrEmpty(app.ClientApplied) || client == null)
                return;

            EventBus.Publish(new SavedAppEventArgs(app));
        }

        public Task<bool> SaveAppAsync(AppData app, ClientData client)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (app == null || !Utils.IsValidApp(app, client, out _))
                        return false;

                    appApiRepository.Update(app);
                    appCachedApiQuery.SetApp(app);
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                    return false;
                }
            });
        }

        /// <summary>
        /// Save the selected application
        /// Will be called when click on save button or Ctrl+S
        /// </summary>
        public void SaveSelectedApp()
        {
            try
            {
                Core.Domain.Model.ExploreApps.Location archiveLocation = Core.Domain.Model.ExploreApps.Location.Archive;
                Core.Domain.Model.ExploreApps.Location review1Location = Core.Domain.Model.ExploreApps.Location.Review1;
                Core.Domain.Model.ExploreApps.Location review2Location = Core.Domain.Model.ExploreApps.Location.Review2;
                Core.Domain.Model.ExploreApps.Location review3Location = Core.Domain.Model.ExploreApps.Location.Review3;
                Core.Domain.Model.ExploreApps.Location newAppsLocation = Core.Domain.Model.ExploreApps.Location.NewApps;

                AppData app = this.olvAppExplore.SelectedObject as AppData;

                if (app == null)
                    return;

                Role role = formMaster.CURRENT_ROLE;
                if (role != null && role.RoleName != "Administrator")
                {
                    if (!CurrentUserHasArchivePermission() && app.LocationId == archiveLocation.LocationId)
                    {
                        MessageBox.Show("You don't have permission to edit Archived Application.", "Action Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    if (formMaster.CurrentLocation.LocationId != formMaster.CURRENT_USER.UserId.Id &&
                        app.LocationId != review1Location.LocationId &&
                        app.LocationId != review2Location.LocationId &&
                        app.LocationId != review3Location.LocationId &&
                        app.LocationId != newAppsLocation.LocationId)
                    {
                        MessageBox.Show("Selected application is not in your location. Please pick up then you can modify it.", "Action Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        return;
                    }
                }

                ClientData client = clientCachedApiQuery.GetClient(app.ClientApplied);
                if (client.ClientRevoked)
                {
                    MessageBox.Show("Unable to save! The client of application is blocked", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (app != null && !string.IsNullOrEmpty(app.ApplicationId))
                {
                    appCachedApiQuery.Remove(app.ApplicationId);
                    AppData appBeforeSave = appCachedApiQuery.GetApp(app.ApplicationId);

                    UpdateAppFromControls(app, out var errorMessages);

                    if (errorMessages.Any())
                    {
                        MessageBox.Show(errorMessages.FirstOrDefault(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (Utils.IsValidApp(app, client, out var messages))
                    {
                        using (new HourGlass())
                        {
                            if (app.LocationId == Core.Domain.Model.ExploreApps.Location.Archive.LocationId && app.CompletedDate == null) // If location = Archive
                            {
                                app.CompletedDate = DateTime.UtcNow;
                                appMenuControl1.CompletedDate = (DateTime.Now);
                            }
                            appApiRepository.Update(app);
                            appCachedApiQuery.Remove(app.ApplicationId);
                            olvAppExplore.RefreshObject(app);
                            appCachedApiQuery.RemoveAllAppsForCheckDuplicate();

                            _originalClientApplied = app.ClientApplied;
                        }
                    }
                    else
                    {
                        if (messages.Any())
                        {
                            MessageBox.Show(messages.FirstOrDefault(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Unable to save! The application is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        return;
                    }
                }

                if (string.IsNullOrEmpty(app.ClientApplied) || client == null)
                    return;

                UpdateControlsFromApp(app);
                EventBus.Publish(new SavedAppEventArgs(app));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show("Unable to save application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ShowApps(List<string> applicationIds)
        {
            try
            {
                GetAppByIdsCommand command = new GetAppByIdsCommand(applicationIds);
                List<AppData> apps = appApiRepository.GetAppByIds(command);
                if (apps == null)
                    apps = new List<AppData>();

                if (apps != null && apps.Count > 0)
                {
                    this.olvAppExplore.SetObjects(apps);
                    this.olvAppExplore.SelectedIndex = 0;
                }
                else
                {
                    this.ResetControls();
                    this.olvAppExplore.ClearObjects();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SearchApp(SearchAppCommand command)
        {
            try
            {
                int count = appApiRepository.Count(command);

                if (count == 0)
                {
                    MessageBox.Show("There're no applications are found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (count > 5000 && count < 10000)
                {
                    DialogResult result = MessageBox.Show(string.Format("{0} applications are found. Do you want to continue?", count), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                        return;
                }
                else if (count >= 10000)
                {
                    MessageBox.Show(string.Format("There're too many applications ({0}) are found. Please choose more detail search criteria.", count), "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<AppData> apps = appApiRepository.Search(command);

                if (apps != null && apps.Count > 0)
                {
                    this.olvAppExplore.SetObjects(apps);
                    this.olvAppExplore.SelectedIndex = 0;
                }
                else
                {
                    this.ResetControls();
                    this.olvAppExplore.ClearObjects();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SimpleSearchApp(SimpleSearchAppCommand command)
        {
            try
            {
                int count = appApiRepository.SimpleSearchCount(command);

                if (count == 0)
                {
                    MessageBox.Show("There're no applications are found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (count > 3000 && count < 7000)
                {
                    DialogResult result = MessageBox.Show(string.Format("{0} applications are found. Do you want to continue?", count), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }
                else if (count >= 7000)
                {
                    MessageBox.Show(string.Format("There're too many applications ({0}) are found. Please choose more detail search criteria.", count), "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<AppData> apps = appApiRepository.SimpleSearch(command);
                if (apps != null && apps.Count > 0)
                {
                    List<AppData> exactApps = SimpleSearchApp_GetExact(command, apps);
                    if (exactApps != null && exactApps.Count > 0)
                    {
                        this.olvAppExplore.SetObjects(exactApps);
                        this.olvAppExplore.SelectedIndex = 0;
                        return;
                    }
                }

                this.ResetControls();
                this.olvAppExplore.ClearObjects();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<AppData> SimpleSearchApp_GetExact(SimpleSearchAppCommand command, List<AppData> apps)
        {
            if (apps == null || apps.Count == 0)
            {
                return null;
            }

            string keyword = command.Keyword;
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return apps;
            }

            // to lowercase
            keyword = keyword.ToLower();

            List<AppData> exactApps = new List<AppData>(apps.Count);
            string columnName = SimpleSearchAppData.GetColumnNameByFieldName(command.SearchIn);

            try
            {
                if (columnName.Equals("all_fields"))
                {
                    exactApps = (from application in apps
                                 where application != null &&
                                        ((application.StreetAddress ?? string.Empty).ToLower().Contains(keyword) ||
                                            (application.ClientAppliedName ?? string.Empty).ToLower().Contains(keyword) ||
                                            ((application.FinalComments ?? string.Empty).ToLower().Contains(keyword) ||
                                                (application.StaffComments ?? string.Empty).ToLower().Contains(keyword)) ||
                                            ((application.LastName ?? string.Empty).ToLower().Contains(keyword) ||
                                                (application.FirstName ?? string.Empty).ToLower().Contains(keyword) ||
                                                (application.MiddleName ?? string.Empty).ToLower().Contains(keyword)) ||
                                            (application.Priority != null &&
                                                (application.Priority.Value.ToString().Equals(keyword) ||
                                                (application.Priority.DisplayName ?? string.Empty).ToLower().Contains(keyword))) ||
                                            (application.ReportManagement ?? string.Empty).ToLower().Contains(keyword) ||
                                            (application.ReportTypeName ?? string.Empty).ToLower().Contains(keyword) ||
                                            (application.ScreenerName ?? string.Empty).ToLower().Contains(keyword) ||
                                            ((application.AppSSN ?? string.Empty).ToLower().Contains(keyword) ||
                                                (application.BirthDate.HasValue &&
                                                    application.BirthDate.Value.ToString("MM/dd/yyyy").Contains(keyword))) ||
                                            (application.ReportSpecialField ?? string.Empty).ToLower().Contains(keyword) ||
                                            (application.ContactAttempts != null &&
                                             application.ContactAttempts.Any(contactAttempt => (contactAttempt != null) &&
                                                                                                ((contactAttempt.ContactAttemptType != null &&
                                                                                                    (contactAttempt.ContactAttemptType.DisplayName ?? string.Empty).ToLower().Contains(keyword)) ||
                                                                                                (contactAttempt.Note ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                                (contactAttempt.PhoneFaxEmail ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                                (contactAttempt.Recipient ?? string.Empty).ToLower().Contains(keyword)))) ||
                                            (application.CreditInfo != null &&
                                             (application.CreditInfo.ChildSupport.ToString().Equals(keyword) ||
                                                application.CreditInfo.Collections.ToString().Equals(keyword) ||
                                                application.CreditInfo.CreditHistoryBankrupted.ToString().ToLower().Equals(keyword) ||
                                                application.CreditInfo.CreditMatched.ToString().ToLower().Equals(keyword) ||
                                                (application.CreditInfo.CreditPreface ?? string.Empty).ToLower().Contains(keyword) ||
                                                application.CreditInfo.CreditReportObtained.ToString().ToLower().Equals(keyword) ||
                                                (application.CreditInfo.Dates ?? string.Empty).ToLower().Contains(keyword) ||
                                                application.CreditInfo.Judgements.ToString().Equals(keyword) ||
                                                application.CreditInfo.Liens.ToString().Equals(keyword) ||
                                                application.CreditInfo.PastDueAmounts.ToString().Equals(keyword) ||
                                                application.CreditInfo.PositiveCreditSince.ToString().ToLower().Equals(keyword) ||
                                                application.CreditInfo.Rent.ToString().Equals(keyword))) ||
                                            (application.CreditRefs != null &&
                                             application.CreditRefs.Any(creditRef => (creditRef != null) &&
                                                                                        ((creditRef.Balance ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                        (creditRef.Company ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                        (creditRef.HighBalance ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                        (creditRef.Opened ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                        (creditRef.PayHabits ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                        (creditRef.Phone ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                        (creditRef.Rating ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                        (creditRef.SW ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                        (creditRef.Terms ?? string.Empty).ToLower().Contains(keyword)))) ||
                                            (application.Charges != null &&
                                             application.Charges.Any(charge => (charge != null) &&
                                                                                ((charge.Charge ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                (charge.County ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                (charge.Date ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                (charge.Heading ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                (charge.Sentence ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                (charge.State ?? string.Empty).ToLower().Contains(keyword)))) ||
                                            (application.EmpRefs != null &&
                                             application.EmpRefs.Any(empRef => (empRef != null) &&
                                                                                ((empRef.Comment ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                (empRef.FullTime ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                (empRef.Hired ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                (empRef.Info ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                (empRef.Pos ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                (empRef.RH ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                (empRef.Salary ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                (empRef.SW ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                (empRef.Termination ?? string.Empty).ToLower().Contains(keyword)))) ||
                                            (application.EmpVer != null &&
                                             ((application.EmpVer.Co ?? string.Empty).ToLower().Contains(keyword) ||
                                                (application.EmpVer.Co2 ?? string.Empty).ToLower().Contains(keyword) ||
                                                (application.EmpVer.FullTime ?? string.Empty).ToLower().Contains(keyword) ||
                                                (application.EmpVer.FullTime2 ?? string.Empty).ToLower().Contains(keyword) ||
                                                (application.EmpVer.Heading ?? string.Empty).ToLower().Contains(keyword) ||
                                                (application.EmpVer.Heading2 ?? string.Empty).ToLower().Contains(keyword) ||
                                                (application.EmpVer.Hire ?? string.Empty).ToLower().Contains(keyword) ||
                                                (application.EmpVer.Hire2 ?? string.Empty).ToLower().Contains(keyword) ||
                                                (application.EmpVer.MiscComment ?? string.Empty).ToLower().Contains(keyword) ||
                                                (application.EmpVer.Pos ?? string.Empty).ToLower().Contains(keyword) ||
                                                (application.EmpVer.Pos2 ?? string.Empty).ToLower().Contains(keyword) ||
                                                (application.EmpVer.Salary ?? string.Empty).ToLower().Contains(keyword) ||
                                                (application.EmpVer.Salary2 ?? string.Empty).ToLower().Contains(keyword) ||
                                                (application.EmpVer.SW ?? string.Empty).ToLower().Contains(keyword) ||
                                                (application.EmpVer.SW2 ?? string.Empty).ToLower().Contains(keyword) ||
                                                (application.EmpVer.Tele ?? string.Empty).ToLower().Contains(keyword) ||
                                                (application.EmpVer.Tele2 ?? string.Empty).ToLower().Contains(keyword))) ||
                                            (application.Evictions != null &&
                                             application.Evictions.Any(eviction => (eviction != null) &&
                                                                                    ((eviction.County ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                    (eviction.Date ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                    (eviction.Heading ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                    (eviction.Owners ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                    (eviction.State ?? string.Empty).ToLower().Contains(keyword)))) ||
                                            (application.RentalRefs != null &&
                                             application.RentalRefs.Any(rentalRef => (rentalRef != null) &&
                                                                                        (rentalRef.AddressMatch.ToString().ToLower().Contains(keyword) ||
                                                                                        rentalRef.Complaints.ToString().ToLower().Contains(keyword) ||
                                                                                        rentalRef.Damages.ToString().ToLower().Contains(keyword) ||
                                                                                        rentalRef.KickedOut.ToString().ToLower().Contains(keyword) ||
                                                                                        rentalRef.LateNSF.ToString().ToLower().Contains(keyword) ||
                                                                                        rentalRef.Owing.ToString().ToLower().Contains(keyword) ||
                                                                                        rentalRef.Pets.ToString().ToLower().Contains(keyword) ||
                                                                                        rentalRef.PrprNotice.ToString().ToLower().Contains(keyword) ||
                                                                                        rentalRef.ReRent.ToString().ToLower().Contains(keyword) ||
                                                                                        rentalRef.RltveFrnd.ToString().ToLower().Contains(keyword) ||
                                                                                        rentalRef.Roommates.ToString().ToLower().Contains(keyword) ||
                                                                                        rentalRef.Written.ToString().ToLower().Contains(keyword) ||
                                                                                        (rentalRef.MoveIn ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                        (rentalRef.MoveOut ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                        (rentalRef.Amount ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                        (rentalRef.SW ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                        (rentalRef.Comp ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                        (rentalRef.Phone ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                        (rentalRef.Comment ?? string.Empty).ToLower().Contains(keyword)))))
                                 select application).ToList<AppData>();
                }
                else if (columnName.Equals("contact_attempt"))
                {
                    exactApps = (from application in apps
                                 where application.ContactAttempts != null &&
                                    application.ContactAttempts.Any(contactAttempt => (contactAttempt != null) &&
                                                                                    ((contactAttempt.ContactAttemptType != null &&
                                                                                        (contactAttempt.ContactAttemptType.DisplayName ?? string.Empty).ToLower().Contains(keyword)) ||
                                                                                    (contactAttempt.Note ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                    (contactAttempt.PhoneFaxEmail ?? string.Empty).ToLower().Contains(keyword) ||
                                                                                    (contactAttempt.Recipient ?? string.Empty).ToLower().Contains(keyword)))
                                 select application).ToList<AppData>();
                }
                else if (columnName.Equals("credit_info"))
                {
                    exactApps = (from application in apps
                                 where application.CreditInfo != null &&
                                (application.CreditInfo.ChildSupport.ToString().Equals(keyword) ||
                                application.CreditInfo.Collections.ToString().Equals(keyword) ||
                                application.CreditInfo.CreditHistoryBankrupted.ToString().ToLower().Equals(keyword) ||
                                application.CreditInfo.CreditMatched.ToString().ToLower().Equals(keyword) ||
                                (application.CreditInfo.CreditPreface ?? string.Empty).ToLower().Contains(keyword) ||
                                application.CreditInfo.CreditReportObtained.ToString().ToLower().Equals(keyword) ||
                                (application.CreditInfo.Dates ?? string.Empty).ToLower().Contains(keyword) ||
                                application.CreditInfo.Judgements.ToString().Equals(keyword) ||
                                application.CreditInfo.Liens.ToString().Equals(keyword) ||
                                application.CreditInfo.PastDueAmounts.ToString().Equals(keyword) ||
                                application.CreditInfo.PositiveCreditSince.ToString().ToLower().Equals(keyword) ||
                                application.CreditInfo.Rent.ToString().Equals(keyword))
                                 select application).ToList<AppData>();
                }
                else if (columnName.Equals("credit_refs"))
                {
                    exactApps = (from application in apps
                                 where application.CreditRefs != null &&
                                application.CreditRefs.Any(creditRef => (creditRef != null) &&
                                                                        ((creditRef.Balance ?? string.Empty).ToLower().Contains(keyword) ||
                                                                        (creditRef.Company ?? string.Empty).ToLower().Contains(keyword) ||
                                                                        (creditRef.HighBalance ?? string.Empty).ToLower().Contains(keyword) ||
                                                                        (creditRef.Opened ?? string.Empty).ToLower().Contains(keyword) ||
                                                                        (creditRef.PayHabits ?? string.Empty).ToLower().Contains(keyword) ||
                                                                        (creditRef.Phone ?? string.Empty).ToLower().Contains(keyword) ||
                                                                        (creditRef.Rating ?? string.Empty).ToLower().Contains(keyword) ||
                                                                        (creditRef.SW ?? string.Empty).ToLower().Contains(keyword) ||
                                                                        (creditRef.Terms ?? string.Empty).ToLower().Contains(keyword)))
                                 select application).ToList<AppData>();
                }
                else if (columnName.Equals("charges"))
                {
                    exactApps = (from application in apps
                                 where application.Charges != null &&
                                application.Charges.Any(charge => (charge != null) &&
                                                                ((charge.Charge ?? string.Empty).ToLower().Contains(keyword) ||
                                                                (charge.County ?? string.Empty).ToLower().Contains(keyword) ||
                                                                (charge.Date ?? string.Empty).ToLower().Contains(keyword) ||
                                                                (charge.Heading ?? string.Empty).ToLower().Contains(keyword) ||
                                                                (charge.Sentence ?? string.Empty).ToLower().Contains(keyword) ||
                                                                (charge.State ?? string.Empty).ToLower().Contains(keyword)))
                                 select application).ToList<AppData>();
                }
                else if (columnName.Equals("emp_refs"))
                {
                    exactApps = (from application in apps
                                 where application.EmpRefs != null &&
                                application.EmpRefs.Any(empRef => (empRef != null) &&
                                                                ((empRef.Comment ?? string.Empty).ToLower().Contains(keyword) ||
                                                                (empRef.FullTime ?? string.Empty).ToLower().Contains(keyword) ||
                                                                (empRef.Hired ?? string.Empty).ToLower().Contains(keyword) ||
                                                                (empRef.Info ?? string.Empty).ToLower().Contains(keyword) ||
                                                                (empRef.Pos ?? string.Empty).ToLower().Contains(keyword) ||
                                                                (empRef.RH ?? string.Empty).ToLower().Contains(keyword) ||
                                                                (empRef.Salary ?? string.Empty).ToLower().Contains(keyword) ||
                                                                (empRef.SW ?? string.Empty).ToLower().Contains(keyword) ||
                                                                (empRef.Termination ?? string.Empty).ToLower().Contains(keyword)))
                                 select application).ToList<AppData>();
                }
                else if (columnName.Equals("emp_ver"))
                {
                    exactApps = (from application in apps
                                 where application.EmpVer != null &&
                                ((application.EmpVer.Co ?? string.Empty).ToLower().Contains(keyword) ||
                                (application.EmpVer.Co2 ?? string.Empty).ToLower().Contains(keyword) ||
                                (application.EmpVer.FullTime ?? string.Empty).ToLower().Contains(keyword) ||
                                (application.EmpVer.FullTime2 ?? string.Empty).ToLower().Contains(keyword) ||
                                (application.EmpVer.Heading ?? string.Empty).ToLower().Contains(keyword) ||
                                (application.EmpVer.Heading2 ?? string.Empty).ToLower().Contains(keyword) ||
                                (application.EmpVer.Hire ?? string.Empty).ToLower().Contains(keyword) ||
                                (application.EmpVer.Hire2 ?? string.Empty).ToLower().Contains(keyword) ||
                                (application.EmpVer.MiscComment ?? string.Empty).ToLower().Contains(keyword) ||
                                (application.EmpVer.Pos ?? string.Empty).ToLower().Contains(keyword) ||
                                (application.EmpVer.Pos2 ?? string.Empty).ToLower().Contains(keyword) ||
                                (application.EmpVer.Salary ?? string.Empty).ToLower().Contains(keyword) ||
                                (application.EmpVer.Salary2 ?? string.Empty).ToLower().Contains(keyword) ||
                                (application.EmpVer.SW ?? string.Empty).ToLower().Contains(keyword) ||
                                (application.EmpVer.SW2 ?? string.Empty).ToLower().Contains(keyword) ||
                                (application.EmpVer.Tele ?? string.Empty).ToLower().Contains(keyword) ||
                                (application.EmpVer.Tele2 ?? string.Empty).ToLower().Contains(keyword))
                                 select application).ToList<AppData>();
                }
                else if (columnName.Equals("evictions"))
                {
                    exactApps = (from application in apps
                                 where application.Evictions != null &&
                                application.Evictions.Any(eviction => (eviction != null) &&
                                                                    ((eviction.County ?? string.Empty).ToLower().Contains(keyword) ||
                                                                    (eviction.Date ?? string.Empty).ToLower().Contains(keyword) ||
                                                                    (eviction.Heading ?? string.Empty).ToLower().Contains(keyword) ||
                                                                    (eviction.Owners ?? string.Empty).ToLower().Contains(keyword) ||
                                                                    (eviction.State ?? string.Empty).ToLower().Contains(keyword)))
                                 select application).ToList<AppData>();
                }
                else if (columnName.Equals("rental_refs"))
                {
                    exactApps = (from application in apps
                                 where application.RentalRefs != null &&
                                application.RentalRefs.Any(rentalRef => (rentalRef != null) &&
                                                                        (rentalRef.AddressMatch.ToString().ToLower().Contains(keyword) ||
                                                                        rentalRef.Complaints.ToString().ToLower().Contains(keyword) ||
                                                                        rentalRef.Damages.ToString().ToLower().Contains(keyword) ||
                                                                        rentalRef.KickedOut.ToString().ToLower().Contains(keyword) ||
                                                                        rentalRef.LateNSF.ToString().ToLower().Contains(keyword) ||
                                                                        rentalRef.Owing.ToString().ToLower().Contains(keyword) ||
                                                                        rentalRef.Pets.ToString().ToLower().Contains(keyword) ||
                                                                        rentalRef.PrprNotice.ToString().ToLower().Contains(keyword) ||
                                                                        rentalRef.ReRent.ToString().ToLower().Contains(keyword) ||
                                                                        rentalRef.RltveFrnd.ToString().ToLower().Contains(keyword) ||
                                                                        rentalRef.Roommates.ToString().ToLower().Contains(keyword) ||
                                                                        rentalRef.Written.ToString().ToLower().Contains(keyword) ||
                                                                        (rentalRef.MoveIn ?? string.Empty).ToLower().Contains(keyword) ||
                                                                        (rentalRef.MoveOut ?? string.Empty).ToLower().Contains(keyword) ||
                                                                        (rentalRef.Amount ?? string.Empty).ToLower().Contains(keyword) ||
                                                                        (rentalRef.SW ?? string.Empty).ToLower().Contains(keyword) ||
                                                                        (rentalRef.Comp ?? string.Empty).ToLower().Contains(keyword) ||
                                                                        (rentalRef.Phone ?? string.Empty).ToLower().Contains(keyword) ||
                                                                        (rentalRef.Comment ?? string.Empty).ToLower().Contains(keyword)))
                                 select application).ToList<AppData>();
                }
                else
                {
                    return apps;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return apps;
            }

            return exactApps;
        }

        public void UpdateAppFromControls(AppData app, out List<string> messages)
        {
            messages = new List<string>();
            try
            {   
                partOneControl1.UpdateAppFromControls(app);
                partTwoControl1.UpdateAppFromControls(app, out messages);
                partThreeControl1.UpdateAppFromControls(app);
                partFourControl1.UpdateAppFromControls(app);
                partFiveControl1.UpdateAppFromControls(app);
                if (partSixControl1.Visible == true)
                {
                    partSixControl1.UpdateAppFromControls(app);
                }
                else if (partSixControl2.Visible == true)
                {
                    partSixControl2.UpdateAppFromControls(app);
                }
                ciTypeOne1.UpdateAppFromControls(app);
                ciTypeTwo1.UpdateAppFromControls(app);
                empTypeOne1.UpdateAppFromControls(app);
                empTypeTwo1.UpdateAppFromControls(app);
                criEvControl1.UpdateAppFromControls(app);
                finalInfoControl1.UpdateAppFromControls(app);
                rentalControl1.UpdateAppFromControls(app);
                appMenuControl1.UpdateAppFromControls(app);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateControlsFromApp(AppData app)
        {
            try
            {
                using (new HourGlass())
                {
                    GlobalVars.IsIgnoreAutoSave = true;
                    if (!string.IsNullOrEmpty(app.ReportTypeId))
                    {
                        ReportTypeData currentReportType = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);
                        string reportAbsuluteTypeName = currentReportType.AbsoluteTypeName;
                        LoadControlsByType(reportAbsuluteTypeName);
                    }

                    partTwoControl1.UpdateControlsFromApp(app);
                    partThreeControl1.UpdateControlsFromApp(app);
                    partFourControl1.UpdateControlsFromApp(app);
                    partFiveControl1.UpdateControlsFromApp(app);
                    partSixControl1.UpdateControlsFromApp(app);
                    partSixControl2.UpdateControlsFromApp(app);
                    ciTypeOne1.UpdateControlsFromApp(app);
                    ciTypeTwo1.UpdateControlsFromApp(app);
                    empTypeOne1.UpdateControlsFromApp(app);
                    empTypeTwo1.UpdateControlsFromApp(app);
                    criEvControl1.UpdateControlsFromApp(app);
                    finalInfoControl1.UpdateControlsFromApp(app);
                    rentalControl1.UpdateControlsFromApp(app);

                    partOneControl1.UpdateControlsFromApp(app);

                    // Check visible for button Special Criteria & Special Entry
                    if (!string.IsNullOrEmpty(app.ClientApplied))
                    {
                        ClientCachedApiQuery clientCachedApiQuery = ClientCachedApiQuery.Instance;
                        ClientData clientApplied = clientCachedApiQuery.GetClient(app.ClientApplied);

                        if (clientApplied != null)
                        {
                            string specialEntry = clientApplied.SpecialEntryInfo;
                            if (!string.IsNullOrEmpty(specialEntry))
                            {
                                partOneControl1.ClientAppliedName = app.ClientAppliedName;
                                partOneControl1.SpecialEntry = specialEntry;
                                partOneControl1.SetVisibleButtonSpecialEntry(true);
                            }
                            else
                            {
                                partOneControl1.SetVisibleButtonSpecialEntry(false);
                            }

                            string specialCriteria = clientApplied.SpecialCriteriaInfo;
                            if (!string.IsNullOrEmpty(specialCriteria))
                            {
                                finalInfoControl1.ClientAppliedName = app.ClientAppliedName;
                                finalInfoControl1.SpecialCriteriaInfo = specialCriteria;
                                finalInfoControl1.SetVisibleForButtonCriteria(true);
                            }
                            else
                            {
                                finalInfoControl1.SetVisibleForButtonCriteria(false);
                            }
                        }
                    }

                    bool crrUserHasArchivePermission = this.CurrentUserHasArchivePermission();

                    appMenuControl1.hasArchivePermission = crrUserHasArchivePermission;
                    appMenuControl1.UpdateControlsFromApp(app);

                    GlobalVars.IsIgnoreAutoSave = false;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetControls()
        {
            partOneControl1.ResetControls();
            partTwoControl1.ResetControls();
            partThreeControl1.ResetControls();
            partFourControl1.ResetControls();
            partFiveControl1.ResetControls();
            partSixControl1.ResetControls();
            partSixControl2.ResetControls();
            ciTypeOne1.ResetControls();
            ciTypeTwo1.ResetControls();
            empTypeOne1.ResetControls();
            empTypeTwo1.ResetControls();
            criEvControl1.ResetControls();
            finalInfoControl1.ResetControls();
            rentalControl1.ResetControls();
            appMenuControl1.ResetControls();
        }

        private void olvAppExplore_SelectionChanged(object sender, EventArgs e)
        {
            AppData app = this.olvAppExplore.SelectedObject as AppData;

            if (app != null)
            {
                using (new HourGlass())
                {
                    UpdateControlsFromApp(app);
                    currentLoadedApp = app;
                    if (selectedObjects.Count > 0)
                        selectedObjects.Clear();
                    selectedObjects.Add(app);
                    this._originalClientApplied = app.ClientApplied;
                    ReportTypeData reportType = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);
                    if (!string.IsNullOrEmpty(app.ClientApplied))
                    {
                        ClientData client = clientCachedApiQuery.GetClient(app.ClientApplied);

                        if (client != null)
                        {
                            appMenuControl1.ClientBillingInfo = client.BillingInfo;
                        }
                        formMaster.SetAppExploreButtonsVisible(app, client, reportType);
                    }
                    else
                    {
                        formMaster.SetAppExploreButtonsVisible(app, null, reportType);
                    }
                }
            }
            else if (olvAppExplore.Items.Count > 0 && olvAppExplore.MultiSelect && olvAppExplore.SelectedObjects.Count > 0)
            {
                ObjectListView olv = sender as ObjectListView;
                Core.Domain.Model.ExploreApps.Location archiveLocation = Core.Domain.Model.ExploreApps.Location.Archive;
                List<AppData> listSelectedApps = new List<AppData>();

                if (selectedObjects.Count > 0)
                    selectedObjects.Clear();

                foreach (AppData appData in olvAppExplore.SelectedObjects)
                {
                    listSelectedApps.Add(appData);
                    selectedObjects.Add(appData);
                }


                AppData contextApp = _contextApp;

                if (contextApp == null)
                    return;

                if (contextApp.LocationId == Core.Domain.Model.ExploreApps.Location.Archive.LocationId && !this.CurrentUserHasArchivePermission())
                {
                    return;
                }

                if (listSelectedApps.Count > 0)
                {
                    bool containArchivedApp = false;

                    foreach (AppData item in listSelectedApps)
                    {
                        if (item.LocationId == archiveLocation.LocationId)
                        {
                            containArchivedApp = true;
                            break;
                        }
                    }

                    if (containArchivedApp)
                    {
                        bool crrUserHasArchivePermission = this.CurrentUserHasArchivePermission();

                        appMenuControl1.hasArchivePermission = crrUserHasArchivePermission;
                        appMenuControl1.UpdateControlsFromApp(contextApp);
                    }
                }
            }
            else
            {
                //currentLoadedApp = null;
                //ResetControls();
                if (selectedObjects.Count == 1)
                    olvAppExplore.SelectedObject = selectedObjects.FirstOrDefault();
                else if (selectedObjects.Count > 1)
                    olvAppExplore.SelectedObjects = selectedObjects;
            }


        }

        private void olvAppExplore_ItemsChanged(object sender, EventArgs e)
        {
            if (formMaster != null)
            {
                string message = (olvAppExplore.Items.Count > 0) ? string.Format("{0} Apps. In View", olvAppExplore.Items.Count) : string.Empty;
                this.formMaster.SetAppCount(message);
            }
        }

        private void cmnuItemEportCreditFullApps_Click(object sender, EventArgs e)
        {
            List<AppData> apps = GetListAllApps();
            AppData selectedApp = this.currentLoadedApp;
            if (apps != null && apps.Count > 0)
            {
                if (formPullCredit == null || formPullCredit.IsDisposed)
                {
                    formPullCredit = new FormPullCredit(this.formMaster, this);
                }
                formPullCredit.SetSelectdApp(selectedApp);
                formPullCredit.SetApps(apps);
                formPullCredit.BringToFront();
                formPullCredit.Show();
            }
            else
            {
                MessageBox.Show("No app selected!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmnuItemEportCreditSelectedApps_Click(object sender, EventArgs e)
        {
            List<AppData> apps = GetListSelectedApps();
            AppData selectedApp = this.currentLoadedApp;
            if (apps.Count > 0)
            {
                try
                {
                    using (new HourGlass())
                    {
                        if (formPullCredit == null || formPullCredit.IsDisposed)
                        {
                            formPullCredit = new FormPullCredit(this.formMaster, this);
                        }
                        formPullCredit.SetSelectdApp(selectedApp);
                        formPullCredit.SetApps(apps);
                        formPullCredit.BringToFront();
                        formPullCredit.Show();
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                }



            }
            else
            {
                MessageBox.Show("No apps selected!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        public void SelectItemOLVAppExplore(string appId)
        {
            if (this.olvAppExplore.Objects == null ||
                this.olvAppExplore.Items.Count == 0 ||
                string.IsNullOrEmpty(appId))
            {
                return;
            }

            foreach (AppData app in this.olvAppExplore.Objects)
            {
                if (app != null && app.ApplicationId.Equals(appId))
                {
                    this.olvAppExplore.SelectedIndex = -1;
                    this.olvAppExplore.SelectObject(app, true);
                    this.olvAppExplore.EnsureModelVisible(app);
                    break;
                }
            }
        }

        public void SetItemsOLVAppExplore(List<AppData> apps)
        {
            if (apps != null && apps.Count > 0)
            {
                this.olvAppExplore.SetObjects(apps);
                this.olvAppExplore.SelectedIndex = 0;
            }
            else
            {
                this.olvAppExplore.ClearObjects();
            }
        }

        public List<AppData> GetListSelectedApps()
        {
            List<AppData> apps = new List<AppData>();
            foreach (AppData app in this.olvAppExplore.SelectedObjects)
            {
                if (!string.IsNullOrEmpty(app.ApplicationId))
                {
                    apps.Add(app);
                }
            }
            return apps;
        }

        public List<AppData> GetListAllApps()
        {
            List<AppData> apps = new List<AppData>();

            if (this.olvAppExplore.Objects == null || this.olvAppExplore.GetItemCount() == 0)
            {
                return apps;
            }

            foreach (AppData app in this.olvAppExplore.Objects)
            {
                if (app != null && !string.IsNullOrEmpty(app.ApplicationId))
                {
                    apps.Add(app);
                }
            }

            return apps;
        }

        public AppData GetSelectedApp()
        {
            if (this.olvAppExplore.Items.Count > 0 && this.olvAppExplore.SelectedObjects.Count > 0)
            {
                AppData app = olvAppExplore.SelectedObjects[olvAppExplore.SelectedObjects.Count - 1] as AppData;
                return app;
            }
            return null;
        }

        public bool IsAutoSaveAvailable()
        {
            if (this.partOneControl1.IsClientAppliedFocus == true)
                return false;

            return true;
        }

        #region User Controls Events

        private void OnClientAppliedChanged(object sender, ClientAppliedChangedEventArgs e)
        {
            try
            {
                using (new HourGlass())
                {
                    ClientData newClient = e.NewClientApplied;
                    AppData app = this.olvAppExplore.SelectedObject as AppData;

                    if (app != null)
                    {
                        ReportTypeCachedApiQuery reportTypeCachedApiQuery = ReportTypeCachedApiQuery.Instance;
                        ReportTypeData reportTypeData = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);

                        if (newClient != null)
                        {
                            // appMenuControl1.UpdateInvoiceDivisionClientChanged(newClient.ClientId, app.InvoiceDivision);
                            partTwoControl1.UpdateInvoiceDivisionClientChanged(newClient.ClientId, app.InvoiceDivision);

                            if ((newClient.ManagementCompany != null))
                            {
                                this.partFiveControl1.UpdateReportManagement(newClient.ManagementCompany.Name);
                                app.ReportManagement = newClient.ManagementCompany.Name;
                            }
                            else
                            {
                                this.partFiveControl1.UpdateReportManagement("Ind");
                                app.ReportManagement = "Ind";
                            }
                            if (e.ClientChangedBy == ClientAppliedChangedEventArgs.ChangedBy.ByEnterKeyPress)
                            {
                                this.partFiveControl1.UpdateReportCommunity(newClient.ClientName);
                                app.ReportCommunity = newClient.ClientName;
                                if (reportTypeData.TypeName == "Emp1")
                                {
                                    this.partSixControl2.UpdateReportCompApplied(newClient.ClientName);
                                    app.CompanyApplied = newClient.ClientName;
                                }
                                ReportTypeData newReportTypeData = reportTypeCachedApiQuery.GetReportType(newClient.DefaultReportTypeId);
                                if (newReportTypeData == null)
                                {
                                    newReportTypeData = reportTypeCachedApiQuery.GetAllReportTypes().Find(r => r.TypeName == GlobalConstants.DefaultReportTypeName);
                                }
                                app.ReportTypeId = newReportTypeData.ReportTypeId;
                                app.ReportTypeName = newReportTypeData.TypeName;
                            }
                            app.ClientApplied = newClient.ClientId;
                            app.ClientAppliedName = newClient.ClientName;

                            appApiRepository.Update(app);
                            appCachedApiQuery.SetApp(app);
                            olvAppExplore.RefreshObject(app);
                            if (e.ClientChangedBy == ClientAppliedChangedEventArgs.ChangedBy.ByEnterKeyPress)
                            {
                                UpdateControlsFromApp(app);
                            }
                        }
                    }
                    appMenuControl1.UpdateReportTypeClientChanged(newClient.ClientId);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewClientInformationHandler(object sender, ClientData e)
        {
            Form _frmClientInfo = FormMaster.getFormByName("FormClientInfo");
            if (_frmClientInfo == null)
            {
                _frmClientInfo = new FormClientInfo(formMaster);
            }

            ((FormClientInfo)_frmClientInfo).ViewClientInformationFromAppExplore(e);
        }

        #endregion;

        #region App Workflow

        private void olvAppExplore_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                ObjectListView olv = sender as ObjectListView;

                List<AppData> apps = new List<AppData>();
                foreach (AppData app in olvAppExplore.SelectedObjects)
                {
                    apps.Add(app);
                }

                AppData contextApp = _contextApp;

                if (contextApp == null)
                    return;

                if (contextApp.LocationId == Core.Domain.Model.ExploreApps.Location.Archive.LocationId && !this.CurrentUserHasArchivePermission())
                {
                    return;
                }

                int index = this.olvAppExplore.IndexOf(contextApp);
                User currentUser = formMaster.CURRENT_USER;
                LocationData contextLocation = new LocationData(contextApp.LocationId, contextApp.LocationName);

                LocationData newLocation = new LocationData(contextLocation.LocationId, contextLocation.LocationName);
                List<LocationData> locations = new List<LocationData>();
                DialogResult dialogResult = Utils.ConfirmMoveAppToNewLocation(contextApp, apps, currentUser, contextLocation, ref newLocation, locations, true);
                if (dialogResult == DialogResult.Yes && newLocation != null)
                {
                    using (new HourGlass())
                    {
                        for (int i = 0; i < apps.Count; i++)
                        {
                            AppData app = apps[i];
                            Utils.MoveAppToNewLocation(app, locations[i]);
                            if (app.LocationId == Core.Domain.Model.ExploreApps.Location.Archive.LocationId && app.CompletedDate == null)
                                app.CompletedDate = DateTime.UtcNow;
                            appApiRepository.Update(app);
                            appCachedApiQuery.Remove(app.ApplicationId);
                        }
                        this.olvAppExplore.RemoveObjects(apps);
                    }
                    if (index >= this.olvAppExplore.GetItemCount())
                    {
                        index--;
                    }
                    this.olvAppExplore.SelectedIndex = index;
                    appCachedApiQuery.RemoveAllAppsForCheckDuplicate();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion;

        private void PrintAppReportHandler(object sender, PrintAppEventArgs e)
        {
            try
            {
                ClientCachedApiQuery clientCachedApiQuery = ClientCachedApiQuery.Instance;
                ReportTypeCachedApiQuery reportTypeCachedApiQuery = ReportTypeCachedApiQuery.Instance;
                AppData app = this.olvAppExplore.SelectedObject as AppData;
                List<AppReportItem> reportItems = e.ReportItems;
                FormDocumentComplete dialog = null;
                if (app != null && !string.IsNullOrEmpty(app.ApplicationId))
                {
                    using (new HourGlass())
                    {
                        UpdateAppFromControls(app, out _);
                        appApiRepository.Update(app);
                        EventBus.Publish(new SavedAppEventArgs(app));
                        ClientData client = clientCachedApiQuery.GetClient(app.ClientApplied);
                        ReportTypeData reportType = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);
                        if (client == null)
                        {
                            throw new Exception("Invalid client! Please choose a valid client for the application.");
                        }
                        if (reportType == null)
                        {
                            throw new Exception("Invalid report type! Please choose a valid client for the application.");
                        }
                        DocumentCompleteResult result = BuildDocumentOpenXML(reportItems, app, client, reportType);
                        if (result != null)
                        {
                            dialog = new FormDocumentComplete("Report", result);
                            dialog.ConfirmEdit = false;
                            dialog.DefaultClientName = client.ClientName;
                            dialog.DefaultEmailTo = client.DefaultDeliverReportsTo;

                            dialog.SetMainAction(e.MainAction);
                            if (e.MainAction == PrintAppEventArgs.MainActionType.EmailTo)
                            {
                                dialog.SetFirstLoadClientId(client.ClientId);
                                dialog.SetFirstLoadClientEmail(client.DefaultDeliverReportsTo);
                            }

                            dialog.StartPosition = FormStartPosition.CenterScreen;
                            dialog.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void EmailApps(List<AppData> apps)
        {
            if (apps.Count == 0)
                return;

            if (apps.Count == 1)
            {
                try
                {
                    EmailSingleApp(apps.FirstOrDefault());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    string clientId = apps.FirstOrDefault().ClientApplied;
                    ClientData client = clientCachedApiQuery.GetClient(clientId);
                    if (client == null)
                    {
                        MessageBox.Show("Invalid client. Please choose application with valid client", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    foreach (AppData app in apps)
                    {
                        if (clientId != app.ClientApplied)
                        {
                            MessageBox.Show("Invalid Report(s). Please choose application from same client", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                    }
                    FormProgress formProgress = new FormProgress();
                    formProgress.StartPosition = FormStartPosition.CenterScreen;
                    formProgress.Argument = apps;
                    formProgress.DoWork += new FormProgress.DoWorkEventHandler(emailApps_DoWork);
                    DialogResult result = formProgress.ShowDialog();
                    if (result == DialogResult.Cancel)
                    {
                        MessageBox.Show("Operation has been cancelled", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (result == DialogResult.Abort)
                    {
                        MessageBox.Show("Exception:" + Environment.NewLine + formProgress.Result.Error.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    List<string> documents = (List<string>)formProgress.Result.Result;
                    if (documents.Count > 0)
                    {
                        string defaultEmailTitle = "Completed Screening Report(s)";
                        string defaultEmailTo = client.DefaultDeliverReportsTo;
                        if (string.IsNullOrEmpty(defaultEmailTo)) defaultEmailTo = client.Email;
                        FormMultipleDocumentComplete dialog = new FormMultipleDocumentComplete(defaultEmailTitle, documents, defaultEmailTo);
                        List<string> applicantNames = new List<string>();
                        foreach (var app in apps)
                        {
                            ReportTypeData reportType = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);
                            var applicantName = Utils.GetApplicantName(app, reportType);
                            if (!applicantNames.Contains(applicantName))
                            {
                                applicantNames.Add(applicantName);
                            }
                        }
                        dialog.ApplicantNames = applicantNames;
                        dialog.SetMainAction(PrintAppEventArgs.MainActionType.EmailTo);
                        dialog.DefaultClientName = client.ClientName;
                        dialog.StartPosition = FormStartPosition.CenterScreen;
                        dialog.Show();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EmailSingleApp(AppData app)
        {
            try
            {
                // assume app is always not null
                FormDocumentComplete dialog = null;
                ClientCachedApiQuery clientCachedApiQuery = ClientCachedApiQuery.Instance;
                ReportTypeCachedApiQuery reportTypeCachedApiQuery = ReportTypeCachedApiQuery.Instance;
                ClientData client = clientCachedApiQuery.GetClient(app.ClientApplied);
                ReportTypeData reportType = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);
                var applicantName = Utils.GetApplicantName(app, reportType);
                if (client == null)
                {
                    throw new Exception("Invalid client! Please choose a valid client for the application.");
                }
                if (reportType == null)
                {
                    throw new Exception("Invalid report type! Please choose a valid client for the application.");
                }

                if (app == null || client == null || reportType == null)
                    return;

                if (app != null && !string.IsNullOrEmpty(app.ApplicationId))
                {
                    using (new HourGlass())
                    {
                        List<AppReportItem> lstReport = AppReportItem.GetAppReportItems(app, reportType);
                        DocumentCompleteResult result = BuildDocumentOpenXML(lstReport, app, client, reportType);
                        if (result != null)
                        {
                            dialog = new FormDocumentComplete("Document Completed!", result);
                            dialog.ConfirmEdit = false;
                            dialog.DefaultClientName = client.ClientName;
                            dialog.DefaultEmailTo = client.DefaultDeliverReportsTo;
                            dialog.SetFirstLoadClientId(client.ClientId);
                            dialog.SetFirstLoadClientEmail(client.DefaultDeliverReportsTo);
                            List<string> applicantNames = new List<string>();
                            applicantNames.Add(applicantName);
                            dialog.ApplicantNames = applicantNames;

                            dialog.SetMainAction(PrintAppEventArgs.MainActionType.EmailTo);
                            dialog.StartPosition = FormStartPosition.CenterScreen;
                            dialog.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Could not prepare email");
            }
        }

        private void emailApps_DoWork(FormProgress sender, DoWorkEventArgs e)
        {
            List<AppData> apps = (List<AppData>)sender.Argument;
            if (apps.Count == 0)
                return;

            int numTotal = apps.Count;
            int numProcessed = 0;

            ClientCachedApiQuery clientCachedApiQuery = ClientCachedApiQuery.Instance;
            ReportTypeCachedApiQuery reportTypeCachedApiQuery = ReportTypeCachedApiQuery.Instance;
            WordService word = null;
            List<string> documents = new List<string>();
            foreach (AppData app in apps)
            {
                try
                {
                    ClientData client = clientCachedApiQuery.GetClient(app.ClientApplied);
                    ReportTypeData reportType = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);

                    if (app == null || client == null || reportType == null)
                        continue;

                    string applicantName = Utils.GetApplicantName(app, reportType);
                    List<AppReportItem> lstReport = AppReportItem.GetAppReportItems(app, reportType);

                    string documentFile = GenerateDoucmentReportOpenXML(lstReport, app, client, reportType);
                    documents.Add(documentFile);

                    numProcessed++;
                    int percentage = (100 * numProcessed) / numTotal;
                    string status = string.Format("Prepare to email application: {0}-{1}", applicantName, client.ClientName);
                    sender.SetProgress(percentage, status);
                    if (sender.IsCancellation())
                        return;
                    e.Result = documents;
                }
                catch (Exception ex)
                {
                    if (word != null)
                        word.Quit();
                    throw new Exception("There were errors when email applications");
                }
            }
        }

        public void PrintAppsWithProgressDialog(List<AppData> apps)
        {

            FormProgress formProgress = new FormProgress();
            formProgress.StartPosition = FormStartPosition.CenterScreen;
            formProgress.Argument = apps;
            formProgress.DoWork += new FormProgress.DoWorkEventHandler(printApps_DoWork);
            DialogResult result = formProgress.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                MessageBox.Show("Operation has been cancelled", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (result == DialogResult.Abort)
            {
                MessageBox.Show("Exception:" + Environment.NewLine + formProgress.Result.Error.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void printApps_DoWork(FormProgress sender, DoWorkEventArgs e)
        {
            List<AppData> apps = (List<AppData>)sender.Argument;
            if (apps.Count == 0)
                return;

            int numTotal = apps.Count;
            int numProcessed = 0;

            ClientCachedApiQuery clientCachedApiQuery = ClientCachedApiQuery.Instance;
            ReportTypeCachedApiQuery reportTypeCachedApiQuery = ReportTypeCachedApiQuery.Instance;
            WordService word = null;
            foreach (AppData app in apps)
            {
                try
                {
                    ClientData client = clientCachedApiQuery.GetClient(app.ClientApplied);
                    ReportTypeData reportType = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);

                    if (app == null || client == null || reportType == null)
                        continue;

                    string applicantName = Utils.GetApplicantName(app, reportType);
                    List<AppReportItem> lstReport = AppReportItem.GetAppReportItems(app, reportType);

                    string documentFile = GenerateDoucmentReportOpenXML(lstReport, app, client, reportType);
                    word = new WordService(documentFile, "Application Report", false);
                    word.Print(1);

                    numProcessed++;
                    int percentage = (100 * numProcessed) / numTotal;
                    string status = string.Format("Print application: {0}-{1}", applicantName, client.ClientName);
                    sender.SetProgress(percentage, status);
                    if (sender.IsCancellation())
                        return;
                }
                catch (Exception ex)
                {
                    if (word != null)
                        word.Quit();
                    throw new Exception("There were errors when printing applications");
                }
            }
        }

        private void MoveLocationUsingComboBoxHandler(object sender, MoveLocationEventArgs e)
        {
            try
            {
                AppData selectedApp = (AppData)olvAppExplore.SelectedObject;
                AppData contextApp = this._contextApp;
                if (contextApp == null && selectedApp == null)
                    return;
                else if (selectedApp != null)
                {
                    contextApp = selectedApp;
                }
                int index = this.olvAppExplore.IndexOf(contextApp);
                if (contextApp == null)
                    return;
                List<AppData> apps = new List<AppData>();
                if (e.MoveMultipleApps == true)
                {
                    foreach (AppData app in olvAppExplore.SelectedObjects)
                    {
                        apps.Add(app);
                    }
                }
                else
                {
                    apps = new List<AppData>() { contextApp };
                }

                LocationData contextLocation = new LocationData(contextApp.LocationId, contextApp.LocationName);
                LocationData newLocation = e.NewLocation;
                User currentUser = formMaster.CURRENT_USER;
                List<LocationData> locations = new List<LocationData>();
                DialogResult dialogResult = Utils.ConfirmMoveAppToNewLocation(contextApp, apps, currentUser, contextLocation, ref newLocation, locations, false);
                if (dialogResult == DialogResult.Yes && newLocation != null)
                {
                    using (new HourGlass())
                    {
                        for (int i = 0; i < apps.Count; i++)
                        {
                            AppData app = apps[i];
                            Utils.MoveAppToNewLocation(app, locations[i], formMaster.CURRENT_USER.UserName);
                            if (app.LocationId == Core.Domain.Model.ExploreApps.Location.Archive.LocationId && app.CompletedDate == null)
                                app.CompletedDate = DateTime.UtcNow;

                            appApiRepository.Update(app);
                            appCachedApiQuery.Remove(app.ApplicationId);
                        }
                        this.olvAppExplore.RemoveObjects(apps);
                    }
                }
                if (index >= this.olvAppExplore.GetItemCount())
                {
                    index--;
                }
                this.olvAppExplore.SelectedIndex = index;
                appCachedApiQuery.RemoveAllAppsForCheckDuplicate();
                e.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MoveScreenerUsingComboBoxHandler(object sender, MoveScreenerEventArgs e)
        {
            try
            {
                AppData app = (AppData)olvAppExplore.SelectedObject;
                if (app == null)
                    return;
                ScreenerData currentScreener = e.CurrentScreener;
                ScreenerData newScreener = e.NewScreener;
                DialogResult dialogResult = Utils.ConfirmMoveAppToNewScreener();
                if (dialogResult == DialogResult.Yes)
                {
                    using (new HourGlass())
                    {
                        app.ScreenerId = newScreener.ScreenerId;
                        app.ScreenerName = newScreener.ScreenerName;
                        appApiRepository.Update(app);
                        appCachedApiQuery.Remove(app.ApplicationId);
                        this.olvAppExplore.RefreshObject(app);
                        e.Success = true;
                    }
                }
                else
                {
                    //UpdateControlsFromApp(app);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReviewCommentHandler(object sender, EventArgs e)
        {
            try
            {
                AppData app = null;
                ReviewComment comment = new ReviewComment();
                string applicantName = "";
                ReviewCommentApiRepository repository = new ReviewCommentApiRepository();
                app = (AppData)olvAppExplore.SelectedObject;
                FormReviewComment formReviewComment = new FormReviewComment(applicantName);

                if (app == null)
                    return;
                using (new HourGlass())
                {
                    ReportTypeData reportType = (ReportTypeData)reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);
                    applicantName = Utils.GetApplicantName(app, reportType);
                    comment = repository.Find(app.ApplicationId);
                }

                // Check permission for Add/Edit Review Comments
                if (formMaster.CURRENT_USER != null)
                {
                    Role role = formMaster.CURRENT_ROLE;
                    FeatureAuthorization featureAuth = new FeatureAuthorization();

                    if (role != null)
                    {
                        foreach (FeaturePermission item in role.FeaturePermissions)
                        {
                            if (item.FeatureName == featureAuth.FeatureNameToString(FeatureName.AddEditReviewComment))
                            {
                                if (!item.IsAllowed)
                                {
                                    formReviewComment.hasEditPermission = false;
                                }
                                else
                                {
                                    formReviewComment.hasEditPermission = true;
                                }
                            }
                        }
                    }
                }
                //

                formReviewComment.StartPosition = FormStartPosition.CenterParent;
                formReviewComment.UpdateControlFromReviewComment(comment, app.LastName + ", " + app.FirstName);

                formReviewComment.ShowDialog();

                using (new HourGlass())
                {
                    if (comment == null)
                        comment = new ReviewComment();
                    if (string.IsNullOrEmpty(comment.ReviewCommentId))
                    {
                        formReviewComment.UpdateReviewCommentFromControls(comment);
                        comment.ReviewCommentId = app.ApplicationId;
                        repository.Add(comment);
                    }
                    else
                    {
                        formReviewComment.UpdateReviewCommentFromControls(comment);
                        repository.Update(comment);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Mark the app is completed by set the CompletedDate for that app
        /// </summary>
        private void MarkCompleteClickHandler(object sender, EventArgs e)
        {
            try
            {
                AppData selectedApp = (AppData)olvAppExplore.SelectedObject;
                if (selectedApp == null)
                    return;

                if (selectedApp.CompletedDate != null)
                    return;

                // Do not mark the app as completed if the app is not in NewApps, Pickup, Review or current User Location
                if (formMaster.CurrentLocation.LocationId != formMaster.CURRENT_USER.UserId.Id &&
                    selectedApp.LocationId != Core.Domain.Model.ExploreApps.Location.NewApps.LocationId &&
                    selectedApp.LocationId != Core.Domain.Model.ExploreApps.Location.Pickup.LocationId &&
                    selectedApp.LocationId != Core.Domain.Model.ExploreApps.Location.Review1.LocationId &&
                    selectedApp.LocationId != Core.Domain.Model.ExploreApps.Location.Review2.LocationId &&
                    selectedApp.LocationId != Core.Domain.Model.ExploreApps.Location.Review3.LocationId)
                    return;

                selectedApp.CompletedDate = DateTime.UtcNow;
                appApiRepository.Update(selectedApp);
                appCachedApiQuery.Remove(selectedApp.ApplicationId);
                UpdateControlsFromApp(selectedApp);
                olvAppExplore.RefreshObject(selectedApp);

            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MarkInProcessClickHandler(object sender, EventArgs e)
        {
            try
            {
                AppData selectedApp = (AppData)olvAppExplore.SelectedObject;
                if (selectedApp == null)
                    return;

                if (selectedApp.CompletedDate == null)
                    return;

                // Do not mark the app as completed if the app is not in NewApps, Pickup, Review or current User Location
                if (formMaster.CurrentLocation.LocationId != formMaster.CURRENT_USER.UserId.Id &&
                    selectedApp.LocationId != Core.Domain.Model.ExploreApps.Location.NewApps.LocationId &&
                    selectedApp.LocationId != Core.Domain.Model.ExploreApps.Location.Pickup.LocationId &&
                    selectedApp.LocationId != Core.Domain.Model.ExploreApps.Location.Review1.LocationId &&
                    selectedApp.LocationId != Core.Domain.Model.ExploreApps.Location.Review2.LocationId &&
                    selectedApp.LocationId != Core.Domain.Model.ExploreApps.Location.Review3.LocationId)
                    return;

                selectedApp.CompletedDate = null;
                appApiRepository.Update(selectedApp);
                appCachedApiQuery.Remove(selectedApp.ApplicationId);
                UpdateControlsFromApp(selectedApp);
                olvAppExplore.RefreshObject(selectedApp);

            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handle the Goto app (should be called when user click on Goto button)
        /// </summary>
        private void GotoAppClickHandler(object sender, EventArgs e)
        {
            try
            {
                Button button = sender as Button;
                AppData selectedApp = (AppData)olvAppExplore.SelectedObject;
                AppData contextApp = this._contextApp;
                if (contextApp == null && selectedApp == null)
                    return;
                else if (selectedApp != null)
                {
                    contextApp = selectedApp;
                }
                if (contextApp == null)
                    return;
                List<AppData> apps = new List<AppData>();
                foreach (AppData app in olvAppExplore.SelectedObjects)
                {
                    apps.Add(app);
                }
                if (contextApp != null && !string.IsNullOrEmpty(contextApp.ApplicationId))
                {
                    int index = this.olvAppExplore.IndexOf(contextApp);
                    DialogResult dialogResult = DialogResult.No;
                    User currentUser = formMaster.CURRENT_USER;
                    LocationData contextLocation = new LocationData(contextApp.LocationId, contextApp.LocationName);
                    LocationData newLocation = new LocationData(contextLocation.LocationId, contextLocation.LocationName);
                    List<LocationData> locations = new List<LocationData>();
                    Core.Domain.Model.ExploreApps.Location newAppsLocation = Core.Domain.Model.ExploreApps.Location.NewApps;
                    Core.Domain.Model.ExploreApps.Location pickupLocation = Core.Domain.Model.ExploreApps.Location.Pickup;
                    Core.Domain.Model.ExploreApps.Location review1Location = Core.Domain.Model.ExploreApps.Location.Review1;
                    Core.Domain.Model.ExploreApps.Location review2Location = Core.Domain.Model.ExploreApps.Location.Review2;
                    Core.Domain.Model.ExploreApps.Location review3Location = Core.Domain.Model.ExploreApps.Location.Review3;
                    Core.Domain.Model.ExploreApps.Location archiveLocation = Core.Domain.Model.ExploreApps.Location.Archive;

                    if (contextLocation.LocationId == newAppsLocation.LocationId)
                    {
                        newLocation.LocationId = pickupLocation.LocationId;
                        newLocation.LocationName = pickupLocation.LocationName;
                        dialogResult = Utils.ConfirmMoveAppToNewLocation(contextApp, apps, currentUser, contextLocation, ref newLocation, locations, true);
                    }
                    else if (contextLocation.LocationId == pickupLocation.LocationId)
                    {
                        if (button != null)
                        {
                            ChangeLocation(currentUser.UserId.Id);
                            formMaster.CurrentLocation = new LocationData(currentUser.UserId.Id, currentUser.UserName);
                            return;
                        }
                        else
                        {
                            newLocation.LocationId = currentUser.UserId.Id;
                            newLocation.LocationName = currentUser.UserName;
                            dialogResult = Utils.ConfirmMoveAppToNewLocation(contextApp, apps, currentUser, contextLocation, ref newLocation, locations, true);
                        }
                    }
                    else if (contextLocation.LocationId == archiveLocation.LocationId)
                    {
                        if (button != null)
                        {
                            ChangeLocation(currentUser.UserId.Id);
                            formMaster.CurrentLocation = new LocationData(currentUser.UserId.Id, currentUser.UserName);
                            return;
                        }
                        else
                        {
                            dialogResult = Utils.ConfirmMoveAppToNewLocation(contextApp, apps, currentUser, contextLocation, ref newLocation, locations, true);
                        }
                    }
                    else if (contextLocation.LocationId == currentUser.UserId.Id)
                    {
                        if (button != null)
                        {
                            ChangeLocation(pickupLocation.LocationId);
                            formMaster.CurrentLocation = new LocationData(pickupLocation.LocationId, pickupLocation.LocationName);
                            return;
                        }
                        else
                        {
                            newLocation.LocationId = review1Location.LocationId;
                            newLocation.LocationName = review1Location.LocationName;
                            dialogResult = Utils.ConfirmMoveAppToNewLocation(contextApp, apps, currentUser, contextLocation, ref newLocation, locations, true);
                        }
                    }
                    else if (contextLocation.LocationId == review1Location.LocationId ||
                        contextLocation.LocationId == review2Location.LocationId ||
                        contextLocation.LocationId == review3Location.LocationId)
                    {
                        newLocation.LocationId = currentUser.UserId.Id;
                        newLocation.LocationName = currentUser.UserName;
                        dialogResult = Utils.ConfirmMoveAppToNewLocation(contextApp, apps, currentUser, contextLocation, ref newLocation, locations, true);
                    }
                    else
                    {
                        newLocation.LocationId = review1Location.LocationId;
                        newLocation.LocationName = review1Location.LocationName;
                        dialogResult = Utils.ConfirmMoveAppToNewLocation(contextApp, apps, currentUser, contextLocation, ref newLocation, locations, true);
                    }

                    if (dialogResult == DialogResult.Yes && newLocation != null)
                    {
                        using (new HourGlass())
                        {
                            for (int i = 0; i < apps.Count; i++)
                            {
                                AppData app = apps[i];
                                Utils.MoveAppToNewLocation(app, locations[i]);
                                if (app.LocationId == Core.Domain.Model.ExploreApps.Location.Archive.LocationId && app.CompletedDate == null)
                                    app.CompletedDate = DateTime.UtcNow;
                                appApiRepository.Update(app);
                                appCachedApiQuery.Remove(app.ApplicationId);
                            }
                            this.olvAppExplore.RemoveObjects(apps);
                        }
                    }
                    if (index >= this.olvAppExplore.GetItemCount())
                    {
                        index--;
                    }
                    this.olvAppExplore.SelectedIndex = index;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CompleteAppClickHandler(object sender, EventArgs e)
        {
            try
            {
                AppData selectedApp = (AppData)olvAppExplore.SelectedObject;
                AppData contextApp = this._contextApp;
                if (contextApp == null && selectedApp == null)
                    return;
                else if (selectedApp != null)
                {
                    contextApp = selectedApp;
                }
                int index = this.olvAppExplore.IndexOf(contextApp);
                if (contextApp == null)
                    return;
                List<AppData> apps = new List<AppData>();
                foreach (AppData app in olvAppExplore.SelectedObjects)
                {
                    apps.Add(app);
                }
                if (contextApp != null && !string.IsNullOrEmpty(contextApp.ApplicationId))
                {
                    DialogResult dialogResult = DialogResult.No;
                    User currentUser = formMaster.CURRENT_USER;
                    LocationData contextLocation = new LocationData(contextApp.LocationId, contextApp.LocationName);
                    LocationData newLocation = new LocationData(contextLocation.LocationId, contextLocation.LocationName);
                    List<LocationData> locations = new List<LocationData>();
                    Core.Domain.Model.ExploreApps.Location newAppsLocation = Core.Domain.Model.ExploreApps.Location.NewApps;
                    Core.Domain.Model.ExploreApps.Location pickupLocation = Core.Domain.Model.ExploreApps.Location.Pickup;
                    Core.Domain.Model.ExploreApps.Location review1Location = Core.Domain.Model.ExploreApps.Location.Review1;
                    Core.Domain.Model.ExploreApps.Location review2Location = Core.Domain.Model.ExploreApps.Location.Review2;
                    Core.Domain.Model.ExploreApps.Location review3Location = Core.Domain.Model.ExploreApps.Location.Review3;
                    Core.Domain.Model.ExploreApps.Location archiveLocation = Core.Domain.Model.ExploreApps.Location.Archive;

                    if (contextLocation.LocationId == newAppsLocation.LocationId)
                    {
                        using (new HourGlass())
                        {
                            List<AppData> allApps = GetListAllApps();
                            if (formPullCredit.IsDisposed)
                            {
                                formPullCredit = new FormPullCredit(this.formMaster, this);
                            }
                            formPullCredit.SetApps(apps);
                            formPullCredit.BringToFront();
                        }
                        formPullCredit.Show();
                        return;
                    }
                    else if (contextLocation.LocationId == pickupLocation.LocationId)
                    {
                        dialogResult = Utils.ConfirmMoveAppToNewLocation(contextApp, apps, currentUser, contextLocation, ref newLocation, locations, true);
                    }
                    else if (contextLocation.LocationId == review1Location.LocationId ||
                        contextLocation.LocationId == review2Location.LocationId ||
                        contextLocation.LocationId == review3Location.LocationId)
                    {
                        newLocation = new LocationData(archiveLocation.LocationId, archiveLocation.LocationName);
                        dialogResult = Utils.ConfirmMoveAppToNewLocation(contextApp, apps, currentUser, contextLocation, ref newLocation, locations, false);
                    }
                    else if (contextLocation.LocationId == currentUser.UserId.Id)
                    {
                        dialogResult = Utils.ConfirmMoveAppToNewLocation(contextApp, apps, currentUser, contextLocation, ref newLocation, locations, true);
                    }
                    else
                    {
                        dialogResult = Utils.ConfirmMoveAppToNewLocation(contextApp, apps, currentUser, contextLocation, ref newLocation, locations, true);
                    }
                    if (dialogResult == DialogResult.Yes && newLocation != null)
                    {
                        using (new HourGlass())
                        {
                            for (int i = 0; i < apps.Count; i++)
                            {
                                AppData app = apps[i];
                                Utils.MoveAppToNewLocation(app, locations[i]);
                                if (app.LocationId == Core.Domain.Model.ExploreApps.Location.Archive.LocationId && app.CompletedDate == null)
                                    app.CompletedDate = DateTime.UtcNow;
                                appApiRepository.Update(app);
                                appCachedApiQuery.Remove(app.ApplicationId);
                            }
                            this.olvAppExplore.RemoveObjects(apps);
                        }
                    }
                    if (index >= this.olvAppExplore.GetItemCount())
                    {
                        index--;
                    }
                    this.olvAppExplore.SelectedIndex = index;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InvoiceDivisionChangedHandler(object sender, InvoiceDivisionChangedEventArgs e)
        {
            try
            {
                AppData app = (AppData)olvAppExplore.SelectedObject;
                ReportTypeData reportTypeData = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);
                if (app == null)
                {
                    return;
                }
                if (e.InvoiceDivisionName.Equals("(None)"))
                {
                    this.partFiveControl1.UpdateReportCommunity(app.ClientAppliedName);
                    if (reportTypeData.TypeName == "Emp1")
                    {
                        this.partSixControl2.UpdateReportCompApplied(app.ClientAppliedName);
                    }
                }
                else
                {
                    this.partFiveControl1.UpdateReportCommunity(e.InvoiceDivisionName);
                    if (reportTypeData.TypeName == "Emp1")
                    {
                        this.partSixControl2.UpdateReportCompApplied(e.InvoiceDivisionName);
                    }
                }

                if (e.IsEnter)
                {
                    ClientData client = ClientCachedApiQuery.Instance.GetClient(app.ClientApplied);
                    if (client.ClientRevoked)
                    {
                        MessageBox.Show("Unable to save! The client of application is blocked", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!client.InvoiceDivisions.Any(inv => inv.DivisionName.Equals(e.InvoiceDivisionName)))
                    {
                        InvoiceDivisionData item = new InvoiceDivisionData();
                        item.DivisionName = e.InvoiceDivisionName;
                        client.InvoiceDivisions.Add(item);
                    }
                    new ClientApiRepository().Update(client);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BeforeSetTemplateRentalRefHandler(object sender, BeforeSetTemplateEventArgs e)
        {
            try
            {
                AppData app = null;
                app = (AppData)olvAppExplore.SelectedObject;
                if (app == null)
                    return;
                string content = e.Content;
                if (content == null)
                    return;
                ClientData client = clientCachedApiQuery.GetClient(app.ClientApplied);
                content = TagReplaceHelper.ReplaceClientInfo(content, client);

                ReportTypeData reportTypeData = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);

                if (reportTypeData != null)
                {
                    string applicatioName = Utils.GetApplicantName(app, reportTypeData);
                    content = TagReplaceHelper.ReplaceApplicantName(content, applicatioName);
                }

                e.Content = content;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string GenerateDocumentReportPdf(List<AppReportItem> lstReports, AppData app, ClientData client, ReportTypeData reportType)
        {
            var filePath = GenerateDoucmentReportOpenXML(lstReports, app, client, reportType);
            var pdfFilePath = Path.ChangeExtension(filePath, "pdf");

            Word.Application oApplication = null;
            Word.Document oDocument = null;
            try
            {
                oApplication = new Word.Application();
                oApplication.Visible = false;
                oDocument = oApplication.Documents.Open(filePath);
                if (oDocument != null)
                {
                    oDocument.ExportAsFixedFormat(pdfFilePath, Word.Enums.WdExportFormat.wdExportFormatPDF, false);
                    oDocument.Close();
                }
                oApplication.Quit();
                return pdfFilePath;
            }
            catch (Exception)
            {
                if (oDocument != null) oDocument.Close();
                if (oApplication != null) oApplication.Quit();
                throw new IOException("Cannot generate pdf file. Please close program and try again.");
            }
        }

        public string GenerateDoucmentReportOpenXML(List<AppReportItem> lstReport, AppData app, ClientData client, ReportTypeData reportType)
        {
            string applicantName = Utils.GetApplicantName(app, reportType);

            string toSaveFileName = string.Format("{0}-{1}", applicantName, client.ClientName);

            if (app.LocationName.ToUpper() != "ARCHIVE")
            {
                toSaveFileName = string.Format("-{0}-{1}", applicantName, client.ClientName);
            }
            else
            {
                toSaveFileName = string.Format("+{0}-{1}", applicantName, client.ClientName);
            }

            TemplateHelper templateHelper = new TemplateHelper();

            foreach (AppReportItem item in lstReport)
            {
                string filename = WordTemplatePathResolver.GetTemplateFileName(item.WordDocumentType);
                if (!string.IsNullOrEmpty(filename))
                {
                    string url = string.Format("api/templates");
                    string savePath = WordTemplatePathResolver.GetWordTemplatePath(item.WordDocumentType);
                    templateHelper.DownloadTemplate(savePath, filename);
                }
            }

            List<Source> documentBuilderSources = new List<Source>();

            foreach (AppReportItem item in lstReport)
            {
                switch (item.WordDocumentType)
                {
                    case WordDocumentType.ResidentialNameEmpPage:
                        AppReportDocumentBuilderOpenXML.ResidentialNameEmpPage(documentBuilderSources, app, client, reportType);
                        break;
                    case WordDocumentType.ResRentalRefs:
                        AppReportDocumentBuilderOpenXML.ResRentalRefsPaging(documentBuilderSources, app, client, reportType, item.PageNo);
                        break;
                    case WordDocumentType.CommRentalRefs:
                        AppReportDocumentBuilderOpenXML.CommRentalRefsPaging(documentBuilderSources, app, client, reportType, item.PageNo);
                        break;
                    case WordDocumentType.ResCredCrimPage:
                        AppReportDocumentBuilderOpenXML.ResCredCrimPage(documentBuilderSources, app, client, reportType);
                        break;
                    case WordDocumentType.CreditOnlyPage:
                        AppReportDocumentBuilderOpenXML.CreditOnlyPage(documentBuilderSources, app, client, reportType);
                        break;
                    case WordDocumentType.CrimNameCrimPage:
                        AppReportDocumentBuilderOpenXML.CrimNameCrimPage(documentBuilderSources, app, client, reportType);
                        break;
                    case WordDocumentType.ResFinalPage:
                        AppReportDocumentBuilderOpenXML.ResFinalPage(documentBuilderSources, app, client, reportType);
                        break;
                    case WordDocumentType.ResFinalPageA:
                        AppReportDocumentBuilderOpenXML.ResFinalPageA(documentBuilderSources, app, client, reportType);
                        break;
                    case WordDocumentType.ResXCriminalPage:
                        AppReportDocumentBuilderOpenXML.ResXCriminalPage(documentBuilderSources, app, client, reportType, item.PageNo);
                        break;
                    case WordDocumentType.ResXEvictionPage:
                        AppReportDocumentBuilderOpenXML.ResXEvictionPage(documentBuilderSources, app, client, reportType, item.PageNo);
                        break;
                    case WordDocumentType.DeclinationLetter:
                        AppReportDocumentBuilderOpenXML.DeclinationLetter(documentBuilderSources, app, client, reportType);
                        break;
                    case WordDocumentType.AdverseActionLetter:
                        AppReportDocumentBuilderOpenXML.AdverseActionLetter(documentBuilderSources, app, client, reportType);
                        break;
                    case WordDocumentType.FinalCommentsPage:
                        AppReportDocumentBuilderOpenXML.FinalCommentsPage(documentBuilderSources, app, client, reportType);
                        break;
                    case WordDocumentType.EmpNameCrimPage:
                        AppReportDocumentBuilderOpenXML.EmpNameCrimPage(documentBuilderSources, app, client, reportType);
                        break;
                    case WordDocumentType.EmpRefsPage:
                        AppReportDocumentBuilderOpenXML.EmpRefsPaging(documentBuilderSources, app, client, reportType, item.PageNo);
                        break;
                    case WordDocumentType.EmpFinalPage:
                        AppReportDocumentBuilderOpenXML.EmpFinalPage(documentBuilderSources, app, client, reportType);
                        break;
                    case WordDocumentType.EmpFinalPageComment:
                        AppReportDocumentBuilderOpenXML.EmpFinalPage(documentBuilderSources, app, client, reportType);
                        break;
                    case WordDocumentType.CommFinalPage:
                        AppReportDocumentBuilderOpenXML.CommFinalPage(documentBuilderSources, app, client, reportType, 1);
                        break;
                    case WordDocumentType.CommNameBankPage:
                        AppReportDocumentBuilderOpenXML.CommNameBankPage(documentBuilderSources, app, client, reportType);
                        break;
                    case WordDocumentType.CreditRefs:
                        AppReportDocumentBuilderOpenXML.CreditRefsPage(documentBuilderSources, app, client, reportType, item.PageNo);
                        break;
                }
            }

            WmlDocument mergedDocument = DocumentBuilder.BuildDocument(documentBuilderSources);

            string workingFilePath = string.Empty;
            byte[] byteArray = mergedDocument.DocumentByteArray;
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    WordMLService.RemoveUnknownElement(wordDoc.MainDocumentPart);
                    wordDoc.Save();
                }

                workingFilePath = FileNameHelper.GetWriteableFilePath(Path.GetTempPath(), toSaveFileName, "docx");
                using (FileStream fileStream = new FileStream(workingFilePath,
                    System.IO.FileMode.CreateNew, FileAccess.Write))
                {
                    mem.WriteTo(fileStream);
                }
            }
            return workingFilePath;
        }

        DocumentCompleteResult BuildDocumentOpenXML(List<AppReportItem> lstReport, AppData app, ClientData client, ReportTypeData reportType)
        {
            string workingFilePath = GenerateDoucmentReportOpenXML(lstReport, app, client, reportType);

            if (!string.IsNullOrEmpty(workingFilePath))
            {
                string applicantName = Utils.GetApplicantName(app, reportType);
                string toSaveFileName = string.Format("{0} - {1}", applicantName, client.ClientName);
                WordService word = new WordService(workingFilePath, toSaveFileName, false, false);
                string emailSubject = string.Format("Completed Screening Report(s)");
                return new DocumentCompleteResult(workingFilePath, word, emailSubject);
            }
            return null;
        }

        private void FormAppExplore_FormShown(object sender, EventArgs e)
        {
            GlobalVars.IsFormLoaded = true;
        }

        private void FormAppExplore_VisibleChanged(object sender, EventArgs e)
        {
            using (new HourGlass())
            {
                if (this.Visible)
                {
                    this.RefreshDisplayedApps();
                    AppData app = this.olvAppExplore.SelectedObject as AppData;
                    if (app != null)
                    {
                        ReportTypeData reportType = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);
                        if (!string.IsNullOrEmpty(app.ClientApplied))
                        {
                            ClientData client = clientCachedApiQuery.GetClient(app.ClientApplied);
                            if (client != null)
                            {
                                appMenuControl1.ClientBillingInfo = client.BillingInfo;
                                formMaster.SetAppExploreButtonsVisible(app, client, reportType);
                            }
                        }
                        else
                        {
                            formMaster.SetAppExploreButtonsVisible(app, null, reportType);
                        }
                    }
                    else
                    {
                        this.ResetControls();
                    }
                    if (this.formMaster != null)
                    {
                        string message = (olvAppExplore.Items.Count > 0) ? string.Format("{0} Apps. In View", olvAppExplore.Items.Count) : string.Empty;

                        this.formMaster.SetAppCount(message);
                    }
                }
                if (this.Visible && this.loadCompleted)
                {
                    this.netToolControl1.LoadInternetToolData();
                }
            }
        }

        #region Context Menu

        private void deleteAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedApp();
        }

        private void addNewAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewApp();
        }

        private void searchApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formMaster.rbtnSearchApp_Click(this, null);
        }

        private void enterArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formMaster.rbtnArchive_Click(this, null);
        }

        private void UpdateContextMenu(LocationData contextLocation)
        {
            Core.Domain.Model.ExploreApps.Location newAppsLocation = Core.Domain.Model.ExploreApps.Location.NewApps;
            Core.Domain.Model.ExploreApps.Location pickupLocation = Core.Domain.Model.ExploreApps.Location.Pickup;
            Core.Domain.Model.ExploreApps.Location review1Location = Core.Domain.Model.ExploreApps.Location.Review1;
            Core.Domain.Model.ExploreApps.Location review2Location = Core.Domain.Model.ExploreApps.Location.Review2;
            Core.Domain.Model.ExploreApps.Location review3Location = Core.Domain.Model.ExploreApps.Location.Review3;
            Core.Domain.Model.ExploreApps.Location archiveLocation = Core.Domain.Model.ExploreApps.Location.Archive;

            if (contextLocation == null)
            {
                LocationData currLocation = formMaster.CurrentLocation;
                cmnuOLVAppExplore.Items.Remove(changeLocationToolStripMenuItem);
                moveToToolStripMenuItem.Enabled = false;

                // Pull credit                
                if (currLocation.LocationId != newAppsLocation.LocationId)
                {
                    this.cmnuItemEportCreditFullApps.Enabled = false;
                    this.cmnuItemEportCreditSelectedApps.Enabled = false;
                }
                else
                {
                    this.cmnuItemEportCreditFullApps.Enabled = true;
                    this.cmnuItemEportCreditSelectedApps.Enabled = true;
                }
                return;
            }
            else
            {
                // Check permission move to other Location for users who don't have Archive Apps permission

                var listSelectedApps = olvAppExplore.SelectedObjects;

                if (!this.CurrentUserHasArchivePermission() && contextLocation.LocationId == archiveLocation.LocationId)
                {
                    changeLocationToolStripMenuItem.Enabled = false;
                    moveToToolStripMenuItem.Enabled = false;
                    return;
                }

                if (listSelectedApps.Count > 0)
                {
                    bool containArchivedApp = false;

                    foreach (AppData item in listSelectedApps)
                    {
                        if (item.LocationId == archiveLocation.LocationId)
                        {
                            containArchivedApp = true;
                            break;
                        }
                    }

                    if (containArchivedApp)
                    {
                        changeLocationToolStripMenuItem.Enabled = true;
                        moveToToolStripMenuItem.Enabled = true;
                    }
                }

                //

                changeLocationToolStripMenuItem.Enabled = true;
                moveToToolStripMenuItem.Enabled = true;

                // Pull credit
                //if (contextLocation.LocationId != newAppsLocation.LocationId)
                //{
                //    this.cmnuItemEportCreditFullApps.Enabled = false;
                //    this.cmnuItemEportCreditSelectedApps.Enabled = false;
                //}
                //else
                //{
                //    this.cmnuItemEportCreditFullApps.Enabled = true;
                //    this.cmnuItemEportCreditSelectedApps.Enabled = true;
                //}
                this.cmnuItemEportCreditFullApps.Enabled = true;
            }

            moveToToolStripMenuItem.DropDownItems.Clear();
            List<LocationData> availableLocationsFromUsers = this.GetAvailableLocationFromUsers(contextLocation);
            List<LocationData> availableLocations = this.GetAvailableMoveToOptions(contextLocation);
            LocationData currentLocation = formMaster.CurrentLocation;
            foreach (LocationData location in availableLocationsFromUsers)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Size = new System.Drawing.Size(135, 22);
                item.Text = location.LocationName;
                MoveLocationEventArgs args = new MoveLocationEventArgs(location, true);
                item.Click += new EventHandler(delegate (object s, EventArgs ev)
                {
                    MoveLocationUsingComboBoxHandler(this, args);
                });
                moveToToolStripMenuItem.DropDownItems.Add(item);
            }

            moveToToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());

            foreach (LocationData location in availableLocations)
            {
                if (!this.CurrentUserHasArchivePermission() && location.LocationId == archiveLocation.LocationId)
                {
                    continue;
                }

                if (location.LocationId == review2Location.LocationId || location.LocationId == review3Location.LocationId)
                {
                    continue;
                }

                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Size = new System.Drawing.Size(135, 22);
                item.Text = location.LocationName;
                item.Text = location.LocationName;
                if (location.LocationId == this.formMaster.CURRENT_USER.UserId.Id)
                {
                    item.Text = "My Desk";
                }
                MoveLocationEventArgs args = new MoveLocationEventArgs(location, true);
                item.Click += new EventHandler(delegate (object s, EventArgs ev)
                {
                    MoveLocationUsingComboBoxHandler(this, args);
                });

                if (location.LocationId == review1Location.LocationId)
                {
                    item.Text = "Review";
                    moveToToolStripMenuItem.DropDownItems.Add(item);
                }
                else
                {
                    moveToToolStripMenuItem.DropDownItems.Add(item);
                }
            }

            if (contextLocation.LocationId != archiveLocation.LocationId)
            {
                if (!cmnuOLVAppExplore.Items.Contains(changeLocationToolStripMenuItem))
                {
                    cmnuOLVAppExplore.Items.Insert(0, changeLocationToolStripMenuItem);
                }
                if (contextLocation.LocationId == newAppsLocation.LocationId)
                {
                    changeLocationToolStripMenuItem.Text = "Move To Pickup";
                }
                else if (contextLocation.LocationId == pickupLocation.LocationId)
                {
                    changeLocationToolStripMenuItem.Text = "Pickup";
                }
                else if (contextLocation.LocationId == review1Location.LocationId ||
                    contextLocation.LocationId == review2Location.LocationId ||
                    contextLocation.LocationId == review3Location.LocationId)
                {
                    changeLocationToolStripMenuItem.Text = "Return App(s)";
                }
            }
            else
            {
                changeLocationToolStripMenuItem.Text = "Move To Review";
            }
        }

        private void cmnuOLVAppExplore_Opening(object sender, CancelEventArgs e)
        {
            AppData app = this._contextApp;
            LocationData contextLocation = null;
            if (app != null)
                contextLocation = new LocationData(app.LocationId, app.LocationName);

            UpdateContextMenu(contextLocation);

            e.Cancel = false;
        }

        private void olvAppExplore_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            e.MenuStrip = cmnuOLVAppExplore;
            _contextApp = e.Model as AppData;
        }

        private void olvAppExplore_CellClick(object sender, CellClickEventArgs e)
        {
            _contextApp = e.Model as AppData;
        }

        public void PrintConfirmations(List<AppData> apps)
        {
            WordDocumentType docType = WordDocumentType.Confirm;

            TemplateHelper templateHelper = new TemplateHelper();
            string filename = WordTemplatePathResolver.GetTemplateFileName(docType);
            if (!string.IsNullOrEmpty(filename))
            {
                string url = string.Format("api/templates");
                string savePath = WordTemplatePathResolver.GetWordTemplatePath(docType);
                templateHelper.DownloadTemplate(savePath, filename);
            }

            if (apps.Count == 0)
                return;

            FormProgress formProgress = new FormProgress();
            formProgress.Text = "Print Confirmations";
            formProgress.Argument = apps;
            formProgress.DoWork += new FormProgress.DoWorkEventHandler(printConfirmations_DoWork);
            formProgress.StartPosition = FormStartPosition.CenterScreen;
            DialogResult result = formProgress.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                MessageBox.Show("Operation has been cancelled", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (result == DialogResult.Abort)
            {
                MessageBox.Show("Exception:" + Environment.NewLine + formProgress.Result.Error.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public void EmailConfirmations(List<AppData> apps)
        {
            WordDocumentType docType = WordDocumentType.Confirm;

            TemplateHelper templateHelper = new TemplateHelper();
            string filename = WordTemplatePathResolver.GetTemplateFileName(docType);
            if (!string.IsNullOrEmpty(filename))
            {
                string url = string.Format("api/templates");
                string savePath = WordTemplatePathResolver.GetWordTemplatePath(docType);
                templateHelper.DownloadTemplate(savePath, filename);
            }

            if (apps.Count == 0)
                return;

            FormProgress formProgress = new FormProgress();
            formProgress.Text = "Print Email Confirmations";
            formProgress.Argument = apps;
            formProgress.DoWork += new FormProgress.DoWorkEventHandler(emailConfirmations_DoWork);
            formProgress.StartPosition = FormStartPosition.CenterScreen;
            DialogResult result = formProgress.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                MessageBox.Show("Operation has been cancelled", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (result == DialogResult.Abort)
            {
                MessageBox.Show("Exception:" + Environment.NewLine + formProgress.Result.Error.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void PrintConfirmation(AppData app, ClientData client, ReportTypeData reportType)
        {
            if (app == null)
                return;

            DocumentCompleteResult result = null;
            string toSaveFileName = string.Format("Confirmation - {0}", Utils.GetApplicantName(app, reportType));
            try
            {
                result = ConfirmDocumentBuilder.Confirmation(app, toSaveFileName);
                if (result != null && client != null)
                {
                    result.PrintWordDocument(1);
                }
            }
            catch (Exception ex)
            {
                if (result != null)
                    result.QuitWordDocument(false);
            }
            finally
            {
                if (result != null)
                    result.QuitWordDocument(false);
            }
        }

        private void EmailOrFaxOrPrintConfirmation(AppData app, ClientData client, ReportTypeData reportType)
        {
            if (app == null)
                return;

            DocumentCompleteResult result = null;
            string toSaveFileName = string.Format("Confirmation - {0}", Utils.GetApplicantName(app, reportType));
            try
            {
                result = ConfirmDocumentBuilder.Confirmation(app, toSaveFileName);
                if (result != null && client != null)
                {
                    if (!client.DefaultVerifyConfirmDelivery)
                    {
                        string email = string.IsNullOrEmpty(client.DefaultDeliverConfirmationsTo) ? client.Email : client.DefaultDeliverConfirmationsTo;
                        if (!string.IsNullOrEmpty(email))
                        {
                            result.SendOutlookEmail(email);
                        }
                        else if (!string.IsNullOrEmpty(client.Fax))
                        {
                            result.SendFax(client.Fax);
                        }
                        else
                        {
                            result.PrintWordDocument(1);
                        }
                    }
                    else
                    {
                        string email = string.IsNullOrEmpty(client.DefaultDeliverConfirmationsTo) ? client.Email : client.DefaultDeliverConfirmationsTo;
                        result.ShowOutlookEmail(email ?? string.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                if (result != null)
                    result.QuitWordDocument(false);
            }
            finally
            {
                if (result != null)
                    result.QuitWordDocument(false);
            }
        }

        private void printConfirmations_DoWork(FormProgress sender, DoWorkEventArgs e)
        {
            List<AppData> apps = (List<AppData>)e.Argument;
            int numTotal = apps.Count;
            int numProcessed = 0;

            foreach (AppData app in apps)
            {

                ClientData client = clientCachedApiQuery.GetClient(app.ClientApplied);
                ReportTypeData reportType = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);
                string applicant = Utils.GetApplicantName(app, reportType);
                PrintConfirmation(app, client, reportType);
                int pecentage = (100 * numProcessed) / numTotal;
                string status = string.Format("Printing Confirmation for {0}", applicant);
                sender.SetProgress(pecentage, status);
                numProcessed++;

                if (sender.IsCancellation())
                    return;
            }
        }

        private void emailConfirmations_DoWork(FormProgress sender, DoWorkEventArgs e)
        {
            List<AppData> apps = (List<AppData>)e.Argument;
            int numTotal = apps.Count;
            int numProcessed = 0;

            foreach (AppData app in apps)
            {
                ClientData client = clientCachedApiQuery.GetClient(app.ClientApplied);
                ReportTypeData reportType = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);
                string applicant = Utils.GetApplicantName(app, reportType);
                EmailOrFaxOrPrintConfirmation(app, client, reportType);
                int pecentage = (100 * numProcessed) / numTotal;
                string status = string.Format("Prepare Confirmation for {0}", applicant);
                sender.SetProgress(pecentage, status);
                numProcessed++;

                if (sender.IsCancellation())
                    return;
            }
        }

        private void emailConfirmationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<AppData> lstSelectedApps = new List<AppData>();
                foreach (AppData appdata in this.olvAppExplore.SelectedObjects)
                {
                    lstSelectedApps.Add(appdata);
                }
                EmailConfirmations(lstSelectedApps);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<AppData> apps = this.olvAppExplore.SelectedObjects.Cast<AppData>().ToList();

            if (apps == null || apps.Count == 0)
                return;

            PrintAppsWithProgressDialog(apps);
        }

        private void emailRecipientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<AppData> apps = this.olvAppExplore.SelectedObjects.Cast<AppData>().ToList();

            if (apps == null || apps.Count == 0)
                return;

            EmailApps(apps);
        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isUploaded = false;

            using (new HourGlass())
            {
                isUploaded = this.UploadMultiReports();
            }

            if (isUploaded)
            {
                MessageBox.Show("Upload reports completed!", "Upload Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void fromSelectedApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<AppData> apps = GetListSelectedApps();
                FormAppDataGrid frmAppDataGrid = new FormAppDataGrid();
                frmAppDataGrid.SetApps(apps);
                frmAppDataGrid.BringToFront();
                frmAppDataGrid.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }

        private void fromAllShownApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<AppData> apps = GetListAllApps();
                FormAppDataGrid frmAppDataGrid = new FormAppDataGrid();
                frmAppDataGrid.SetApps(apps);
                frmAppDataGrid.BringToFront();
                frmAppDataGrid.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }

        private void checkDupAllAppsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<AppData> apps = GetListAllApps();
            AppData selectedApp = this.currentLoadedApp;
            if (apps != null && apps.Count > 0)
            {
                using (new HourGlass())
                {
                    var formCheckDuplicateApps = new FormCheckDuplicatesApps();
                    formCheckDuplicateApps.SetApps(apps);
                    formCheckDuplicateApps.BringToFront();
                    formCheckDuplicateApps.Show();
                }
            }
            else
            {
                MessageBox.Show("No app in the location!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkDupSelectedAppsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<AppData> apps = GetListSelectedApps();
            AppData selectedApp = this.currentLoadedApp;
            if (apps.Count > 0)
            {
                try
                {
                    using (new HourGlass())
                    {
                        var formCheckDuplicateApps = new FormCheckDuplicatesApps();
                        formCheckDuplicateApps.SetApps(apps);
                        formCheckDuplicateApps.BringToFront();
                        formCheckDuplicateApps.Show();
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                }
            }
            else
            {
                MessageBox.Show("No apps selected!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion;

        #region Check Permission

        public bool CurrentUserHasArchivePermission()
        {
            bool hasPermission = false;
            if (formMaster.CURRENT_USER != null)
            {
                Role role = formMaster.CURRENT_ROLE;
                FeatureAuthorization featureAuth = new FeatureAuthorization();

                if (role != null)
                {
                    foreach (FeaturePermission item in role.FeaturePermissions)
                    {
                        if (item.FeatureName == featureAuth.FeatureNameToString(FeatureName.ArchiveApps))
                        {
                            if (!item.IsAllowed)
                            {
                                hasPermission = false;
                            }
                            else
                            {
                                hasPermission = true;
                            }
                        }
                    }
                }
            }
            return hasPermission;
        }

        #endregion

        #region Upload Reports

        public bool UploadMultiReports()
        {
            try
            {
                List<AppData> apps = this.olvAppExplore.SelectedObjects.Cast<AppData>().ToList();

                if (apps != null && apps.Count > 0)
                {
                    int count = 0;

                    foreach (AppData app in apps)
                    {
                        ReportTypeCachedApiQuery reportTypeCachedApiQuery = ReportTypeCachedApiQuery.Instance;
                        ReportTypeData currentReportType = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);
                        List<AppReportItem> lstReportItems = AppReportItem.GetAppReportItems(app, currentReportType);

                        if (lstReportItems == null || lstReportItems.Count == 0)
                        {
                            continue;
                        }

                        if (lstReportItems == null)
                        {
                            continue;
                        }

                        ReportTypeData reportType = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);

                        ClientData client = clientCachedApiQuery.GetClient(app.ClientApplied);

                        if (client == null)
                        {
                            continue;
                        }

                        if (string.IsNullOrEmpty(client.WebsiteDir))
                        {
                            continue;
                        }

                        count++;
                        string filePath = GenerateDocumentReportPdf(lstReportItems, app, client, reportType);
                        string fileName = Path.GetFileName(filePath);

                        if (File.Exists(filePath))
                        {
                            //upload to FTP
                            FTPService ftpClient = new FTPService(formMaster.SYSTEM_CONFIG.FtpUri, formMaster.SYSTEM_CONFIG.FtpUsername, formMaster.SYSTEM_CONFIG.FtpPassword);

                            string[] files = Directory.GetFiles(AppEnvironment.TempFolder.DisplayName, fileName);
                            string clientPath = string.Format("bemroseconsulting.com/secure/client/");

                            string clientFolder = client.WebsiteDir;
                            string uploadPath = clientPath + clientFolder;

                            if (!string.IsNullOrEmpty(clientFolder))
                            {
                                bool isValid = ftpClient.IsValidFolder(uploadPath, formMaster.SYSTEM_CONFIG.FtpUsername, formMaster.SYSTEM_CONFIG.FtpPassword);
                                if (isValid)
                                {
                                    foreach (string file in files)
                                    {
                                        string uploadFileName = (app.CompletedDate != null) ? "+" + fileName.Substring(1) : "-" + fileName.Substring(1);
                                        ftpClient.uploadFileDoc(uploadPath + "/" + uploadFileName, file);
                                        if (app.CompletedDate != null)
                                        {
                                            string oldFileName = "-" + fileName.Substring(1);
                                            if (ftpClient.CheckIfFileExistsOnServer(uploadPath + "/" + oldFileName))
                                            {
                                                ftpClient.DeleteFile(uploadPath + "/" + oldFileName);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (string file in files)
                                    {
                                        string uploadFileName = (app.CompletedDate != null) ? "+" + fileName.Substring(1) : "-" + fileName.Substring(1);
                                        ftpClient.uploadFileDoc(uploadPath + "/" + uploadFileName, file);
                                        if (app.CompletedDate != null)
                                        {
                                            string oldFileName = "-" + fileName.Substring(1);
                                            if (ftpClient.CheckIfFileExistsOnServer("/" + oldFileName))
                                            {
                                                ftpClient.DeleteFile("/" + oldFileName);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                foreach (string file in files)
                                {
                                    string uploadFileName = (app.CompletedDate != null) ? "+" + fileName.Substring(1) : "-" + fileName.Substring(1);
                                    ftpClient.uploadFileDoc(uploadPath + "/" + uploadFileName, file);
                                    if (app.CompletedDate != null)
                                    {
                                        string oldFileName = "-" + fileName.Substring(1);
                                        if (ftpClient.CheckIfFileExistsOnServer("/" + oldFileName))
                                        {
                                            ftpClient.DeleteFile("/" + oldFileName);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (count > 0)
                    {
                        return true; // Tshere's at least 1 report uploaded
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show(ex.Message);
            }
            return false; // No reports uploaded
        }

        #endregion Upload Reports

        public void CheckSpellingCurrentTextBox()
        {
            if (this.ActiveControl != null && this.ActiveControl.Parent != null
                && this.ActiveControl is UserControl && ((this.ActiveControl.Parent is TabPage)
                || (this.ActiveControl.Parent == panel3))) // hardcode for report type Employment
            {
                UserControl userControl = this.ActiveControl as UserControl;
                if (userControl.ActiveControl != null
                    && (userControl.ActiveControl is TextBox || userControl.ActiveControl is RichTextBox))
                {
                    if (string.IsNullOrEmpty(userControl.ActiveControl.Text))
                    {
                        return;
                    }

                    checkSpellingCurrentTextBox = true;
                    currentCheckSpellingControl = userControl.ActiveControl;
                    //DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                    spellChecker.Text = currentCheckSpellingControl.Text;
                    spellChecker.SpellCheck();
                }
            }
        }

        public void CheckSpellingSelectedApp()
        {
            AppData app = this.olvAppExplore.SelectedObject as AppData;
            if (app == null || string.IsNullOrEmpty(app.ApplicationId) ||
                string.IsNullOrEmpty(app.ReportTypeId))
            {
                return;
            }

            ReportTypeData reportType = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);
            if (reportType == null || string.IsNullOrEmpty(reportType.AbsoluteTypeName))
            {
                return;
            }

            checkSpellingCurrentTextBox = false;
            currentActiveTabIndex = tabAppExplore.SelectedIndex;
            spellChecker.SuggestionFormEndOfTextEvent = false;

            switch (reportType.AbsoluteTypeName)
            {
                case "Commercial":
                    tabAppExplore.SelectedTab = tabAppInfoDetail;
                    currentCheckSpellingControl = partFiveControl1.CommunityControl;
                    //DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                    spellChecker.Text = currentCheckSpellingControl.Text;
                    spellChecker.SpellCheck();
                    break;
                case "Employment":
                    tabAppExplore.SelectedTab = tabAppInfoDetail;
                    currentCheckSpellingControl = partSixControl2.CompAppliedControl;
                    //DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                    spellChecker.Text = currentCheckSpellingControl.Text;
                    spellChecker.SpellCheck();
                    break;
                case "Residential":
                    tabAppExplore.SelectedTab = tabAppInfoDetail;
                    currentCheckSpellingControl = partFiveControl1.CommunityControl;
                    //DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                    spellChecker.Text = currentCheckSpellingControl.Text;
                    spellChecker.SpellCheck();
                    break;
                case "Credit":
                    tabAppExplore.SelectedTab = tabAppInfoDetail;
                    currentCheckSpellingControl = partFiveControl1.CommunityControl;
                    //DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                    spellChecker.Text = currentCheckSpellingControl.Text;
                    spellChecker.SpellCheck();
                    break;
                case "Credit/Criminal":
                    tabAppExplore.SelectedTab = tabAppInfoDetail;
                    currentCheckSpellingControl = partFiveControl1.CommunityControl;
                    //DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                    spellChecker.Text = currentCheckSpellingControl.Text;
                    spellChecker.SpellCheck();
                    break;
                case "Criminal":
                    tabAppExplore.SelectedTab = tabAppInfoDetail;
                    currentCheckSpellingControl = partFiveControl1.CommunityControl;
                    //DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                    spellChecker.Text = currentCheckSpellingControl.Text;
                    spellChecker.SpellCheck();
                    break;
                default:
                    spellChecker.SuggestionFormEndOfTextEvent = true;
                    MessageBox.Show("Undefined Report Type!");
                    break;
            }
        }

        private void spellChecker_ReplacedWord(object sender, ReplaceWordEventArgs e)
        {
            if (currentCheckSpellingControl == null)
            {
                return;
            }

            int start = 0;
            int length = 0;

            if (currentCheckSpellingControl is RichTextBox)
            {
                start = ((RichTextBox)currentCheckSpellingControl).SelectionStart;
                length = ((RichTextBox)currentCheckSpellingControl).SelectionLength;
            }
            else if (currentCheckSpellingControl is TextBox)
            {
                start = ((TextBox)currentCheckSpellingControl).SelectionStart;
                length = ((TextBox)currentCheckSpellingControl).SelectionLength;
            }

            if (currentCheckSpellingControl is RichTextBox)
            {
                ((RichTextBox)currentCheckSpellingControl).Select(e.TextIndex, e.Word.Length);
                ((RichTextBox)currentCheckSpellingControl).SelectedText = e.ReplacementWord;
            }
            else if (currentCheckSpellingControl is TextBox)
            {
                ((TextBox)currentCheckSpellingControl).Select(e.TextIndex, e.Word.Length);
                ((TextBox)currentCheckSpellingControl).SelectedText = e.ReplacementWord;
            }

            if (start > currentCheckSpellingControl.Text.Length)
            {
                start = currentCheckSpellingControl.Text.Length;
            }

            if ((start + length) > currentCheckSpellingControl.Text.Length)
            {
                length = 0;
            }

            if (currentCheckSpellingControl is RichTextBox)
            {
                ((RichTextBox)currentCheckSpellingControl).Select(start, length);
            }
            else if (currentCheckSpellingControl is TextBox)
            {
                ((TextBox)currentCheckSpellingControl).Select(start, length);
            }
        }

        private void spellChecker_DeletedWord(object sender, SpellingEventArgs e)
        {
            if (currentCheckSpellingControl == null)
            {
                return;
            }

            int start = 0;
            int length = 0;

            if (currentCheckSpellingControl is RichTextBox)
            {
                start = ((RichTextBox)currentCheckSpellingControl).SelectionStart;
                length = ((RichTextBox)currentCheckSpellingControl).SelectionLength;
            }
            else if (currentCheckSpellingControl is TextBox)
            {
                start = ((TextBox)currentCheckSpellingControl).SelectionStart;
                length = ((TextBox)currentCheckSpellingControl).SelectionLength;
            }

            if (currentCheckSpellingControl is RichTextBox)
            {
                ((RichTextBox)currentCheckSpellingControl).Select(e.TextIndex, e.Word.Length);
                ((RichTextBox)currentCheckSpellingControl).SelectedText = "";
            }
            else if (currentCheckSpellingControl is TextBox)
            {
                ((TextBox)currentCheckSpellingControl).Select(e.TextIndex, e.Word.Length);
                ((TextBox)currentCheckSpellingControl).SelectedText = "";
            }

            if (start > currentCheckSpellingControl.Text.Length)
            {
                start = currentCheckSpellingControl.Text.Length;
            }

            if ((start + length) > currentCheckSpellingControl.Text.Length)
            {
                length = 0;
            }

            if (currentCheckSpellingControl is RichTextBox)
            {
                ((RichTextBox)currentCheckSpellingControl).Select(start, length);
            }
            else if (currentCheckSpellingControl is TextBox)
            {
                ((TextBox)currentCheckSpellingControl).Select(start, length);
            }
        }

        private void spellChecker_EndOfText(object sender, System.EventArgs e)
        {
            if (currentCheckSpellingControl == null)
            {
                spellChecker.SuggestionFormEndOfTextEvent = true;
                return;
            }

            if (checkSpellingCurrentTextBox)
            {
                //ClearOutlineCheckSpellingControl(currentCheckSpellingControl);
                currentCheckSpellingControl = null;
                MessageBox.Show("Spell Check Complete!", "Information", MessageBoxButtons.OK);
                spellChecker.SuggestionForm.Hide();
                spellChecker.SuggestionFormEndOfTextEvent = true;
                return;
            }

            AppData app = this.olvAppExplore.SelectedObject as AppData;
            if (app == null || string.IsNullOrEmpty(app.ApplicationId) ||
                string.IsNullOrEmpty(app.ReportTypeId))
            {
                //ClearOutlineCheckSpellingControl(currentCheckSpellingControl);
                currentCheckSpellingControl = null;
                spellChecker.SuggestionFormEndOfTextEvent = true;
                return;
            }

            ReportTypeData reportType = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);
            if (reportType == null || string.IsNullOrEmpty(reportType.AbsoluteTypeName))
            {
                //ClearOutlineCheckSpellingControl(currentCheckSpellingControl);
                currentCheckSpellingControl = null;
                spellChecker.SuggestionFormEndOfTextEvent = true;
                return;
            }

            switch (reportType.AbsoluteTypeName)
            {
                case "Commercial":
                    SpellingCheckCommercial();
                    break;
                case "Employment":
                    SpellingCheckEmployment();
                    break;
                case "Residential":
                    SpellingCheckResidential();
                    break;
                case "Credit":
                    SpellingCheckCredit();
                    break;
                case "Credit/Criminal":
                    SpellingCheckCreditCriminal();
                    break;
                case "Criminal":
                    SpellingCheckCriminal();
                    break;
                default:
                    MessageBox.Show("Undefined Report Type!");
                    break;
            }
        }

        private void spellChecker_OnCancelSuggestionForm(object sender, EventArgs e)
        {
            if (currentCheckSpellingControl != null)
            {
                //ClearOutlineCheckSpellingControl(currentCheckSpellingControl);
                currentCheckSpellingControl = null;
                spellChecker.SuggestionFormEndOfTextEvent = true;
            }
        }

        private void SpellingCheckCommercial()
        {
            //ClearOutlineCheckSpellingControl(currentCheckSpellingControl);
            if (tabAppExplore.SelectedTab == tabAppInfoDetail)
            {
                if (currentCheckSpellingControl == partFiveControl1.CommunityControl)
                {
                    currentCheckSpellingControl = partFiveControl1.ManagementControl;
                }
                else // currentCheckSpellingControl == partFiveControl1.ManagementControl
                {
                    tabAppExplore.SelectedTab = tabCreditInfoDetail;
                    currentCheckSpellingControl = ciTypeTwo1.BankControl;
                }
                //DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                spellChecker.Text = currentCheckSpellingControl.Text;
                spellChecker.SpellCheck();
                return;
            }
            else if (tabAppExplore.SelectedTab == tabCreditInfoDetail)
            {
                if (currentCheckSpellingControl == ciTypeTwo1.BankControl)
                {
                    currentCheckSpellingControl = ciTypeTwo1.Opened2Control;
                }
                else if (currentCheckSpellingControl == ciTypeTwo1.Opened2Control)
                {
                    currentCheckSpellingControl = ciTypeTwo1.Balance2Control;
                }
                else if (currentCheckSpellingControl == ciTypeTwo1.Balance2Control)
                {
                    currentCheckSpellingControl = ciTypeTwo1.AcctControl;
                }
                else if (currentCheckSpellingControl == ciTypeTwo1.AcctControl)
                {
                    currentCheckSpellingControl = ciTypeTwo1.NSFControl;
                }
                else if (currentCheckSpellingControl == ciTypeTwo1.NSFControl)
                {
                    currentCheckSpellingControl = ciTypeTwo1.SW2Control;
                }
                else if (currentCheckSpellingControl == ciTypeTwo1.SW2Control)
                {
                    currentCheckSpellingControl = ciTypeTwo1.CompanyControl;
                }
                else if (currentCheckSpellingControl == ciTypeTwo1.CompanyControl)
                {
                    currentCheckSpellingControl = ciTypeTwo1.PhoneControl;
                }
                else if (currentCheckSpellingControl == ciTypeTwo1.PhoneControl)
                {
                    currentCheckSpellingControl = ciTypeTwo1.Opened1Control;
                }
                else if (currentCheckSpellingControl == ciTypeTwo1.Opened1Control)
                {
                    currentCheckSpellingControl = ciTypeTwo1.TermControl;
                }
                else if (currentCheckSpellingControl == ciTypeTwo1.TermControl)
                {
                    currentCheckSpellingControl = ciTypeTwo1.Balance1Control;
                }
                else if (currentCheckSpellingControl == ciTypeTwo1.Balance1Control)
                {
                    currentCheckSpellingControl = ciTypeTwo1.HighBlcControl;
                }
                else if (currentCheckSpellingControl == ciTypeTwo1.HighBlcControl)
                {
                    currentCheckSpellingControl = ciTypeTwo1.PayHabitControl;
                }
                else if (currentCheckSpellingControl == ciTypeTwo1.PayHabitControl)
                {
                    currentCheckSpellingControl = ciTypeTwo1.RatingControl;
                }
                else if (currentCheckSpellingControl == ciTypeTwo1.RatingControl)
                {
                    currentCheckSpellingControl = ciTypeTwo1.SWControl;
                }
                else // currentCheckSpellingControl == ciTypeTwo1.SWControl
                {
                    tabAppExplore.SelectedTab = tabRentalInfoDetail;
                    currentCheckSpellingControl = rentalControl1.MIControl;
                }
                //DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                spellChecker.Text = currentCheckSpellingControl.Text;
                spellChecker.SpellCheck();
                return;
            }
            else if (tabAppExplore.SelectedTab == tabRentalInfoDetail)
            {
                if (currentCheckSpellingControl == rentalControl1.MIControl)
                {
                    currentCheckSpellingControl = rentalControl1.MOControl;
                }
                else if (currentCheckSpellingControl == rentalControl1.MOControl)
                {
                    currentCheckSpellingControl = rentalControl1.MoneyControl;
                }
                else if (currentCheckSpellingControl == rentalControl1.MoneyControl)
                {
                    currentCheckSpellingControl = rentalControl1.SWControl;
                }
                else if (currentCheckSpellingControl == rentalControl1.SWControl)
                {
                    currentCheckSpellingControl = rentalControl1.CompControl;
                }
                else if (currentCheckSpellingControl == rentalControl1.CompControl)
                {
                    currentCheckSpellingControl = rentalControl1.PhoneControl;
                }
                else if (currentCheckSpellingControl == rentalControl1.PhoneControl)
                {
                    currentCheckSpellingControl = rentalControl1.CommentControl;
                }
                else // currentCheckSpellingControl == rentalControl1.CommentControl
                {
                    tabAppExplore.SelectedTab = tabFinalDetail;
                    currentCheckSpellingControl = finalInfoControl1.FinCommentControl;
                }
                //DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                spellChecker.Text = currentCheckSpellingControl.Text;
                spellChecker.SpellCheck();
                return;
            }
            else if (tabAppExplore.SelectedTab == tabFinalDetail)
            {
                if (currentCheckSpellingControl == finalInfoControl1.FinCommentControl)
                {
                    currentCheckSpellingControl = finalInfoControl1.AppCommentControl;
                    spellChecker.Text = currentCheckSpellingControl.Text;
                    spellChecker.SpellCheck();
                    return;
                }
                else // currentCheckSpellingControl == finalInfoControl1.AppCommentControl
                {
                    MessageBox.Show("Spell Check Complete!", "Information", MessageBoxButtons.OK);
                    spellChecker.SuggestionForm.Hide();
                    tabAppExplore.SelectedIndex = currentActiveTabIndex;
                    currentCheckSpellingControl = null;
                    spellChecker.SuggestionFormEndOfTextEvent = true;
                }
            }
        }

        private void SpellingCheckEmployment()
        {
            //ClearOutlineCheckSpellingControl(currentCheckSpellingControl);
            if (tabAppExplore.SelectedTab == tabAppInfoDetail)
            {
                if (currentCheckSpellingControl == partSixControl2.CompAppliedControl)
                {
                    currentCheckSpellingControl = partSixControl2.PosAppliedControl;
                }
                else if (currentCheckSpellingControl == partSixControl2.PosAppliedControl)
                {
                    tabAppExplore.SelectedTab = tabEmpInfoDetail;
                    currentCheckSpellingControl = empTypeTwo1.EmployerControl;
                }
                //DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                spellChecker.Text = currentCheckSpellingControl.Text;
                spellChecker.SpellCheck();
                return;
            }
            else if (tabAppExplore.SelectedTab == tabEmpInfoDetail)
            {
                if (currentCheckSpellingControl == empTypeTwo1.EmployerControl)
                {
                    currentCheckSpellingControl = empTypeTwo1.CommentControl;
                }
                else if (currentCheckSpellingControl == empTypeTwo1.CommentControl)
                {
                    currentCheckSpellingControl = empTypeTwo1.SWControl;
                }
                else if (currentCheckSpellingControl == empTypeTwo1.SWControl)
                {
                    currentCheckSpellingControl = empTypeTwo1.PosControl;
                }
                else if (currentCheckSpellingControl == empTypeTwo1.PosControl)
                {
                    currentCheckSpellingControl = empTypeTwo1.HiredControl;
                }
                else if (currentCheckSpellingControl == empTypeTwo1.HiredControl)
                {
                    currentCheckSpellingControl = empTypeTwo1.TermControl;
                }
                else if (currentCheckSpellingControl == empTypeTwo1.TermControl)
                {
                    currentCheckSpellingControl = empTypeTwo1.FTControl;
                }
                else if (currentCheckSpellingControl == empTypeTwo1.FTControl)
                {
                    currentCheckSpellingControl = empTypeTwo1.MoneyControl;
                }
                else if (currentCheckSpellingControl == empTypeTwo1.MoneyControl)
                {
                    currentCheckSpellingControl = empTypeTwo1.RHControl;
                }
                else // currentCheckSpellingControl == empTypeTwo1.RHControl
                {
                    tabAppExplore.SelectedTab = tabRentalInfoDetail;
                    currentCheckSpellingControl = rentalControl1.MIControl;
                }
                //DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                spellChecker.Text = currentCheckSpellingControl.Text;
                spellChecker.SpellCheck();
                return;
            }
            else if (tabAppExplore.SelectedTab == tabRentalInfoDetail)
            {
                if (currentCheckSpellingControl == rentalControl1.MIControl)
                {
                    currentCheckSpellingControl = rentalControl1.MOControl;
                }
                else if (currentCheckSpellingControl == rentalControl1.MOControl)
                {
                    currentCheckSpellingControl = rentalControl1.MoneyControl;
                }
                else if (currentCheckSpellingControl == rentalControl1.MoneyControl)
                {
                    currentCheckSpellingControl = rentalControl1.SWControl;
                }
                else if (currentCheckSpellingControl == rentalControl1.SWControl)
                {
                    currentCheckSpellingControl = rentalControl1.CompControl;
                }
                else if (currentCheckSpellingControl == rentalControl1.CompControl)
                {
                    currentCheckSpellingControl = rentalControl1.PhoneControl;
                }
                else if (currentCheckSpellingControl == rentalControl1.PhoneControl)
                {
                    currentCheckSpellingControl = rentalControl1.CommentControl;
                }
                else // currentCheckSpellingControl == rentalControl1.CommentControl
                {
                    tabAppExplore.SelectedTab = tabCriEviDetail;
                    currentCheckSpellingControl = criEvControl1.Heading1Control;
                }
                //DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                spellChecker.Text = currentCheckSpellingControl.Text;
                spellChecker.SpellCheck();
                return;
            }
            else if (tabAppExplore.SelectedTab == tabCriEviDetail)
            {
                if (currentCheckSpellingControl == criEvControl1.Heading1Control)
                {
                    currentCheckSpellingControl = criEvControl1.ChargeControl;
                }
                else if (currentCheckSpellingControl == criEvControl1.ChargeControl)
                {
                    currentCheckSpellingControl = criEvControl1.SentenceControl;
                }
                else if (currentCheckSpellingControl == criEvControl1.SentenceControl)
                {
                    currentCheckSpellingControl = criEvControl1.Heading2Control;
                }
                else // currentCheckSpellingControl == criEvControl1.Heading2Control
                {
                    tabAppExplore.SelectedTab = tabFinalDetail;
                    currentCheckSpellingControl = finalInfoControl1.FinCommentControl;
                }
                //DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                spellChecker.Text = currentCheckSpellingControl.Text;
                spellChecker.SpellCheck();
                return;
            }
            else if (tabAppExplore.SelectedTab == tabFinalDetail)
            {
                //if (currentCheckSpellingControl == finalInfoControl1.FinCommentControl)
                //{
                //    currentCheckSpellingControl = finalInfoControl1.AppCommentControl;
                //}
                //else // currentCheckSpellingControl == finalInfoControl1.AppCommentControl
                //{
                //    tabAppExplore.SelectedTab = tabMenuDetail;
                //    appMenuControl1.TabControl.SelectedTab = appMenuControl1.TabPageContactsControl;
                //    currentCheckSpellingControl = appMenuControl1.CommentControl;
                //}
                ////DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                //spellChecker.Text = currentCheckSpellingControl.Text;
                //spellChecker.SpellCheck();
                //return;

                if (currentCheckSpellingControl == finalInfoControl1.FinCommentControl)
                {
                    currentCheckSpellingControl = finalInfoControl1.AppCommentControl;
                    spellChecker.Text = currentCheckSpellingControl.Text;
                    spellChecker.SpellCheck();
                    return;
                }
                else // currentCheckSpellingControl == finalInfoControl1.AppCommentControl
                {
                    MessageBox.Show("Spell Check Complete!", "Information", MessageBoxButtons.OK);
                    spellChecker.SuggestionForm.Hide();
                    tabAppExplore.SelectedIndex = currentActiveTabIndex;
                    currentCheckSpellingControl = null;
                    spellChecker.SuggestionFormEndOfTextEvent = true;
                }
            }
            //else // tabAppExplore.SelectedTab == tabMenuDetail
            //{
            //    MessageBox.Show("Spell Check Complete!", "Information", MessageBoxButtons.OK);
            //    spellChecker.SuggestionForm.Hide();
            //    tabAppExplore.SelectedIndex = currentActiveTabIndex;
            //    currentCheckSpellingControl = null;
            //    spellChecker.SuggestionFormEndOfTextEvent = true;
            //}
        }

        private void SpellingCheckResidential()
        {
            //ClearOutlineCheckSpellingControl(currentCheckSpellingControl);
            if (tabAppExplore.SelectedTab == tabAppInfoDetail)
            {
                if (currentCheckSpellingControl == partFiveControl1.CommunityControl)
                {
                    currentCheckSpellingControl = partFiveControl1.ManagementControl;
                }
                else // currentCheckSpellingControl == partFiveControl1.ManagementControl
                {
                    tabAppExplore.SelectedTab = tabEmpInfoDetail;
                    currentCheckSpellingControl = empTypeOne1.Heading1Control;
                }
                //DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                spellChecker.Text = currentCheckSpellingControl.Text;
                spellChecker.SpellCheck();
                return;
            }
            else if (tabAppExplore.SelectedTab == tabEmpInfoDetail)
            {
                if (currentCheckSpellingControl == empTypeOne1.Heading1Control)
                {
                    currentCheckSpellingControl = empTypeOne1.Pos1Control;
                }
                else if (currentCheckSpellingControl == empTypeOne1.Pos1Control)
                {
                    currentCheckSpellingControl = empTypeOne1.Hire1Control;
                }
                else if (currentCheckSpellingControl == empTypeOne1.Hire1Control)
                {
                    currentCheckSpellingControl = empTypeOne1.SW1Control;
                }
                else if (currentCheckSpellingControl == empTypeOne1.SW1Control)
                {
                    currentCheckSpellingControl = empTypeOne1.Money1Control;
                }
                else if (currentCheckSpellingControl == empTypeOne1.Money1Control)
                {
                    currentCheckSpellingControl = empTypeOne1.Co1Control;
                }
                else if (currentCheckSpellingControl == empTypeOne1.Co1Control)
                {
                    currentCheckSpellingControl = empTypeOne1.FT1Control;
                }
                else if (currentCheckSpellingControl == empTypeOne1.FT1Control)
                {
                    currentCheckSpellingControl = empTypeOne1.Tele1Control;
                }
                else if (currentCheckSpellingControl == empTypeOne1.Tele1Control)
                {
                    currentCheckSpellingControl = empTypeOne1.MiscCommentControl;
                }
                else if (currentCheckSpellingControl == empTypeOne1.MiscCommentControl)
                {
                    currentCheckSpellingControl = empTypeOne1.Heading2Control;
                }
                else if (currentCheckSpellingControl == empTypeOne1.Heading2Control)
                {
                    currentCheckSpellingControl = empTypeOne1.Pos2Control;
                }
                else if (currentCheckSpellingControl == empTypeOne1.Pos2Control)
                {
                    currentCheckSpellingControl = empTypeOne1.Hire2Control;
                }
                else if (currentCheckSpellingControl == empTypeOne1.Hire2Control)
                {
                    currentCheckSpellingControl = empTypeOne1.SW2Control;
                }
                else if (currentCheckSpellingControl == empTypeOne1.SW2Control)
                {
                    currentCheckSpellingControl = empTypeOne1.Money2Control;
                }
                else if (currentCheckSpellingControl == empTypeOne1.Money2Control)
                {
                    currentCheckSpellingControl = empTypeOne1.Co2Control;
                }
                else if (currentCheckSpellingControl == empTypeOne1.Co2Control)
                {
                    currentCheckSpellingControl = empTypeOne1.FT2Control;
                }
                else if (currentCheckSpellingControl == empTypeOne1.FT2Control)
                {
                    currentCheckSpellingControl = empTypeOne1.Tele2Control;
                }
                else // currentCheckSpellingControl == empTypeOne1.Tele2Control
                {
                    tabAppExplore.SelectedTab = tabRentalInfoDetail;
                    currentCheckSpellingControl = rentalControl1.MIControl;
                }
                //DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                spellChecker.Text = currentCheckSpellingControl.Text;
                spellChecker.SpellCheck();
                return;
            }
            else if (tabAppExplore.SelectedTab == tabRentalInfoDetail)
            {
                if (currentCheckSpellingControl == rentalControl1.MIControl)
                {
                    currentCheckSpellingControl = rentalControl1.MOControl;
                }
                else if (currentCheckSpellingControl == rentalControl1.MOControl)
                {
                    currentCheckSpellingControl = rentalControl1.MoneyControl;
                }
                else if (currentCheckSpellingControl == rentalControl1.MoneyControl)
                {
                    currentCheckSpellingControl = rentalControl1.SWControl;
                }
                else if (currentCheckSpellingControl == rentalControl1.SWControl)
                {
                    currentCheckSpellingControl = rentalControl1.CompControl;
                }
                else if (currentCheckSpellingControl == rentalControl1.CompControl)
                {
                    currentCheckSpellingControl = rentalControl1.PhoneControl;
                }
                else if (currentCheckSpellingControl == rentalControl1.PhoneControl)
                {
                    currentCheckSpellingControl = rentalControl1.CommentControl;
                }
                else // currentCheckSpellingControl == rentalControl1.CommentControl
                {
                    tabAppExplore.SelectedTab = tabCriEviDetail;
                    currentCheckSpellingControl = criEvControl1.Heading1Control;
                }
                //DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                spellChecker.Text = currentCheckSpellingControl.Text;
                spellChecker.SpellCheck();
                return;
            }
            else if (tabAppExplore.SelectedTab == tabCriEviDetail)
            {
                if (currentCheckSpellingControl == criEvControl1.Heading1Control)
                {
                    currentCheckSpellingControl = criEvControl1.ChargeControl;
                }
                else if (currentCheckSpellingControl == criEvControl1.ChargeControl)
                {
                    currentCheckSpellingControl = criEvControl1.SentenceControl;
                }
                else if (currentCheckSpellingControl == criEvControl1.SentenceControl)
                {
                    currentCheckSpellingControl = criEvControl1.Heading2Control;
                }
                else // currentCheckSpellingControl == criEvControl1.Heading2Control
                {
                    tabAppExplore.SelectedTab = tabFinalDetail;
                    currentCheckSpellingControl = finalInfoControl1.FinCommentControl;
                }
                //DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                spellChecker.Text = currentCheckSpellingControl.Text;
                spellChecker.SpellCheck();
                return;
            }
            else if (tabAppExplore.SelectedTab == tabFinalDetail)
            {
                //if (currentCheckSpellingControl == finalInfoControl1.FinCommentControl)
                //{
                //    currentCheckSpellingControl = finalInfoControl1.AppCommentControl;
                //}
                //else // currentCheckSpellingControl == finalInfoControl1.AppCommentControl
                //{
                //    tabAppExplore.SelectedTab = tabMenuDetail;
                //    appMenuControl1.TabControl.SelectedTab = appMenuControl1.TabPageContactsControl;
                //    currentCheckSpellingControl = appMenuControl1.CommentControl;
                //}
                ////DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                //spellChecker.Text = currentCheckSpellingControl.Text;
                //spellChecker.SpellCheck();
                //return;

                if (currentCheckSpellingControl == finalInfoControl1.FinCommentControl)
                {
                    currentCheckSpellingControl = finalInfoControl1.AppCommentControl;
                    spellChecker.Text = currentCheckSpellingControl.Text;
                    spellChecker.SpellCheck();
                    return;
                }
                else // currentCheckSpellingControl == finalInfoControl1.AppCommentControl
                {
                    MessageBox.Show("Spell Check Complete!", "Information", MessageBoxButtons.OK);
                    spellChecker.SuggestionForm.Hide();
                    tabAppExplore.SelectedIndex = currentActiveTabIndex;
                    currentCheckSpellingControl = null;
                    spellChecker.SuggestionFormEndOfTextEvent = true;
                }
            }
            //else // tabAppExplore.SelectedTab == tabMenuDetail
            //{
            //    MessageBox.Show("Spell Check Complete!", "Information", MessageBoxButtons.OK);
            //    spellChecker.SuggestionForm.Hide();
            //    tabAppExplore.SelectedIndex = currentActiveTabIndex;
            //    currentCheckSpellingControl = null;
            //    spellChecker.SuggestionFormEndOfTextEvent = true;
            //}
        }

        private void SpellingCheckCredit()
        {
            //ClearOutlineCheckSpellingControl(currentCheckSpellingControl);
            if (tabAppExplore.SelectedTab == tabAppInfoDetail)
            {
                if (currentCheckSpellingControl == partFiveControl1.CommunityControl)
                {
                    currentCheckSpellingControl = partFiveControl1.ManagementControl;
                }
                else // currentCheckSpellingControl == partFiveControl1.ManagementControl
                {
                    tabAppExplore.SelectedTab = tabCriEviDetail;
                    currentCheckSpellingControl = criEvControl1.Heading1Control;
                }
                //DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                spellChecker.Text = currentCheckSpellingControl.Text;
                spellChecker.SpellCheck();
                return;
            }
            else if (tabAppExplore.SelectedTab == tabCriEviDetail)
            {
                if (currentCheckSpellingControl == criEvControl1.Heading1Control)
                {
                    currentCheckSpellingControl = criEvControl1.ChargeControl;
                }
                else if (currentCheckSpellingControl == criEvControl1.ChargeControl)
                {
                    currentCheckSpellingControl = criEvControl1.SentenceControl;
                }
                else if (currentCheckSpellingControl == criEvControl1.SentenceControl)
                {
                    currentCheckSpellingControl = criEvControl1.Heading2Control;
                }
                else // currentCheckSpellingControl == criEvControl1.Heading2Control
                {
                    tabAppExplore.SelectedTab = tabFinalDetail;
                    currentCheckSpellingControl = finalInfoControl1.FinCommentControl;
                }
                //DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                spellChecker.Text = currentCheckSpellingControl.Text;
                spellChecker.SpellCheck();
                return;
            }
            else if (tabAppExplore.SelectedTab == tabFinalDetail)
            {
                //if (currentCheckSpellingControl == finalInfoControl1.FinCommentControl)
                //{
                //    currentCheckSpellingControl = finalInfoControl1.AppCommentControl;
                //}
                //else // currentCheckSpellingControl == finalInfoControl1.AppCommentControl
                //{
                //    tabAppExplore.SelectedTab = tabMenuDetail;
                //    appMenuControl1.TabControl.SelectedTab = appMenuControl1.TabPageContactsControl;
                //    currentCheckSpellingControl = appMenuControl1.CommentControl;
                //}
                ////DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                //spellChecker.Text = currentCheckSpellingControl.Text;
                //spellChecker.SpellCheck();
                //return;

                if (currentCheckSpellingControl == finalInfoControl1.FinCommentControl)
                {
                    currentCheckSpellingControl = finalInfoControl1.AppCommentControl;
                    spellChecker.Text = currentCheckSpellingControl.Text;
                    spellChecker.SpellCheck();
                    return;
                }
                else // currentCheckSpellingControl == finalInfoControl1.AppCommentControl
                {
                    MessageBox.Show("Spell Check Complete!", "Information", MessageBoxButtons.OK);
                    spellChecker.SuggestionForm.Hide();
                    tabAppExplore.SelectedIndex = currentActiveTabIndex;
                    currentCheckSpellingControl = null;
                    spellChecker.SuggestionFormEndOfTextEvent = true;
                }
            }
            //else // tabAppExplore.SelectedTab == tabMenuDetail
            //{
            //    MessageBox.Show("Spell Check Complete!", "Information", MessageBoxButtons.OK);
            //    spellChecker.SuggestionForm.Hide();
            //    tabAppExplore.SelectedIndex = currentActiveTabIndex;
            //    currentCheckSpellingControl = null;
            //    spellChecker.SuggestionFormEndOfTextEvent = true;
            //}
        }

        private void SpellingCheckCreditCriminal()
        {
            //ClearOutlineCheckSpellingControl(currentCheckSpellingControl);
            if (tabAppExplore.SelectedTab == tabAppInfoDetail)
            {
                if (currentCheckSpellingControl == partFiveControl1.CommunityControl)
                {
                    currentCheckSpellingControl = partFiveControl1.ManagementControl;
                }
                else // currentCheckSpellingControl == partFiveControl1.ManagementControl
                {
                    tabAppExplore.SelectedTab = tabCriEviDetail;
                    currentCheckSpellingControl = criEvControl1.Heading1Control;
                }
                //DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                spellChecker.Text = currentCheckSpellingControl.Text;
                spellChecker.SpellCheck();
                return;
            }
            else if (tabAppExplore.SelectedTab == tabCriEviDetail)
            {
                if (currentCheckSpellingControl == criEvControl1.Heading1Control)
                {
                    currentCheckSpellingControl = criEvControl1.ChargeControl;
                }
                else if (currentCheckSpellingControl == criEvControl1.ChargeControl)
                {
                    currentCheckSpellingControl = criEvControl1.SentenceControl;
                }
                else if (currentCheckSpellingControl == criEvControl1.SentenceControl)
                {
                    currentCheckSpellingControl = criEvControl1.Heading2Control;
                }
                else // currentCheckSpellingControl == criEvControl1.Heading2Control
                {
                    tabAppExplore.SelectedTab = tabFinalDetail;
                    currentCheckSpellingControl = finalInfoControl1.FinCommentControl;
                }
                //DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                spellChecker.Text = currentCheckSpellingControl.Text;
                spellChecker.SpellCheck();
                return;
            }
            else if (tabAppExplore.SelectedTab == tabFinalDetail)
            {
                //if (currentCheckSpellingControl == finalInfoControl1.FinCommentControl)
                //{
                //    currentCheckSpellingControl = finalInfoControl1.AppCommentControl;
                //}
                //else // currentCheckSpellingControl == finalInfoControl1.AppCommentControl
                //{
                //    tabAppExplore.SelectedTab = tabMenuDetail;
                //    appMenuControl1.TabControl.SelectedTab = appMenuControl1.TabPageContactsControl;
                //    currentCheckSpellingControl = appMenuControl1.CommentControl;
                //}
                ////DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                //spellChecker.Text = currentCheckSpellingControl.Text;
                //spellChecker.SpellCheck();
                //return;

                if (currentCheckSpellingControl == finalInfoControl1.FinCommentControl)
                {
                    currentCheckSpellingControl = finalInfoControl1.AppCommentControl;
                    spellChecker.Text = currentCheckSpellingControl.Text;
                    spellChecker.SpellCheck();
                    return;
                }
                else // currentCheckSpellingControl == finalInfoControl1.AppCommentControl
                {
                    MessageBox.Show("Spell Check Complete!", "Information", MessageBoxButtons.OK);
                    spellChecker.SuggestionForm.Hide();
                    tabAppExplore.SelectedIndex = currentActiveTabIndex;
                    currentCheckSpellingControl = null;
                    spellChecker.SuggestionFormEndOfTextEvent = true;
                }
            }
            //else // tabAppExplore.SelectedTab == tabMenuDetail
            //{
            //    MessageBox.Show("Spell Check Complete!", "Information", MessageBoxButtons.OK);
            //    spellChecker.SuggestionForm.Hide();
            //    tabAppExplore.SelectedIndex = currentActiveTabIndex;
            //    currentCheckSpellingControl = null;
            //    spellChecker.SuggestionFormEndOfTextEvent = true;
            //}
        }

        private void SpellingCheckCriminal()
        {
            //ClearOutlineCheckSpellingControl(currentCheckSpellingControl);
            if (tabAppExplore.SelectedTab == tabAppInfoDetail)
            {
                if (currentCheckSpellingControl == partFiveControl1.CommunityControl)
                {
                    currentCheckSpellingControl = partFiveControl1.ManagementControl;
                }
                else // currentCheckSpellingControl == partFiveControl1.ManagementControl
                {
                    tabAppExplore.SelectedTab = tabCriEviDetail;
                    currentCheckSpellingControl = criEvControl1.Heading1Control;
                }
                //DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                spellChecker.Text = currentCheckSpellingControl.Text;
                spellChecker.SpellCheck();
                return;
            }
            else if (tabAppExplore.SelectedTab == tabCriEviDetail)
            {
                if (currentCheckSpellingControl == criEvControl1.Heading1Control)
                {
                    currentCheckSpellingControl = criEvControl1.ChargeControl;
                }
                else if (currentCheckSpellingControl == criEvControl1.ChargeControl)
                {
                    currentCheckSpellingControl = criEvControl1.SentenceControl;
                }
                else if (currentCheckSpellingControl == criEvControl1.SentenceControl)
                {
                    currentCheckSpellingControl = criEvControl1.Heading2Control;
                }
                else // currentCheckSpellingControl == criEvControl1.Heading2Control
                {
                    tabAppExplore.SelectedTab = tabFinalDetail;
                    currentCheckSpellingControl = finalInfoControl1.FinCommentControl;
                }
                //DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                spellChecker.Text = currentCheckSpellingControl.Text;
                spellChecker.SpellCheck();
                return;
            }
            else if (tabAppExplore.SelectedTab == tabFinalDetail)
            {
                //if (currentCheckSpellingControl == finalInfoControl1.FinCommentControl)
                //{
                //    currentCheckSpellingControl = finalInfoControl1.AppCommentControl;
                //}
                //else // currentCheckSpellingControl == finalInfoControl1.AppCommentControl
                //{
                //    tabAppExplore.SelectedTab = tabMenuDetail;
                //    appMenuControl1.TabControl.SelectedTab = appMenuControl1.TabPageContactsControl;
                //    currentCheckSpellingControl = appMenuControl1.CommentControl;
                //}
                ////DrawOutlineCheckSpellingControl(currentCheckSpellingControl);
                //spellChecker.Text = currentCheckSpellingControl.Text;
                //spellChecker.SpellCheck();
                //return;

                if (currentCheckSpellingControl == finalInfoControl1.FinCommentControl)
                {
                    currentCheckSpellingControl = finalInfoControl1.AppCommentControl;
                    spellChecker.Text = currentCheckSpellingControl.Text;
                    spellChecker.SpellCheck();
                    return;
                }
                else // currentCheckSpellingControl == finalInfoControl1.AppCommentControl
                {
                    MessageBox.Show("Spell Check Complete!", "Information", MessageBoxButtons.OK);
                    spellChecker.SuggestionForm.Hide();
                    tabAppExplore.SelectedIndex = currentActiveTabIndex;
                    currentCheckSpellingControl = null;
                    spellChecker.SuggestionFormEndOfTextEvent = true;
                }
            }
            //else // tabAppExplore.SelectedTab == tabMenuDetail
            //{
            //    MessageBox.Show("Spell Check Complete!", "Information", MessageBoxButtons.OK);
            //    spellChecker.SuggestionForm.Hide();
            //    tabAppExplore.SelectedIndex = currentActiveTabIndex;
            //    currentCheckSpellingControl = null;
            //    spellChecker.SuggestionFormEndOfTextEvent = true;
            //}
        }

        private void DrawOutlineCheckSpellingControl(Control control)
        {
            if (control == null)
            {
                return;
            }

            Graphics graphic;
            if (!checkSpellingGraphics.TryGetValue(control.Parent.Name, out graphic))
            {
                graphic = control.Parent.CreateGraphics();
                checkSpellingGraphics.Add(control.Parent.Name, graphic);
            }

            control.Parent.Select();
            control.Focus();

            graphic.DrawRectangle(checkSpellingPen, new Rectangle(control.Location.X - 2, control.Location.Y - 2,
                control.Width + 2, control.Height + 2));
        }

        private void ClearOutlineCheckSpellingControl(Control control)
        {
            if (control == null)
            {
                return;
            }

            Graphics graphic;
            if (!checkSpellingGraphics.TryGetValue(control.Parent.Name, out graphic))
            {
                return;
            }

            graphic.Clear(Color.White);
        }

        private void FormAppExplore_FormClosing(object sender, FormClosingEventArgs e)
        {
            checkSpellingPen.Dispose();
            checkSpellingGraphics.Clear();
        }

        public void FocusToApplicationInfo()
        {
            tabAppExplore.SelectedTab = tabAppInfoDetail;
        }

        #region button events
        public void FocusToCreditInfo()
        {
            tabAppExplore.SelectedTab = tabCreditInfoDetail;
        }

        public void FocusToEmploymentInfo()
        {
            tabAppExplore.SelectedTab = tabEmpInfoDetail;
        }

        public void FocusToRentalInfo()
        {
            tabAppExplore.SelectedTab = tabRentalInfoDetail;
        }

        public void FocusToCriminalEviction()
        {
            tabAppExplore.SelectedTab = tabCriEviDetail;
        }

        public void FocusToFinalInfo()
        {
            tabAppExplore.SelectedTab = tabFinalDetail;
        }

        public void FocusToAppMenu()
        {
            tabAppExplore.SelectedTab = tabMenuDetail;
        }

        public void FocusToInternetTool()
        {
            tabAppExplore.SelectedTab = tabNetToolDetail;
        }

        public void OpenVerifs1()
        {
            if (tabAppExplore.SelectedTab == tabEmpInfoDetail)
            {
                empTypeOne1.btnVerfs1_Click(this, null);
            }
        }

        public void OpenVerifs2()
        {
            if (tabAppExplore.SelectedTab == tabEmpInfoDetail)
            {
                empTypeOne1.btnVerfs2_Click(this, null);
            }
        }

        public void OpenStandardRef()
        {
            if (tabAppExplore.SelectedTab == tabRentalInfoDetail)
            {
                rentalControl1.btnRefs_Click(this, null);
            }
            else if (tabAppExplore.SelectedTab == tabFinalDetail)
            {
                finalInfoControl1.btnSComments_Click(this, null);
            }
        }

        public void NewItem()
        {
            if (tabAppExplore.SelectedTab == tabRentalInfoDetail)
            {
                rentalControl1.btnAddRef_Click(this, null);
            }
            else if (tabAppExplore.SelectedTab == tabCriEviDetail)
            {
                criEvControl1.btnAddCharge_Click(this, null);
            }
            else if (tabAppExplore.SelectedTab == tabMenuDetail)
            {
                appMenuControl1.ShortcutKetAddContactAttemp();
            }
        }

        public void DeleteItem()
        {
            if (tabAppExplore.SelectedTab == tabRentalInfoDetail)
            {
                rentalControl1.btnDelRef_Click(this, null);
            }
            else if (tabAppExplore.SelectedTab == tabCriEviDetail)
            {
                criEvControl1.btnDelCharge_Click(this, null);
            }
            else if (tabAppExplore.SelectedTab == tabMenuDetail)
            {
                appMenuControl1.ShortcutKetDeleteContactAttemp();
            }
        }

        public void EventAltP()
        {
            if (tabAppExplore.SelectedTab == tabMenuDetail)
            {
                appMenuControl1.btnPrint_Click(this, null);
            }
            if (tabAppExplore.SelectedTab == tabFinalDetail)
            {
                finalInfoControl1.OpenSpecialCriteriaInfo();
            }
        }

        #endregion button events

        public void RefreshDisplayedApps()
        {
            int selectedIndex = this.olvAppExplore.SelectedIndex;

            List<AppData> listSelectedApps = this.GetListAllApps();
            var location = formMaster.CurrentLocation;

            if (location.LocationId == Core.Domain.Model.ExploreApps.Location.Archive.LocationId ||
                location.LocationId == Core.Domain.Model.ExploreApps.Location.Search.LocationId)
                return;

            List<AppData> lstAppByLocation = appApiRepository.FindByLocation(location.LocationId);

            if (lstAppByLocation == null)
            {
                this.olvAppExplore.Items.Clear();
            }
            else if (lstAppByLocation.Count == 0)
            {
                if (listSelectedApps.Count > 0)
                {
                    this.olvAppExplore.Items.Clear();
                }
            }
            else
            {
                if (listSelectedApps.Count > 0)
                {
                    List<string> appIds = new List<string>();
                    foreach (var app in listSelectedApps)
                    {
                        string id = app.ApplicationId;
                        if (!appIds.Contains(id))
                        {
                            appIds.Add(id);
                        }
                    }

                    Dictionary<string, AppData> dic = new Dictionary<string, AppData>();

                    if (lstAppByLocation.Count > 0)
                    {
                        foreach (AppData item in lstAppByLocation)
                        {
                            dic.Add(item.ApplicationId, item);
                        }
                    }

                    // Update displayed apps on App Explore
                    for (int i = 0; i < olvAppExplore.Items.Count; i++)
                    {
                        AppData app = (AppData)olvAppExplore.GetModelObject(i);
                        if (app != null)
                        {
                            if (dic.ContainsKey(app.ApplicationId))
                            {
                                SetPropertiesForAppReference(app, dic[app.ApplicationId]);
                                olvAppExplore.RefreshObject(app);
                            }
                            else
                            {
                                olvAppExplore.RemoveObject(app);
                            }
                        }
                    }

                    // Add new object that created by other session
                    foreach (var appId in dic.Keys)
                    {
                        if (!appIds.Contains(appId))
                        {
                            olvAppExplore.AddObject(dic[appId]);
                        }
                    }

                    // reload the common data
                    this.partOneControl1.ReloadClientsCombobox();

                    olvAppExplore.SelectedIndex = selectedIndex;
                }
            }
        }

        private void SetPropertiesForAppReference(AppData referencedApp, AppData newApp)
        {
            try
            {
                referencedApp.AppSSN = newApp.AppSSN;
                referencedApp.AcctComm = newApp.AcctComm;
                referencedApp.BalanceComm = newApp.BalanceComm;
                referencedApp.BankComm = newApp.BankComm;
                referencedApp.BirthDate = newApp.BirthDate;
                referencedApp.Charges = newApp.Charges;
                referencedApp.City = newApp.City;
                referencedApp.ClientApplied = newApp.ClientApplied;
                referencedApp.ClientAppliedName = newApp.ClientAppliedName;
                referencedApp.ClientName = newApp.ClientName;
                referencedApp.Company = newApp.Company;
                referencedApp.CompanyApplied = newApp.CompanyApplied;
                referencedApp.CompletedDate = newApp.CompletedDate;
                referencedApp.ContactAttempts = newApp.ContactAttempts;
                referencedApp.CreatedAt = newApp.CreatedAt;
                referencedApp.CreditInfo = newApp.CreditInfo;
                referencedApp.CreditPulled = newApp.CreditPulled;
                referencedApp.CreditRefs = newApp.CreditRefs;
                referencedApp.DateActive = newApp.DateActive;
                referencedApp.EmpRefs = newApp.EmpRefs;
                referencedApp.EmpVer = newApp.EmpVer;
                referencedApp.Evictions = newApp.Evictions;
                referencedApp.FinalComments = newApp.FinalComments;
                referencedApp.FirstName = newApp.FirstName;
                referencedApp.HouseNumber = newApp.HouseNumber;
                referencedApp.InvoiceDivision = newApp.InvoiceDivision;
                referencedApp.LastName = newApp.LastName;
                referencedApp.LocationId = newApp.LocationId;
                referencedApp.LocationName = newApp.LocationName;
                referencedApp.MiddleName = newApp.MiddleName;
                referencedApp.MoveInDate = newApp.MoveInDate;
                referencedApp.NSFODComm = newApp.NSFODComm;
                referencedApp.OpenedComm = newApp.OpenedComm;
                referencedApp.PagesReceived = newApp.PagesReceived;
                referencedApp.Phone = newApp.Phone;
                referencedApp.PositionApplied = newApp.PositionApplied;
                referencedApp.PostalCode = newApp.PostalCode;
                referencedApp.Priority = newApp.Priority;
                referencedApp.ReceivedDate = newApp.ReceivedDate;
                referencedApp.Recommendation = newApp.Recommendation;
                referencedApp.RegAgent = newApp.RegAgent;
                referencedApp.RentalRefs = newApp.RentalRefs;
                referencedApp.RentAmount = newApp.RentAmount;
                referencedApp.ReportCommunity = newApp.ReportCommunity;
                referencedApp.ReportManagement = newApp.ReportManagement;
                referencedApp.ReportSpecialField = newApp.ReportSpecialField;
                referencedApp.ReportTypeId = newApp.ReportTypeId;
                referencedApp.ReportTypeName = newApp.ReportTypeName;
                referencedApp.ScreenerId = newApp.ScreenerId;
                referencedApp.ScreenerName = newApp.ScreenerName;
                referencedApp.StaffComments = newApp.StaffComments;
                referencedApp.State = newApp.State;
                referencedApp.StateActive = newApp.StateActive;
                referencedApp.StreetAddress = newApp.StreetAddress;
                referencedApp.SWComm = newApp.SWComm;
                referencedApp.UnitNumber = newApp.UnitNumber;
                referencedApp.UpdatedAt = newApp.UpdatedAt;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string strSearch = this.txtSearch.Text.Trim();
            bool filter = false;

            if (e.KeyCode == Keys.Back && strSearch.Length == 0)
            {
                strSearch = string.Empty;
                new ObjectListViewService().FilterOlv(this.olvAppExplore, strSearch);
                filter = true;
            }
            else if (e.KeyCode == Keys.Enter && strSearch.Length > 0)
            {
                new ObjectListViewService().FilterOlv(this.olvAppExplore, strSearch);
                filter = true;
            }

            if (filter)
            {
                if (this.olvAppExplore.Items.Count > 0)
                {
                    this.olvAppExplore.SelectedIndex = 0;
                    this.olvAppExplore.EnsureVisible(0);
                }
                else
                {
                    ResetControls();
                }
            }
        }

        #region Drag Drop

        private void olvAppExplore_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void olvAppExplore_DragDrop(object sender, DragEventArgs e)
        {
            Point point = olvAppExplore.PointToClient(new Point(e.X, e.Y));
            ListViewItem item = olvAppExplore.GetItemAt(point.X, point.Y);
            if (item == null)
            {
                return;
            }

            if (item.Index == olvAppExplore.SelectedIndex)
            {
                return;
            }

            AppData dropApp = (AppData)olvAppExplore.GetModelObject(item.Index);
            if (dropApp == null || string.IsNullOrEmpty(dropApp.ApplicationId)
                || string.IsNullOrEmpty(dropApp.ReportTypeId))
            {
                return;
            }

            ReportTypeData reportType = reportTypeCachedApiQuery.GetReportType(dropApp.ReportTypeId);
            if (reportType == null || string.IsNullOrEmpty(reportType.AbsoluteTypeName))
            {
                return;
            }

            bool canDrop = false;
            string referenceType = string.Empty;

            // Check if can drop
            if (reportType.AbsoluteTypeName.Equals("Commercial"))
            {
                if (tabAppExplore.SelectedTab == tabCreditInfoDetail)
                {
                    canDrop = true;
                    referenceType = "credit reference(s)";
                }
                else if (tabAppExplore.SelectedTab == tabRentalInfoDetail)
                {
                    canDrop = true;
                    referenceType = "rental reference(s)";
                }
            }
            else if (reportType.AbsoluteTypeName.Equals("Employment"))
            {
                if (tabAppExplore.SelectedTab == tabEmpInfoDetail)
                {
                    canDrop = true;
                    referenceType = "employer reference(s)";
                }
                else if (tabAppExplore.SelectedTab == tabRentalInfoDetail)
                {
                    canDrop = true;
                    referenceType = "rental reference(s)";
                }
                else if (tabAppExplore.SelectedTab == tabCriEviDetail)
                {
                    if (criEvControl1.CurrentActionCopyToOtherApp ==
                        UserControls.AppExplore.GeneralInfo.CriEvControl.ActionCopyToOtherApp.Charge)
                    {
                        canDrop = true;
                        referenceType = "criminal charge(s)";
                    }
                    else if (criEvControl1.CurrentActionCopyToOtherApp ==
                      UserControls.AppExplore.GeneralInfo.CriEvControl.ActionCopyToOtherApp.Eviction)
                    {
                        canDrop = true;
                        referenceType = "criminal eviction(s)";
                    }
                }
            }
            else if (reportType.AbsoluteTypeName.Equals("Residential"))
            {
                if (tabAppExplore.SelectedTab == tabRentalInfoDetail)
                {
                    canDrop = true;
                    referenceType = "rental reference(s)";
                }
                else if (tabAppExplore.SelectedTab == tabCriEviDetail)
                {
                    if (criEvControl1.CurrentActionCopyToOtherApp ==
                        UserControls.AppExplore.GeneralInfo.CriEvControl.ActionCopyToOtherApp.Charge)
                    {
                        canDrop = true;
                        referenceType = "criminal charge(s)";
                    }
                    else if (criEvControl1.CurrentActionCopyToOtherApp ==
                      UserControls.AppExplore.GeneralInfo.CriEvControl.ActionCopyToOtherApp.Eviction)
                    {
                        canDrop = true;
                        referenceType = "criminal eviction(s)";
                    }
                }
            }
            else if (reportType.AbsoluteTypeName.Equals("Credit")
                || reportType.AbsoluteTypeName.Equals("Credit/Criminal")
                || reportType.AbsoluteTypeName.Equals("Criminal"))
            {
                if (tabAppExplore.SelectedTab == tabCriEviDetail)
                {
                    if (criEvControl1.CurrentActionCopyToOtherApp ==
                        UserControls.AppExplore.GeneralInfo.CriEvControl.ActionCopyToOtherApp.Charge)
                    {
                        canDrop = true;
                        referenceType = "criminal charge(s)";
                    }
                    else if (criEvControl1.CurrentActionCopyToOtherApp ==
                      UserControls.AppExplore.GeneralInfo.CriEvControl.ActionCopyToOtherApp.Eviction)
                    {
                        canDrop = true;
                        referenceType = "criminal eviction(s)";
                    }
                }
            }

            if (!canDrop)
            {
                return;
            }

            FormDragDropConfirmation formConfirmation = new FormDragDropConfirmation();
            formConfirmation.StartPosition = FormStartPosition.CenterParent;

            FormDragDropConfirmation.Action currentAction = FormDragDropConfirmation.Action.Cancel;
            bool hasAction = false;
            string applicantName = Utils.GetApplicantName(dropApp, reportType);
            string message = "Do you want to replace all or append only the "
                                + referenceType + " for " + applicantName + "?";
            formConfirmation.Message = message;

            DialogResult dialogResult = formConfirmation.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                currentAction = formConfirmation.FormAction;
                hasAction = true;
                formConfirmation.Close();
            }

            if (!hasAction || currentAction == FormDragDropConfirmation.Action.Cancel)
            {
                return;
            }

            // Get data from DragDrop event
            if (reportType.AbsoluteTypeName.Equals("Commercial"))
            {
                if (tabAppExplore.SelectedTab == tabCreditInfoDetail)
                {
                    DragDropData.CreditRef data = (DragDropData.CreditRef)e.Data.GetData(typeof(DragDropData.CreditRef));
                    if (currentAction == FormDragDropConfirmation.Action.ReplaceAll)
                    {
                        dropApp.CreditRefs.Clear();
                        dropApp.CreditRefs.AddRange(data.list);
                    }
                    else if (currentAction == FormDragDropConfirmation.Action.Append)
                    {
                        CreditRefData currentItem = data.list[data.currentIndex];
                        dropApp.CreditRefs.Add(currentItem);
                    }
                }
                else if (tabAppExplore.SelectedTab == tabRentalInfoDetail)
                {
                    DragDropData.RentalRef data = (DragDropData.RentalRef)e.Data.GetData(typeof(DragDropData.RentalRef));
                    if (currentAction == FormDragDropConfirmation.Action.ReplaceAll)
                    {
                        dropApp.RentalRefs.Clear();
                        dropApp.RentalRefs.AddRange(data.list);
                    }
                    else if (currentAction == FormDragDropConfirmation.Action.Append)
                    {
                        RentalRefData currentItem = data.list[data.currentIndex];
                        dropApp.RentalRefs.Add(currentItem);
                    }
                }
            }
            else if (reportType.AbsoluteTypeName.Equals("Employment"))
            {
                if (tabAppExplore.SelectedTab == tabEmpInfoDetail)
                {
                    DragDropData.EmpRef data = (DragDropData.EmpRef)e.Data.GetData(typeof(DragDropData.EmpRef));
                    if (currentAction == FormDragDropConfirmation.Action.ReplaceAll)
                    {
                        dropApp.EmpRefs.Clear();
                        dropApp.EmpRefs.AddRange(data.list);
                    }
                    else if (currentAction == FormDragDropConfirmation.Action.Append)
                    {
                        EmpRefData currentItem = data.list[data.currentIndex];
                        dropApp.EmpRefs.Add(currentItem);
                    }
                }
                else if (tabAppExplore.SelectedTab == tabRentalInfoDetail)
                {
                    DragDropData.RentalRef data = (DragDropData.RentalRef)e.Data.GetData(typeof(DragDropData.RentalRef));
                    if (currentAction == FormDragDropConfirmation.Action.ReplaceAll)
                    {
                        dropApp.RentalRefs.Clear();
                        dropApp.RentalRefs.AddRange(data.list);
                    }
                    else if (currentAction == FormDragDropConfirmation.Action.Append)
                    {
                        RentalRefData currentItem = data.list[data.currentIndex];
                        dropApp.RentalRefs.Add(currentItem);
                    }
                }
                else if (tabAppExplore.SelectedTab == tabCriEviDetail)
                {
                    if (criEvControl1.CurrentActionCopyToOtherApp ==
                        UserControls.AppExplore.GeneralInfo.CriEvControl.ActionCopyToOtherApp.Charge)
                    {
                        DragDropData.ChargeRef data = (DragDropData.ChargeRef)e.Data.GetData(typeof(DragDropData.ChargeRef));
                        if (currentAction == FormDragDropConfirmation.Action.ReplaceAll)
                        {
                            dropApp.Charges.Clear();
                            dropApp.Charges.AddRange(data.list);
                        }
                        else if (currentAction == FormDragDropConfirmation.Action.Append)
                        {
                            ChargeRefData currentItem = data.list[data.currentIndex];
                            dropApp.Charges.Add(currentItem);
                        }
                    }
                    else if (criEvControl1.CurrentActionCopyToOtherApp ==
                        UserControls.AppExplore.GeneralInfo.CriEvControl.ActionCopyToOtherApp.Eviction)
                    {
                        DragDropData.EvictionRef data = (DragDropData.EvictionRef)e.Data.GetData(typeof(DragDropData.EvictionRef));
                        if (currentAction == FormDragDropConfirmation.Action.ReplaceAll)
                        {
                            dropApp.Evictions.Clear();
                            dropApp.Evictions.AddRange(data.list);
                        }
                        else if (currentAction == FormDragDropConfirmation.Action.Append)
                        {
                            EvictionRefData currentItem = data.list[data.currentIndex];
                            dropApp.Evictions.Add(currentItem);
                        }
                    }
                }
            }
            else if (reportType.AbsoluteTypeName.Equals("Residential"))
            {
                if (tabAppExplore.SelectedTab == tabRentalInfoDetail)
                {
                    DragDropData.RentalRef data = (DragDropData.RentalRef)e.Data.GetData(typeof(DragDropData.RentalRef));
                    if (currentAction == FormDragDropConfirmation.Action.ReplaceAll)
                    {
                        dropApp.RentalRefs.Clear();
                        dropApp.RentalRefs.AddRange(data.list);
                    }
                    else if (currentAction == FormDragDropConfirmation.Action.Append)
                    {
                        RentalRefData currentItem = data.list[data.currentIndex];
                        dropApp.RentalRefs.Add(currentItem);
                    }
                }
                else if (tabAppExplore.SelectedTab == tabCriEviDetail)
                {
                    if (criEvControl1.CurrentActionCopyToOtherApp ==
                        UserControls.AppExplore.GeneralInfo.CriEvControl.ActionCopyToOtherApp.Charge)
                    {
                        DragDropData.ChargeRef data = (DragDropData.ChargeRef)e.Data.GetData(typeof(DragDropData.ChargeRef));
                        if (currentAction == FormDragDropConfirmation.Action.ReplaceAll)
                        {
                            dropApp.Charges.Clear();
                            dropApp.Charges.AddRange(data.list);
                        }
                        else if (currentAction == FormDragDropConfirmation.Action.Append)
                        {
                            ChargeRefData currentItem = data.list[data.currentIndex];
                            dropApp.Charges.Add(currentItem);
                        }
                    }
                    else if (criEvControl1.CurrentActionCopyToOtherApp ==
                        UserControls.AppExplore.GeneralInfo.CriEvControl.ActionCopyToOtherApp.Eviction)
                    {
                        DragDropData.EvictionRef data = (DragDropData.EvictionRef)e.Data.GetData(typeof(DragDropData.EvictionRef));
                        if (currentAction == FormDragDropConfirmation.Action.ReplaceAll)
                        {
                            dropApp.Evictions.Clear();
                            dropApp.Evictions.AddRange(data.list);
                        }
                        else if (currentAction == FormDragDropConfirmation.Action.Append)
                        {
                            EvictionRefData currentItem = data.list[data.currentIndex];
                            dropApp.Evictions.Add(currentItem);
                        }
                    }
                }
            }
            else if (reportType.AbsoluteTypeName.Equals("Credit")
                || reportType.AbsoluteTypeName.Equals("Credit/Criminal")
                || reportType.AbsoluteTypeName.Equals("Criminal"))
            {
                if (tabAppExplore.SelectedTab == tabCriEviDetail)
                {
                    if (criEvControl1.CurrentActionCopyToOtherApp ==
                        UserControls.AppExplore.GeneralInfo.CriEvControl.ActionCopyToOtherApp.Charge)
                    {
                        DragDropData.ChargeRef data = (DragDropData.ChargeRef)e.Data.GetData(typeof(DragDropData.ChargeRef));
                        if (currentAction == FormDragDropConfirmation.Action.ReplaceAll)
                        {
                            dropApp.Charges.Clear();
                            dropApp.Charges.AddRange(data.list);
                        }
                        else if (currentAction == FormDragDropConfirmation.Action.Append)
                        {
                            ChargeRefData currentItem = data.list[data.currentIndex];
                            dropApp.Charges.Add(currentItem);
                        }
                    }
                    else if (criEvControl1.CurrentActionCopyToOtherApp ==
                        UserControls.AppExplore.GeneralInfo.CriEvControl.ActionCopyToOtherApp.Eviction)
                    {
                        DragDropData.EvictionRef data = (DragDropData.EvictionRef)e.Data.GetData(typeof(DragDropData.EvictionRef));
                        if (currentAction == FormDragDropConfirmation.Action.ReplaceAll)
                        {
                            dropApp.Evictions.Clear();
                            dropApp.Evictions.AddRange(data.list);
                        }
                        else if (currentAction == FormDragDropConfirmation.Action.Append)
                        {
                            EvictionRefData currentItem = data.list[data.currentIndex];
                            dropApp.Evictions.Add(currentItem);
                        }
                    }
                }
            }

            using (new HourGlass())
            {
                try
                {
                    appApiRepository.Update(dropApp);
                    appCachedApiQuery.SetApp(dropApp);
                    //_logger.Info("Copy success!");
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                }
            }
        }

        #endregion

        public bool RigthSectionIsFocused()
        {
            return this.olvAppExplore.Focused;
        }

        public void ShowArchivedAppFromInvoice(AppData app)
        {
            try
            {
                using (new HourGlass())
                {
                    List<AppData> apps = new List<AppData>();
                    apps.Add(app);

                    if (apps != null && apps.Count > 0)
                    {
                        this.olvAppExplore.SetObjects(apps);
                    }
                    else
                    {
                        this.ResetControls();
                        this.olvAppExplore.ClearObjects();
                    }

                    if (app == null)
                    {
                        this.olvAppExplore.SelectedIndex = 0;
                    }
                    else
                    {
                        for (int i = 0; i < this.olvAppExplore.Items.Count; i++)
                        {
                            AppData item = (AppData)this.olvAppExplore.GetModelObject(i);
                            if (item != null && !string.IsNullOrEmpty(item.ApplicationId) &&
                                item.ApplicationId.Equals(app.ApplicationId))
                            {
                                this.olvAppExplore.SelectedIndex = i;
                                this.olvAppExplore.EnsureVisible(i);
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
