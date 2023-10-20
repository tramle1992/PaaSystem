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
using StandardTemplate = Administration.Application.Data.StandardTemplate;
using Common.Infrastructure.UI;
using Administration.Infrastructure.StandardTemplate;
using Administration.Domain.Model.StandardTemplate;
using Common.Infrastructure.Helper;
using PaaApplication.ExtendControls;
using PaaApplication.Models.AppExplore;
using PaaApplication.Helper;
using InfoResource.Infrastructure.InfoResource;
using InfoResource.Domain.Model.InfoResource;
using InfoResource.Application.Data;

namespace PaaApplication.UserControls.AppExplore.RentalInfo
{
    public partial class RentalControl : UserControl
    {
        public TextBox MIControl
        {
            get { return txtMI; }
        }

        public TextBox MOControl
        {
            get { return txtMO; }
        }

        public TextBox MoneyControl
        {
            get { return txtMoney; }
        }

        public TextBox SWControl
        {
            get { return txtSW; }
        }

        public TextBox CompControl
        {
            get { return txtComp; }
        }

        public TextBox PhoneControl
        {
            get { return txtPhone; }
        }

        public RichTextBox CommentControl
        {
            get { return txtComment; }
        }

        private List<RentalRefData> _rentalRefs = new List<RentalRefData>();
        private int _currentIndex = -1;
        private string _currentApplicationId = string.Empty;
        
        private List<TemplateItem> lstTemplateRefs = new List<TemplateItem>();
        private RichTextBoxContextMenu richTextBoxContextMenu;

        public EventHandler<BeforeSetTemplateEventArgs> BeforeSetTemplateRentalRef;
        private InfoResourceApiRepository infoResourceApiRepository = new InfoResourceApiRepository();
        private InfoResourceCachedApiQuery infoResourceCachedApiQuery = InfoResourceCachedApiQuery.Instance;
        private ResourceTypeCachedApiQuery resourceTypeCachedApiQuery = ResourceTypeCachedApiQuery.Instance;

        public RentalControl()
        {
            InitializeComponent();

            this.richTextBoxContextMenu = new RichTextBoxContextMenu(this.txtComment);
        }

