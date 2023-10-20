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

namespace PaaApplication.UserControls.AppExplore.CreditInfo
{
    public partial class CITypeTwoControl : UserControl
    {
        public TextBox BankControl
        {
            get { return txtBank; }
        }

        public TextBox Opened2Control
        {
            get { return txtOpened2; }
        }

        public TextBox Balance2Control
        {
            get { return txtBalance2; }
        }

        public TextBox AcctControl
        {
            get { return txtAcct; }
        }

        public TextBox NSFControl
        {
            get { return txtNSF; }
        }

        public TextBox SW2Control
        {
            get { return txtSW2; }
        }

        public TextBox CompanyControl
        {
            get { return txtCompany; }
        }

        public TextBox PhoneControl
        {
            get { return txtPhone; }
        }

        public TextBox Opened1Control
        {
            get { return txtOpened1; }
        }

        public TextBox TermControl
        {
            get { return txtTerm; }
        }

        public TextBox Balance1Control
        {
            get { return txtBalance1; }
        }

        public TextBox HighBlcControl
        {
            get { return txtHighBlc; }
        }

        public TextBox PayHabitControl
        {
            get { return txtPayHabit; }
        }

        public TextBox RatingControl
        {
            get { return txtRating; }
        }

        public TextBox SWControl
        {
            get { return txtSW; }
        }

        private List<CreditRefData> _creditRefs = new List<CreditRefData>();
        private int _currentIndex = -1;
        private string _currentApplicationId = string.Empty;

        public CITypeTwoControl()
        {
            InitializeComponent();
        }

        //private void SetCreditRefs(List<CreditRefData> creditRefs)
        //{
        //    this._creditRefs = creditRefs;
        //}

        private List<CreditRefData> GetCreditRefs()
        {
            return this._creditRefs;
        }

        private CreditRefData GetCurrentCreditRef()
        {
            CreditRefData creditRef = new CreditRefData();
            creditRef.Company = txtCompany.Text;
            creditRef.Phone = txtPhone.Text;
            creditRef.Opened = txtOpened1.Text;
            creditRef.Terms = txtTerm.Text;
            creditRef.Balance = txtBalance1.Text;
            creditRef.HighBalance = txtHighBlc.Text;
            creditRef.PayHabits = txtPayHabit.Text;
            creditRef.Rating = txtRating.Text;
            creditRef.SW = txtSW.Text;

            return creditRef;
        }

        private void SetCurrentCreditRef(CreditRefData creditRef)
        {
            if (creditRef == null)
                return;

            txtCompany.Text = creditRef.Company;
            txtPhone.Text = creditRef.Phone;
            txtOpened1.Text = creditRef.Opened;
            txtTerm.Text = creditRef.Terms;
            txtBalance1.Text = creditRef.Balance;
            txtPayHabit.Text = creditRef.PayHabits;
            txtRating.Text = creditRef.Rating;
            txtSW.Text = creditRef.SW;
            txtHighBlc.Text = creditRef.HighBalance;
        }

        public void ResetControls()
        {
            txtBank.Text = "";
            txtOpened2.Text = "";
            txtBalance2.Text = "";
            txtAcct.Text = "";
            txtNSF.Text = "";
            txtSW2.Text = "";

            txtCompany.Text = "";
            txtPhone.Text = "";
            txtOpened1.Text = "";
            txtTerm.Text = "";
            txtBalance1.Text = "";
            txtBalance2.Text = "";
            txtPayHabit.Text = "";
            txtRating.Text = "";
            txtSW.Text = "";

            _creditRefs = new List<CreditRefData>();
            _currentIndex = -1;
            _currentApplicationId = string.Empty;
        }

        public void UpdateAppFromControls(AppData app)
        {
            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                return;
            }

            SaveCurrentReference();

            app.CreditRefs = this._creditRefs;
            app.BankComm = txtBank.Text;
            app.OpenedComm = txtOpened2.Text;
            app.BalanceComm = txtBalance2.Text;
            app.AcctComm = txtAcct.Text;
            app.NSFODComm = txtNSF.Text;
            app.SWComm = txtSW2.Text;
            app.CreditRefs = GetCreditRefs();
        }

