using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Application.Data.ExploreApps;
using Core.Application.Data.ClientInfo;
using Core.Infrastructure.ClientInfo;
using IdentityAccess.Infrastructure.Identity;
using IdentityAccess.Domain.Model.Identity;
using Core.Domain.Model.ExploreApps;
using IdentityAccess.CommonType;
using System.IO;
using Common.Application;
using PaaApplication.Models.AppExplore;
using PaaApplication.Models.Common;
using Common.Infrastructure.Office;
using Word = NetOffice.WordApi;
using PaaApplication.Helper;
using Core.Infrastructure.ExploreApps;
using PaaApplication.Forms.AppExplore;
using ImageComboBox;
using Common.Infrastructure.ComboBoxCustom;
using PaaApplication.Forms;
using PaaApplication.Models.ClientInfo;

namespace PaaApplication.UserControls.AppExplore.GeneralInfo
{
    public partial class AppMenuControl : UserControl
    {
        List<ContactAttemptTypeData> _contactAttemptTypes = new List<ContactAttemptTypeData>();
        List<ContactAttemptData> _contactAttempts = new List<ContactAttemptData>();

        private int _currentIndexContactsAttemp = -1;
        private LocationData _currentLocationBeforeChange;
        private ScreenerData _currentScreenerBeforeChange;

        List<ClientData> _clients;
        List<ReportTypeData> _reportTypes;

       public FormMaster FormMaster { get; set; }

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public DateTime? CompletedDate
        {
            get
            {
                if (dtpCompletedDate.Visible) return dtpCompletedDate.Value;
                return null;
            }
            set
            {
                if (value == null)
                {
                    dtpCompletedDate.Visible = false;
                    btnInProcessTest.Visible = true;
                    btnInProcessTest.Text = "(In-Process)";
                }
                else
                {
                    btnInProcessTest.Visible = false;
                    dtpCompletedDate.Visible = true;
                    dtpCompletedDate.Value = (DateTime)value;
                }
            }
        }

        public string ClientBillingInfo
        {
            get;
            set;
        }

        public TextBox CommentControl
        {
            get { return txtComment; }
        }

        public TabControl TabControl
        {
            get { return tabAppContact; }
        }

        public TabPage TabPageContactsControl
        {
            get { return tabContacts; }
        }

        public TabPage TabPageAppInfoControl
        {
            get { return tabAppInfo; }
        }

        public EventHandler<PrintAppEventArgs> PrintAppReports;
        public EventHandler<MoveLocationEventArgs> MoveLocation;
        public EventHandler<MoveScreenerEventArgs> MoveScreener;
        public EventHandler<EventArgs> ReviewComment;
        public EventHandler<EventArgs> GotoAppClick;
        public EventHandler<EventArgs> CompleteAppClick;
        public EventHandler<EventArgs> MarkCompleteClick;
        public EventHandler<EventArgs> MarkInProcessClick;        
        public EventHandler<InvoiceDivisionChangedEventArgs> InvoiceDivisionChanged;
        public EventHandler<ClientUpdatedEventArgs> ClientUpdated;

        public bool hasArchivePermission;

        public AppMenuControl()
        {
            InitializeComponent();
            this.cmbPrintOptions.SelectedIndex = 1;
            // Hide temporarily
            TabControl.TabPages.Remove(this.tabContacts);

            btnCompleteTest.FlatAppearance.MouseOverBackColor = btnCompleteTest.BackColor;
            btnCompleteTest.BackColorChanged += (s, e) => {
                btnCompleteTest.FlatAppearance.MouseOverBackColor = btnCompleteTest.BackColor;
            };

            btnCompleteTest.DoubleClick += new EventHandler(btnCompleteTest_DoubleClick);

            btnInProcessTest.FlatAppearance.MouseOverBackColor = btnInProcessTest.BackColor;
            btnInProcessTest.BackColorChanged += (s, e) => {
                btnInProcessTest.FlatAppearance.MouseOverBackColor = btnInProcessTest.BackColor;
            };

            btnInProcessTest.DoubleClick += new EventHandler(lblCompl_DoubleClick);
        }

        private List<LocationData> GetAllLocations()
        {
            List<LocationData> _locations = new List<LocationData>();
            List<User> _users = UserCachedApiQuery.Instance.GetActiveUsers();
            _locations.AddRange(LocationData.PreDefineLocations());
            foreach (User user in _users)
            {
                LocationData location = new LocationData(user.UserId.Id, user.UserName);
                _locations.Add(location);
            }
            return _locations;
        }

