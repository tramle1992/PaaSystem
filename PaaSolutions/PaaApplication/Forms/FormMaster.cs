using Common.Infrastructure.Office;
using Common.Infrastructure.UI;
using Core.Application.Data.ClientInfo;
using InfoResource.Application.Data;
using PaaApplication.Forms.Administration;
using PaaApplication.Forms.Adminstration;
using PaaApplication.Forms.AppExplore;
using PaaApplication.Forms.ClientInfo;
using PaaApplication.Forms.Datagrid;
using PaaApplication.Forms.Invoicing;
using PaaApplication.Forms.UserManager;
using PaaApplication.Models.ClientInfo;
using PaaApplication.Models.Common;
using PaaApplication.Themes;
using System;
using System.Collections.Generic;
using System.Configuration;
using IdentityAccess.Infrastructure.Identity;
using System.Drawing;
using System.Windows.Forms;
using IdentityAccess.Domain.Model.Identity;
using System.IO;
using IdentityAccess.Infrastructure.Access;
using IdentityAccess.Domain.Model.Access;
using IdentityAccess.Infrastructure.Authorization;
using Core.Application.Data.ExploreApps;
using IdentityAccess.CommonType;
using PaaApplication.Helper;
using Core.Application.Command.ExploreApps;
using Core.Infrastructure.ClientInfo;
using PaaApplication.Models.AppExplore;
using Invoice.Infrastructure;
using Invoice.Application.Data;
using TimeCard.Infrastructure.TimeCard;
using TimeCard.Command;
using TimeCard.Data;
using InfoResource.Infrastructure.InfoResource;
using Administration.Domain.Model.InternetTool;
using Administration.Infrastructure.InternetTool;
using Core.Infrastructure.ExploreApps;
using SystemConfiguration.Application.Data;
using SystemConfiguration.Infrastructure;
using Common.Application;
using System.Threading.Tasks;
using Nito.AsyncEx;
using Word = NetOffice.WordApi;
using System.Data.Linq;

using Invoice.Application;
using PaaApplication.Models;

namespace PaaApplication.Forms
{
    public partial class FormMaster : RibbonForm
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static List<Form> formList = new List<Form>();
        
        private Timer timer = new Timer();
        private Timer timerForceToExit = new Timer();
        public Timer timerForAutoSave = new Timer();
        private Timer timerForAutoRefresh = new Timer();
        private readonly AsyncLock _mutex = new AsyncLock();
        private int prevActiveTab = -1;

        // Api repositories
        InvoiceApiRepository invoiceApiRepository = new InvoiceApiRepository();
        SysConfigApiRepository sysConfigApiRepository = new SysConfigApiRepository();
        AppApiRepository appApiRepository = new AppApiRepository();

        // Forms
        FormZipCode _formZipCode;
        FormSearchArchive _frmSearchArchive;
        FormSearchApplication _frmSearchApplications;
        FormAppDataGrid _frmAppDataGrid;
        FormInfoResources _frmInfoResources;
        FormClientInfo _frmClientInfo;
        FormBillingManager _frmInvoicing;

        // Global Data List
        public List<ClientData> LIST_CLIENTS = new List<ClientData>();
        public List<string> LIST_INVOICE_DIVISIONS = new List<string>();
        public List<string> LIST_CUSTOMER_NUMBERS = new List<string>();
        public List<User> LIST_USERS = new List<User>();
        public List<User> LIST_ACTIVE_USERS = new List<User>();
        public List<ResourceData> LIST_INFO_RESOURCES = new List<ResourceData>();
        public List<Role> LIST_ROLES = new List<Role>();
        public List<ReportTypeData> LIST_REPORT_TYPES = new List<ReportTypeData>();
        public List<InternetItem> LIST_INTERNET_TOOLS = new List<InternetItem>();
        public List<AppData> LIST_APPS_FOR_INVOICE = new List<AppData>();

        // Global System Config
        public ConfigData SYSTEM_CONFIG = new ConfigData();

        #region user Params

        public User CURRENT_USER { get; set; }

        public Role CURRENT_ROLE { get; set; }

        public LocationData CurrentLocation { get; set; }

        public Image UserAvatar
        {
            set
            {
                this.rbtnMyProfile.Image = value;
                this.rbtnDesk.Image = value;
            }
        }

        #endregion

        public FormMaster()
        {
            InitializeComponent();
            InitializeEventBus();
            ChangeTheme();
            LoadSysConfig();
            LoadGlobalData();
        }

        private void InitializeEventBus()
        {
            EventBus.Subscribe(e =>
            {
                if (e is EditAppsEventArgs && e != null && ((EditAppsEventArgs)e).ApplicationIds != null)
                {
                    EditAppsEventHandler(((EditAppsEventArgs)e).ApplicationIds);
                }
            });
        }

        private void LoadSysConfig()
        {
            SYSTEM_CONFIG = sysConfigApiRepository.Find(GlobalConstants.SYS_CONFIG_ID);
            if (SYSTEM_CONFIG == null || string.IsNullOrEmpty(SYSTEM_CONFIG.ConfigId))
            {
                SYSTEM_CONFIG = new ConfigData();
                SYSTEM_CONFIG.BackupLocation = GlobalConstants.DEFAULT_BACKUP_LOCATION;
                SYSTEM_CONFIG.BackupTime = GlobalConstants.DEFAULT_BACKUP_TIME;
                SYSTEM_CONFIG.WorkingHourFrom = GlobalConstants.DEFAULT_WORKING_HOUR_FROM;
                SYSTEM_CONFIG.WorkingHourTo = GlobalConstants.DEFAULT_WORKING_HOUR_TO;
                SYSTEM_CONFIG.NumberAppsBonus = (short)GlobalConstants.DEFAULT_NUMBER_APPS_BONUS;
                SYSTEM_CONFIG.BillingEmailConfirmation = GlobalConstants.DEFAULT_BILLING_EMAIL_CONFIRMATION;
                SYSTEM_CONFIG.FtpUri = GlobalConstants.DEFAULT_FTP_URI;
                SYSTEM_CONFIG.FtpUsername = GlobalConstants.DEFAULT_FTP_USERNAME;
                SYSTEM_CONFIG.FtpPassword = GlobalConstants.DEFAULT_FTP_PASSWORD;
                SYSTEM_CONFIG.AutoSaveTimeInterval = GlobalConstants.DEFAULT_AUTO_SAVE_TIME_INTERVAL;
            }

            GlobalVars.IsIgnoreAutoSave = false;
            GlobalVars.IsFormLoaded = false;
        }

        private void LoadGlobalData()
        {
            LoadDataAsync().Wait();
        }

        private void RegisterHandlers()
        {
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += new EventHandler(timer_Tick);

            timerTriggerLogOut.Interval = GlobalConstants.DEFAULT_CHECKING_LOGOUT_TIME_INTERVAL * 1000; // Trigger checking logOut time every 3 minutes
            timerTriggerLogOut.Enabled = true;
            timerTriggerLogOut.Tick += timerTriggerLogOut_Tick;

            timerForceToExit.Interval = GlobalConstants.DEFAULT_FORCE_EXIT_AFTER_TIME * 1000; // Force Exit App after 15 minutes
            timerForceToExit.Enabled = false;
            timerForceToExit.Tick += timerForceToExit_Tick;

            timerForAutoRefresh.Interval = SYSTEM_CONFIG.AutoSaveTimeInterval * 1000 + 300000; // Trigger refresh function

            timerForAutoSave.Interval = SYSTEM_CONFIG.AutoSaveTimeInterval * 1000; // Trigger save function
            timerForAutoSave.Enabled = true;
            timerForAutoSave.Tick += timerForAutoSave_Tick;

            timerForAutoRefresh.Interval = SYSTEM_CONFIG.AutoSaveTimeInterval * 1000 + 300000; // Trigger refresh function
            timerForAutoRefresh.Enabled = true;
            timerForAutoRefresh.Tick += timerForAutoRefresh_Tick;



            GlobalVars.IsIgnoreAutoSave = false;
        }

        public void ResetHandlers()
        {
            timerForAutoSave.Interval = SYSTEM_CONFIG.AutoSaveTimeInterval * 1000;

            timerForAutoRefresh.Interval = SYSTEM_CONFIG.AutoSaveTimeInterval * 1000 + 300000;
        }

        void timerForAutoRefresh_Tick(object sender, EventArgs e)
        {
            RefreshAllDataAsync();
        }