        public void UpdateControlsFromApp(AppData app)
        {
            try
            {
                ResetControls();

                if (app == null || string.IsNullOrEmpty(app.ApplicationId))
                {
                    _currentApplicationId = string.Empty;
                    return;
                }

                txtBank.Text = app.BankComm;
                txtOpened2.Text = app.OpenedComm;
                txtBalance2.Text = app.BalanceComm;
                txtAcct.Text = app.AcctComm;
                txtNSF.Text = app.NSFODComm;
                txtSW2.Text = app.SWComm;

                FillDataToControlsAtFirst(app);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
                throw;
            }
        }

        private void SaveCurrentReference()
        {
            try
            {
                CreditRefData currentCredit = GetCurrentCreditRef();

                if (currentCredit != null)
                {
                    if (_creditRefs.ElementAtOrDefault(_currentIndex) != null)
                    {
                        _creditRefs[_currentIndex] = currentCredit;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
                throw;
            }
        }

        private void FillDataToControlsAtFirst(AppData app)
        {
            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                _currentApplicationId = string.Empty;
                return;
            }

            try
            {
                if (!app.ApplicationId.Equals(_currentApplicationId) || _currentIndex < 0)
                {
                    _currentIndex = 0;
                }

                if (app.CreditRefs == null)
                {
                    _creditRefs = new List<CreditRefData>();
                }
                else
                {
                    _creditRefs = app.CreditRefs;
                }

                if (_creditRefs.Any())
                {
                    EnableCreditRef();
                    this.SetCurrentCreditRef(_creditRefs[_currentIndex]);
                    SetLabel(lblRef, _currentIndex + 1, _creditRefs.Count);
                }
                else
                {
                    DisableCreditRef();
                    SetLabel(lblRef, 0, 0);
                }

                _currentApplicationId = app.ApplicationId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private void EnableCreditRef()
        {
            txtCompany.Enabled = true;
            txtPhone.Enabled = true;
            txtOpened1.Enabled = true;
            txtTerm.Enabled = true;
            txtBalance1.Enabled = true;
            txtPayHabit.Enabled = true;
            txtRating.Enabled = true;
            txtHighBlc.Enabled = true;
            txtSW.Enabled = true;
        }

        private void DisableCreditRef()
        {
            txtCompany.Enabled = false;
            txtPhone.Enabled = false;
            txtOpened1.Enabled = false;
            txtTerm.Enabled = false;
            txtBalance1.Enabled = false;
            txtPayHabit.Enabled = false;
            txtHighBlc.Enabled = false;
            txtRating.Enabled = false;
            txtSW.Enabled = false;
        }

        private void SetLabel(Label label, int index, int count)
        {
            label.Text = string.Format("{0}/{1}", index, count);
        }

        private void ResetCredit()
        {
            txtCompany.Text = "";
            txtPhone.Text = "";
            txtOpened1.Text = "";
            txtTerm.Text = "";
            txtBalance1.Text = "";
            txtPayHabit.Text = "";
            txtRating.Text = "";
            txtSW.Text = "";
        }

        private void btnNewReference_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_creditRefs.Count == 0 && _creditRefs != null)
            {
                EnableCreditRef();
                CreditRefData credit = new CreditRefData();

                _creditRefs.Add(credit);
                SetCurrentCreditRef(credit);
                _currentIndex = _creditRefs.Count - 1;
                SetLabel(lblRef, _currentIndex + 1, _creditRefs.Count);
            }
            else
            {
                SaveCurrentReference();

                CreditRefData newCredit = new CreditRefData();
                if (newCredit != null)
                {
                    _creditRefs.Add(newCredit);

                    SetCurrentCreditRef(newCredit);
                    _currentIndex = _creditRefs.Count - 1;
                    SetLabel(lblRef, _currentIndex + 1, _creditRefs.Count);
                }
            }
        }

        private void btnDelReference_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_creditRefs == null || _creditRefs.Count == 0) return;