        private List<ScreenerData> GetAllScreeners()
        {
            List<ScreenerData> _screeners = new List<ScreenerData>();
            List<User> _users = UserCachedApiQuery.Instance.GetActiveUsers();

            foreach (User user in _users)
            {
                ScreenerData screener = new ScreenerData();
                screener.ScreenerId = user.UserId.Id;
                screener.ScreenerName = user.UserName;
                _screeners.Add(screener);
            }
            return _screeners;
        }

        private Image LookupScreenerAvatar(string screenerId)
        {
            UserCachedApiQuery userCachedApiQuery = UserCachedApiQuery.Instance;
            List<User> _users = userCachedApiQuery.GetAllUsers();
            User user = _users.Find(u => u.UserId.Id == screenerId);
            if (user != null && user.Avatar != null)
            {
                using (var ms = new MemoryStream(user.Avatar))
                {
                    return Image.FromStream(ms);
                }
            }
            else
            {
                return PaaApplication.Properties.Resources.user;
            }
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

        public void SetContactAttemptTypes(List<ContactAttemptTypeData> contactAttemptTypes)
        {
            this._contactAttemptTypes = contactAttemptTypes;
        }

        public DateTime? GetReceivedDate()
        {
            return dtpReceivedDate.Value.ToUniversalTime();
        }

        public void SetReceivedDate(DateTime? receivedDate)
        {
            DateTime received = receivedDate ?? DateTime.UtcNow;
            dtpReceivedDate.Value = received.ToLocalTime();
        }

        public List<ContactAttemptData> GetContactAttempts()
        {
            SaveCurrentContactAttemp();
            return this._contactAttempts;
        }

        public void SetContactAttempts(List<ContactAttemptData> contactAttempts)
        {
            this._contactAttempts = contactAttempts;
        }

        public ContactAttemptData GetCurrentContactAttempt()
        {
            if (cmbAttempt.SelectedItem == null) return null;

            ContactAttemptData contactAttempt = new ContactAttemptData();
            ContactAttemptTypeData contactAttempType = (ContactAttemptTypeData)cmbAttempt.SelectedItem;

            contactAttempt.ContactAttemptType = contactAttempType;
            contactAttempt.ReturnedOrResolved = chboxReturned.Checked;
            contactAttempt.Recipient = txtOtherAddr.Text;
            contactAttempt.PhoneFaxEmail = txtPhoneFax.Text;
            contactAttempt.Note = txtComment.Text;

            return contactAttempt;
        }

        public void SetCurrentContactAttempt(ContactAttemptData contactAttempt)
        {
            cmbAttempt.SelectedIndex = cmbAttempt.FindStringExact(contactAttempt.ContactAttemptType.DisplayName);
            chboxReturned.Checked = contactAttempt.ReturnedOrResolved;
            txtOtherAddr.Text = contactAttempt.Recipient;
            txtPhoneFax.Text = contactAttempt.PhoneFaxEmail;
            txtComment.Text = contactAttempt.Note;
        }

        public string GetCurrentReportTypeId()
        {
            return cmbReportType.SelectedValue.ToString();
        }

        public void ResetControls()
        {
            cmbAttempt.SelectedIndex = -1;
            cmbAttempt.Items.Clear();            
            cmbReportType.DataSource = null;
            chboxReturned.Checked = false;
            txtOtherAddr.Text = "";
            txtPhoneFax.Text = "";
            txtComment.Text = "";
            btnInProcessTest.Text = "";
            btnReviewComm.Enabled = false;
            btnCompleteApp.Enabled = false;
            btnGoto.Enabled = false;
            dtpReceivedDate.Value = DateTime.Now;
            cmbReportType.DisplayMember = "TypeName";
            cmbReportType.ValueMember = "ReportTypeId";
            btnReviewComm.Enabled = false;
            btnGoto.Enabled = false;
            btnCompleteApp.Enabled = false;
            olvReportList.ClearObjects();
            dtpReceivedDate.Checked = false;
            dtpCompletedDate.Checked = false;
            cmbLocation.SelectedIndex = -1;
            cmbSceener.SelectedIndex = -1;
            cmbSceener.EditBoxClear();
            cmbLocation.EditBoxClear();
            cmbLocation.Text = string.Empty;
            cmbSceener.Text = string.Empty;
            _currentScreenerBeforeChange = null;
        }        

        public void UpdateReportTypeClientChanged(string clientId)
        {
            if (!string.IsNullOrEmpty(clientId))
            {
                ClientCachedApiQuery clientCachedApiQuery = ClientCachedApiQuery.Instance;
                ClientData client = clientCachedApiQuery.GetClient(clientId);
                ReportTypeCachedApiQuery reportTypeCachedApiQuery = ReportTypeCachedApiQuery.Instance;

                if (FormMaster == null)
                {
                    _reportTypes = reportTypeCachedApiQuery.GetAllReportTypes();
                }
                else
                {
                    _reportTypes = FormMaster.LIST_REPORT_TYPES;
                }

                cmbReportType.DataSource = _reportTypes;
                if (!string.IsNullOrEmpty(client.DefaultReportTypeId))
                {
                    foreach (ReportTypeData reportType in _reportTypes)
                    {
                        if (reportType.ReportTypeId == client.DefaultReportTypeId)
                        {
                            cmbReportType.SelectedItem = reportType;
                            break;
                        }
                    }
                }
                else
                {
                    ReportTypeData res1ReportType = _reportTypes.Find(r => r.TypeName == GlobalConstants.DefaultReportTypeName);
                    cmbReportType.SelectedItem = res1ReportType;

                }
            }
        }

        public void UpdateControlsFromApp(AppData app)
        {
            ResetControls();

            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                return;
            }

            ClientCachedApiQuery clientCachedApiQuery = ClientCachedApiQuery.Instance;
            ReportTypeCachedApiQuery reportTypeCachedApiQuery = ReportTypeCachedApiQuery.Instance;

            List<ClientData> _clients;
            List<ReportTypeData> _reportTypes;
            if (FormMaster == null)
            {
                _clients = clientCachedApiQuery.GetAllClients();
                _reportTypes = reportTypeCachedApiQuery.GetAllReportTypes();
            }
            else
            {
                _clients = FormMaster.LIST_CLIENTS;
                _reportTypes = FormMaster.LIST_REPORT_TYPES;
            }

            List<LocationData> _locations = this.GetAllLocations();
            List<ScreenerData> _screeners = this.GetAllScreeners();
            Core.Domain.Model.ExploreApps.Location archiveLocation = Core.Domain.Model.ExploreApps.Location.Archive;

            if (!this.hasArchivePermission)
            {
                if (app.LocationId == archiveLocation.LocationId)
                {
                    cmbLocation.Enabled = false;
                    dtpCompletedDate.Enabled = false;
                }
                else
                {
                    cmbLocation.Enabled = true;
                    dtpCompletedDate.Enabled = false;
                    _locations.RemoveAll(l => l.LocationId == archiveLocation.LocationId);
                }
            }
            else
            {
                cmbLocation.Enabled = true;
                dtpCompletedDate.Enabled = true;
            }

            cmbReportType.DataSource = _reportTypes;
            locationImageList.Images.Clear();
            screenerImageList.Images.Clear();
            cmbSceener.ComboBoxClear();
            cmbLocation.ComboBoxClear();
            foreach (LocationData location in _locations)
            {
                locationImageList.Images.Add(location.LocationId, this.LookupLocationImage(location.LocationId));
            }
            foreach (LocationData location in _locations)
            {
                ImageComboBoxItem item = new ImageComboBoxItem();
                var index = locationImageList.Images.IndexOfKey(location.LocationId);
                item.Image = index.ToString();
                item.Text = location.LocationName;
                item.Item = location.LocationId;
                cmbLocation.Items.Add(item);
            }
            foreach (ScreenerData screener in _screeners)
            {
                screenerImageList.Images.Add(screener.ScreenerId, this.LookupScreenerAvatar(screener.ScreenerId));
            }
            foreach (ScreenerData screener in _screeners)
            {
                ImageComboBoxItem item = new ImageComboBoxItem();
                var index = screenerImageList.Images.IndexOfKey(screener.ScreenerId);
                item.Image = index.ToString();
                item.Text = screener.ScreenerName;
                item.Item = screener.ScreenerId;
                cmbSceener.Items.Add(item);
            }
            cmbLocation.ImageList = locationImageList;
            cmbSceener.ImageList = screenerImageList;

            if (!string.IsNullOrEmpty(app.ReportTypeId))
            {
                foreach (ReportTypeData reportType in _reportTypes)
                {
                    if (reportType.ReportTypeId == app.ReportTypeId)
                    {
                        cmbReportType.SelectedItem = reportType;
                        break;
                    }
                }
            }            

            if (!string.IsNullOrEmpty(app.LocationId))
            {
                LocationData location = _locations.Find(l => l.LocationId == app.LocationId);
                ReviewCommentApiRepository reviewCommApiReposiroty = new ReviewCommentApiRepository();
                ReviewComment reviewComment = reviewCommApiReposiroty.Find(app.ApplicationId);

                if (location != null)
                {
                    ImageComboBoxItem selectedItem = cmbLocation.Items.Cast<ImageComboBoxItem>().SingleOrDefault(i => i.Item == location.LocationId);
                    cmbLocation.SelectedItem = selectedItem;
                    if (location.LocationId == Core.Domain.Model.ExploreApps.Location.NewApps.LocationId)
                    {
                        if (reviewComment != null && !string.IsNullOrEmpty(reviewComment.Comment))
                        {
                            string rtfString = reviewComment.Comment;
                            string plainText = ConvertRftToPlainText(rtfString);

                            if (!string.IsNullOrEmpty(plainText))
                            {
                                btnReviewComm.Enabled = true;
                            }
                            else
                            {
                                btnReviewComm.Enabled = false;
                            }
                        }
                        else
                        {
                            btnReviewComm.Enabled = false;
                        }

                        btnGoto.Enabled = true;
                        btnGoto.Text = "Move To Pickup";
                        btnCompleteApp.Enabled = true;
                        btnCompleteApp.Text = "Pull Credit Menu";
                    }
                    else if (location.LocationId == Core.Domain.Model.ExploreApps.Location.Pickup.LocationId)
                    {
                        if (reviewComment != null && !string.IsNullOrEmpty(reviewComment.Comment))
                        {
                            string rtfString = reviewComment.Comment;
                            string plainText = ConvertRftToPlainText(rtfString);

                            if (!string.IsNullOrEmpty(plainText))
                            {
                                btnReviewComm.Enabled = true;
                            }
                            else
                            {
                                btnReviewComm.Enabled = false;
                            }
                        }
                        else
                        {
                            btnReviewComm.Enabled = false;
                        }

                        btnGoto.Enabled = true;
                        btnGoto.Text = "Go To My Desk";
                        btnCompleteApp.Enabled = true;
                        btnCompleteApp.Text = "Pickup App(s)";
                    }
                    else if (location.LocationId == Core.Domain.Model.ExploreApps.Location.Review1.LocationId ||
                            location.LocationId == Core.Domain.Model.ExploreApps.Location.Review2.LocationId ||
                            location.LocationId == Core.Domain.Model.ExploreApps.Location.Review3.LocationId)
                    {
                        if (hasArchivePermission)
                            btnCompleteApp.Enabled = true;
                        else
                            btnCompleteApp.Enabled = false;

                        btnReviewComm.Enabled = true;
                        btnGoto.Enabled = true;

                        btnGoto.Text = "Return App(s)";
                        btnCompleteApp.Text = "Archive App(s)";
                    }
                    else if (location.LocationId == Core.Domain.Model.ExploreApps.Location.Archive.LocationId)
                    {
                        if (reviewComment != null && !string.IsNullOrEmpty(reviewComment.Comment))
                        {
                            string rtfString = reviewComment.Comment;
                            string plainText = ConvertRftToPlainText(rtfString);

                            if (!string.IsNullOrEmpty(plainText))
                            {
                                btnReviewComm.Enabled = true;
                            }
                            else
                            {
                                btnReviewComm.Enabled = false;
                            }
                        }
                        else
                        {
                            btnReviewComm.Enabled = false;
                        }

                        btnCompleteApp.Enabled = false;
                        btnGoto.Enabled = false;
                        btnCompleteApp.Text = "";
                        btnGoto.Text = "";
                    }
                    else
                    {
                        if (reviewComment != null && !string.IsNullOrEmpty(reviewComment.Comment))
                        {
                            string rtfString = reviewComment.Comment;
                            string plainText = ConvertRftToPlainText(rtfString);

                            if (!string.IsNullOrEmpty(plainText))
                            {
                                btnReviewComm.Enabled = true;
                            }
                            else
                            {
                                btnReviewComm.Enabled = false;
                            }
                        }
                        else
                        {
                            btnReviewComm.Enabled = false;
                        }

                        btnGoto.Enabled = true;
                        btnGoto.Text = "Move To Pickup";
                        btnCompleteApp.Enabled = true;
                        btnCompleteApp.Text = "Complete App(s)";
                    }
                }
                else
                {
                    cmbLocation.Text = string.Empty;
                    cmbLocation.SelectedIndex = -1;
                }
            }

            if (!string.IsNullOrEmpty(app.ScreenerId))
            {
                ScreenerData screener = _screeners.Find(s => s.ScreenerId == app.ScreenerId);

                if (screener != null)
                {
                    ImageComboBoxItem selectedItem = cmbSceener.Items.Cast<ImageComboBoxItem>().SingleOrDefault(i => i.Item == screener.ScreenerId);
                    cmbSceener.SelectedItem = selectedItem;
                }
                else
                {
                    cmbSceener.SelectedIndex = -1;
                    cmbSceener.Text = app.ScreenerName;
                }
            }

            if (app.CompletedDate == null)
            {
                btnInProcessTest.Visible = true;
                dtpCompletedDate.Visible = false;
                btnInProcessTest.Text = "(In-Process)";
            }
            else
            {
                DateTime completedDateUtc = app.CompletedDate ?? DateTime.UtcNow;
                dtpCompletedDate.Value = completedDateUtc.ToLocalTime();
                dtpCompletedDate.Visible = true;
                btnInProcessTest.Visible = false;
            }

            SetReceivedDate(app.ReceivedDate);
            SetContactAttempts(app.ContactAttempts);

            if (_contactAttempts == null || _contactAttempts.Count == 0)
            {
                DisableContactsAttemp();
            }
            else
            {
                EnableContactsAttemp();
            }
            FillDataToControlsAtFirst(_contactAttempts);

            UpdatePrintingReportsFromApps(app);
        }