        public RentalRefData GetCurrentRentalRef()
        {
            RentalRefData rentalRef = new RentalRefData();

            try
            {
                rentalRef.MoveIn = txtMI.Text;
                rentalRef.MoveOut = txtMO.Text;
                rentalRef.Amount = txtMoney.Text;
                rentalRef.SW = txtSW.Text;
                rentalRef.Comp = txtComp.Text;
                rentalRef.Comment = txtComment.Rtf;
                rentalRef.Phone = txtPhone.Text;

                    #region written

                RadioButton checkedWrittentbutton = groupWritten.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

                if (checkedWrittentbutton != null)
                {
                    if (checkedWrittentbutton.Name == "radioWrittenY")
                    {
                        rentalRef.Written = RentalRefFactInfoData.Yes;
                    }
                    else if (checkedWrittentbutton.Name == "radioWrittenN")
                    {
                        rentalRef.Written = RentalRefFactInfoData.No;
                    }
                    else
                    {
                        rentalRef.Written = RentalRefFactInfoData.NotAvailable;
                    }

                #endregion written

                    #region kicked out

                    RadioButton checkedKickedOutbutton = groupKickedOut.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

                    if (checkedKickedOutbutton.Name == "radioKickedOutY")
                    {
                        rentalRef.KickedOut = RentalRefFactInfoData.Yes;
                    }
                    else if (checkedKickedOutbutton.Name == "radioKickedOutN")
                    {
                        rentalRef.KickedOut = RentalRefFactInfoData.No;
                    }
                    else
                    {
                        rentalRef.KickedOut = RentalRefFactInfoData.NotAvailable;
                    }

                    #endregion kicked out

                    #region Prpr Notice

                    RadioButton checkedPrprNoticeButton = groupPrprNotice.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

                    if (checkedPrprNoticeButton.Name == "radioPrprNoticeY")
                    {
                        rentalRef.PrprNotice = RentalRefFactInfoData.Yes;
                    }
                    else if (checkedPrprNoticeButton.Name == "radioPrprNoticeN")
                    {
                        rentalRef.PrprNotice = RentalRefFactInfoData.No;
                    }
                    else
                    {
                        rentalRef.PrprNotice = RentalRefFactInfoData.NotAvailable;
                    }

                    #endregion Prpr Notice

                    #region Late NSF

                    RadioButton checkedLateNsfButton = groupLateNSF.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

                    if (checkedLateNsfButton.Name == "radioLateNsfY")
                    {
                        rentalRef.LateNSF = RentalRefFactInfoData.Yes;
                    }
                    else if (checkedLateNsfButton.Name == "radioLateNsfN")
                    {
                        rentalRef.LateNSF = RentalRefFactInfoData.No;
                    }
                    else
                    {
                        rentalRef.LateNSF = RentalRefFactInfoData.NotAvailable;
                    }

                    #endregion Late NSF

                    #region Complaints

                    RadioButton checkedComplaintsButton = groupComplaints.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

                    if (checkedComplaintsButton.Name == "radioComplaintY")
                    {
                        rentalRef.Complaints = RentalRefFactInfoData.Yes;
                    }
                    else if (checkedComplaintsButton.Name == "radioComplaintN")
                    {
                        rentalRef.Complaints = RentalRefFactInfoData.No;
                    }
                    else
                    {
                        rentalRef.Complaints = RentalRefFactInfoData.NotAvailable;
                    }

                    #endregion Complaints

                    #region Damages

                    RadioButton checkedDamagesButton = groupDamages.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

                    if (checkedDamagesButton.Name == "radioDamageY")
                    {
                        rentalRef.Damages = RentalRefFactInfoData.Yes;
                    }
                    else if (checkedDamagesButton.Name == "radioDamageN")
                    {
                        rentalRef.Damages = RentalRefFactInfoData.No;
                    }
                    else
                    {
                        rentalRef.Damages = RentalRefFactInfoData.NotAvailable;
                    }

                    #endregion Damages

                    #region Owing

                    RadioButton checkedOwingButton = groupOwing.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

                    if (checkedOwingButton.Name == "radioOwingY")
                    {
                        rentalRef.Owing = RentalRefFactInfoData.Yes;
                    }
                    else if (checkedOwingButton.Name == "radioOwingN")
                    {
                        rentalRef.Owing = RentalRefFactInfoData.No;
                    }
                    else
                    {
                        rentalRef.Owing = RentalRefFactInfoData.NotAvailable;
                    }

                    #endregion Owing

                    #region Roommates

                    RadioButton checkedRoommatesButton = groupRoommates.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

                    if (checkedRoommatesButton.Name == "radioRoomateY")
                    {
                        rentalRef.Roommates = RentalRefFactInfoData.Yes;
                    }
                    else if (checkedRoommatesButton.Name == "radioRoomateN")
                    {
                        rentalRef.Roommates = RentalRefFactInfoData.No;
                    }
                    else
                    {
                        rentalRef.Roommates = RentalRefFactInfoData.NotAvailable;
                    }

                    #endregion Roommates

                    #region Addr Match

                    RadioButton checkedAddrMatchButton = groupAddrMatch.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

                    if (checkedAddrMatchButton.Name == "radioAddrMatchY")
                    {
                        rentalRef.AddressMatch = RentalRefFactInfoData.Yes;
                    }
                    else if (checkedAddrMatchButton.Name == "radioAddrMatchN")
                    {
                        rentalRef.AddressMatch = RentalRefFactInfoData.No;
                    }
                    else
                    {
                        rentalRef.AddressMatch = RentalRefFactInfoData.NotAvailable;
                    }

                    #endregion Addr Match

                    #region Pets

                    RadioButton checkedPetsButton = groupPets.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

                    if (checkedPetsButton.Name == "radioPetY")
                    {
                        rentalRef.Pets = RentalRefFactInfoData.Yes;
                    }
                    else if (checkedPetsButton.Name == "radioPetN")
                    {
                        rentalRef.Pets = RentalRefFactInfoData.No;
                    }
                    else
                    {
                        rentalRef.Pets = RentalRefFactInfoData.NotAvailable;
                    }

                    #endregion Pets

                    #region Rltve/Frnd

                    RadioButton checkedRltveButton = groupRltve.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

                    if (checkedRltveButton.Name == "radioPltveY")
                    {
                        rentalRef.RltveFrnd = RentalRefFactInfoData.Yes;
                    }
                    else if (checkedRltveButton.Name == "radioPltveN")
                    {
                        rentalRef.RltveFrnd = RentalRefFactInfoData.No;
                    }
                    else
                    {
                        rentalRef.RltveFrnd = RentalRefFactInfoData.NotAvailable;
                    }

                    #endregion Rltve/Frnd

                    #region Re-rent

                    RadioButton checkedRerentButton = groupRerent.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

                    if (checkedRerentButton.Name == "radioRerentY")
                    {
                        rentalRef.ReRent = RentalRefFactInfoData.Yes;
                    }
                    else if (checkedRerentButton.Name == "radioRerentN")
                    {
                        rentalRef.ReRent = RentalRefFactInfoData.No;
                    }
                    else
                    {
                        rentalRef.ReRent = RentalRefFactInfoData.NotAvailable;
                    }

                    #endregion Re-rent

                    #region bed bugs

                    RadioButton checkedBedBugsButton = groupBedBugs.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

                    if (checkedBedBugsButton.Name == "radioBedBugsY")
                    {
                        rentalRef.BedBugs = RentalRefFactInfoData.Yes;
                    }
                    else if (checkedBedBugsButton.Name == "radioBedBugsN")
                    {
                        rentalRef.BedBugs = RentalRefFactInfoData.No;
                    }
                    else
                    {
                        rentalRef.BedBugs = RentalRefFactInfoData.NotAvailable;
                    }

                    #endregion bed bugs
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return rentalRef;
        }

        private void SetCurrentRentalRef(RentalRefData rentalRef)
        {
            if (rentalRef == null)
                return;

            txtMI.Text = rentalRef.MoveIn;
            txtMO.Text = rentalRef.MoveOut;
            txtMoney.Text = rentalRef.Amount;
            txtSW.Text = rentalRef.SW;
            txtComp.Text = rentalRef.Comp;
            txtPhone.Text = rentalRef.Phone;

            try
            {
                txtComment.Rtf = rentalRef.Comment;
            }
            catch
            //in case string format is not rtf.
            {
                txtComment.Text = rentalRef.Comment;
            }

            SetCheckValues(rentalRef);
        }

        private ReferenceItem FromRentalRefFactInfoData(RentalRefFactInfoData fact, string name)
        {
            if (fact == RentalRefFactInfoData.Yes)
                return new ReferenceItem(name, true, false, false);
            else if (fact == RentalRefFactInfoData.No)
                return new ReferenceItem(name, false, true, false);
            else
                return new ReferenceItem(name, false, false, true);
        }

        private RentalRefFactInfoData FromReferenceItem(ReferenceItem item)
        {
            if (item.YesValue == true && item.NoValue == false && item.NAValue == false)
                return RentalRefFactInfoData.Yes;
            else if (item.YesValue == false && item.NoValue == true && item.NAValue == false)
                return RentalRefFactInfoData.No;
            else
                return RentalRefFactInfoData.NotAvailable;
        }

        private void ResetRental()
        {
            txtMI.Clear();
            txtMO.Clear();
            txtMoney.Clear();
            txtSW.Clear();
            txtComp.Clear();
            txtComment.Clear();
            txtPhone.Clear();

            radioAddrMatchNA.Checked = true;
            radioComplaintNA.Checked = true;
            radioDamageNA.Checked = true;
            radioKickedOutNA.Checked = true;
            radioLateNsfNA.Checked = true;
            radioOwingNA.Checked = true;
            radioPetNA.Checked = true;
            radioPltveNA.Checked = true;
            radioPrprNoticeNA.Checked = true;
            radioRerentNA.Checked = true;
            radioRoomateNA.Checked = true;
            radioWrittenNA.Checked = true;
            radioBedBugsNA.Checked = true;
        }

        public void ResetControls()
        {
            txtMI.Clear();
            txtMO.Clear();
            txtMoney.Clear();
            txtSW.Clear();
            txtComp.Clear();
            txtComment.Clear();
            txtPhone.Clear();

            radioAddrMatchNA.Checked = true;
            radioComplaintNA.Checked = true;
            radioDamageNA.Checked = true;
            radioKickedOutNA.Checked = true;
            radioLateNsfNA.Checked = true;
            radioOwingNA.Checked = true;
            radioPetNA.Checked = true;
            radioPltveNA.Checked = true;
            radioPrprNoticeNA.Checked = true;
            radioRerentNA.Checked = true;
            radioRoomateNA.Checked = true;
            radioWrittenNA.Checked = true;
            radioBedBugsNA.Checked = true;

            _rentalRefs = new List<RentalRefData>();
            _currentApplicationId = string.Empty;
            _currentIndex = -1;

            SetLabel(lblStdRef, 0, 0);
        }

        private void DisableControls()
        {
            groupWritten.Enabled = false;
            groupKickedOut.Enabled = false;
            groupLateNSF.Enabled = false;
            groupComplaints.Enabled = false;
            groupDamages.Enabled = false;
            groupOwing.Enabled = false;
            groupPets.Enabled = false;
            groupPrprNotice.Enabled = false;
            groupRerent.Enabled = false;
            groupRltve.Enabled = false;
            groupBedBugs.Enabled = false;
            groupRoommates.Enabled = false;
            groupAddrMatch.Enabled = false;

            txtComment.Enabled = false;
            txtComp.Enabled = false;
            txtMI.Enabled = false;
            txtMO.Enabled = false;
            txtMoney.Enabled = false;
            txtPhone.Enabled = false;
            txtSW.Enabled = false;
        }

        private void EnableControls()
        {
            groupWritten.Enabled = true;
            groupKickedOut.Enabled = true;
            groupLateNSF.Enabled = true;
            groupComplaints.Enabled = true;
            groupDamages.Enabled = true;
            groupOwing.Enabled = true;
            groupPets.Enabled = true;
            groupPrprNotice.Enabled = true;
            groupRerent.Enabled = true;
            groupRltve.Enabled = true;
            groupBedBugs.Enabled = true;
            groupRoommates.Enabled = true;
            groupAddrMatch.Enabled = true;

            txtComment.Enabled = true;
            txtComp.Enabled = true;
            txtMI.Enabled = true;
            txtMO.Enabled = true;
            txtMoney.Enabled = true;
            txtPhone.Enabled = true;
            txtSW.Enabled = true;
        }

        private void SaveCurrentRental()
        {
            RentalRefData rental = GetCurrentRentalRef();

            if (rental != null && _rentalRefs.ElementAtOrDefault(_currentIndex) != null)
            {
                _rentalRefs[_currentIndex] = rental;
            }
        }

        public void UpdateControlsFromApp(AppData app)
        {
            ResetRental();

            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                _currentApplicationId = string.Empty;
                return;
            }

            FillDataToControlsAtFirst(app);
        }

        public void UpdateAppFromControls(AppData app)
        {
            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                return;
            }

            SaveCurrentRental();
            app.RentalRefs = _rentalRefs;
        }

