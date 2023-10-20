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
using Core.Domain.Model.ExploreApps;
using PaaApplication.Helper;

namespace PaaApplication.UserControls.AppExplore.GeneralInfo
{
    public partial class CriEvControl : UserControl
    {
        public enum ActionCopyToOtherApp
        {
            Charge,
            Eviction,
            None
        }

        public TextBox Heading1Control
        {
            get { return txtHeading1; }
        }

        public TextBox ChargeControl
        {
            get { return txtCharge; }
        }

        public TextBox SentenceControl
        {
            get { return txtSentence; }
        }

        public TextBox Heading2Control
        {
            get { return txtHeading2; }
        }

        public ActionCopyToOtherApp CurrentActionCopyToOtherApp
        {
            get { return _currentActionCopyToOtherApp; }
        }

        public CriEvControl()
        {
            InitializeComponent();
        }

        List<ChargeRefData> _charges = new List<ChargeRefData>();
        List<EvictionRefData> _evictions = new List<EvictionRefData>();
        private int _currentIndexCharges = -1;
        private int _currentIndexEvictions = -1;
        private string _currentApplicationId = string.Empty;

        private ActionCopyToOtherApp _currentActionCopyToOtherApp = ActionCopyToOtherApp.None;

        public void ResetControls()
        {
            txtHeading1.Text = "";
            txtState1.Text = "";
            txtCounty1.Text = "";
            txtCharge.Text = "";
            txtDate1.Text = "";
            txtSentence.Text = "";

            txtHeading2.Text = "";
            txtState2.Text = "";
            txtCounty2.Text = "";
            txtOwner.Text = "";
            txtDate2.Text = "";

            _charges = new List<ChargeRefData>(); ;
            _currentIndexCharges = -1;
            _evictions = new List<EvictionRefData>();
            _currentIndexEvictions = -1;
            _currentApplicationId = string.Empty;
        }

        private void SetLabel(Label label, int index, int count)
        {
            label.Text = string.Format("{0}/{1}", index, count);
        }

        public void UpdateControlsFromApp(AppData app)
        {
            try
            {
                ResetCharge();
                ResetEviction();

                if (app == null || string.IsNullOrEmpty(app.ApplicationId))
                {
                    _currentApplicationId = string.Empty;
                    return;
                }

                FillDataToControlsAtFirst(app);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
                throw;
            }
        }

        public void UpdateAppFromControls(AppData app)
        {
            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                return;
            }

            SaveCurrentCharge();
            SaveCurrentEviction();
            app.Charges = _charges;
            app.Evictions = _evictions;
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
                if (!app.ApplicationId.Equals(_currentApplicationId))
                {
                    _currentIndexCharges = 0;
                    _currentIndexEvictions = 0;
                }
                else
                {
                    if (_currentIndexCharges < 0)
                    {
                        _currentIndexCharges = 0;
                    }
                    if (_currentIndexEvictions < 0)
                    {
                        _currentIndexEvictions = 0;
                    }
                }

                if (app.Charges == null)
                {
                    _charges = new List<ChargeRefData>();
                }
                else
                {
                    _charges = app.Charges;
                }

                if (app.Evictions == null)
                {
                    _evictions = new List<EvictionRefData>();
                }
                else
                {
                    _evictions = app.Evictions;
                }

                if (_charges.Any())
                {
                    EnableCharge();
                    this.SetCurrentCharge(_charges[_currentIndexCharges]);
                    SetLabel(lblCharge, _currentIndexCharges + 1, _charges.Count);
                }
                else
                {
                    DisableCharge();
                    SetLabel(lblCharge, 0, 0);
                }

                if (_evictions.Any())
                {
                    EnableEviction();
                    this.SetCurrentEviction(_evictions[_currentIndexEvictions]);
                    SetLabel(lblEviction, _currentIndexEvictions + 1, _evictions.Count);
                }
                else
                {
                    DisableEviction();
                    SetLabel(lblEviction, 0, 0);
                }

                _currentApplicationId = app.ApplicationId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #region Charge

        public void SetCurrentCharge(ChargeRefData charge)
        {
            if (charge == null)
                return;

            txtHeading1.Text = charge.Heading;
            txtState1.Text = charge.State;
            txtCounty1.Text = charge.County;
            txtCharge.Text = charge.Charge;
            txtDate1.Text = charge.Date;
            txtSentence.Text = charge.Sentence;
        }