        public void UpdateAppFromControls(AppData app)
        {
            try
            {
                if (app == null || string.IsNullOrEmpty(app.ApplicationId))
                {
                    return;
                }

                app.ReceivedDate = GetReceivedDate();
                app.ContactAttempts = GetContactAttempts();
                app.ReportTypeId = (cmbReportType.SelectedItem as ReportTypeData).ReportTypeId;
                app.ReportTypeName = (cmbReportType.SelectedItem as ReportTypeData).TypeName;

                if (dtpCompletedDate.Visible)
                {
                    app.CompletedDate = dtpCompletedDate.Value.ToUniversalTime();
                }

                ImageComboBoxItem screenerItem = cmbSceener.SelectedItem as ImageComboBoxItem;
                if (screenerItem != null)
                {
                    app.ScreenerId = screenerItem.Item.ToString();
                    app.ScreenerName = screenerItem.Text;
                }

                ImageComboBoxItem locationItem = cmbLocation.SelectedItem as ImageComboBoxItem;
                LocationData location = (cmbLocation.SelectedItem as LocationData);
                if (locationItem != null)
                {
                    app.LocationId = locationItem.ToString();
                    app.LocationName = locationItem.Text;
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        #region Get Report Items


        private void UpdatePrintingReportsFromApps(AppData app)
        {
            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                return;
            }

            ReportTypeCachedApiQuery reportTypeCachedApiQuery = ReportTypeCachedApiQuery.Instance;
            ReportTypeData currentReportType = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);

            List<AppReportItem> lstReportItems = AppReportItem.GetAppReportItems(app, currentReportType);

            olvReportList.SetObjects(lstReportItems);
        }

        #endregion;

        //contacts attemp

        private void LoadContactAttempType()
        {
            cmbAttempt.DisplayMember = "DisplayName";
            cmbAttempt.ValueMember = "Value";

            if (cmbAttempt.Items.Count > 0) return;

            IEnumerable<ContactAttemptType> contactAttemptTypes = ContactAttemptType.GetAll<ContactAttemptType>();
            List<ContactAttemptTypeData> lstContactAttemptTypes = new List<ContactAttemptTypeData>();

            foreach (ContactAttemptType contactType in contactAttemptTypes)
            {
                cmbAttempt.Items.Add(AutoMapper.Mapper.Map<ContactAttemptType, ContactAttemptTypeData>(contactType));
            }
        }

        private void EnableContactsAttemp()
        {
            cmbAttempt.Enabled = true;
            chboxReturned.Enabled = true;
            txtOtherAddr.Enabled = true;
            txtPhoneFax.Enabled = true;
            txtComment.Enabled = true;
        }

        private void DisableContactsAttemp()
        {
            cmbAttempt.Text = "";
            cmbAttempt.Enabled = false;
            chboxReturned.Enabled = false;
            txtOtherAddr.Enabled = false;
            txtPhoneFax.Enabled = false;
            txtComment.Enabled = false;
        }

        private void SetLabel(Label label, int index, int count)
        {
            label.Text = string.Format("{0}/{1}", index, count);
        }

        private void ResetContactsAttemp()
        {
            cmbAttempt.SelectedIndex = 2;
            chboxReturned.Checked = false;
            txtOtherAddr.Clear();
            txtPhoneFax.Clear();
            txtComment.Clear();
        }

        private void FillDataToControlsAtFirst(List<ContactAttemptData> contactsAttemp)
        {
            try
            {
                _currentIndexContactsAttemp = 0;
                LoadContactAttempType();

                if (contactsAttemp != null && contactsAttemp.Any())
                {
                    this.SetCurrentContactAttempt(contactsAttemp[0]);
                    SetLabel(lblContactAttemp, 1, contactsAttemp.Count);
                }
                else
                {
                    SetLabel(lblContactAttemp, 0, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
            }
        }

        private void SaveCurrentContactAttemp()
        {
            ContactAttemptData currentContact = GetCurrentContactAttempt();

            if (currentContact != null)
            {
                if (_contactAttempts.ElementAtOrDefault(_currentIndexContactsAttemp) != null)
                {
                    _contactAttempts[_currentIndexContactsAttemp] = currentContact;
                }
            }
        }

        #region UI Events

        private void btnNewAttempt_Click(object sender, EventArgs e)
        {
            try
            {
                SaveCurrentContactAttemp();

                if (_contactAttempts == null) _contactAttempts = new List<ContactAttemptData>();

                if (_contactAttempts.Count == 0)
                {
                    EnableContactsAttemp();
                    ContactAttemptData contact = new ContactAttemptData();
                    ContactAttemptTypeData contactType = AutoMapper.Mapper.Map<ContactAttemptType, ContactAttemptTypeData>(ContactAttemptType.RentalReference);
                    contact.ContactAttemptType = contactType;

                    _contactAttempts.Add(contact);
                    SetCurrentContactAttempt(contact);
                    _currentIndexContactsAttemp = _contactAttempts.Count - 1;
                    SetLabel(lblContactAttemp, _currentIndexContactsAttemp + 1, _contactAttempts.Count);
                }
                else
                {
                    ContactAttemptData contactData = new ContactAttemptData();
                    ContactAttemptTypeData contactType = AutoMapper.Mapper.Map<ContactAttemptType, ContactAttemptTypeData>(ContactAttemptType.RentalReference);
                    contactData.ContactAttemptType = contactType;
                    contactData.Note = string.Empty;
                    contactData.PhoneFaxEmail = string.Empty;
                    contactData.Recipient = string.Empty;
                    contactData.ReturnedOrResolved = false;

                    if (contactData != null)
                    {
                        _contactAttempts.Add(contactData);
                        SetCurrentContactAttempt(contactData);
                        _currentIndexContactsAttemp = _contactAttempts.Count - 1;
                        SetLabel(lblContactAttemp, _currentIndexContactsAttemp + 1, _contactAttempts.Count);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
            }
        }

        private void btnDelAttempt_Click(object sender, EventArgs e)
        {
            try
            {
                if (_contactAttempts == null || _contactAttempts.Count == 0) return;

                if (MessageBox.Show("Delete Contact Attemp that is currently being displayed ?", "Delete Contact Attemp", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    if (_contactAttempts != null && _contactAttempts.Count > 0)
                    {
                        _contactAttempts.RemoveAt(_currentIndexContactsAttemp);

                        if (_contactAttempts.ElementAtOrDefault(_currentIndexContactsAttemp) != null)
                        {
                            ContactAttemptData contact = _contactAttempts[_currentIndexContactsAttemp];
                            SetCurrentContactAttempt(contact);
                            SetLabel(lblContactAttemp, _currentIndexContactsAttemp + 1, _contactAttempts.Count);
                        }
                        else
                        {
                            _currentIndexContactsAttemp = _currentIndexContactsAttemp - 1;
                            if (_contactAttempts.ElementAtOrDefault(_currentIndexContactsAttemp) != null)
                            {
                                ContactAttemptData contact = _contactAttempts[_currentIndexContactsAttemp];
                                SetCurrentContactAttempt(contact);
                                SetLabel(lblContactAttemp, _currentIndexContactsAttemp + 1, _contactAttempts.Count);
                            }
                            else
                            {
                                SetLabel(lblContactAttemp, 0, 0);
                                ResetContactsAttemp();
                                DisableContactsAttemp();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
                throw;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_contactAttempts != null && _contactAttempts.Any())
            {
                SaveCurrentContactAttemp();
                int preIndex = _currentIndexContactsAttemp - 1;

                if (_contactAttempts.ElementAtOrDefault(preIndex) == null)
                {
                    return;
                }

                if (_contactAttempts[preIndex] != null)
                {
                    SetLabel(lblContactAttemp, preIndex + 1, _contactAttempts.Count());
                    this.SetCurrentContactAttempt(_contactAttempts[preIndex]);
                    _currentIndexContactsAttemp = preIndex;
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_contactAttempts != null && _contactAttempts.Any())
            {
                SaveCurrentContactAttemp();
                int nextIndex = _currentIndexContactsAttemp + 1;

                if (_contactAttempts.ElementAtOrDefault(nextIndex) == null) return;

                if (_contactAttempts[nextIndex] != null)
                {
                    SetLabel(lblContactAttemp, nextIndex + 1, _contactAttempts.Count);
                    this.SetCurrentContactAttempt(_contactAttempts[nextIndex]);
                    _currentIndexContactsAttemp = nextIndex;
                }
            }
        }

        public void btnPrint_Click(object sender, EventArgs e)
        {
            bool isPrintAll = cmbPrintOptions.Text == "Print All" ? true : false;
            FirePrintAppReports(sender, PrintAppEventArgs.MainActionType.Print, isPrintAll);
        }

        public void FirePrintAppReports(object sender, PrintAppEventArgs.MainActionType mainAction, bool isPrintAll = true)
        {
            List<AppReportItem> lstPrintItems = new List<AppReportItem>();

            if (olvReportList.GetItemCount() == 0)
            {
                return;
            }

            if (isPrintAll)
            {
                lstPrintItems = olvReportList.Objects.Cast<AppReportItem>().ToList();
            }
            else
            {
                foreach (AppReportItem item in olvReportList.SelectedObjects)
                {
                    lstPrintItems.Add(item);
                }
            }

            if (lstPrintItems == null)
                return;

            if (lstPrintItems.Count > 0)
            {
                if (PrintAppReports != null)
                {
                    PrintAppEventArgs arg = new PrintAppEventArgs(lstPrintItems, mainAction);
                    PrintAppReports(sender, arg);
                }
            }
        }

        private void cmbLocation_Enter(object sender, EventArgs e)
        {
            ImageComboBox.ImageComboBox cmb = sender as ImageComboBox.ImageComboBox;
            ImageComboBoxItem item = cmb.SelectedItem as ImageComboBoxItem;
            if (item != null)
            {
                _currentLocationBeforeChange = new LocationData(item.Item.ToString(), item.Text);
            }
        }

        private void cmbSceener_Enter(object sender, EventArgs e)
        {
            ImageComboBox.ImageComboBox cmb = sender as ImageComboBox.ImageComboBox;
            ImageComboBoxItem item = cmb.SelectedItem as ImageComboBoxItem;
            if (item != null)
            {
                _currentScreenerBeforeChange = new ScreenerData(item.Item.ToString(), item.Text);
            }
            else
            {
                _currentScreenerBeforeChange = new ScreenerData("", cmb.Text);
            }
        }

        private void cmbSceener_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ImageComboBox.ImageComboBox cmb = sender as ImageComboBox.ImageComboBox;
            ImageComboBoxItem item = cmb.SelectedItem as ImageComboBoxItem;
            ScreenerData newScreener = new ScreenerData(item.Item.ToString(), item.Text);
            if ((_currentScreenerBeforeChange != null && newScreener != null && _currentScreenerBeforeChange.ScreenerId != newScreener.ScreenerId) ||
                (_currentScreenerBeforeChange == null && newScreener != null))
            {
                MoveScreenerEventArgs arg = new MoveScreenerEventArgs(_currentScreenerBeforeChange, newScreener);
                if (MoveScreener != null)
                {
                    MoveScreener(sender, arg);
                    if (arg.Success == true)
                    {
                        return;
                    }
                }
            }

            if (_currentScreenerBeforeChange != null &&
                !string.IsNullOrEmpty(_currentScreenerBeforeChange.ScreenerId))
            {
                ImageComboBoxItem selectedItem = cmb.Items.Cast<ImageComboBoxItem>().SingleOrDefault(i => i.Item.ToString() == _currentScreenerBeforeChange.ScreenerId);
                if (selectedItem != null)
                {
                    cmb.SelectedItem = selectedItem;
                }
                else
                {
                    cmb.SelectedIndex = -1;
                    cmb.EditBoxClear();
                    cmb.SelectedText = _currentScreenerBeforeChange.ScreenerName;
                }
            }

            else if (_currentScreenerBeforeChange != null)
            {
                cmb.SelectedIndex = -1;
                cmb.EditBoxClear();
                cmb.SelectedText = _currentScreenerBeforeChange.ScreenerName;
            }
            else if (_currentScreenerBeforeChange == null)
            {
                cmb.SelectedIndex = -1;
                cmb.EditBoxClear();
            }
        }

        private void cmbSceener_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_currentScreenerBeforeChange != null && cmbSceener.SelectedIndex == -1)
            {
                //cmbSceener.Text = _currentScreenerBeforeChange.ScreenerName;
            }
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ImageComboBox.ImageComboBox cmb = sender as ImageComboBox.ImageComboBox;
            ImageComboBoxItem item = cmb.SelectedItem as ImageComboBoxItem;
            LocationData newLocation = new LocationData(item.Item.ToString(), item.Text);
            if (_currentLocationBeforeChange != null && newLocation != null && _currentLocationBeforeChange.LocationId != newLocation.LocationId)
            {
                MoveLocationEventArgs arg = new MoveLocationEventArgs(newLocation, false);
                if (MoveLocation != null)
                {
                    MoveLocation(sender, arg);
                    if (arg.Success == true)
                    {
                        return;
                    }
                }
            }
            if (_currentLocationBeforeChange == null)
            {
                cmb.SelectedIndex = -1;
                return;
            }
            ImageComboBoxItem selectedItem = cmb.Items.Cast<ImageComboBoxItem>().SingleOrDefault(i => i.Item.ToString() == _currentLocationBeforeChange.LocationId);
            cmb.SelectedItem = selectedItem;
        }

        private void btnReviewComm_Click(object sender, EventArgs e)
        {
            if (ReviewComment != null)
            {
                ReviewComment(sender, e);
            }
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            if (GotoAppClick != null)
            {
                GotoAppClick(sender, e);
            }
        }

        private void btnCompleteApp_Click(object sender, EventArgs e)
        {
            if (CompleteAppClick != null)
            {
                CompleteAppClick(sender, e);
            }
        }

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
       
        private void lblCompl_DoubleClick(object sender, EventArgs e)
        {
            if (MarkCompleteClick != null)
            {
                MarkCompleteClick(sender, e);
            }            
        }

        #endregion;

        private string ConvertRftToPlainText(string rftString)
        {
            return Utils.RtfToText(rftString);
        }

        public List<AppReportItem> GetListReportItems()
        {
            return olvReportList.Objects.Cast<AppReportItem>().ToList();
        }

        public void ShortcutKetAddContactAttemp()
        {
            if (tabAppContact.SelectedTab == tabContacts)
            {
                btnNewAttempt_Click(this, null);
            }
        }

        public void ShortcutKetDeleteContactAttemp()
        {
            if (tabAppContact.SelectedTab == tabContacts)
            {
                btnDelAttempt_Click(this, null);
            }
        }        

        public void btnCompleteTest_DoubleClick(object sender, EventArgs e)
        {
            if (MarkInProcessClick != null)
            {
                MarkInProcessClick(sender, e);
            }
        }
    }
}