        private void FillDataToControlsAtFirst(AppData app)
        {
            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                _currentApplicationId = string.Empty;
                return;
            }

            if (!app.ApplicationId.Equals(_currentApplicationId) || _currentIndex < 0)
            {
                _currentIndex = 0;
            }

            if (app.RentalRefs == null)
            {
                _rentalRefs = new List<RentalRefData>();
            }
            else
            {
                _rentalRefs = app.RentalRefs;
            }

            if (_rentalRefs.Any())
            {
                EnableControls();
                SetCurrentRentalRef(_rentalRefs[_currentIndex]);
                SetCheckValues(_rentalRefs[_currentIndex]);
                SetLabel(lblStdRef, _currentIndex + 1, _rentalRefs.Count);
            }
            else
            {
                DisableControls();
                SetLabel(lblStdRef, 0, 0);
            }

            _currentApplicationId = app.ApplicationId;
        }

        private void SetLabel(Label labelControl, int index, int count)
        {
            labelControl.Text = string.Format("{0}/{1}", index, count);
        }

        private void SetCheckValues(RentalRefData rentalItem)
        {
            try
            {
                #region Written

                if (rentalItem.Written == RentalRefFactInfoData.No)
                {
                    radioWrittenN.Checked = true;
                }
                else if (rentalItem.Written == RentalRefFactInfoData.Yes)
                {
                    radioWrittenY.Checked = true;
                }
                else
                {
                    radioWrittenNA.Checked = true;
                }

                #endregion Written

                #region kicked out

                if (rentalItem.KickedOut == RentalRefFactInfoData.Yes)
                {
                    radioKickedOutY.Checked = true;
                }
                else if (rentalItem.KickedOut == RentalRefFactInfoData.No)
                {
                    radioKickedOutN.Checked = true;
                }
                else
                {
                    radioKickedOutNA.Checked = true;
                }

                #endregion kicked out

                #region prpr notice

                if (rentalItem.PrprNotice == RentalRefFactInfoData.Yes)
                {
                    radioPrprNoticeY.Checked = true;
                }
                else if (rentalItem.PrprNotice == RentalRefFactInfoData.No)
                {
                    radioPrprNoticeN.Checked = true;
                }
                else
                {
                    radioPrprNoticeNA.Checked = true;
                }

                #endregion prpr notice

                #region late nsf

                if (rentalItem.LateNSF == RentalRefFactInfoData.Yes)
                {
                    radioLateNsfY.Checked = true;
                }
                else if (rentalItem.LateNSF == RentalRefFactInfoData.No)
                {
                    radioLateNsfN.Checked = true;
                }
                else
                {
                    radioLateNsfNA.Checked = true;
                }

                #endregion late nsf

                #region complaints

                if (rentalItem.Complaints == RentalRefFactInfoData.Yes)
                {
                    radioComplaintY.Checked = true;
                }
                else if (rentalItem.Complaints == RentalRefFactInfoData.No)
                {
                    radioComplaintN.Checked = true;
                }
                else
                {
                    radioComplaintNA.Checked = true;
                }

                #endregion complaints

                #region damages

                if (rentalItem.Damages == RentalRefFactInfoData.Yes)
                {
                    radioDamageY.Checked = true;
                }
                else if (rentalItem.Damages == RentalRefFactInfoData.No)
                {
                    radioDamageN.Checked = true;
                }
                else
                {
                    radioDamageNA.Checked = true;
                }
                #endregion damages

                #region owing

                if (rentalItem.Owing == RentalRefFactInfoData.Yes)
                {
                    radioOwingY.Checked = true;
                }
                else if (rentalItem.Owing == RentalRefFactInfoData.No)
                {
                    radioOwingN.Checked = true;
                }
                else
                {
                    radioOwingNA.Checked = true;
                }

                #endregion owing

                #region roommates

                if (rentalItem.Roommates == RentalRefFactInfoData.Yes)
                {
                    radioRoomateY.Checked = true;
                }
                else if (rentalItem.Roommates == RentalRefFactInfoData.No)
                {
                    radioRoomateN.Checked = true;
                }
                else
                {
                    radioRoomateNA.Checked = true;
                }

                #endregion roommates

                #region addr match

                if (rentalItem.AddressMatch == RentalRefFactInfoData.Yes)
                {
                    radioAddrMatchY.Checked = true;
                }
                else if (rentalItem.AddressMatch == RentalRefFactInfoData.No)
                {
                    radioAddrMatchN.Checked = true;
                }
                else
                {
                    radioAddrMatchNA.Checked = true;
                }

                #endregion addr match

                #region pets

                if (rentalItem.Pets == RentalRefFactInfoData.Yes)
                {
                    radioPetY.Checked = true;
                }
                else if (rentalItem.Pets == RentalRefFactInfoData.No)
                {
                    radioPetN.Checked = true;
                }
                else
                {
                    radioPetNA.Checked = true;
                }

                #endregion pets

                #region RltveFrnd

                if (rentalItem.RltveFrnd == RentalRefFactInfoData.Yes)
                {
                    radioPltveY.Checked = true;
                }
                else if (rentalItem.RltveFrnd == RentalRefFactInfoData.No)
                {
                    radioPltveN.Checked = true;
                }
                else
                {
                    radioPltveNA.Checked = true;
                }
                #endregion RltveFrnd

                #region re-rent
                if (rentalItem.ReRent == RentalRefFactInfoData.Yes)
                {
                    radioRerentY.Checked = true;
                }
                else if (rentalItem.ReRent == RentalRefFactInfoData.No)
                {
                    radioRerentN.Checked = true;
                }
                else
                {
                    radioRerentNA.Checked = true;
                }
                #endregion re-rent

                #region bed bugs
                if (rentalItem.BedBugs == RentalRefFactInfoData.Yes)
                {
                    radioBedBugsY.Checked = true;
                }
                else if (rentalItem.BedBugs == RentalRefFactInfoData.No)
                {
                    radioBedBugsN.Checked = true;
                }
                else
                {
                    radioBedBugsNA.Checked = true;
                }
                #endregion bed bugs
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
                throw;
            }
        }