        public ChargeRefData GetCurrentCharge()
        {
            if (_charges == null || _charges.Count == 0) return null;

            ChargeRefData charge = new ChargeRefData();
            charge.Heading = txtHeading1.Text;
            charge.State = txtState1.Text;
            charge.County = txtCounty1.Text;
            charge.Charge = txtCharge.Text;
            charge.Date = txtDate1.Text;
            charge.Sentence = txtSentence.Text;

            return charge;
        }

        //private List<ChargeRefData> GetCharges()
        //{
        //    return _charges;
        //}

        private void ResetCharge()
        {
            txtHeading1.Text = "";
            txtState1.Text = "";
            txtCounty1.Text = "";
            txtCharge.Text = "";
            txtDate1.Text = "";
            txtSentence.Text = "";
        }

        private void DisableCharge()
        {
            txtHeading1.ReadOnly = true;
            txtState1.ReadOnly = true;
            txtCounty1.ReadOnly = true;
            txtCharge.ReadOnly = true;
            txtDate1.ReadOnly = true;
            txtSentence.ReadOnly = true;
        }

        private void EnableCharge()
        {
            txtHeading1.ReadOnly = false;
            txtState1.ReadOnly = false;
            txtCounty1.ReadOnly = false;
            txtCharge.ReadOnly = false;
            txtDate1.ReadOnly = false;
            txtSentence.ReadOnly = false;
        }

        #endregion Charge

        #region Eviction

        //private List<EvictionRefData> GetEvictions()
        //{
        //    return _evictions;
        //}

        public EvictionRefData GetCurrentEviction()
        {
            EvictionRefData eviction = new EvictionRefData();
            eviction.Heading = txtHeading2.Text;
            eviction.State = txtState2.Text;
            eviction.County = txtCounty2.Text;
            eviction.Owners = txtOwner.Text;
            eviction.Date = txtDate2.Text;

            return eviction;
        }

        public void SetCurrentEviction(EvictionRefData eviction)
        {
            if (eviction == null)
                return;

            txtHeading2.Text = eviction.Heading;
            txtState2.Text = eviction.State;
            txtCounty2.Text = eviction.County;
            txtOwner.Text = eviction.Owners;
            txtDate2.Text = eviction.Date;
        }

        private void ResetEviction()
        {
            txtHeading2.Text = "";
            txtState2.Text = "";
            txtCounty2.Text = "";
            txtOwner.Text = "";
            txtDate2.Text = "";
        }

        private void DisableEviction()
        {
            txtHeading2.ReadOnly = true;
            txtState2.ReadOnly = true;
            txtCounty2.ReadOnly = true;
            txtOwner.ReadOnly = true;
            txtDate2.ReadOnly = true;
        }

        private void EnableEviction()
        {
            txtHeading2.ReadOnly = false;
            txtState2.ReadOnly = false;
            txtCounty2.ReadOnly = false;
            txtOwner.ReadOnly = false;
            txtDate2.ReadOnly = false;
        }

        private void SaveCurrentEviction()
        {
            EvictionRefData currentEviction = GetCurrentEviction();

            if (currentEviction != null && _evictions != null)
            {
                if (_evictions.ElementAtOrDefault(_currentIndexEvictions) != null)
                {
                    _evictions[_currentIndexEvictions] = currentEviction;
                }
            }
        }

        #endregion Eviction

        #region control events Charges

        private void SaveCurrentCharge()
        {
            ChargeRefData currentCharge = GetCurrentCharge();

            if (currentCharge != null && _charges != null)
            {
                if (_charges.ElementAtOrDefault(_currentIndexCharges) != null)
                {
                    _charges[_currentIndexCharges] = currentCharge;
                }
            }
        }

        public void btnAddCharge_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            SaveCurrentCharge();

            if (_charges == null || _charges.Count == 0)
            {
                EnableCharge();
                ChargeRefData charge = new ChargeRefData();
                charge.Heading = "";
                charge.State = "Oregon";
                charge.County = "All";
                charge.Charge = "None";
                charge.Date = "N/A";
                charge.Sentence = "N/A";

                _charges.Add(charge);
                SetCurrentCharge(charge);
                _currentIndexCharges = _charges.Count - 1;
                SetLabel(lblCharge, _currentIndexCharges + 1, _charges.Count());
            }
            else
            {
                ChargeRefData newCharge = GetCurrentCharge();
                if (newCharge != null)
                {
                    if (!newCharge.Charge.ToLower().Equals("none"))
                    {
                        newCharge.Charge = string.Empty;
                        newCharge.Date = string.Empty;
                        newCharge.Sentence = string.Empty;
                    }

                    _charges.Add(newCharge);

                    SetCurrentCharge(newCharge);
                    _currentIndexCharges = _charges.Count - 1;
                    SetLabel(lblCharge, _currentIndexCharges + 1, _charges.Count());
                }
            }

        }