        void timerTriggerLogOut_Tick(object sender, EventArgs e)
        {
            TimeCardApiRepository tcApiRepository = new TimeCardApiRepository();
            DateTime? currentTime = tcApiRepository.GetServerUtcTime();

            if (currentTime != null)
            {
                DateTime timeToCheck = ((DateTime)currentTime).ToLocalTime();

                double timeDiff = (SYSTEM_CONFIG.WorkingHourTo - timeToCheck.TimeOfDay).TotalMinutes;
                if (timeDiff > 13 && timeDiff < 17)
                {
                    timerTriggerLogOut.Enabled = false;
                    timerForceToExit.Enabled = true;
                    MessageBox.Show("It's time you should logout since it's " + timeToCheck.ToString("hh:mm:ss tt") + " now. \nPlease complete you tasks and logout or system will automatically Exit after 15 minutes.", "It's time to Logout!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        void timerForceToExit_Tick(object sender, EventArgs e)
        {
            this.LogOut();
            this.OnFormClosing(new FormClosingEventArgs(CloseReason.ApplicationExitCall, false));
        }

        void timerForAutoSave_Tick(object sender, EventArgs e)
        {
            if (!GlobalVars.IsIgnoreAutoSave)
            {
                SaveAppAsync();
                SaveClientAsync();
                SaveUserAsync();
            }
        }

        private void frmMaster_Load(object sender, EventArgs e)
        {
            RegisterHandlers();
            InitializeButtonLocations();
            InitializeForms();
            RefreshAllDataAsync();
        }

        #region Initialize Button DropDown

        public void InitializeButtonLocations()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMaster));

            InitializeDesk();
            InitializeChangeLocation();
        }

        private void InitializeDesk()
        {
            rbtnDesk.DropDownItems.Clear();
            List<LocationData> availableDesks = GetAvailableDesk();
            User currentUser = this.CURRENT_USER;
            if (currentUser != null)
            {
                rbtnDesk.Text = currentUser.UserName;
                Image imgUser = ImageHelper.ResizeImage(LookupLocationImage(currentUser.UserId.Id), new Size(83, 50));
                rbtnDesk.Image = imgUser;
            }

            RibbonButton reviewButton = null;
            foreach (LocationData location in availableDesks)
            {
                RibbonButton rbtnLocation = new RibbonButton();
                Image img = ImageHelper.ResizeImage(LookupLocationImage(location.LocationId), new Size(16, 16));
                rbtnLocation.SmallImage = img;
                rbtnLocation.Style = RibbonButtonStyle.Normal;
                rbtnLocation.Text = location.LocationName;
                rbtnLocation.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
                rbtnLocation.Value = location.LocationId;
                rbtnLocation.Click += new EventHandler(this.rbtnChangeLocation_Click);

                if (location.LocationId == Core.Domain.Model.ExploreApps.Location.Review1.LocationId ||
                    location.LocationId == Core.Domain.Model.ExploreApps.Location.Review2.LocationId ||
                    location.LocationId == Core.Domain.Model.ExploreApps.Location.Review3.LocationId)
                {
                    // create reviewItem menu if not existed
                    if (reviewButton == null)
                    {
                        reviewButton = new RibbonButton();
                        reviewButton.SmallImage = img;
                        reviewButton.Style = RibbonButtonStyle.DropDown;
                        reviewButton.Text = "Review";
                        reviewButton.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
                        reviewButton.DropDownItems.Clear();
                        rbtnDesk.DropDownItems.Add(reviewButton);
                    }
                    reviewButton.DropDownItems.Add(rbtnLocation);
                }
                else
                {
                    rbtnDesk.DropDownItems.Add(rbtnLocation);
                }
            }

            rbtnDesk.DropDownItems.Add(new RibbonSeparator());

            // Archive button
            RibbonButton archive = new RibbonButton();
            Image archiveImg = ImageHelper.ResizeImage((Image)PaaApplication.Properties.Resources.archive, new Size(16, 16));
            archive.SmallImage = archiveImg;
            archive.Style = RibbonButtonStyle.Normal;
            archive.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            archive.Click += new EventHandler(this.rbtnArchive_Click);
            archive.Text = "Archive";

            // Search button
            RibbonButton search = new RibbonButton();
            Image searchImg = ImageHelper.ResizeImage((Image)PaaApplication.Properties.Resources.search, new Size(16, 16));
            search.SmallImage = archiveImg;
            search.Style = RibbonButtonStyle.Normal;
            search.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            search.Click += new EventHandler(this.rbtnSearchApp_Click);
            search.Text = "Search";

            rbtnDesk.DropDownItems.Add(archive);
            rbtnDesk.DropDownItems.Add(search);
        }

        public void InitializeChangeLocation()
        {
            rbtnChangeLocation.DropDownItems.Clear();
            List<LocationData> locationsFromUsers = GetAvailableLocationFromUsers();
            List<LocationData> specialLocations = GetSpecialLocations();

            foreach (LocationData location in locationsFromUsers)
            {
                RibbonButton rbtnLocation = new RibbonButton();
                Image img = ImageHelper.ResizeImage(LookupLocationImage(location.LocationId), new Size(16, 16));
                rbtnLocation.SmallImage = img;
                rbtnLocation.Style = RibbonButtonStyle.Normal;
                rbtnLocation.Text = location.LocationName;
                rbtnLocation.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
                rbtnLocation.Value = location.LocationId;
                rbtnLocation.Click += new EventHandler(this.rbtnChangeLocation_Click);
                this.rbtnChangeLocation.DropDownItems.Add(rbtnLocation);
            }

            this.rbtnChangeLocation.DropDownItems.Add(new RibbonSeparator());
            RibbonButton reviewButton = null;
            foreach (LocationData location in specialLocations)
            {
                RibbonButton rbtnLocation = new RibbonButton();
                Image img = ImageHelper.ResizeImage(LookupLocationImage(location.LocationId), new Size(16, 16));
                rbtnLocation.SmallImage = img;
                rbtnLocation.Style = RibbonButtonStyle.Normal;
                rbtnLocation.Text = location.LocationName;
                rbtnLocation.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
                rbtnLocation.Value = location.LocationId;
                rbtnLocation.Click += new EventHandler(this.rbtnChangeLocation_Click);

                if (location.LocationId == Core.Domain.Model.ExploreApps.Location.Review1.LocationId || 
                    location.LocationId == Core.Domain.Model.ExploreApps.Location.Review2.LocationId || 
                    location.LocationId == Core.Domain.Model.ExploreApps.Location.Review3.LocationId)
                {
                    // create reviewItem menu if not existed
                    if (reviewButton == null)
                    {
                        reviewButton = new RibbonButton();
                        reviewButton.SmallImage = img;
                        reviewButton.Style = RibbonButtonStyle.DropDown;
                        reviewButton.Text = "Review";
                        reviewButton.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
                        reviewButton.DropDownItems.Clear();
                        rbtnChangeLocation.DropDownItems.Add(reviewButton);
                    }
                    reviewButton.DropDownItems.Add(rbtnLocation);
                }
                else
                {
                    this.rbtnChangeLocation.DropDownItems.Add(rbtnLocation);
                }
            }

            rbtnChangeLocation.DropDownItems.Add(new RibbonSeparator());

            // Archive button
            RibbonButton archive = new RibbonButton();
            Image archiveImg = ImageHelper.ResizeImage((Image)PaaApplication.Properties.Resources.archive, new Size(16, 16));
            archive.SmallImage = archiveImg;
            archive.Style = RibbonButtonStyle.Normal;
            archive.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            archive.Click += new EventHandler(this.rbtnArchive_Click);
            archive.Text = "Archive";

            // Search button
            RibbonButton search = new RibbonButton();
            Image searchImg = ImageHelper.ResizeImage((Image)PaaApplication.Properties.Resources.search, new Size(16, 16));
            search.SmallImage = archiveImg;
            search.Style = RibbonButtonStyle.Normal;
            search.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            search.Click += new EventHandler(this.rbtnSearchApp_Click);
            search.Text = "Search";

            rbtnChangeLocation.DropDownItems.Add(archive);
            rbtnChangeLocation.DropDownItems.Add(search);
        }

        private List<LocationData> GetAvailableDesk()
        {
            User user = CURRENT_USER;
            List<LocationData> locations = new List<LocationData>();
            Core.Domain.Model.ExploreApps.Location pickup = Core.Domain.Model.ExploreApps.Location.Pickup;
            Core.Domain.Model.ExploreApps.Location review1 = Core.Domain.Model.ExploreApps.Location.Review1;
            Core.Domain.Model.ExploreApps.Location review2 = Core.Domain.Model.ExploreApps.Location.Review2;
            Core.Domain.Model.ExploreApps.Location review3 = Core.Domain.Model.ExploreApps.Location.Review3;
            Core.Domain.Model.ExploreApps.Location newApps = Core.Domain.Model.ExploreApps.Location.NewApps;

            LocationData userLocation = AutoMapper.Mapper.Map<Core.Domain.Model.ExploreApps.Location, LocationData>(Core.Domain.Model.ExploreApps.Location.FromUser(user));
            locations.Add(new LocationData(userLocation.LocationId, "My Desk"));
            locations.Add(new LocationData(pickup.LocationId, pickup.LocationName));
            locations.Add(new LocationData(review1.LocationId, review1.LocationName));
            locations.Add(new LocationData(review2.LocationId, review2.LocationName));
            locations.Add(new LocationData(review3.LocationId, review3.LocationName));
            locations.Add(new LocationData(newApps.LocationId, newApps.LocationName));

            if (CurrentLocation != null)
            {
                return locations.FindAll(l => l.LocationId != CurrentLocation.LocationId);
            }
            else
            {
                return locations;
            }
        }

        private List<LocationData> GetAvailableLocationFromUsers()
        {
            List<LocationData> locations = new List<LocationData>();
            List<User> _users = UserCachedApiQuery.Instance.GetActiveUsers();

            foreach (User user in _users)
            {
                LocationData location = new LocationData(user.UserId.Id, user.UserName);
                locations.Add(location);
            }

            if (CurrentLocation != null)
            {
                return locations.FindAll(l => l.LocationId != CurrentLocation.LocationId);
            }
            else
            {
                return locations;
            }
        }

        private List<LocationData> GetSpecialLocations()
        {
            List<LocationData> locations = new List<LocationData>();
            Core.Domain.Model.ExploreApps.Location review1 = Core.Domain.Model.ExploreApps.Location.Review1;
            Core.Domain.Model.ExploreApps.Location review2 = Core.Domain.Model.ExploreApps.Location.Review2;
            Core.Domain.Model.ExploreApps.Location review3 = Core.Domain.Model.ExploreApps.Location.Review3;
            Core.Domain.Model.ExploreApps.Location pickup = Core.Domain.Model.ExploreApps.Location.Pickup;
            Core.Domain.Model.ExploreApps.Location newApps = Core.Domain.Model.ExploreApps.Location.NewApps;

            locations.Add(new LocationData(pickup.LocationId, pickup.LocationName));
            locations.Add(new LocationData(review1.LocationId, review1.LocationName));
            locations.Add(new LocationData(review2.LocationId, review2.LocationName));
            locations.Add(new LocationData(review3.LocationId, review3.LocationName));
            locations.Add(new LocationData(newApps.LocationId, newApps.LocationName));

            if (CurrentLocation != null)
            {
                return locations.FindAll(l => l.LocationId != CurrentLocation.LocationId);
            }
            else
            {
                return locations;
            }
        }

        private List<LocationData> GetAllLocations()
        {
            UserCachedApiQuery userCachedApiQuery = UserCachedApiQuery.Instance;
            List<LocationData> _locations = new List<LocationData>();
            List<User> _users = userCachedApiQuery.GetAllUsers().FindAll(u => u.Status == UserStatus.Active);
            _locations.AddRange(LocationData.PreDefineLocations());
            foreach (User user in _users)
            {
                LocationData location = new LocationData(user.UserId.Id, user.UserName);
                _locations.Add(location);
            }
            return _locations;
        }

        private Image LookupLocationImage(string locationId)
        {
            UserCachedApiQuery userCachedApiQuery = UserCachedApiQuery.Instance;
            List<User> _users = userCachedApiQuery.GetAllUsers();
            User user = _users.Find(u => u.UserId.Id == locationId);
            if (user != null && user.Avatar != null)
            {
                using (var ms = new MemoryStream(user.Avatar))
                {
                    return Image.FromStream(ms);
                }
            }
            else
            {
                if (locationId == Core.Domain.Model.ExploreApps.Location.NewApps.LocationId)
                {
                    return PaaApplication.Properties.Resources.newapp;
                }
                else if (locationId == Core.Domain.Model.ExploreApps.Location.Pickup.LocationId)
                {
                    return PaaApplication.Properties.Resources.pickup;
                }
                else if (locationId == Core.Domain.Model.ExploreApps.Location.Review1.LocationId ||
                    locationId == Core.Domain.Model.ExploreApps.Location.Review2.LocationId ||
                    locationId == Core.Domain.Model.ExploreApps.Location.Review3.LocationId)
                {
                    return PaaApplication.Properties.Resources.review;
                }
                else if (locationId == Core.Domain.Model.ExploreApps.Location.Archive.LocationId)
                {
                    return PaaApplication.Properties.Resources.archive;
                }
                else if (locationId == Core.Domain.Model.ExploreApps.Location.Search.LocationId)
                {
                    return PaaApplication.Properties.Resources.search;
                }
                return PaaApplication.Properties.Resources.newapp;
            }
        }

        private void rbtnChangeLocation_Click(object sender, EventArgs e)
        {
            try
            {
                RibbonButton rb = sender as RibbonButton;
                if (rb != null)
                {
                    string newLocationId = rb.Value;
                    string newLocationName = rb.Text;
                    string currentLocationId = CurrentLocation.LocationId;
                    string currentLocationName = CurrentLocation.LocationName;

                    using (new HourGlass())
                    {
                        FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
                        form.ChangeLocation(newLocationId);
                        CurrentLocation = new LocationData(newLocationId, newLocationName);
                        InitializeButtonLocations();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void rbtnArchive_Click(object sender, EventArgs e)
        {
            if (_frmSearchArchive != null)
            {
                _frmSearchArchive.StartPosition = FormStartPosition.CenterParent;
                DialogResult result = _frmSearchArchive.ShowDialog();
                if (result == DialogResult.OK)
                {
                    SearchAppCommand command = _frmSearchArchive.GetSearchCommand();
                    using (new HourGlass())
                    {
                        Core.Domain.Model.ExploreApps.Location archive = Core.Domain.Model.ExploreApps.Location.Archive;
                        FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
                        form.SearchApp(command);
                        CurrentLocation = new LocationData(archive.LocationId, archive.LocationName);
                        InitializeButtonLocations();
                    }
                }
            }
        }

        #endregion;

        #region MenuStrip

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;
            string date = t.ToLongDateString();
            string time = t.ToLongTimeString();
            sttlblClock.Text = string.Format("{0} | {1}", date, time);
        }

        #endregion MenuStrip

        #region Theme

        private void ChangeTheme()
        {
            Theme.ColorTable = new BlackSkin();
            ribbon.Refresh();
        }

        #endregion Theme

        #region Form

        public void InitializeForms()
        {
            _frmSearchArchive = new FormSearchArchive(this);
            _frmSearchApplications = new FormSearchApplication(this);
            _frmAppDataGrid = new FormAppDataGrid();
        }

        public static Form getFormByName(string formName)
        {
            foreach (Form form in formList)
            {
                if (form.Name == formName)
                {
                    return form;
                }
            }
            return null;
        }

        private void hideAllForm(string exclusiveFormName = "")
        {
            SetStandardTemplatesButtonsVisible(false);
            SetAppExploreButtonsVisible(null, null, null);

            foreach (Form form in formList)
            {
                if (form.Name != exclusiveFormName)
                    form.Hide();
            }
        }

        #endregion Form

        #region RibbonTab General

        private void ribbon_ActiveTabChanged(object sender, EventArgs e)
        {
            int rtabIndex = int.Parse(ribbon.ActiveTab.Value);

            if (rtabIndex == 0)
            {
                hideAllForm();
                SetAppCount();
            }
            else if (rtabIndex == 1) // Client Info
            {
                var prevTab = ribbon.Tabs[prevActiveTab];
                ribbon.ActiveTab = prevTab;
                rtabIndex = prevActiveTab;

                _frmClientInfo = (_frmClientInfo != null) ? _frmClientInfo : null;
                if (_frmClientInfo != null && !_frmClientInfo.IsDisposed)
                {
                    _frmClientInfo.Show();

                    if (_frmClientInfo.WindowState == FormWindowState.Minimized)
                    {
                        _frmClientInfo.Focus();
                        _frmClientInfo.WindowState = FormWindowState.Normal;
                    }
                }
                else
                {
                    _frmClientInfo = new FormClientInfo(this);
                    formList.Add(_frmClientInfo);
                }

                _frmClientInfo.Init();
                _frmClientInfo.BringToFront();
                _frmClientInfo.Show();
            }
            else if (rtabIndex == 2) // Application Explore
            {
                Form frmAppExplore = getFormByName("FormAppExplore");

                if (frmAppExplore == null)
                {
                    frmAppExplore = new FormAppExplore(this);
                    frmAppExplore.TopLevel = false;
                    frmAppExplore.Dock = DockStyle.Fill;
                    pnlContentDisplay.Controls.Add(frmAppExplore);
                    formList.Add(frmAppExplore);
                }

                hideAllForm("FormAppExplore");

                if (prevActiveTab != rtabIndex)
                {
                    frmAppExplore.BringToFront();
                    frmAppExplore.Show();
                }
            }
            else if (rtabIndex == 3) // Info resource
            {
                var prevTab = ribbon.Tabs[prevActiveTab];
                ribbon.ActiveTab = prevTab;
                rtabIndex = prevActiveTab;

                _frmInfoResources = (_frmInfoResources != null) ? _frmInfoResources : null;
                if (_frmInfoResources != null && !_frmInfoResources.IsDisposed)
                {
                    _frmInfoResources.Show();

                    // Show minimized form
                    if (_frmInfoResources.WindowState == FormWindowState.Minimized)
                    {
                        _frmInfoResources.Focus();
                        _frmInfoResources.WindowState = FormWindowState.Normal;
                    }
                }
                else
                {
                    _frmInfoResources = new FormInfoResources(this);
                    _frmInfoResources.CurrentType = InfoResourceType.Landlord;
                }

                _frmInfoResources.OnOpenWindows(sender, e);
                          
            }
            else if (rtabIndex == 4) // Invoicing
            {
                var prevTab = ribbon.Tabs[prevActiveTab];
                ribbon.ActiveTab = prevTab;
                rtabIndex = prevActiveTab;

                _frmInvoicing = (_frmInvoicing != null) ? _frmInvoicing : null;
                if (_frmInvoicing != null && !_frmInvoicing.IsDisposed)
                {
                    _frmInvoicing.Show();

                    // Show minimized form
                    if (_frmInvoicing.WindowState == FormWindowState.Minimized)
                    {
                        _frmInvoicing.Focus();
                        _frmInvoicing.WindowState = FormWindowState.Normal;
                    }
                }
                else
                {
                    _frmInvoicing = new FormBillingManager(this);
                }

                _frmInvoicing.LoadClients();
                _frmInvoicing.BringToFront();
                _frmInvoicing.Show();
            }
            else if (rtabIndex == 5) // User Profile
            {
                FormUserProfile frm = (FormUserProfile)getFormByName("FormUserProfile");

                if (frm == null)
                {
                    frm = new FormUserProfile(this);
                    frm.TopLevel = false;
                    frm.Dock = DockStyle.Fill;
                    pnlContentDisplay.Controls.Add(frm);
                    formList.Add(frm);
                }

                hideAllForm("FormUserProfile");

                if (prevActiveTab != rtabIndex)
                {
                    UserApiRepository userApi = new UserApiRepository();

                    using (new HourGlass())
                    {
                        CURRENT_USER = userApi.Find(CURRENT_USER.UserId.Id);
                    }

                    using (MemoryStream memoryStream = new MemoryStream(CURRENT_USER.Avatar))
                    {
                        Image originalImage = Image.FromStream(memoryStream);
                        Image resizedImage = frm.ResizeImage(originalImage, new Size(80, 53), true);

                        rbtnMyProfile.Image = resizedImage;
                    }

                    frm.BringToFront();
                    frm.Show();
                }
                SetAppCount();
            }
            else if (rtabIndex == 6)
            {
                hideAllForm();
                SetAppCount();
            }
            else if (rtabIndex == 7)
            {
                hideAllForm();
                SetAppCount();
            }


            prevActiveTab = rtabIndex;
        }

        #endregion RibbonTab General

        #region RibbonTab AutoDocument

        private void rbtnAutoDoc_Click(object sender, EventArgs e)
        {
            Form form = getFormByName("FormDocumentsMenu");
            if (form == null)
            {
                form = new FormDocumentsMenu();
                form.TopLevel = false;
                this.Controls.Add(form);
                formList.Add(form);
            }
            form.Location = new Point(rpnlAutoDoc.Bounds.X + 12, rpnlAutoDoc.Bounds.Y + 108);
            form.StartPosition = FormStartPosition.Manual;
            hideAllForm();
            form.BringToFront();
            form.Show();
        }

        private void rbtnAutoReport_Click(object sender, EventArgs e)
        {
            Form form = getFormByName("FormReportsMenu");
            if (form == null)
            {
                form = new FormReportsMenu();
                form.TopLevel = false;
                this.Controls.Add(form);
                formList.Add(form);
            }
            form.Location = new Point(rpnlAutoDoc.Bounds.X + 112, rpnlAutoDoc.Bounds.Y + 108);
            form.StartPosition = FormStartPosition.Manual;
            hideAllForm();
            form.BringToFront();
            form.Show();
        }

        private void rbtnEditTimecard_Click(object sender, EventArgs e)
        {
            Form form = getFormByName("FormTimecard");
            if (form == null)
            {
                form = new FormTimecard(this);
                form.Dock = DockStyle.Fill;
                form.TopLevel = false;
                pnlContentDisplay.Controls.Add(form);
                formList.Add(form);
            }
            hideAllForm();
            form.BringToFront();
            form.Show();
        }

        private void rbtnCustomChart_Click(object sender, EventArgs e)
        {
            Form form = getFormByName("FormCustomChart");
            if (form == null)
            {
                form = new FormCustomChart();
                form.Dock = DockStyle.Fill;
                form.TopLevel = false;
                pnlContentDisplay.Controls.Add(form);
                formList.Add(form);
            }
            hideAllForm();
            form.BringToFront();
            form.Show();
        }

        private void rbtnCommonChart_Click(object sender, EventArgs e)
        {
            Form form = getFormByName("FormCommonChart");
            if (form == null)
            {
                form = new FormCommonChart();
                form.Dock = DockStyle.Fill;
                form.TopLevel = false;
                pnlContentDisplay.Controls.Add(form);
                formList.Add(form);
            }
            hideAllForm();
            form.BringToFront();
            form.Show();
        }

        private void rbtnCreditReports_Click(object sender, EventArgs e)
        {
            Form form = getFormByName("FormCreditReport");
            if (form == null)
            {
                form = new FormCreditReport();
                form.Dock = DockStyle.Fill;
                form.TopLevel = false;
                pnlContentDisplay.Controls.Add(form);
                formList.Add(form);
            }
            hideAllForm();
            form.BringToFront();
            form.Show();
        }

        #endregion RibbonTab AutoDocument

        #region RibbonTab InfoResources

        private void rbtnDocLib_Click(object sender, EventArgs e)
        {
            this.rbtnDocLib.Checked = true;
            this.rbtnLandlordContact.Checked = false;
            this.rbtnCriminalInfo.Checked = false;
            this.rbtnEmployment.Checked = false;

            OpenInfoResourceForm(InfoResourceType.Document);
        }
        
        private void OpenInfoResourceForm(InfoResourceType type)
        {
            _frmInfoResources = (_frmInfoResources != null) ? _frmInfoResources : null;
            if (_frmInfoResources != null && !_frmInfoResources.IsDisposed)
            {
                _frmInfoResources.Show();
            }
            else
            {
                _frmInfoResources = new FormInfoResources(this);
            }

            _frmInfoResources.CurrentType = type;
            _frmInfoResources.LoadData();
            _frmInfoResources.BringToFront();
            _frmInfoResources.Show();            
        }

        #endregion RibbonTab InfoResources

        #region RibbonTab Invoicing

        private void rbtnSearchApplications_Click(object sender, EventArgs e)
        {
            FormInvSearchApps form = (FormInvSearchApps)getFormByName("FormInvSearchApps");
            if (form == null)
            {
                FormBillingManager formBillingManager = (FormBillingManager)getFormByName("FormBillingManager");
                if (formBillingManager == null)
                {
                    return;
                }

                form = new FormInvSearchApps(formBillingManager);
                form.TopLevel = false;
                this.Controls.Add(form);
                formList.Add(form);

                form.OnSearchApps += new EventHandler<List<AppData>>(delegate(object delegateSender, List<AppData> data)
                {
                    formBillingManager.SetOLVApplications(data, null);
                });
            }
            if (!form.Visible)
            {
                form.Location = new Point(rpnlSearchInvoices.Bounds.X + 103, rpnlSearchInvoices.Bounds.Y + 108);
                form.StartPosition = FormStartPosition.Manual;
                form.BringToFront();
                form.Show();
            }
            else
            {
                form.Hide();
            }
        }

        public void rbtnSearchInvoices_Click(object sender, EventArgs e)
        {
            FormSearchInvs form = (FormSearchInvs)getFormByName("FormSearchInvs");
            if (form == null)
            {
                FormBillingManager formBillingManager = (FormBillingManager)getFormByName("FormBillingManager");
                if (formBillingManager == null)
                {
                    return;
                }

                form = new FormSearchInvs(formBillingManager);
                form.TopLevel = false;
                this.Controls.Add(form);
                formList.Add(form);

                form.OnSearchInvoices += new EventHandler<List<InvoiceData>>(delegate(object delegateSender, List<InvoiceData> data)
                {
                    formBillingManager.SetOLVInvoices(data, null);
                });
            }
            if (!form.Visible)
            {
                form.Location = new Point(rpnlSearchInvoices.Bounds.X + 12, rpnlSearchInvoices.Bounds.Y + 108);
                form.StartPosition = FormStartPosition.Manual;
                form.BringToFront();
                form.Show();
            }
            else
            {
                form.Hide();
            }
        }

        private void rbtnBillingMonth_DoubleClick(object sender, EventArgs e)
        {
            this.rbtnBillingMonth.CloseDropDown();

            FormBillingManager formBillingManager = (FormBillingManager)getFormByName("FormBillingManager");
            if (formBillingManager == null)
            {
                return;
            }

            FormAutomaticBilling form = new FormAutomaticBilling(formBillingManager);
            form.StartPosition = FormStartPosition.CenterParent;
            form.BringToFront();
            form.ShowDialog();
        }

        #endregion RibbonTab Invoicing

        #region RibbonTab UserManager

        private void rbtnMyProfile_Click(object sender, EventArgs e)
        {
            Form frmUserProf = getFormByName("FormUserProfile");

            if (frmUserProf == null)
            {
                frmUserProf = new FormUserProfile(this);
                frmUserProf.TopLevel = false;
                frmUserProf.Dock = DockStyle.Fill;
                pnlContentDisplay.Controls.Add(frmUserProf);
                formList.Add(frmUserProf);
            }
            hideAllForm();
            frmUserProf.BringToFront();
            frmUserProf.Show();
        }

        private void rbtnUserMgt_Click(object sender, EventArgs e)
        {
            Form frmUserMgm = getFormByName("FormUserManager");

            if (frmUserMgm == null)
            {
                frmUserMgm = new FormUserManager(this);
                frmUserMgm.TopLevel = false;
                frmUserMgm.Dock = DockStyle.Fill;
                pnlContentDisplay.Controls.Add(frmUserMgm);
                formList.Add(frmUserMgm);
            }
            hideAllForm();
            frmUserMgm.BringToFront();
            frmUserMgm.Show();
        }

        private void rbtnRoleMgt_Click(object sender, EventArgs e)
        {
            Form frmRoleMgm = getFormByName("FormRoleMgm");

            if (frmRoleMgm == null)
            {
                frmRoleMgm = new FormRoleMgm(this);
                frmRoleMgm.TopLevel = false;
                frmRoleMgm.Dock = DockStyle.Fill;
                pnlContentDisplay.Controls.Add(frmRoleMgm);
                formList.Add(frmRoleMgm);
            }
            hideAllForm();
            frmRoleMgm.BringToFront();
            frmRoleMgm.Show();
        }

        private void rbtnSaveUser_Click(object sender, EventArgs e)
        {
            FormUserManager formUserMgm = (FormUserManager)getFormByName("FormUserManager");
            FormRoleMgm formRole = (FormRoleMgm)getFormByName("FormRoleMgm");
            FormUserProfile formUserProfile = (FormUserProfile)getFormByName("FormUserProfile");

            if (formUserMgm != null && formUserMgm.Visible)
            {
                using (new HourGlass())
                {
                    formUserMgm.UpdateUser();
                }
            }
            else if (formRole != null && formRole.Visible)
            {
                using (new HourGlass())
                {
                    formRole.UpdateRole();
                }
            }
            else if (formUserProfile != null && formUserProfile.Visible)
            {
                using (new HourGlass())
                {
                    formUserProfile.UpdateUser();
                }
            }
        }

        #endregion UserManager

        #region RibbonTab ClientInfo

        private void rbtnSearchClient_Click(object sender, EventArgs e)
        {
            Form form = getFormByName("FormSearchClient");
            FormClientInfo formClientInfo = (FormClientInfo)getFormByName("FormClientInfo");
            if (form == null)
            {
                form = new FormSearchClient();
                formList.Add(form);

                if (formClientInfo != null)
                {
                    (form as FormSearchClient).OnSearchClient += new EventHandler<List<string>>(delegate(object delegateSender, List<string> data)
                    {
                        formClientInfo.SetClientOlv(data);
                    });
                }
            }

            if (formClientInfo != null)
            {
                ClientCachedApiQuery clientCacheApi = ClientCachedApiQuery.Instance;
                (form as FormSearchClient).ClientData = clientCacheApi.GetAllClients();
            }

            form.StartPosition = FormStartPosition.CenterParent;
            form.BringToFront();
            form.ShowDialog();
        }

        private void rbtnEditClientPrice_Click(object sender, EventArgs e)
        {
            FormClientInfo formClientInfo = (FormClientInfo)getFormByName("FormClientInfo");
            if (formClientInfo == null)
            {
                return;
            }

            ClientData selectedClient = formClientInfo.GetSelectedClient();
            if (selectedClient == null)
            {
                MessageBox.Show("Please select client to edit Special Prices.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FormClientEditSpecialPrice form = new FormClientEditSpecialPrice(selectedClient);
            form.OnEditSpecialPrices += new EventHandler<ClientData>(delegate(object delegateSender, ClientData data)
            {
                formClientInfo.OnEditSpecialPricesCompletedHandler(data);
            });
            form.StartPosition = FormStartPosition.CenterParent;
            form.BringToFront();
            form.ShowDialog();
        }

        private void rbtnCreateClient_Click(object sender, EventArgs e)
        {
            FormClientInfo form = (FormClientInfo)getFormByName("FormClientInfo");
            form.ShowFormAddNewClient();
        }

        private void rbtnDeleteClient_Click(object sender, EventArgs e)
        {
            FormClientInfo form = (FormClientInfo)getFormByName("FormClientInfo");
            form.DeleteClient();
        }

        private void rbtnSaveClient_Click(object sender, EventArgs e)
        {
            FormClientInfo formClientInfo = (FormClientInfo)getFormByName("FormClientInfo");

            if (formClientInfo != null)
            {
                using (new HourGlass())
                {
                    formClientInfo.SaveClient();
                }
            }
        }

        private void rbtnForClient_Click(object sender, EventArgs e)
        {
            FormClientInfo form = (FormClientInfo)getFormByName("FormClientInfo");
            List<ClientData> clients = form.GetListSelectedClients();
            List<string> clientIds = new List<string>();
            foreach (ClientData client in clients)
            {
                clientIds.Add(client.ClientId);
            }
            ShowAppsByClients(clientIds);
        }

        private void rbtnForShownClient_Click(object sender, EventArgs e)
        {
            FormClientInfo form = (FormClientInfo)getFormByName("FormClientInfo");
            List<ClientData> clients = form.GetShownClients();
            List<string> clientIds = new List<string>();
            foreach (ClientData client in clients)
            {
                clientIds.Add(client.ClientId);
            }
            ShowAppsByClients(clientIds);
        }

        private void rbtnNotForClient_Click(object sender, EventArgs e)
        {
            FormClientInfo form = (FormClientInfo)getFormByName("FormClientInfo");
            List<ClientData> clients = form.GetNotShownClients();
            List<string> clientIds = new List<string>();
            foreach (ClientData client in clients)
            {
                clientIds.Add(client.ClientId);
            }
            ShowAppsByClients(clientIds);
        }

        public void ShowAppsByClients(List<string> clientIds)
        {
            SearchAppCommand command = new SearchAppCommand();
            command.ClientIds = clientIds;
            this.ribbon.ActiveTab = this.rtabExploreApps;
            using (new HourGlass())
            {
                FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
                form.SearchApp(command);
            }
        }

        #endregion RibbonTab ClientInfo

        #region RibbonTab Administration

        private void rbtnReportMgt_Click(object sender, EventArgs e)
        {
            Form formReportsManagement = getFormByName("FormReportsManagement");

            if (formReportsManagement == null)
            {
                formReportsManagement = new FormReportsManagement(this);
                formReportsManagement.TopLevel = false;
                formReportsManagement.Dock = DockStyle.Fill;
                pnlContentDisplay.Controls.Add(formReportsManagement);
                formList.Add(formReportsManagement);
            }

            SetStandardTemplatesButtonsVisible(false);

            formReportsManagement.BringToFront();
            formReportsManagement.Show();
        }

        private void rbtnStandardTemp_Click(object sender, EventArgs e)
        {
            Form formStandardTemplates = getFormByName("FormStandardTemplates");

            if (formStandardTemplates == null)
            {
                formStandardTemplates = new FormStandardTemplates();
                formStandardTemplates.TopLevel = false;
                formStandardTemplates.Dock = DockStyle.Fill;
                pnlContentDisplay.Controls.Add(formStandardTemplates);
                formList.Add(formStandardTemplates);
            }

            SetStandardTemplatesButtonsVisible(true);

            formStandardTemplates.BringToFront();
            formStandardTemplates.Show();
        }

        private void rbtnInternetTool_Click(object sender, EventArgs e)
        {
            Form formInternetTools = getFormByName("FormInternetTools");

            if (formInternetTools == null)
            {
                formInternetTools = new FormInternetTools(this);
                formInternetTools.TopLevel = false;
                formInternetTools.Dock = DockStyle.Fill;
                pnlContentDisplay.Controls.Add(formInternetTools);
                formList.Add(formInternetTools);
            }

            SetStandardTemplatesButtonsVisible(false);

            formInternetTools.BringToFront();
            formInternetTools.Show();
        }

        private void rbtnTemplateCreate_Click(object sender, EventArgs e)
        {
            Form formStandardTemplates = getFormByName("FormStandardTemplates");

            if (formStandardTemplates != null)
            {
                ((FormStandardTemplates)formStandardTemplates).AddNewTemplate();
            }
        }

        private void rbtnTemplateDelete_Click(object sender, EventArgs e)
        {
            Form formStandardTemplates = getFormByName("FormStandardTemplates");

            if (formStandardTemplates != null)
            {
                ((FormStandardTemplates)formStandardTemplates).DeleteTemplate();
            }
        }

        private void rbtnTemplateSave_Click(object sender, EventArgs e)
        {
            Form formStandardTemplates = getFormByName("FormStandardTemplates");

            if (formStandardTemplates != null)
            {
                ((FormStandardTemplates)formStandardTemplates).SaveTemplate();
            }
        }

        #endregion RibbonTab Administration

        #region Data Grid Events
        private void rbtnDatagridSelectedClients_Click(object sender, EventArgs e)
        {
            try
            {
                FormClientInfo form = (FormClientInfo)getFormByName("FormClientInfo");
                if (form != null)
                {
                    List<string> clientIds = form.GetListSelectedClientIds();
                    FormClientDataGrid formClientDataGrid = new FormClientDataGrid(clientIds);
                    formClientDataGrid.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }

        private void rbtnDatagridAllShownClients_Click(object sender, EventArgs e)
        {
            try
            {
                FormClientDataGrid formClientDataGrid = new FormClientDataGrid();
                formClientDataGrid.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }

        private void rbtnDatagridSelectedApps_Click(object sender, EventArgs e)
        {
            try
            {
                FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
                if (form != null)
                {
                    List<AppData> apps = form.GetListSelectedApps();
                    if (_frmAppDataGrid.IsDisposed)
                    {
                        _frmAppDataGrid = new FormAppDataGrid();
                    }
                    _frmAppDataGrid.SetApps(apps);
                    _frmAppDataGrid.BringToFront();
                    _frmAppDataGrid.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }

        private void rbtnDatagridAllApps_Click(object sender, EventArgs e)
        {
            try
            {
                FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
                if (form != null)
                {
                    List<AppData> apps = form.GetListAllApps();
                    if (_frmAppDataGrid.IsDisposed)
                    {
                        _frmAppDataGrid = new FormAppDataGrid();
                    }
                    _frmAppDataGrid.SetApps(apps);
                    _frmAppDataGrid.BringToFront();
                    _frmAppDataGrid.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }

        private void rbtnApplication_Click(object sender, EventArgs e)
        {
            Form frm = getFormByName("FormAppDatagrid");

            if (frm == null)
            {
                frm = new FormAppDatagrid();
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                pnlContentDisplay.Controls.Add(frm);
                formList.Add(frm);
            }

            hideAllForm();
            frm.BringToFront();
            frm.Show();
        }

        private void rbtnClients_Click(object sender, EventArgs e)
        {
            Form frm = getFormByName("FormClientDatagrid");

            if (frm == null)
            {
                frm = new FormClientDatagrid();
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                pnlContentDisplay.Controls.Add(frm);
                formList.Add(frm);
            }

            hideAllForm();
            frm.BringToFront();

            frm.Show();

            //frm.WindowState = FormWindowState.Maximized;
        }

        private void rbtnInvoices_Click(object sender, EventArgs e)
        {
            Form frm = getFormByName("FormInvoiceDatagrid");

            if (frm == null)
            {
                frm = new FormInvoiceDatagrid();
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                pnlContentDisplay.Controls.Add(frm);
                formList.Add(frm);
            }

            hideAllForm();
            frm.BringToFront();
            frm.Show();
        }

        #endregion Data Grid Events

        #region Common Print Events

        public void CommonPrintDocument(WordDocumentType documentType, ClientData data)
        {
            DocumentCompleteResult result = null;
            WordDocumentBuilder wordDocumentBuilder = new WordDocumentBuilder();
            if (documentType == WordDocumentType.ClientInfo)
            {
                result = wordDocumentBuilder.BuildClientInfoDocument(documentType, data);
            }
            else if (documentType == WordDocumentType.ResidentialContract ||
                documentType == WordDocumentType.EmploymentContract)
            {
                result = wordDocumentBuilder.BuildContractDocument(documentType, data);
            }
            if (result != null)
            {
                result.PrintWordDocument(1);
                result.QuitWordDocument(false);
            }
        }

        private void rbtnCommonPrint_Click(object sender, EventArgs e)
        {
            RibbonButton button = sender as System.Windows.Forms.RibbonButton;
            WordDocumentType documentType = WordDocumentType.ClientInfo;
            if (button == rbtnCommonPrintClientInfo)
            {
                documentType = WordDocumentType.ClientInfo;
            }
            else if (button == rbtnCommonPrintResContract)
            {
                documentType = WordDocumentType.ResidentialContract;
            }
            else if (button == rbtnCommonPrintEmpContract)
            {
                documentType = WordDocumentType.EmploymentContract;
            }
            try
            {
                FormClientInfo form = (FormClientInfo)getFormByName("FormClientInfo");
                if (form != null)
                {
                    List<ClientData> clients = form.GetListSelectedClients();
                    using (new HourGlass())
                    {
                        foreach (ClientData client in clients)
                        {
                            CommonPrintDocument(documentType, client);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Common Print Events

        #region Email Events
        private void rbtnEmailSelectedClients_Click(object sender, EventArgs e)
        {
            FormClientInfo form = (FormClientInfo)getFormByName("FormClientInfo");
            if (form != null)
            {
                List<ClientData> clients = form.GetListSelectedClients();
                form.SendCustomerServiceEmailToClients(clients);
            }
        }

        private void rbtnEmailAllShownClients_Click(object sender, EventArgs e)
        {
            FormClientInfo form = (FormClientInfo)getFormByName("FormClientInfo");
            if (form != null)
            {
                List<ClientData> clients = form.GetListAllClients();
                form.SendCustomerServiceEmailToClients(clients);
            }
        }
        #endregion Email Events

        #region Print Covers Events

        private DocumentCompleteResult PrintCover(WordDocumentType docType)
        {
            using (new HourGlass())
            {
                ClientCachedApiQuery clientCachedApiQuery = ClientCachedApiQuery.Instance;
                ReportTypeCachedApiQuery reportTypeCachedApiQuery = ReportTypeCachedApiQuery.Instance;
                FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
                if (form != null && form.Visible)
                {
                    AppData app = form.GetSelectedApp();
                    if (app != null)
                    {
                        ClientData client = clientCachedApiQuery.GetClient(app.ClientApplied);
                        ReportTypeData reportType = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);
                        TemplateHelper templateHelper = new TemplateHelper();
                        User user = this.CURRENT_USER;
                        string templateName = WordTemplatePathResolver.GetTemplateFileName(docType);
                        string savePath = WordTemplatePathResolver.GetWordTemplatePath(docType);

                        templateHelper.DownloadTemplate(savePath, templateName);

                        if (!string.IsNullOrEmpty(savePath))
                        {
                            WordService word = new WordService(savePath, null, false);
                            Word.Application applicationInstance = word.GetApplicationInstance();
                            Word.Document documentInstance = word.GetDocumentInstance();
                            AppReportDocumentBuilder.Cover(applicationInstance, app, client, reportType, user, docType);
                            DocumentCompleteResult result = new DocumentCompleteResult(null, word, string.Empty);
                            return result;
                        }
                    }
                }
            }
            return null;
        }

        private void PrintSelectedFileCoverPages(List<AppData> apps)
        {
            DocumentCompleteResult result = null;
            ClientCachedApiQuery clientCachedApiQuery = ClientCachedApiQuery.Instance;
            ReportTypeCachedApiQuery reportTypeCachedApiQuery = ReportTypeCachedApiQuery.Instance;
            LocationData location = this.CurrentLocation;
            if (location.LocationId == Core.Domain.Model.ExploreApps.Location.NewApps.LocationId ||
                location.LocationId == Core.Domain.Model.ExploreApps.Location.Pickup.LocationId ||
                location.LocationName == "Clerical")
            {
                apps.Sort((x, y) => DateTime.Compare(x.ReceivedDate.Value, y.ReceivedDate.Value));
            }

            if (apps.Count == 0)
                return;

            try
            {
                WordDocumentType docType = WordDocumentType.FileCoverPage;

                WordService word = new WordService();
                Word.Application wordApplication = word.GetApplicationInstance();

                TemplateHelper templateHelper = new TemplateHelper();
                string filename = WordTemplatePathResolver.GetTemplateFileName(docType);
                if (!string.IsNullOrEmpty(filename))
                {
                    string url = string.Format("api/templates");
                    string savePath = WordTemplatePathResolver.GetWordTemplatePath(docType);
                    templateHelper.DownloadTemplate(savePath, filename);
                }

                string templatePath = WordTemplatePathResolver.GetWordTemplatePath(docType);

                if (!File.Exists(templatePath))
                {
                    return;
                }

                foreach (AppData app in apps)
                {
                    ClientData client = clientCachedApiQuery.GetClient(app.ClientApplied);
                    ReportTypeData reportType = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);
                    AppReportDocumentBuilder.FileCover(wordApplication, app, client, reportType);
                }

                result = new DocumentCompleteResult(null, word, "File Cover Pages");
                if (result != null)
                {
                    result.PrintWordDocument(1);
                    result.QuitWordDocument(false);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result != null)
                {
                    result.QuitWordDocument(false);
                }
            }
        }

        private void PrintFileCoverPages(AppData app, ReportTypeData reportType)
        {
            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
                return;

            string receivedDate = app.ReceivedDate.HasValue ? app.ReceivedDate.Value.ToString("M/d/yy") : "";
            string applicantName = Utils.GetApplicantName(app, reportType);
            string reportTypeName = reportType.AbsoluteTypeName;
        }

        private void rbtnRentalCover_Click(object sender, EventArgs e)
        {
            DocumentCompleteResult result = null;
            WordDocumentType docType = WordDocumentType.RentalCover;
            try
            {
                result = PrintCover(docType);
                if (result != null)
                    result.SetWordDocumentVisible(true);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result != null)
                {
                    result.QuitWordDocument(false);
                }
            }
        }

        private void rbtnEmpVerCover_Click(object sender, EventArgs e)
        {
            DocumentCompleteResult result = null;
            WordDocumentType docType = WordDocumentType.EmpVerCover;
            try
            {
                result = PrintCover(docType);
                if (result != null)
                    result.SetWordDocumentVisible(true);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                if (result != null)
                {
                    result.QuitWordDocument(false);
                }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbtnCriminalCover_Click(object sender, EventArgs e)
        {
            DocumentCompleteResult result = null;
            WordDocumentType docType = WordDocumentType.CrimCover;
            try
            {
                result = PrintCover(docType);
                if (result != null)
                    result.SetWordDocumentVisible(true);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                if (result != null)
                {
                    result.QuitWordDocument(false);
                }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbtnGenericCover_Click(object sender, EventArgs e)
        {
            DocumentCompleteResult result = null;
            WordDocumentType docType = WordDocumentType.GenericCover;
            try
            {
                result = PrintCover(docType);
                if (result != null)
                    result.SetWordDocumentVisible(true);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                if (result != null)
                {
                    result.QuitWordDocument(false);
                }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbtnCreditRefCover_Click(object sender, EventArgs e)
        {
            DocumentCompleteResult result = null;
            WordDocumentType docType = WordDocumentType.CredRefCover;
            try
            {
                result = PrintCover(docType);
                if (result != null)
                    result.SetWordDocumentVisible(true);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                if (result != null)
                {
                    result.QuitWordDocument(false);
                }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbtnBankCover_Click(object sender, EventArgs e)
        {
            DocumentCompleteResult result = null;
            WordDocumentType docType = WordDocumentType.BankRefCover;
            try
            {
                result = PrintCover(docType);
                if (result != null)
                    result.SetWordDocumentVisible(true);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                if (result != null)
                {
                    result.QuitWordDocument(false);
                }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbtnClientUpdate_Click(object sender, EventArgs e)
        {
            DocumentCompleteResult result = null;
            WordDocumentType docType = WordDocumentType.ClientUpdate;
            try
            {
                result = PrintCover(docType);
                if (result != null)
                    result.SetWordDocumentVisible(true);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                if (result != null)
                {
                    result.QuitWordDocument(false);
                }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbtnEmpRefCover_Click(object sender, EventArgs e)
        {
            DocumentCompleteResult result = null;
            WordDocumentType docType = WordDocumentType.EmpRefCover;
            try
            {
                result = PrintCover(docType);
                if (result != null)
                    result.SetWordDocumentVisible(true);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                if (result != null)
                {
                    result.QuitWordDocument(false);
                }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbtnDegreeVerCover_Click(object sender, EventArgs e)
        {
            DocumentCompleteResult result = null;
            WordDocumentType docType = WordDocumentType.DegreeVerCover;
            try
            {
                result = PrintCover(docType);
                if (result != null)
                    result.SetWordDocumentVisible(true);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                if (result != null)
                {
                    result.QuitWordDocument(false);
                }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbtnPrintFileCoverPages_Click(object sender, EventArgs e)
        {
            try
            {
                List<AppData> lstSelectedApps = new List<AppData>();
                FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
                if (form != null && form.Visible)
                {
                    lstSelectedApps = form.GetListSelectedApps();
                    PrintSelectedFileCoverPages(lstSelectedApps);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbtnPrintConfirmPages_Click(object sender, EventArgs e)
        {
            try
            {
                List<AppData> lstSelectedApps = new List<AppData>();
                FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
                if (form != null && form.Visible)
                {
                    lstSelectedApps = form.GetListSelectedApps();
                    form.PrintConfirmations(lstSelectedApps);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void SetStandardTemplatesButtonsVisible(bool btnSave)
        {
            if (btnSave)
            {
                this.rpnlStandardTemplatesButtons.Visible = true;
                this.rbtnStandardTemplatesSave.Visible = true;
            }
            else
            {
                this.rpnlStandardTemplatesButtons.Visible = false;
                this.rbtnStandardTemplatesSave.Visible = false;
            }
        }

        public void SetAppExploreButtonsVisible(AppData app, ClientData client, ReportTypeData reportType)
        {
            if (client == null || string.IsNullOrEmpty(client.ClientId))
            {
                this.rbtnEmailReport.Visible = false;
                this.rbtnPrintReport.Visible = false;
                this.rbtnUploadReport.Visible = false;
                return;
            }

            // Print
            RibbonButton rbtnLocalPrint = new RibbonButton();
            rbtnLocalPrint.Text = "Print Selected Reports";
            rbtnLocalPrint.Click += rbtnLocalPrint_Click;
            // Upload
            RibbonButton rbtnLocalUpload = null;
            if (!string.IsNullOrEmpty(client.WebsiteDir))
            {
                rbtnLocalUpload = new RibbonButton();
                rbtnLocalUpload.Text = "Upload Selected Reports";
                rbtnLocalUpload.Click += rbtnLocalUpload_Click;
            }

            if (!string.IsNullOrEmpty(client.DefaultDeliverReportsTo))
            {
                this.rbtnEmailReport.DropDownItems.Clear();

                // Email to
                RibbonButton rbtnLocalEmailTo = new RibbonButton();
                rbtnLocalEmailTo.Text = "Email to: " + client.DefaultDeliverReportsTo;
                rbtnLocalEmailTo.Click += rbtnLocalEmailTo_Click;
                // Email
                RibbonButton rbtnLocalEmail = new RibbonButton();
                rbtnLocalEmail.Text = "Email Selected Reports";
                rbtnLocalEmail.Click += rbtnLocalEmail_Click;
                // Add buttons
                this.rbtnEmailReport.DropDownItems.Add(rbtnLocalEmailTo);
                this.rbtnEmailReport.DropDownItems.Add(rbtnLocalPrint);
                this.rbtnEmailReport.DropDownItems.Add(rbtnLocalEmail);
                if (rbtnLocalUpload != null)
                {
                    this.rbtnEmailReport.DropDownItems.Add(rbtnLocalUpload);
                }

                this.rbtnEmailReport.Visible = true;
                this.rbtnPrintReport.Visible = false;
            }
            else
            {
                this.rbtnPrintReport.DropDownItems.Clear();

                // Email
                RibbonButton rbtnLocalEmail = new RibbonButton();
                rbtnLocalEmail.Text = "Email Selected Reports";
                rbtnLocalEmail.Click += rbtnLocalEmail_Click;
                // Add buttons
                this.rbtnPrintReport.DropDownItems.Add(rbtnLocalPrint);
                this.rbtnPrintReport.DropDownItems.Add(rbtnLocalEmail);
                if (rbtnLocalUpload != null)
                {
                    this.rbtnPrintReport.DropDownItems.Add(rbtnLocalUpload);
                }

                this.rbtnPrintReport.Visible = true;
                this.rbtnEmailReport.Visible = false;
            }

            if (rbtnLocalUpload != null)
            {
                this.rbtnUploadReport.Visible = true;
            }
            else
            {
                this.rbtnUploadReport.Visible = false;
            }

            if (app != null && reportType != null)
            {
                rbtnPrintCoverSheet.Enabled = true;
                LocationData currentLocation = CurrentLocation;
                bool isResidential = (reportType.AbsoluteTypeName == GlobalConstants.Residential);
                bool isCommercial = (reportType.AbsoluteTypeName == GlobalConstants.Commercial);
                bool isCreditOnly = (reportType.AbsoluteTypeName == GlobalConstants.CreditOnly);
                bool isCrimminalOnly = (reportType.AbsoluteTypeName == GlobalConstants.CrimminalOnly);
                bool isCreditCrimminal = (reportType.AbsoluteTypeName == GlobalConstants.CreditCrimminal);
                bool isEmployment = (reportType.AbsoluteTypeName == GlobalConstants.Employment);

                rbtnEmpVerCover.Visible = (isResidential || isEmployment);
                rbtnEmpRefCover.Visible = isEmployment;
                rbtnCriminalCover.Visible = (isResidential || isEmployment || isCreditCrimminal || isCrimminalOnly);
                rbtnDegreeVerCover.Visible = isEmployment;
                rbtnBankCover.Visible = isCommercial || isResidential;
                rbtnCreditRefCover.Visible = isCommercial;
                rbtnPrintConfirmPages.Visible = true;
            }
            else
            {
                rbtnPrintCoverSheet.Enabled = false;
            }
        }

        void rbtnLocalUpload_Click(object sender, EventArgs e)
        {
            FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
            bool isUploaded = false;

            using (new HourGlass())
            {
                isUploaded = form.UploadMultiReports();
            }

            if (isUploaded)
            {
                MessageBox.Show("Upload reports completed!", "Upload Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void rbtnLocalPrint_Click(object sender, EventArgs e)
        {
            FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
            if (form != null)
            {
                List<AppData> apps = form.GetListSelectedApps();
                form.PrintAppsWithProgressDialog(apps);
            }
        }

        void rbtnLocalEmail_Click(object sender, EventArgs e)
        {
            FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
            if (form != null)
            {
                List<AppData> apps = form.GetListSelectedApps();
                form.EmailApps(apps);
            }
        }

        void rbtnLocalEmailTo_Click(object sender, EventArgs e)
        {
            FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
            if (form != null)
            {
                List<AppData> apps = form.GetListSelectedApps();
                form.EmailApps(apps);
            }
        }

        void rbtnBillingMonthSub_Click(object sender, EventArgs e)
        {
            RibbonButton rbtn = sender as RibbonButton;
            DateTime currentBillingMonth;
            if (rbtn == rbtnBillingMonthSub1)
            {
                currentBillingMonth = DateTime.Now;
            }
            else if (rbtn == rbtnBillingMonthSub2)
            {
                currentBillingMonth = DateTime.Now.AddMonths(-1);
            }
            else // rbtn == rbtnBillingMonthSub3
            {
                currentBillingMonth = DateTime.Now.AddMonths(-2);
            }
            rbtnBillingMonth.Text = "Billing: " + currentBillingMonth.ToString("MM/yy");
            FormBillingManager form = (FormBillingManager)getFormByName("FormBillingManager");
            if (form != null)
            {
                form.SetCurrentBillingMonth(currentBillingMonth);
            }
        }

        #region Login / Logout

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.LogOut();
            this.OnFormClosing(new FormClosingEventArgs(CloseReason.None, false));
        }

        private void LogOut()
        {
            UpdateTimeCardLogOutCommand command = new UpdateTimeCardLogOutCommand(CURRENT_USER.UserId.Id);
            TimeCardApiRepository tcApiRepository = new TimeCardApiRepository();
            tcApiRepository.UpdateDateCardWhenLogOut(command);
        }

        #endregion Login / Logout

        #region Check Permission

        private void CheckPermissionForRibbon()
        {
            User currentUser = this.CURRENT_USER;
            FeatureAuthorization featureAuth = new FeatureAuthorization();

            Role role = this.CURRENT_ROLE;

            if (role != null)
            {
                foreach (FeaturePermission item in role.FeaturePermissions)
                {
                    #region Auto Document

                    if (item.FeatureName == featureAuth.FeatureNameToString(FeatureName.Modue_AutoDocument))
                    {
                        if (!item.IsAllowed)
                        {
                            rtabAutoDocument.Visible = false;
                        }
                        else
                        {
                            rtabAutoDocument.Visible = true;
                        }
                    }

                    #endregion

                    #region Client info

                    if (item.FeatureName == featureAuth.FeatureNameToString(FeatureName.ViewClientInfo))
                    {
                        if (!item.IsAllowed)
                        {
                            rtabClientInfo.Visible = false;
                        }
                        else
                        {
                            rtabClientInfo.Visible = true;
                        }
                    }

                    if (item.FeatureName == featureAuth.FeatureNameToString(FeatureName.AddNewClient))
                    {
                        if (!item.IsAllowed)
                        {
                            rbtnCreateClient.Visible = false;
                        }
                        else
                        {
                            rbtnCreateClient.Visible = true;
                        }
                    }

                    if (item.FeatureName == featureAuth.FeatureNameToString(FeatureName.DeleteClient))
                    {
                        if (!item.IsAllowed)
                        {
                            rbtnDeleteClient.Visible = false;
                        }
                        else
                        {
                            rbtnDeleteClient.Visible = true;
                        }
                    }

                    if (!rbtnDeleteClient.Visible && !rbtnCreateClient.Visible)
                    {
                        rpnlCreateClient.Visible = false;
                    }

                    if (item.FeatureName == featureAuth.FeatureNameToString(FeatureName.EditSpecialPrice))
                    {
                        if (!item.IsAllowed)
                        {
                            rbtnEditClientPrice.Visible = false;
                            rpnlEditPrice.Visible = false;
                        }
                        else
                        {
                            rbtnEditClientPrice.Visible = true;
                            rpnlEditPrice.Visible = true;
                        }
                    }

                    #endregion

                    #region Explore Apps

                    if (item.FeatureName == featureAuth.FeatureNameToString(FeatureName.ViewExploreApp))
                    {
                        if (!item.IsAllowed)
                        {
                            rtabExploreApps.Visible = false;
                        }
                        else
                        {
                            rtabExploreApps.Visible = true;
                        }
                    }

                    #endregion Explore Apps

                    #region Info Resources

                    if (item.FeatureName == featureAuth.FeatureNameToString(FeatureName.ViewInfoResource))
                    {
                        if (!item.IsAllowed)
                        {
                            rtabInfoResources.Visible = false;
                        }
                        else
                        {
                            rtabInfoResources.Visible = true;
                        }
                    }

                    #endregion Info Resources

                    #region Invoicing

                    if (item.FeatureName == featureAuth.FeatureNameToString(FeatureName.Module_Invoicing))
                    {
                        if (!item.IsAllowed)
                        {
                            rtabInvoicing.Visible = false;
                        }
                        else
                        {
                            rtabInvoicing.Visible = true;
                        }
                    }

                    #endregion

                    #region User Manager

                    if (item.FeatureName == featureAuth.FeatureNameToString(FeatureName.Module_UserManager))
                    {
                        if (!item.IsAllowed)
                        {
                            rbtnUserMgt.Visible = false;
                            rbtnRoleMgt.Visible = false;
                            rpnlRoleMgt.Visible = false;
                            rbtnSaveUser.Visible = false;
                            rpnlBtnSaveUser.Visible = false;
                        }
                        else
                        {
                            rbtnUserMgt.Visible = true;
                            rbtnRoleMgt.Visible = true;
                            rpnlRoleMgt.Visible = true;
                            rbtnSaveUser.Visible = true;
                            rpnlBtnSaveUser.Visible = true;
                        }
                    }

                    #endregion

                    #region Administration

                    if (item.FeatureName == featureAuth.FeatureNameToString(FeatureName.Administration))
                    {
                        if (!item.IsAllowed)
                        {
                            rtabAdministration.Visible = false;
                        }
                        else
                        {
                            rtabAdministration.Visible = true;
                        }
                    }

                    #endregion
                }
            }
        }

        #endregion Check Permission

        private void FormMaster_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                User currentUser = this.CURRENT_USER;
                this.ribbon.ActiveTab = this.rtabExploreApps;
                CheckPermissionForRibbon();
                FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
                if (form != null)
                {
                    form.ChangeLocation(currentUser.UserId.Id);
                    CurrentLocation = new LocationData(currentUser.UserId.Id, currentUser.UserName);
                }
            }
        }

        #region App Explore Events

        private void rbtnCreateNewApp_Click(object sender, EventArgs e)
        {
            using (new HourGlass())
            {
                FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
                form.CreateNewApp();
            }
        }

        private void rbtnDeleteApp_Click(object sender, EventArgs e)
        {
            FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
            form.DeleteSelectedApp();
        }

        private void rbtnCopyApp_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to copy the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                using (new HourGlass())
                {
                    FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
                    form.CopySelectedApp();
                }
            }
        }

        private void rbtnMarkAppRoommates_Click(object sender, EventArgs e)
        {
            using (new HourGlass())
            {
                FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
                form.MarkAsRoommates();
            }
        }

        private void rbtnSaveApp_Click(object sender, EventArgs e)
        {
            FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
            form.SaveSelectedApp();
        }

        public void rbtnSearchApp_Click(object sender, EventArgs e)
        {
            if (_frmSearchApplications != null)
            {
                _frmSearchApplications.StartPosition = FormStartPosition.CenterParent;
                DialogResult result = _frmSearchApplications.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (_frmSearchApplications.ActiveTab == 0)
                    {
                        SearchAppCommand command = _frmSearchApplications.GetSearchCommand();
                        using (new HourGlass())
                        {
                            FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
                            form.SearchApp(command);
                        }
                    }
                    else if (_frmSearchApplications.ActiveTab == 1)
                    {
                        SimpleSearchAppCommand command = _frmSearchApplications.GetSimpleSearchCommand();
                        using (new HourGlass())
                        {
                            FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
                            form.SimpleSearchApp(command);
                        }
                    }
                    else
                    {
                        SearchAppCommand command = _frmSearchApplications.GetCustomSearchCommand();
                        using (new HourGlass())
                        {
                            FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
                            form.SearchApp(command);
                        }
                    }

                    Core.Domain.Model.ExploreApps.Location searchLocation = Core.Domain.Model.ExploreApps.Location.Search;
                    CurrentLocation = new LocationData(searchLocation.LocationId, searchLocation.LocationName);
                    InitializeButtonLocations();
                }
            }
        }

        private void rbtnGeoLookup_Click(object sender, EventArgs e)
        {
            if (_formZipCode != null && !_formZipCode.IsDisposed)
            {
                _formZipCode.Show();
            }
            else
            {
                _formZipCode = new FormZipCode();
                _formZipCode.Show();
            }
        }

        private void rbtnDesk_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                rbtnDesk.CloseDropDown();

                User user = CURRENT_USER;

                string currentLocationId = CurrentLocation.LocationId;
                string currentLocationName = CurrentLocation.LocationName;

                string newLocationId = user.UserId.Id;
                string newLocationName = user.UserName;

                LocationData newLocation = new LocationData(user.UserId.Id, user.UserName);

                if (newLocation.LocationId != CurrentLocation.LocationId)
                {
                    FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
                    form.ChangeLocation(newLocationId);
                    CurrentLocation = new LocationData(newLocationId, newLocationName);

                }
                InitializeButtonLocations();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbtnAppAction_DoubleClick(object sender, EventArgs e)
        {
            rbtnAppAction.CloseDropDown();
            FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
            form.CreateNewApp();
        }

        private void rbtnUploadReport_Click(object sender, EventArgs e)
        {
            FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");

            bool isUploaded = false;
            using (new HourGlass())
            {
                isUploaded = form.UploadMultiReports();
            }

            if (isUploaded)
            {
                MessageBox.Show("Upload reports completed!", "Upload Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void rbtnCheckCurrApp_Click(object sender, EventArgs e)
        {
            FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
            if (form != null)
            {
                form.CheckSpellingSelectedApp();
            }
        }

        private void rbtnCheckCurrTextBox_Click(object sender, EventArgs e)
        {
            FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
            if (form != null)
            {
                form.CheckSpellingCurrentTextBox();
            }
        }

       public void ViewAppExplore()
        {
            using (new HourGlass())
            {
                ribbon.ActiveTab = rtabExploreApps;
            }
        }

        public void EditApplicationFromInvoicing(AppData app)
        {
            Role role = CURRENT_ROLE;
            if (app == null || string.IsNullOrEmpty(app.ApplicationId) || !rtabExploreApps.Visible)
            {
                return;
            }
            using (new HourGlass())
            {
                AppData latestApp = new AppApiRepository().Find(app.ApplicationId);

                if (latestApp != null)
                {
                    if (!role.RoleName.Equals("Administrator") && latestApp.LocationId == Core.Domain.Model.ExploreApps.Location.Archive.LocationId)
                    {
                        MessageBox.Show("Application has been archived. You can not edit at this time.", "Action Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    ribbon.ActiveTab = rtabExploreApps;
                    FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");

                    if (latestApp.LocationId != Core.Domain.Model.ExploreApps.Location.Archive.LocationId)
                    {
                        form.ChangeLocation(latestApp.LocationId, latestApp);
                    }
                    else
                    {
                        form.ShowArchivedAppFromInvoice(latestApp);
                    }

                    this.BringToFront();
                }
            }
        }

        #endregion

        private void FormMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.LogOut();
        }

        private void rbtnSystemConfg_Click(object sender, EventArgs e)
        {
            Form formSysConfig = getFormByName("FormSysConfig");

            if (formSysConfig == null)
            {
                formSysConfig = new FormSysConfig(this);
                formSysConfig.TopLevel = false;
                formSysConfig.Dock = DockStyle.Fill;
                pnlContentDisplay.Controls.Add(formSysConfig);
                formList.Add(formSysConfig);
            }

            formSysConfig.BringToFront();
            formSysConfig.Show();
        }

        #region HOT KEYs

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F1:
                    rbtnHelp_Click(this, null);
                    return true;
            }

            #region Auto Document
            if (int.Parse(ribbon.ActiveTab.Value) == 0) // Auto Document
            {
                switch (keyData)
                {
                    case Keys.Alt | Keys.C:
                        this.rbtnCustomChart_Click(this, null);
                        return true;
                }
            }
            #endregion Auto Document

            #region Client Info

            else if (int.Parse(ribbon.ActiveTab.Value) == 1) // Client Info
            {
                FormClientInfo form = (FormClientInfo)getFormByName("FormClientInfo");

                if (form.RigthSectionIsFocused() && keyData == Keys.Delete)
                {
                    form.DeleteClient();
                }

                switch (keyData)
                {
                    case Keys.F5:
                        // Call Refresh and reload function

                        using (new HourGlass())
                        {
                            //RefreshAllDataAsync();
                            RefreshData();
                            form.RefreshData();
                        }
                        return true;
                    case Keys.Control | Keys.S:
                        using (new HourGlass())
                        {
                            form.SaveClient();
                        }
                        return true;
                    case Keys.Alt | Keys.U:
                        form.OpenFormMagement();
                        return true;
                    case Keys.Alt | Keys.S:
                        new FormSearchClient().btnCustomSQLQuery_Click(this, null);
                        return true;
                    case Keys.Alt | Keys.A:
                        form.ShowFormAddNewClient();
                        return true;
                }
            }
            #endregion Client Info

            #region Explore App
            else if (int.Parse(ribbon.ActiveTab.Value) == 2) // Explore App
            {
                FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");

                if (form.RigthSectionIsFocused() && keyData == Keys.Delete)
                {
                    form.DeleteSelectedApp();
                }

                switch (keyData)
                {
                    case Keys.Control | Keys.N:
                        using (new HourGlass())
                        {
                            form.CreateNewApp();
                        }
                        return true;
                    case Keys.Control | Keys.F:
                        using (new HourGlass())
                        {
                            rbtnSearchApp_Click(this, null);
                        }
                        return true;
                    case Keys.Control | Keys.A:
                        rbtnArchive_Click(this, null);
                        return true;
                    case Keys.Alt | Keys.A:
                        form.FocusToApplicationInfo();
                        return true;
                    case Keys.Alt | Keys.C:
                        form.FocusToCreditInfo();
                        return true;
                    case Keys.Alt | Keys.D:
                        form.DeleteItem();
                        return true;
                    case Keys.Alt | Keys.E:
                        form.FocusToEmploymentInfo();
                        return true;
                    case Keys.Alt | Keys.F:
                        form.FocusToFinalInfo();
                        return true;
                    case Keys.Alt | Keys.I:
                        form.FocusToCriminalEviction();
                        return true;
                    case Keys.Alt | Keys.N:
                        form.NewItem();
                        return true;
                    case Keys.Alt | Keys.M:
                        form.FocusToAppMenu();
                        return true;
                    case Keys.Alt | Keys.P:
                        form.EventAltP();
                        return true;
                    case Keys.Alt | Keys.R:
                        form.FocusToRentalInfo();
                        return true;
                    case Keys.Alt | Keys.S:
                        form.OpenStandardRef();
                        return true;
                    case Keys.Alt | Keys.T:
                        form.FocusToInternetTool();
                        return true;
                    case Keys.Alt | Keys.D1:
                        form.OpenVerifs1();
                        return true;
                    case Keys.Alt | Keys.D2:
                        form.OpenVerifs2();
                        return true;
                    case Keys.Control | Keys.P:
                        var newAppLocation = Core.Domain.Model.ExploreApps.Location.Pickup;
                        MoveToLocation(newAppLocation);
                        return true;
                    case Keys.Control | Keys.R:
                        FormChooseReviewLocationToMove formChooseReview = new FormChooseReviewLocationToMove();
                        DialogResult result = formChooseReview.ShowDialog();
                        if (result == DialogResult.Yes)
                        {
                            var reviewLocation = formChooseReview.ChoosenReviewLocation;
                            MoveToLocation(AutoMapper.Mapper.Map<LocationData, Core.Domain.Model.ExploreApps.Location>(reviewLocation));
                            formChooseReview.Close();
                        }
                        return true;
                    case Keys.Control | Keys.D:
                        form.CheckSpellingCurrentTextBox();
                        return true;
                    case Keys.F5:
                        using (new HourGlass())
                        {
                            form.RefreshDisplayedApps();
                        }
                        return true;
                    case Keys.Control | Keys.S:
                        form.SaveSelectedApp();
                        return true;

                }
            }
            #endregion Explore App

            #region Info Resource
            
            #endregion Info Resource

            #region Invoicing

            else if (int.Parse(ribbon.ActiveTab.Value) == 4) // Invoicing
            {
                FormBillingManager form = (FormBillingManager)getFormByName("FormBillingManager");
                switch (keyData)
                {
                    case Keys.F5:
                        using (new HourGlass())
                        {
                            this.RefreshData();
                            form.LoadClients();
                        }
                        return true;
                }
            }

            #endregion Invoicing

            #region User Management

            else if (int.Parse(ribbon.ActiveTab.Value) == 5) // user management
            {
                FormUserManager formUserMgt = (FormUserManager)getFormByName("FormUserManager");
                FormRoleMgm formRoleMgt = (FormRoleMgm)getFormByName("FormRoleMgm");

                switch (keyData)
                {
                    case Keys.F5:
                        if (formUserMgt.Visible)
                        {
                            using (new HourGlass())
                            {
                                RefreshAllDataAsync();
                                formUserMgt.RefreshData();
                            }
                        }
                        else if (formRoleMgt.Visible)
                        {
                            using (new HourGlass())
                            {
                                RefreshAllDataAsync();
                                formRoleMgt.RefreshData();
                            }
                        }

                        return true;
                    case Keys.Control | Keys.S:
                        if (formUserMgt.Visible)
                        {
                            using (new HourGlass())
                            {
                                formUserMgt.UpdateUser();
                            }
                        }
                        else if (formRoleMgt.Visible)
                        {
                            using (new HourGlass())
                            {
                                formRoleMgt.UpdateRole();
                            }
                        }
                        return true;
                }
            }

            #endregion User Management

            #region Administration

            else if (int.Parse(ribbon.ActiveTab.Value) == 7) // Administration
            {
                FormInternetTools formInternet = (FormInternetTools)getFormByName("FormInternetTools");

                FormReportsManagement formReportMgt = (FormReportsManagement)getFormByName("FormReportsManagement");

                switch (keyData)
                {
                    case Keys.F5:
                        if (formInternet != null && formInternet.Visible)
                        {
                            using (new HourGlass())
                            {
                                RefreshAllDataAsync();
                                formInternet.RefreshData();
                            }
                        }
                        else if (formReportMgt != null && formReportMgt.Visible)
                        {
                            using (new HourGlass())
                            {
                                RefreshAllDataAsync();
                                formReportMgt.LoadData(false, true);
                            }
                        }
                        return true;
                }
            }

            #endregion Administration

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion Keyboard Events

        private void MoveToLocation(Core.Domain.Model.ExploreApps.Location location)
        {
            string currentLocationId = CurrentLocation.LocationId;
            string currentLocationName = CurrentLocation.LocationName;

            string newLocationId = location.LocationId;
            string newLocationName = location.LocationName;

            LocationData newLocation = new LocationData(newLocationId, newLocationName);

            if (newLocation.LocationId != CurrentLocation.LocationId)
            {
                FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
                form.ChangeLocation(newLocationId);
                CurrentLocation = new LocationData(newLocationId, newLocationName);

            }
            InitializeButtonLocations();
        }

        #region Auto Save

        private void SaveAppAsync()
        {
            // App Explore
            FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
            if (form != null && form.Visible)
            {
                AppData app = form.GetSelectedApp();
                if (app == null)
                    return;

                if (form.currentLoadedApp == null || !form.currentLoadedApp.ApplicationId.Equals(app.ApplicationId))
                    return;

                if (app.LocationId != CURRENT_USER.UserId.Id &&
                    app.LocationId != Core.Domain.Model.ExploreApps.Location.Review1.LocationId &&
                    app.LocationId != Core.Domain.Model.ExploreApps.Location.Review2.LocationId &&
                    app.LocationId != Core.Domain.Model.ExploreApps.Location.Review3.LocationId &&
                    app.LocationId != Core.Domain.Model.ExploreApps.Location.NewApps.LocationId)
                    return;

                if (!form.IsAutoSaveAvailable())
                    return;

                ClientCachedApiQuery clientCachedApiQuery = ClientCachedApiQuery.Instance;
                ClientData client = clientCachedApiQuery.GetClient(app.ClientApplied);
                if (client.ClientRevoked)
                    return;

                form.SaveApp(app);
            }
        }

        private async void SaveClientAsync()
        {
            // Client
            FormClientInfo formClient = (FormClientInfo)getFormByName("FormClientInfo");
            if (formClient != null && formClient.Visible)
            {
                ClientData client = formClient.GetSelectedClient();

                if (client == null || client.ClientRevoked)
                    return;

                if (formClient.CurrentLoadedClient == null || formClient.CurrentLoadedClient.ClientId != client.ClientId)
                    return;

                formClient.GetClientDataFromForm(client);

                bool result = await formClient.SaveClientAsync(client);
            }
        }

        private async void SaveUserAsync()
        {
            // User Management
            FormUserManager formUserMgt = (FormUserManager)getFormByName("FormUserManager");
            if (formUserMgt != null && formUserMgt.Visible)
            {
                User user = formUserMgt.GetSelectedUser();

                if (formUserMgt.CurrentLoadedUser == null || user == null || formUserMgt.CurrentLoadedUser.UserId.Id != user.UserId.Id)
                    return;

                formUserMgt.SetUserValueFromControls(user);

                if (user == null)
                    return;

                bool result = await formUserMgt.SaveUserAsync(user);

                /*
                if (user != null)
                {
                    formUserMgt.SetUserControlDataValue(user);
                }
                 */
            }
        }

        #endregion

        #region Refresh Data

        private async void RefreshAllDataAsync()
        {
            try
            {
                using (await _mutex.LockAsync())
                {
                    await LoadDataAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        public Task LoadDataAsync()
        {
            return Task.Run(() =>
            {
                System.Threading.Thread.Sleep(100);

                // System Config
                LoadSysConfig();

                // Invoice
                LIST_APPS_FOR_INVOICE = GetAppsForInvoice();

                // Client Info
                ClientCachedApiQuery _clientCachedApiQuery = ClientCachedApiQuery.Instance;
                _clientCachedApiQuery.RemoveAllClients();
                LIST_CLIENTS = _clientCachedApiQuery.GetAllClients();
                if (LIST_CLIENTS == null)
                {
                    LIST_CLIENTS = new List<ClientData>();
                }

                _clientCachedApiQuery.RemoveAllInvoiceDivisions();
                LIST_INVOICE_DIVISIONS = _clientCachedApiQuery.GetAllInvoiceDivisions();
                if (LIST_INVOICE_DIVISIONS == null)
                {
                    LIST_INVOICE_DIVISIONS = new List<string>();
                }

                _clientCachedApiQuery.RemoveAllCustomerNumbers();
                LIST_CUSTOMER_NUMBERS = _clientCachedApiQuery.GetAllCustomerNumbers();
                if (LIST_CUSTOMER_NUMBERS == null)
                {
                    LIST_CUSTOMER_NUMBERS = new List<string>();
                }

                // User Management
                UserCachedApiQuery _userCachedApiQuery = UserCachedApiQuery.Instance;
                _userCachedApiQuery.RemoveAllUsers();
                LIST_USERS = _userCachedApiQuery.GetAllUsers();
                if (LIST_USERS == null)
                {
                    LIST_USERS = new List<User>();
                }

                // Info Resources
                InfoResourceCachedApiQuery infoResourceCachedApiQuery = InfoResourceCachedApiQuery.Instance;
                infoResourceCachedApiQuery.RemoveAllInfoResources();
                LIST_INFO_RESOURCES = infoResourceCachedApiQuery.GetAllResourceItems();
                if (LIST_INFO_RESOURCES == null)
                {
                    LIST_INFO_RESOURCES = new List<ResourceData>();
                }

                // Role Management
                RoleApiRepository _roleApiRepo = new RoleApiRepository();
                LIST_ROLES = _roleApiRepo.FindAll();
                if (LIST_ROLES == null)
                {
                    LIST_ROLES = new List<Role>();
                }

                // Report Management
                LIST_REPORT_TYPES = ReportTypeCachedApiQuery.Instance.GetAllReportTypes();
                if (LIST_REPORT_TYPES == null)
                {
                    LIST_REPORT_TYPES = new List<ReportTypeData>();
                }

                // Internet Tool
                InternetToolCachedApiQuery.Instance.RemoveAllInternetItems();
                LIST_INTERNET_TOOLS = InternetToolCachedApiQuery.Instance.GetAllInternetItems();
                if (LIST_INTERNET_TOOLS == null)
                {
                    LIST_INTERNET_TOOLS = new List<InternetItem>();
                }
            });
        }

        public void RefreshData()
        {
            ClientCachedApiQuery _clientCachedApiQuery = ClientCachedApiQuery.Instance;
            _clientCachedApiQuery.RemoveAllClients();
            LIST_CLIENTS = _clientCachedApiQuery.GetAllClients();
            if (LIST_CLIENTS == null)
            {
                LIST_CLIENTS = new List<ClientData>();
            }

            // User Management
            UserApiRepository _userApiRepo = new UserApiRepository();
            LIST_USERS = _userApiRepo.FindAll();
            if (LIST_USERS == null)
            {
                LIST_USERS = new List<User>();
            }

            // Info Resources
            InfoResourceCachedApiQuery infoResourceCachedApiQuery = InfoResourceCachedApiQuery.Instance;
            infoResourceCachedApiQuery.RemoveAllInfoResources();
            LIST_INFO_RESOURCES = infoResourceCachedApiQuery.GetAllResourceItems();
            if (LIST_INFO_RESOURCES == null)
            {
                LIST_INFO_RESOURCES = new List<ResourceData>();
            }

            // Role Management
            RoleApiRepository _roleApiRepo = new RoleApiRepository();
            LIST_ROLES = _roleApiRepo.FindAll();
            if (LIST_ROLES == null)
            {
                LIST_ROLES = new List<Role>();
            }

            // Report Management
            LIST_REPORT_TYPES = ReportTypeCachedApiQuery.Instance.GetAllReportTypes();
            if (LIST_REPORT_TYPES == null)
            {
                LIST_REPORT_TYPES = new List<ReportTypeData>();
            }

            // Internet Tool
            InternetToolCachedApiQuery.Instance.RemoveAllInternetItems();
            LIST_INTERNET_TOOLS = InternetToolCachedApiQuery.Instance.GetAllInternetItems();
            if (LIST_INTERNET_TOOLS == null)
            {
                LIST_INTERNET_TOOLS = new List<InternetItem>();
            }
        }

        public void RefreshClientData()
        {
            ClientCachedApiQuery _clientCachedApiQuery = ClientCachedApiQuery.Instance;
            _clientCachedApiQuery.RemoveAllClients();
            LIST_CLIENTS = _clientCachedApiQuery.GetAllClients();
            if (LIST_CLIENTS == null)
            {
                LIST_CLIENTS = new List<ClientData>();
            }
        }

        public void RefreshCacheActiveUsers()
        {
            UserApiRepository _userApiRepo = new UserApiRepository();

            UserCachedApiQuery _userCache = UserCachedApiQuery.Instance;

            LIST_ACTIVE_USERS = _userApiRepo.GetActiveUsers();
        }

        #endregion

        #region Data Updated Event Handlers
        internal void ClientUpdatedHandler(object sender, ClientUpdatedEventArgs e)
        {
            ClientData client = e.Client;
            ClientCachedApiQuery.Instance.SetClient(client);
            FormClientInfo frmClientInfo = getFormByName("FormClientInfo") as FormClientInfo;

            if (frmClientInfo != null)
            {
                frmClientInfo.RefreshClient(client);
            }
        }
        #endregion

        private void rbtnRefreshClient_Click(object sender, EventArgs e)
        {
            FormClientInfo form = (FormClientInfo)getFormByName("FormClientInfo");
            using (new HourGlass())
            {
                RefreshClientData();
                form.RefreshData();
            }
        }

        private void rbtnRefreshInfoResources_Click(object sender, EventArgs e)
        {
            FormInfoResources form = (FormInfoResources)getFormByName("FormInfoResources");
            using (new HourGlass())
            {
                RefreshData();
                form.LoadData();
            }
        }

        private void rbtnRefreshUserManager_Click(object sender, EventArgs e)
        {
            FormRoleMgm formRoleMgm = (FormRoleMgm)getFormByName("FormRoleMgm");
            FormUserManager formUserManager = (FormUserManager)getFormByName("FormUserManager");

            if (formRoleMgm != null || formUserManager != null)
            {
                using (new HourGlass())
                {
                    RefreshAllDataAsync();
                    if (formRoleMgm != null)
                    {
                        formRoleMgm.RefreshData();
                    }
                    if (formUserManager != null)
                    {
                        formUserManager.RefreshData();
                    }
                }
            }
        }

        private void rbtnRefreshAdministration_Click(object sender, EventArgs e)
        {
            FormInternetTools formInternet = (FormInternetTools)getFormByName("FormInternetTools");
            FormReportsManagement formReportMgt = (FormReportsManagement)getFormByName("FormReportsManagement");

            if (formInternet != null || formReportMgt != null)
            {
                using (new HourGlass())
                {
                    RefreshAllDataAsync();
                    if (formInternet != null)
                    {
                        formInternet.RefreshData();
                    }
                    if (formReportMgt != null)
                    {
                        formReportMgt.LoadData(false, true);
                    }
                }
            }
        }

        private void rbtnRefreshApp_Click(object sender, EventArgs e)
        {
            FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");

            if (form != null)
            {
                using (new HourGlass())
                {
                    form.RefreshDisplayedApps();
                }
            }
        }

        private void rbtnAbout_Click(object sender, System.EventArgs e)
        {
            FormAbout form = new FormAbout();
            form.Show();
        }

        private void rbtnHelp_Click(object sender, System.EventArgs e)
        {
            string helperUri = ConfigurationManager.AppSettings["Helper.Uri"].ToString();
            System.Diagnostics.Process.Start(helperUri);
        }

        #region Caching Application for Invoice

        private List<AppData> GetAppsForInvoice()
        {
            List<AppData> allApps = new List<AppData>();
            try
            {
                AppApiRepository appApiRepository = new AppApiRepository();
                InvoiceApiRepository invApiRepository = new InvoiceApiRepository();

                InvSearchAppCommand commandLast3Month = new InvSearchAppCommand();

                DateTime currDateInUtc = DateTime.UtcNow;
                DateTime dateInLast3Month = currDateInUtc.AddMonths(-3);

                commandLast3Month.ReceivedFrom
                    = new DateTime(dateInLast3Month.Year,
                        dateInLast3Month.Month,
                        1,
                        0, 0, 0);
                commandLast3Month.ReceivedTo
                    = new DateTime(currDateInUtc.Year,
                        currDateInUtc.Month,
                        DateTime.DaysInMonth(currDateInUtc.Year, currDateInUtc.Month),
                        23, 59, 59);

                List<AppData> appsInLast3Month = appApiRepository.InvSearchApp(commandLast3Month);
                if (appsInLast3Month != null && appsInLast3Month.Count > 0)
                {
                    allApps.AddRange(appsInLast3Month);
                }

                DateTime latestInvoiceDateInUtc = invApiRepository.FindMaxInvoiceDate();
                if (latestInvoiceDateInUtc < commandLast3Month.ReceivedFrom)
                {
                    InvSearchAppCommand commandLatestInvoiceDate = new InvSearchAppCommand();

                    commandLatestInvoiceDate.ReceivedFrom
                        = new DateTime(latestInvoiceDateInUtc.Year,
                            latestInvoiceDateInUtc.Month,
                            1,
                            0, 0, 0);
                    commandLatestInvoiceDate.ReceivedTo
                        = new DateTime(latestInvoiceDateInUtc.Year,
                            latestInvoiceDateInUtc.Month,
                            DateTime.DaysInMonth(latestInvoiceDateInUtc.Year, latestInvoiceDateInUtc.Month),
                            23, 59, 59);

                    List<AppData> appsLatestInvoiceDate = appApiRepository.InvSearchApp(commandLatestInvoiceDate);

                    if (appsLatestInvoiceDate != null && appsLatestInvoiceDate.Count > 0)
                    {
                        allApps.AddRange(appsLatestInvoiceDate);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            return allApps;
        }

        #endregion

        public void RemoveAppFromInvoicing(AppData app)
        {
            try
            {
                FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");

                AppData latestApp = new AppApiRepository().Find(app.ApplicationId);

                if (latestApp != null)
                {
                    if (latestApp.LocationId == Core.Domain.Model.ExploreApps.Location.Archive.LocationId)
                    {
                        MessageBox.Show("Application has been archived. You can not delete at this time.", "Action Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (MessageBox.Show(string.Format("Are you sure to delete application '{0}, {1}' and its associated credit reports?", app.FirstName, app.LastName), "Delete Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        form.RemoveAppFromOtherForm(app);
                        AppCachedApiQuery.Instance.Remove(latestApp.ApplicationId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SetAppCount(string message = "")
        {
            if (string.IsNullOrEmpty(message))
            {
                sttlblCount.Text = "No Apps. In View";
            }
            else
            {
                sttlblCount.Text = message;
            }
        }

        #region Context Menu
        private void rbtnDgAllClients_Click(object sender, EventArgs e)
        {
            try
            {
                FormClientDataGrid formClientDataGrid = new FormClientDataGrid();
                formClientDataGrid.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }

        private void rbtnDgSelectedClients_Click(object sender, EventArgs e)
        {
            FormBillingManager form = (FormBillingManager)getFormByName("FormBillingManager");

            if (form != null)
            {
                List<string> selectClients = form.GetListSelectedClient();
                FormClientDataGrid formClientDataGrid = new FormClientDataGrid(selectClients);
                formClientDataGrid.Show();
            }
        }

        private void rbtnDgSelectedApps_Click(object sender, EventArgs e)
        {
            FormBillingManager form = (FormBillingManager)getFormByName("FormBillingManager");

            if (form != null)
            {
                List<AppData> apps = form.GetListSelectedApps();

                if (_frmAppDataGrid.IsDisposed)
                {
                    _frmAppDataGrid = new FormAppDataGrid();
                }
                _frmAppDataGrid.SetApps(apps);
                _frmAppDataGrid.BringToFront();
                _frmAppDataGrid.Show();
            }
        }

        private void rbtnDgAllShownApps_Click(object sender, EventArgs e)
        {
            try
            {
                FormBillingManager form = (FormBillingManager)getFormByName("FormBillingManager");
                if (form != null)
                {
                    List<AppData> apps = form.GetListAllApps();
                    if (_frmAppDataGrid.IsDisposed)
                    {
                        _frmAppDataGrid = new FormAppDataGrid();
                    }
                    _frmAppDataGrid.SetApps(apps);
                    _frmAppDataGrid.BringToFront();
                    _frmAppDataGrid.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }

        private void rbtnDgAllShownInvoices_Click(object sender, EventArgs e)
        {
            try
            {
                FormBillingManager form = (FormBillingManager)getFormByName("FormBillingManager");
                FormInvDatagrid formDatagrid = new FormInvDatagrid();

                if (form != null)
                {
                    List<InvoiceData> invs = form.GetListAllInvoices();

                    formDatagrid.SetInvs(invs);
                    formDatagrid.BringToFront();
                    formDatagrid.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }

        private void rbtnDgSelectedInvoices_Click(object sender, EventArgs e)
        {
            try
            {
                FormBillingManager form = (FormBillingManager)getFormByName("FormBillingManager");
                FormInvDatagrid formDatagrid = new FormInvDatagrid();

                if (form != null)
                {
                    List<InvoiceData> invs = form.GetListSelectedInvs();

                    formDatagrid.SetInvs(invs);
                    formDatagrid.BringToFront();
                    formDatagrid.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }



        #endregion

        #region Print Invoices
        private void rbtnPrtClientCommon_Click(object sender, EventArgs e)
        {
            RibbonButton button = sender as System.Windows.Forms.RibbonButton;
            WordDocumentType documentType = WordDocumentType.ClientInfo;
            if (button == rbtnPrtClientInfoSheet)
            {
                documentType = WordDocumentType.ClientInfo;
            }
            else if (button == rbtnPrtResidentClienCtact)
            {
                documentType = WordDocumentType.ResidentialContract;
            }
            else if (button == rbtnPrtEmpServCtact)
            {
                documentType = WordDocumentType.EmploymentContract;
            }
            try
            {
                FormBillingManager form = (FormBillingManager)getFormByName("FormBillingManager");
                if (form != null)
                {
                    List<ClientData> clients = form.GetListSelectedClients();
                    using (new HourGlass())
                    {
                        foreach (ClientData client in clients)
                        {
                            CommonPrintDocument(documentType, client);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbtnPrtSelectedInvs_Click(object sender, EventArgs e)
        {
            FormBillingManager form = (FormBillingManager)getFormByName("FormBillingManager");
            if (form != null)
            {
                List<InvoiceData> invoices = form.GetListSelectedInvs();
                form.PrintInvoices(invoices);
            }
        }


        private void rbtnPrtAllShownInvs_Click(object sender, EventArgs e)
        {
            FormBillingManager form = (FormBillingManager)getFormByName("FormBillingManager");
            if (form != null)
            {
                List<InvoiceData> invoices = form.GetListAllInvoices();
                form.PrintInvoices(invoices);
            }
        }

        private void rbtnPrtSelectedInvoices_Click(object sender, EventArgs e)
        {
            FormBillingManager form = (FormBillingManager)getFormByName("FormBillingManager");
            if (form != null)
            {
                List<ClientData> clients = form.GetListSelectedClients();
                form.PrintInvoicesByClientsPastDue(clients);
            }
        }

        private void rbtnPrtAllInvoices_Click(object sender, EventArgs e)
        {
            FormBillingManager form = (FormBillingManager)getFormByName("FormBillingManager");
            if (form != null)
            {
                form.PrintInvoicesByClientsPastDue(null);
            }
        }


        private void rbtnRefreshInvoice_Click(object sender, EventArgs e)
        {
            FormBillingManager frmInvoice = (FormBillingManager)getFormByName("FormBillingManager");

            if (frmInvoice != null)
            {
                using (new HourGlass())
                {
                    this.RefreshData();
                    frmInvoice.LoadClients();
                }
            }
        }

        private void rbtnInvoicePrintMenu_DoubleClick(object sender, EventArgs e)
        {
            rbtnInvoicePrintMenu.CloseDropDown();
            FormBillingManager frmInvoice = (FormBillingManager)getFormByName("FormBillingManager");

            if (frmInvoice != null)
            {
                FormInvShipping formInvShipping = new FormInvShipping(frmInvoice);
                formInvShipping.StartPosition = FormStartPosition.CenterParent;
                formInvShipping.BringToFront();
                formInvShipping.ShowDialog();
            }
        }

        #endregion

        #region EventBus Events

        private void EditAppsEventHandler(List<string> applicationIds)
        {
            FormAppExplore form = (FormAppExplore)getFormByName("FormAppExplore");
            if (applicationIds == null)
                return;

            form.ShowApps(applicationIds);
            Core.Domain.Model.ExploreApps.Location searchLocation = Core.Domain.Model.ExploreApps.Location.Search;
            CurrentLocation = new LocationData(searchLocation.LocationId, searchLocation.LocationName);
            InitializeButtonLocations();
            this.BringToFront();
            ViewAppExplore();
        }
        #endregion        
    }
}