            if (MessageBox.Show("Delete the Credit Reference that is currently being displayed ?", "Delete Credit Reference", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (_creditRefs != null && _creditRefs.Count > 0)
                {
                    _creditRefs.RemoveAt(_currentIndex);

                    if (_creditRefs.ElementAtOrDefault(_currentIndex) != null)
                    {
                        CreditRefData credit = _creditRefs[_currentIndex];
                        SetCurrentCreditRef(credit);
                        SetLabel(lblRef, _currentIndex + 1, _creditRefs.Count);
                    }
                    else
                    {
                        _currentIndex = _currentIndex - 1;
                        if (_creditRefs.ElementAtOrDefault(_currentIndex) != null)
                        {
                            CreditRefData credit = _creditRefs[_currentIndex];
                            SetCurrentCreditRef(credit);
                            SetLabel(lblRef, _currentIndex + 1, _creditRefs.Count);
                        }
                        else
                        {
                            SetLabel(lblRef, 0, 0);
                            ResetCredit();
                            DisableCreditRef();
                        }
                    }
                }
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_creditRefs != null && _creditRefs.Any())
            {
                SaveCurrentReference();
                int preIndex = _currentIndex - 1;

                if (_creditRefs.ElementAtOrDefault(preIndex) == null)
                {
                    return;
                }

                if (_creditRefs[preIndex] != null)
                {
                    SetLabel(lblRef, preIndex + 1, _creditRefs.Count);
                    this.SetCurrentCreditRef(_creditRefs[preIndex]);
                    _currentIndex = preIndex;
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_creditRefs != null && _creditRefs.Any())
            {
                SaveCurrentReference();
                int nextIndex = _currentIndex + 1;

                if (_creditRefs.ElementAtOrDefault(nextIndex) == null) return;

                if (_creditRefs[nextIndex] != null)
                {
                    SetLabel(lblRef, nextIndex + 1, _creditRefs.Count);
                    this.SetCurrentCreditRef(_creditRefs[nextIndex]);
                    _currentIndex = nextIndex;
                }
            }
        }

        private void btnCopy_MouseDown(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_creditRefs == null || _creditRefs.Count == 0 || _currentIndex < 0)
            {
                return;
            }

            CreditRefData currentData = _creditRefs[_currentIndex];
            if (currentData == null)
            {
                return;
            }

            DragDropData.CreditRef data = new DragDropData.CreditRef();
            data.list = AutoMapper.Mapper.Map<List<CreditRefData>, List<CreditRefData>>(_creditRefs);
            data.currentIndex = _currentIndex;

            btnCopy.DoDragDrop(data, DragDropEffects.Move);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            CreditRefData currentItem = GetCurrentCreditRef();
            int currentIndex = _currentIndex;

            if (_currentIndex < _creditRefs.Count - 1)
            {
                var tmp = _creditRefs[currentIndex];
                _creditRefs[currentIndex] = _creditRefs[currentIndex + 1];
                _creditRefs[currentIndex + 1] = tmp;
            }
            else return;

            SetCurrentCreditRef(_creditRefs[currentIndex + 1]);

            _currentIndex = currentIndex + 1;

            this.SetLabel(lblRef, _currentIndex + 1, _creditRefs.Count);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            CreditRefData currentItem = GetCurrentCreditRef();
            int currentIndex = _currentIndex;

            if (_currentIndex > 0)
            {
                var tmp = _creditRefs[currentIndex];
                _creditRefs[currentIndex] = _creditRefs[currentIndex - 1];
                _creditRefs[currentIndex - 1] = tmp;
            }
            else return;

            SetCurrentCreditRef(_creditRefs[currentIndex - 1]);

            _currentIndex = currentIndex - 1;

            this.SetLabel(lblRef, _currentIndex + 1, _creditRefs.Count);
        }
    }
}