        public void btnDelCharge_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_charges == null || _charges.Count == 0) return;

            if (MessageBox.Show("Delete the Criminal that is currently being displayed ?", "Delete Criminal", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (_charges != null && _charges.Count > 0)
                {
                    _charges.RemoveAt(_currentIndexCharges);

                    if (_charges.ElementAtOrDefault(_currentIndexCharges) != null)
                    {
                        ChargeRefData charge = _charges[_currentIndexCharges];
                        SetCurrentCharge(charge);
                        SetLabel(lblCharge, _currentIndexCharges + 1, _charges.Count());
                    }
                    else
                    {
                        _currentIndexCharges = _currentIndexCharges - 1;
                        if (_charges.ElementAtOrDefault(_currentIndexCharges) != null)
                        {
                            ChargeRefData charge = _charges[_currentIndexCharges];
                            SetCurrentCharge(charge);
                            SetLabel(lblCharge, _currentIndexCharges + 1, _charges.Count());
                        }
                        else
                        {
                            SetLabel(lblCharge, 0, 0);
                            ResetCharge();
                            DisableCharge();
                        }
                    }
                }
            }
        }

        private void btnNextCharge_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_charges != null && _charges.Any())
            {
                SaveCurrentCharge();
                int nextIndex = _currentIndexCharges + 1;

                if (_charges.ElementAtOrDefault(nextIndex) == null) return;

                if (_charges[nextIndex] != null)
                {
                    SetLabel(lblCharge, nextIndex + 1, _charges.Count());
                    this.SetCurrentCharge(_charges[nextIndex]);
                    _currentIndexCharges = nextIndex;
                }
            }
        }

        private void btnPreviousCharge_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_charges != null && _charges.Any())
            {
                SaveCurrentCharge();
                int preIndex = _currentIndexCharges - 1;

                if (_charges.ElementAtOrDefault(preIndex) == null)
                {
                    return;
                }

                if (_charges[preIndex] != null)
                {
                    SetLabel(lblCharge, preIndex + 1, _charges.Count());
                    this.SetCurrentCharge(_charges[preIndex]);
                    _currentIndexCharges = preIndex;
                }
            }
        }

        private void btnCopyCharge_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_charges.Count == 0 || _charges == null) return;
            SaveCurrentCharge();
            ChargeRefData currentCharge = GetCurrentCharge();

            List<ChargeRefData> charges = new List<ChargeRefData>();
            if (currentCharge != null)
            {
                int index = 0;
                if(_charges.Count == 1)
                {
                    charges.Add(_charges[0]);
                    charges.Add(currentCharge);

                    _charges = charges;
                    _currentIndexCharges = _charges.Count - 1;
                }
                else if(_charges.Count > 1)
                {
                    for (int i = 0; i <= _charges.Count; i++)
                    {
                        if (i.Equals(_currentIndexCharges + 1))
                        {
                            charges.Add(currentCharge);
                            index = _currentIndexCharges + 1;
                        }
                        if (i == _charges.Count) break;
                        charges.Add(_charges[i]);
                    }

                    _charges = charges;
                    _currentIndexCharges = index;
                }
                
                if (charges.ElementAt(_currentIndexCharges) != null)
                {
                    SetCurrentCharge(_charges[_currentIndexCharges]);
                    SetLabel(lblCharge, _currentIndexCharges + 1, _charges.Count);
                }
            }
        }

        #endregion control events Charges

        #region control events Evictions

        private void btnAddEviction_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            SaveCurrentEviction();

            if (_evictions.Count == 0)
            {
                EnableEviction();
                EvictionRefData eviction = new EvictionRefData();
                eviction.Heading = "";
                eviction.County = "All";
                eviction.Owners = "None";
                eviction.Date = "N/A";
                eviction.State = "Oregon";

                _evictions.Add(eviction);
                SetCurrentEviction(eviction);
                _currentIndexEvictions = _evictions.Count - 1;
                SetLabel(lblEviction, _currentIndexEvictions + 1, _evictions.Count);
            }
            else
            {
                EvictionRefData newEviction = GetCurrentEviction();
                if (newEviction != null)
                {
                    if (!newEviction.Owners.ToLower().Equals("none"))
                    {
                        newEviction.Owners = string.Empty;
                        newEviction.Date = string.Empty;
                    }

                    _evictions.Add(newEviction);

                    SetCurrentEviction(newEviction);
                    _currentIndexEvictions = _evictions.Count - 1;
                    SetLabel(lblEviction, _currentIndexEvictions + 1, _evictions.Count());
                }
            }
        }

        private void btnPreEviction_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_evictions != null && _evictions.Any())
            {
                SaveCurrentEviction();
                int preIndex = _currentIndexEvictions - 1;

                if (_evictions.ElementAtOrDefault(preIndex) == null)
                {
                    return;
                }

                if (_evictions[preIndex] != null)
                {
                    SetLabel(lblEviction, preIndex + 1, _evictions.Count());
                    this.SetCurrentEviction(_evictions[preIndex]);
                    _currentIndexEvictions = preIndex;
                }
            }
        }

        private void btnNextEviction_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_evictions != null && _evictions.Any())
            {
                SaveCurrentEviction();
                int nextIndex = _currentIndexEvictions + 1;

                if (_evictions.ElementAtOrDefault(nextIndex) == null) return;

                if (_evictions[nextIndex] != null)
                {
                    SetLabel(lblEviction, nextIndex + 1, _evictions.Count);
                    this.SetCurrentEviction(_evictions[nextIndex]);
                    _currentIndexEvictions = nextIndex;
                }
            }
        }

        private void btnCopyEviction_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_evictions.Count == 0) return;
            SaveCurrentEviction();
            EvictionRefData currentEviction = GetCurrentEviction();

            List<EvictionRefData> evictions = new List<EvictionRefData>();
            if (currentEviction != null)
            {
                int index = 0;
                if (_evictions.Count == 1)
                {
                    evictions.Add(_evictions[0]);
                    evictions.Add(currentEviction);

                    _evictions = evictions;
                    _currentIndexEvictions = _evictions.Count - 1;
                }
                else if (_evictions.Count > 1)
                {
                    for (int i = 0; i <= _evictions.Count; i++)
                    {
                        if (i.Equals(_currentIndexEvictions + 1))
                        {
                            evictions.Add(currentEviction);
                            index = _currentIndexEvictions + 1;
                        }
                        if (i == _evictions.Count) break;
                        evictions.Add(_evictions[i]);
                    }

                    _evictions = evictions;
                    _currentIndexEvictions = index;
                }

                if (_evictions.ElementAt(_currentIndexEvictions) != null)
                {
                    SetCurrentEviction(_evictions[_currentIndexEvictions]);
                    SetLabel(lblEviction, _currentIndexEvictions + 1, _evictions.Count);
                }
            }
        }

        private void btnDelEviction_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_evictions == null || _evictions.Count == 0) return;

            if (MessageBox.Show("Delete the Eviction that is currently being displayed ?", "Delete Eviction", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (_evictions != null && _evictions.Any())
                {
                    _evictions.RemoveAt(_currentIndexEvictions);

                    if (_evictions.ElementAtOrDefault(_currentIndexEvictions) != null)
                    {
                        EvictionRefData eviction = _evictions[_currentIndexEvictions];
                        SetCurrentEviction(eviction);
                        SetLabel(lblEviction, _currentIndexEvictions + 1, _evictions.Count);
                    }
                    else
                    {
                        _currentIndexEvictions = _currentIndexEvictions - 1;
                        if (_evictions.ElementAtOrDefault(_currentIndexEvictions) != null)
                        {
                            EvictionRefData eviction = _evictions[_currentIndexEvictions];
                            SetCurrentEviction(eviction);
                            SetLabel(lblEviction, _currentIndexEvictions + 1, _evictions.Count);
                        }
                        else
                        {
                            SetLabel(lblEviction, 0, 0);
                            ResetEviction();
                            DisableEviction();
                        }
                    }
                }
            }
        }

        #endregion control events Evictions

        #region hotkey events

        public void ShortcutKeyHandler()
        {

        }

        #endregion

        private void btnChargeUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            ChargeRefData currentItem = GetCurrentCharge();
            int currentIndex = _currentIndexCharges;

            if (_currentIndexCharges < _charges.Count - 1)
            {
                var tmp = _charges[currentIndex];
                _charges[currentIndex] = _charges[currentIndex + 1];
                _charges[currentIndex + 1] = tmp;
            }
            else return;

            SetCurrentCharge(_charges[currentIndex + 1]);

            _currentIndexCharges = currentIndex + 1;

            this.SetLabel(lblCharge, _currentIndexCharges + 1, _charges.Count);
        }

        private void btnChargeDown_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            ChargeRefData currentItem = GetCurrentCharge();
            int currentIndex = _currentIndexCharges;

            if (_currentIndexCharges > 0)
            {
                var tmp = _charges[currentIndex];
                _charges[currentIndex] = _charges[currentIndex - 1];
                _charges[currentIndex - 1] = tmp;
            }
            else return;

            SetCurrentCharge(_charges[currentIndex - 1]);

            _currentIndexCharges = currentIndex - 1;

            this.SetLabel(lblCharge, _currentIndexCharges + 1, _charges.Count);
        }

        private void btnEvicUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            EvictionRefData currentItem = GetCurrentEviction();
            int currentIndex = _currentIndexEvictions;

            if (_currentIndexEvictions < _evictions.Count - 1)
            {
                var tmp = _evictions[currentIndex];
                _evictions[currentIndex] = _evictions[currentIndex + 1];
                _evictions[currentIndex + 1] = tmp;
            }
            else return;

            SetCurrentEviction(_evictions[currentIndex + 1]);

            _currentIndexEvictions = currentIndex + 1;

            this.SetLabel(lblEviction, _currentIndexEvictions + 1, _evictions.Count);
        }

        private void btnEvicDown_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            EvictionRefData currentItem = GetCurrentEviction();
            int currentIndex = _currentIndexEvictions;

            if (_currentIndexEvictions > 0)
            {
                var tmp = _evictions[currentIndex];
                _evictions[currentIndex] = _evictions[currentIndex - 1];
                _evictions[currentIndex - 1] = tmp;
            }
            else return;

            SetCurrentEviction(_evictions[currentIndex - 1]);

            _currentIndexEvictions = currentIndex - 1;

            this.SetLabel(lblEviction, _currentIndexEvictions + 1, _evictions.Count);
        }

        #region Drag Drop

        private void btnCopyChargeToOtherApp_MouseDown(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_charges == null || _charges.Count == 0 || _currentIndexCharges < 0)
            {
                return;
            }

            ChargeRefData currentData = _charges[_currentIndexCharges];
            if (currentData == null)
            {
                return;
            }

            _currentActionCopyToOtherApp = ActionCopyToOtherApp.Charge;

            DragDropData.ChargeRef data = new DragDropData.ChargeRef();
            data.list = AutoMapper.Mapper.Map<List<ChargeRefData>, List<ChargeRefData>>(_charges);
            data.currentIndex = _currentIndexCharges;

            btnCopyChargeToOtherApp.DoDragDrop(data, DragDropEffects.Move);
        }

        private void btnCopyChargeToOtherApp_MouseUp(object sender, MouseEventArgs e)
        {
            _currentActionCopyToOtherApp = ActionCopyToOtherApp.None;
        }

        private void btnCopyEvictionToOtherApp_MouseDown(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_evictions == null || _evictions.Count == 0 || _currentIndexEvictions < 0)
            {
                return;
            }

            EvictionRefData currentData = _evictions[_currentIndexEvictions];
            if (currentData == null)
            {
                return;
            }

            _currentActionCopyToOtherApp = ActionCopyToOtherApp.Eviction;

            DragDropData.EvictionRef data = new DragDropData.EvictionRef();
            data.list = AutoMapper.Mapper.Map<List<EvictionRefData>, List<EvictionRefData>>(_evictions);
            data.currentIndex = _currentIndexEvictions;

            btnCopyEvictionToOtherApp.DoDragDrop(data, DragDropEffects.Move);
        }

        private void btnCopyEvictionToOtherApp_MouseUp(object sender, MouseEventArgs e)
        {
            _currentActionCopyToOtherApp = ActionCopyToOtherApp.None;
        }

        #endregion

        #region txtDate2
        private void txtDate2_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtDate2);
        }
        #endregion

        #region txtHeading2
        private void txtHeading2_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtHeading2);
        }
        #endregion

        #region txtOwner
        private void txtOwner_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtOwner);
        }
        #endregion

        #region txtState2
        private void txtState2_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtState2);
        }
        #endregion

        #region txtCounty2
        private void txtCounty2_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtCounty2);
        }
        #endregion

        #region txtSentence
        private void txtSentence_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtSentence);
        }
        #endregion

        #region txtDate1
        private void txtDate1_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtDate1);
        }
        #endregion

        #region txtCharge
        private void txtCharge_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtCharge);
        }
        #endregion

        #region txtCounty1
        private void txtCounty1_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtCounty1);
        }
        #endregion

        #region txtState1
        private void txtState1_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtState1);
        }
        #endregion

        #region txtHeading1
        private void txtHeading1_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtHeading1);
        }
        #endregion


    }
}