        public void btnAddRef_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            RentalRefData rental = new RentalRefData();
            rental.Written = RentalRefFactInfoData.NotAvailable;
            rental.KickedOut = RentalRefFactInfoData.NotAvailable;
            rental.PrprNotice = RentalRefFactInfoData.NotAvailable;
            rental.LateNSF = RentalRefFactInfoData.NotAvailable;
            rental.Complaints = RentalRefFactInfoData.NotAvailable;
            rental.Damages = RentalRefFactInfoData.NotAvailable;
            rental.Owing = RentalRefFactInfoData.NotAvailable;
            rental.Roommates = RentalRefFactInfoData.NotAvailable;
            rental.AddressMatch = RentalRefFactInfoData.NotAvailable;
            rental.Pets = RentalRefFactInfoData.NotAvailable;
            rental.RltveFrnd = RentalRefFactInfoData.NotAvailable;
            rental.ReRent = RentalRefFactInfoData.NotAvailable;
            rental.BedBugs = RentalRefFactInfoData.NotAvailable;

            rental.MoveIn = "N/A";
            rental.MoveOut = "Current";
            rental.Amount = "N/A";

            if (_rentalRefs != null && _rentalRefs.Count > 0)
            {
                rental.MoveOut = "N/A";
            }

            if (_rentalRefs.Count == 0 && _rentalRefs != null)
            {
                EnableControls();

                _rentalRefs.Add(rental);
                SetCurrentRentalRef(rental);
                _currentIndex = _rentalRefs.Count - 1;
                SetLabel(lblStdRef, _currentIndex + 1, _rentalRefs.Count);
            }
            else
            {
                SaveCurrentRental();

                if (rental != null)
                {
                    _rentalRefs.Add(rental);

                    SetCurrentRentalRef(rental);
                    _currentIndex = _rentalRefs.Count - 1;
                    SetLabel(lblStdRef, _currentIndex + 1, _rentalRefs.Count);
                }
            }
        }

        public void btnDelRef_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_rentalRefs == null || _rentalRefs.Count == 0) return;
            if (MessageBox.Show("Delete the Rental Reference that is currently being displayed ?", "Delete Rental Reference", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (_rentalRefs != null && _rentalRefs.Count > 0)
                {
                    _rentalRefs.RemoveAt(_currentIndex);

                    if (_rentalRefs.ElementAtOrDefault(_currentIndex) != null)
                    {
                        RentalRefData rental = _rentalRefs[_currentIndex];
                        SetCurrentRentalRef(rental);
                        SetLabel(lblStdRef, _currentIndex + 1, _rentalRefs.Count);
                    }
                    else
                    {
                        _currentIndex = _currentIndex - 1;
                        if (_rentalRefs.ElementAtOrDefault(_currentIndex) != null)
                        {
                            RentalRefData rental = _rentalRefs[_currentIndex];
                            SetCurrentRentalRef(rental);
                            SetLabel(lblStdRef, _currentIndex + 1, _rentalRefs.Count);
                        }
                        else
                        {
                            SetLabel(lblStdRef, 0, 0);
                            ResetRental();
                            DisableControls();
                        }
                    }
                }
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_rentalRefs != null && _rentalRefs.Count > 0)
            {
                SaveCurrentRental();
                int preIndex = _currentIndex - 1;

                if (_rentalRefs.ElementAtOrDefault(preIndex) == null)
                {
                    return;
                }

                if (_rentalRefs[preIndex] != null)
                {
                    SetLabel(lblStdRef, preIndex + 1, _rentalRefs.Count);
                    this.SetCurrentRentalRef(_rentalRefs[preIndex]);
                    _currentIndex = preIndex;
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_rentalRefs != null && _rentalRefs.Any())
            {
                SaveCurrentRental();
                int nextIndex = _currentIndex + 1;

                if (_rentalRefs.ElementAtOrDefault(nextIndex) == null) return;

                if (_rentalRefs[nextIndex] != null)
                {
                    SetLabel(lblStdRef, nextIndex + 1, _rentalRefs.Count);
                    this.SetCurrentRentalRef(_rentalRefs[nextIndex]);
                    _currentIndex = nextIndex;
                }
            }
        }

        public void btnRefs_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_rentalRefs.Count == 0 || _rentalRefs == null) return;

            StandardTemplate.RootItemData rootData = StandardTemplate.RootItemData.RENTAL_REFS_ID;

            contextMenu.Items.Clear();

            using (new HourGlass())
            {
                StandardTemplateApiRepository templateApi = new StandardTemplateApiRepository();
                lstTemplateRefs = templateApi.FindChildren(rootData.Value).ToList();
            }

            if (lstTemplateRefs != null && lstTemplateRefs.Any())
            {
                foreach (TemplateItem item in lstTemplateRefs)
                {
                    ToolStripMenuItem submenu = new ToolStripMenuItem();
                    submenu.Click += submenu_Click;

                    if (item.ParentId.Id == rootData.Value)
                    {
                        submenu.Text = item.Name;

                        List<TemplateItem> itemChildren = GetChildren(lstTemplateRefs, item.TemplateItemId.Id);
                        if (itemChildren.Any())
                        {
                            foreach (TemplateItem value in itemChildren)
                            {
                                submenu.DropDownItems.Add(value.Name);
                            }
                            for (int i = 0; i < submenu.DropDownItems.Count; i++)
                            {
                                submenu.DropDownItems[i].Click += dropDownItem_Click;
                            }
                        }
                        contextMenu.Items.Add(submenu);
                    }
                }
            }

            contextMenu.Show(btnRefs, new Point(0, btnRefs.Height));
        }

        private void dropDownItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            ToolStripItem item = sender as ToolStripItem;

            TemplateItem selectedTemplate = (from t in lstTemplateRefs
                                             where t.Name == item.Text
                                             select t).First();

            if (selectedTemplate != null)
            {
                if (!string.IsNullOrEmpty(selectedTemplate.Caption))
                {
                    SetTemplateContent(selectedTemplate.Caption);
                }
                else
                {
                    txtComment.Clear();
                }
            }
        }

        private List<TemplateItem> GetChildren(List<TemplateItem> listAllTemplates, string rootId)
        {
            List<TemplateItem> result = new List<TemplateItem>();
            foreach (TemplateItem item in listAllTemplates)
            {
                if (item.ParentId.Id == rootId)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        private void submenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem subitem = sender as ToolStripMenuItem;

            TemplateItem selectedTemplate = (from t in lstTemplateRefs
                                             where t.Name == subitem.Text
                                             select t).First();

            if (selectedTemplate != null)
            {
                SetTemplateContent(selectedTemplate.Caption);
            }
        }

        private void SetTemplateContent(string content)
        {
            string mo = txtMO.Text ?? string.Empty;

            try
            {
                if (string.IsNullOrEmpty(content))
                {
                    return;
                }

                StandardTemplate.RentalRefsData data = XmlSerializationHelper.Deserialize<StandardTemplate.RentalRefsData>(content);

                if (BeforeSetTemplateRentalRef != null)
                {
                    BeforeSetTemplateEventArgs args = new BeforeSetTemplateEventArgs(data.RentalRefs);
                    BeforeSetTemplateRentalRef(this, args);
                    data.RentalRefs = args.Content;
                }
                try
                {
                    // Check the string contents '\n' and the end or not.. If not, append Line Break for the string..
                    string str = txtComment.Text;

                    var x = str.IndexOf("\n");

                    if (x != str.Length - 1)
                    {
                        txtComment.AppendText("\n");
                    }

                    int insertPos = txtComment.TextLength;
                    txtComment.Select(insertPos, 0);
                    string rtfText = data.RentalRefs;
                    txtComment.SelectedRtf = rtfText;

                    if (mo.ToUpper() == "CURRENT")
                    {
                        rtfText = txtComment.Rtf.Replace("Previous", "Current");
                        txtComment.Rtf = rtfText;
                    }
                    else
                    {
                        rtfText = txtComment.Rtf.Replace("Current", "Previous");
                        txtComment.Rtf = rtfText;
                    }
                }
                catch
                //in case string format is not rtf
                {
                    string currentString = this.txtComment.Text;
                    if (mo.ToUpper() == "CURRENT")
                    {
                        string text = currentString + Environment.NewLine + "Current" + data.RentalRefs;
                        text = text.Replace("Previous", "Current");
                        txtComment.Text = text;
                    }
                    else
                    {
                        string text = currentString + Environment.NewLine + "Previous " + data.RentalRefs;
                        text = text.Replace("Current", "Previous");
                        txtComment.Text = text;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
            }

        }

        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string templateName = e.ClickedItem.Text;

            TemplateItem selectedTemplate = (from t in lstTemplateRefs
                                             where t.Name == templateName
                                             select t).First();

            if (selectedTemplate != null)
            {
                if (!string.IsNullOrEmpty(selectedTemplate.Caption))
                {
                    SetTemplateContent(selectedTemplate.Caption);
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            RentalRefData currentItem = GetCurrentRentalRef();
            int currentIndex = _currentIndex;

            if (_currentIndex < _rentalRefs.Count - 1)
            {
                var tmp = _rentalRefs[currentIndex];
                _rentalRefs[currentIndex] = _rentalRefs[currentIndex + 1];
                _rentalRefs[currentIndex + 1] = tmp;
            }
            else return;

            SetCurrentRentalRef(_rentalRefs[currentIndex + 1]);

            _currentIndex = currentIndex + 1;

            this.SetLabel(lblStdRef, _currentIndex + 1, _rentalRefs.Count);
        }

        private void btnCopy_MouseDown(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_rentalRefs == null || _rentalRefs.Count == 0 || _currentIndex < 0)
            {
                return;
            }

            RentalRefData currentData = _rentalRefs[_currentIndex];
            if (currentData == null)
            {
                return;
            }

            DragDropData.RentalRef data = new DragDropData.RentalRef();
            data.list = AutoMapper.Mapper.Map<List<RentalRefData>, List<RentalRefData>>(_rentalRefs);
            data.currentIndex = _currentIndex;

            btnCopy.DoDragDrop(data, DragDropEffects.Move);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            RentalRefData currentItem = GetCurrentRentalRef();
            int currentIndex = _currentIndex;

            if (_currentIndex > 0)
            {
                var tmp = _rentalRefs[currentIndex];
                _rentalRefs[currentIndex] = _rentalRefs[currentIndex - 1];
                _rentalRefs[currentIndex - 1] = tmp;
            }
            else return;

            SetCurrentRentalRef(_rentalRefs[currentIndex - 1]);

            _currentIndex = currentIndex - 1;

            this.SetLabel(lblStdRef, _currentIndex + 1, _rentalRefs.Count);
        }

        private void RentalControl_Load(object sender, EventArgs e)
        {
            foreach (var item in this.Controls)
            {
                if (item.GetType() == typeof(RadioButton))
                    ((RadioButton)item).TabStopChanged += new System.EventHandler(TabStopChanged);
            }
        }

        private void TabStopChanged(object sender, EventArgs e)
        {
            ((RadioButton)sender).TabStop = true;
        }

        private void groupWritten_Leave(object sender, EventArgs e)
        {
            groupWritten.BackColor = SystemColors.Control;
        }

        private void groupKickedOut_Leave(object sender, EventArgs e)
        {
            groupKickedOut.BackColor = Color.Gainsboro;
        }

        private void groupPrprNotice_Leave(object sender, EventArgs e)
        {
            groupPrprNotice.BackColor = SystemColors.Control;
        }

        private void groupLateNSF_Leave(object sender, EventArgs e)
        {
            groupLateNSF.BackColor = Color.Gainsboro;
        }

        private void groupComplaints_Leave(object sender, EventArgs e)
        {
            groupComplaints.BackColor = SystemColors.Control;
        }

        private void groupDamages_Leave(object sender, EventArgs e)
        {
            groupDamages.BackColor = Color.Gainsboro;
        }

        private void groupOwing_Leave(object sender, EventArgs e)
        {
            groupOwing.BackColor = SystemColors.Control;
        }

        private void groupRoommates_Leave(object sender, EventArgs e)
        {
            groupRoommates.BackColor = Color.Gainsboro;
        }

        private void groupAddrMatch_Leave(object sender, EventArgs e)
        {
            groupAddrMatch.BackColor = SystemColors.Control;
        }

        private void groupPets_Leave(object sender, EventArgs e)
        {
            groupPets.BackColor = Color.Gainsboro;
        }

        private void groupRerent_Leave(object sender, EventArgs e)
        {
            groupRerent.BackColor = Color.Gainsboro;
        }

        private void groupRltve_Leave(object sender, EventArgs e)
        {
            groupRltve.BackColor = SystemColors.Control;
        }

        private void groupPrprNotice_Enter(object sender, EventArgs e)
        {
            groupPrprNotice.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void groupWritten_Enter(object sender, EventArgs e)
        {
            groupWritten.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void groupKickedOut_Enter(object sender, EventArgs e)
        {
            groupKickedOut.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void groupLateNSF_Enter(object sender, EventArgs e)
        {
            groupLateNSF.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void groupComplaints_Enter(object sender, EventArgs e)
        {
            groupComplaints.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void groupDamages_Enter(object sender, EventArgs e)
        {
            groupDamages.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void groupOwing_Enter(object sender, EventArgs e)
        {
            groupOwing.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void groupRoommates_Enter(object sender, EventArgs e)
        {
            groupRoommates.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void groupAddrMatch_Enter(object sender, EventArgs e)
        {
            groupAddrMatch.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void groupPets_Enter(object sender, EventArgs e)
        {
            groupPets.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void groupRerent_Enter(object sender, EventArgs e)
        {
            groupRerent.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void groupRltve_Enter(object sender, EventArgs e)
        {
            groupRltve.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void groupBedBugs_Leave(object sender, EventArgs e)
        {
            groupBedBugs.BackColor = SystemColors.Control;
        }

        private void groupBedBugs_Enter(object sender, EventArgs e)
        {
            groupBedBugs.BackColor = SystemColors.GradientInactiveCaption;
        }

        #region txtMI
        private void txtMI_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtMI);
        }
        #endregion

        #region txtMO
        private void txtMO_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtMO);
        }
        #endregion

        #region txtMoney
        private void txtMoney_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtMoney);
        }
        #endregion

        #region txtSW
        private void txtSW_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtSW);
        }
        #endregion

        #region txtComp
        private void txtComp_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtComp);
        }
        #endregion

        #region txtPhone
        private void txtPhone_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtPhone);
        }
        #endregion

        private void btnCreateInfoResource_Click(object sender, EventArgs e)
        {
            var currentRental = GetCurrentRentalRef();
            List<ResourceTypeData> listResourceTypeData = resourceTypeCachedApiQuery.GetAllItems();

            if (listResourceTypeData != null && listResourceTypeData.Count > 0)
            {
                ResourceTypeData resourceType = (from rsType in listResourceTypeData
                                                 where rsType.Name == "Landlord"
                                                 select rsType).FirstOrDefault();

                if (resourceType != null)
                {
                    ResourceData data = new ResourceData();
                    data.Target = string.Empty;
                    data.Email = string.Empty;
                    data.Phone = currentRental.Phone;
                    data.Name = GetNameForInfoResource();
                    data.Comment = Utils.IsRichText(currentRental.Comment) ? Utils.RtfToText(currentRental.Comment) : currentRental.Comment;
                    data.ResourceTypeData = resourceType;
                    string newId = AddNewResource(data);
                }
            }
        }       

        private string AddNewResource(ResourceData item)
        {
            string newId = "";

            try
            {
                newId = infoResourceApiRepository.Add(item);

                if (!string.IsNullOrEmpty(newId))
                {
                    MessageBox.Show("New Info Resource is created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
            }

            return newId;
        }

        private string GetNameForInfoResource()
        {
            var name = "N/A";

            var currentRental = GetCurrentRentalRef();
            if (!string.IsNullOrEmpty(currentRental.SW)) name = currentRental.SW;

            else if (!string.IsNullOrEmpty(currentRental.Comp)) name = currentRental.Comp;

            return name;
        }
    }
}

