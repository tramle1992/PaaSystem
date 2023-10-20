using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PaaApplication.Forms.ClientInfo;
using Core.Application.Data.ClientInfo;
using Core.Infrastructure.ClientInfo;
using Common.Infrastructure.Office;
using PaaApplication.Helper;
using OpenXmlPowerTools;
using PaaApplication.Models.Common;
using PaaApplication.Models.ClientInfo;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using Common.Infrastructure.Helper;

namespace PaaApplication.UserControls.ClientInfo
{
    public partial class ClientLabelControl : UserControl
    {
        private List<ClientGridData> _lstClientData;
        private Control currControl = new Control();
        GroupBox grbAvailabelAddr = new GroupBox();
        ComboBox cmbAvaiAddr = new ComboBox();
        List<ClientData> clients = ClientCachedApiQuery.Instance.GetAllClients();

        LabelMakerHelper.LabelMaker LblMaker = new LabelMakerHelper.LabelMaker();

        private int currentPage = 1;
        private int flagFirstItem = 0;
        private int flagLastItem = 210;
        private int flagNumPageShow = 7;
        int buttonNumber = 1;

        private string selectedText = string.Empty;

        public ClientLabelControl()
        {
            InitializeComponent(LblMaker.LabelSize);
            _lstClientData = new List<ClientGridData>();
            CreateComboboxForAddLabel();
        }

        public void InitializeSettings()
        {
        }

        public void Refresh(List<ClientGridData> lst)
        {
            this._lstClientData = lst;
            CreateButtons();
            AddTextBox();
        }

        private void AddTextBox()
        {
            tabelFlowLayoutPanel.Hide();
            if (tabelFlowLayoutPanel.Controls.Count > 0)
                {
                    tabelFlowLayoutPanel.Controls.Clear();
                }
            for (int i = flagFirstItem; i < flagLastItem; i++)
            {
                if (_lstClientData.Count() <= i)
                {
                    var client = new ClientGridData();
                    _lstClientData.Add(client);
                }
                var textBox = CreateTextBox(i);
                tabelFlowLayoutPanel.Controls.Add(textBox);
            }
            tabelFlowLayoutPanel.Show();
        }

        private TextBox CreateTextBox(int index)
        {
            TextBox textBox = new TextBox()
            {
                Text =
                (index != -1 && _lstClientData[index] != null && (!string.IsNullOrEmpty(_lstClientData[index].ClientName) || !string.IsNullOrEmpty(_lstClientData[index].BillingAddress)))
                ? _lstClientData[index].ClientName + "\r\n" + _lstClientData[index].BillingAddress
                : string.Empty,
                Name = "txt" + tabelFlowLayoutPanel.Controls.Count.ToString(),
                BackColor = System.Drawing.Color.White,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                Multiline = true,
                Size = LblMaker.TextBoxSize,
                TextAlign = System.Windows.Forms.HorizontalAlignment.Center,
                TabStop = false,
                Margin = new Padding(1),
                ContextMenuStrip = this.labelContextMenuStrip
            };
            textBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtLabel_MouseDown);
            textBox.KeyDown += new KeyEventHandler(this.txtLabel_KeyDown);
            return textBox;
        }

        private void CreateButtons()
        {
            bool isVisibleGoFirst = true;

            buttonNumber = _lstClientData.Count / LblMaker.NumOfItemPerPage;
            buttonNumber = ((_lstClientData.Count % LblMaker.NumOfItemPerPage) == 0 && buttonNumber != 0) ? buttonNumber : buttonNumber + 1;
            if (buttonNumber < 7)
            {
                flagNumPageShow = buttonNumber;
            }
            
            if (buttonsFlowLayoutPanel.Controls.Count > 0)
            {
                buttonsFlowLayoutPanel.Controls.Clear();
            }

            int index = (flagNumPageShow > 7) ? flagNumPageShow - 7 : 0;
                        
            for (int i = index; i < flagNumPageShow; i++)
            {
                Button button = new Button
                {
                    Name = string.Format("btnPage{0}", i + 1),
                    Text = string.Format("{0}", i + 1),
                    Size = new System.Drawing.Size(40, 21)
                };
                button.Click += new System.EventHandler(this.btnPage_Click);
                buttonsFlowLayoutPanel.Controls.Add(button);
                if(button.Name.Equals("btnPage1"))
                {
                    isVisibleGoFirst = false;
                }
            }

            if (buttonNumber > flagNumPageShow)
            {
                //Create ... button
                Button btnThreeDot = new Button
                {
                    Name = "btnThreeDot",
                    Text = "...",
                    Size = new System.Drawing.Size(40, 21)
                };
                btnThreeDot.Click += new System.EventHandler(this.btnPage_Click);
                buttonsFlowLayoutPanel.Controls.Add(btnThreeDot);

                //Create last page button
                Button lastPageButton = new Button
                {
                    Name = string.Format("btnPage{0}", buttonNumber),
                    Text = buttonNumber.ToString(),
                    Size = new System.Drawing.Size(40, 21),
                };
                lastPageButton.Click += new System.EventHandler(this.btnPage_Click);
                buttonsFlowLayoutPanel.Controls.Add(lastPageButton);
                //Create go last button
                Button btnGoLast = new Button
                {
                    Name = "btnGoLast",
                    Text = ">|",
                    Size = new System.Drawing.Size(40, 21)
                };
                btnGoLast.Click += new System.EventHandler(this.btnPage_Click);
                buttonsFlowLayoutPanel.Controls.Add(btnGoLast);
            }

            if(isVisibleGoFirst)
            {
                //Create go first button
                Button btnGoFirst = new Button
                {
                    Name = "btnGoFirst",
                    Text = "|<",
                    Size = new System.Drawing.Size(40, 21)
                };
                btnGoFirst.Click += new System.EventHandler(this.btnPage_Click);
                buttonsFlowLayoutPanel.Controls.Add(btnGoFirst);
                buttonsFlowLayoutPanel.Controls.SetChildIndex(btnGoFirst, 0);
            }
        }

        private void btnPage_Click(object sender, EventArgs e)
        {
            int currPageClicked = currentPage;
            if (int.TryParse(((Button)sender).Text, out currPageClicked))
            {
                if (currPageClicked != currentPage)
                {
                    currentPage = currPageClicked;
                    flagLastItem = currentPage * LblMaker.NumOfItemPerPage;
                    flagFirstItem = flagLastItem - LblMaker.NumOfItemPerPage;
                    AddTextBox();
                }
            }
            else
            {
                if(((Button)sender).Name == "btnThreeDot")
                {
                    currentPage = flagNumPageShow + 1;
                    flagNumPageShow = flagNumPageShow + 7;
                    if (flagNumPageShow > buttonNumber)
                    {
                        flagNumPageShow = buttonNumber;
                    }                    
                    flagLastItem = currentPage * LblMaker.NumOfItemPerPage;
                    flagFirstItem = flagLastItem - LblMaker.NumOfItemPerPage;
                    CreateButtons();
                    AddTextBox();
                }
                if(((Button)sender).Name == "btnGoFirst")
                {
                    currentPage = 1;
                    flagFirstItem = 0;
                    flagLastItem = LblMaker.NumOfItemPerPage;
                    flagNumPageShow = 7;
                    CreateButtons();
                    AddTextBox();
                }
                if (((Button)sender).Name == "btnGoLast")
                {
                    currentPage = buttonNumber;
                    flagLastItem = currentPage * LblMaker.NumOfItemPerPage;
                    flagFirstItem = flagLastItem - LblMaker.NumOfItemPerPage;
                    flagNumPageShow = buttonNumber;
                    CreateButtons();
                    AddTextBox();
                }

            }           
        }

        private void largeLabels4X313ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!LblMaker.LabelSize.Equals("Large"))
            {
                LblMaker = new LabelMakerHelper.LabelMaker("Large");
                int newWidth = (tabelFlowLayoutPanel.Width - 100) / LblMaker.ItemPerRow;
                LblMaker.TextBoxSize = new Size(newWidth, LblMaker.TextBoxSize.Height);
                tabelFlowLayoutPanel.SuspendLayout();
                foreach (Control ctrl in tabelFlowLayoutPanel.Controls)
                {
                    ctrl.Width = newWidth;
                }
                tabelFlowLayoutPanel.ResumeLayout();
                if (tabelFlowLayoutPanel.Controls.Count > LblMaker.NumOfItemPerPage)
                {
                    tabelFlowLayoutPanel.Controls.RemoveAt(LblMaker.NumOfItemPerPage);
                }
                CreateButtons();
            }
        }

        private void smallLabels1X258ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!LblMaker.LabelSize.Equals("Small"))
            {
                LblMaker = new LabelMakerHelper.LabelMaker();
                int newWidth = (tabelFlowLayoutPanel.Width - 100) / LblMaker.ItemPerRow;
                LblMaker.TextBoxSize = new Size(newWidth, LblMaker.TextBoxSize.Height);
                tabelFlowLayoutPanel.SuspendLayout();
                foreach (Control ctrl in tabelFlowLayoutPanel.Controls)
                {
                    ctrl.Width = newWidth;
                }
                tabelFlowLayoutPanel.ResumeLayout();
                if (tabelFlowLayoutPanel.Controls.Count < LblMaker.NumOfItemPerPage)
                {
                    int i = LblMaker.NumOfItemPerPage - 1;
                    var textBox = CreateTextBox(i);
                    tabelFlowLayoutPanel.Controls.Add(textBox);
                }
                CreateButtons();
            }
        }

        private void insertLabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flagLastItem = currentPage * LblMaker.NumOfItemPerPage;
            flagFirstItem = flagLastItem - LblMaker.NumOfItemPerPage;
            int index = tabelFlowLayoutPanel.Controls.GetChildIndex(currControl);
            int indexInClientList = index + flagFirstItem;
            var client = new ClientGridData();
            _lstClientData.Insert(indexInClientList, client);

            var textBox = CreateTextBox(-1);
            tabelFlowLayoutPanel.Controls.Add(textBox);
            tabelFlowLayoutPanel.Controls.SetChildIndex(textBox, index);

            if (tabelFlowLayoutPanel.Controls.Count > LblMaker.NumOfItemPerPage)
            {
                tabelFlowLayoutPanel.Controls.RemoveAt(LblMaker.NumOfItemPerPage);
            }
            CreateButtons();
        }

        private void deleteThisLabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flagLastItem = currentPage * LblMaker.NumOfItemPerPage;
            flagFirstItem = flagLastItem - LblMaker.NumOfItemPerPage;
            int index = tabelFlowLayoutPanel.Controls.GetChildIndex(currControl);
            int indexInClientList = index + flagFirstItem;
            _lstClientData.RemoveAt(indexInClientList);
            tabelFlowLayoutPanel.Controls.RemoveAt(index);

            if (tabelFlowLayoutPanel.Controls.Count < LblMaker.NumOfItemPerPage)
            {
                var textBox = CreateTextBox(flagLastItem - 1);
                tabelFlowLayoutPanel.Controls.Add(textBox);
            }
            CreateButtons();
        }

        private void addLabelFrClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grbAvailabelAddr.Visible = true;
            grbAvailabelAddr.BringToFront();
            grbAvailabelAddr.Location = new System.Drawing.Point(currControl.Location.X, currControl.Location.Y + 47);

            cmbAvaiAddr.DataSource = clients;
            cmbAvaiAddr.DisplayMember = "ClientName";
            cmbAvaiAddr.ValueMember = "ClientId";
            cmbAvaiAddr.SelectedItem = clients.FirstOrDefault(cl => (cl.ClientName + "\r\n" + cl.BillingAddress) == currControl.Text);
            cmbAvaiAddr.Focus();

        }

        private void printLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WordService word = null;
            try
            {
                string documentFile = GenerateDocumentReportOpenXML();
                word = new WordService(documentFile, "Labels", false);
                word.Print(1);
            }
            catch (Exception ex)
            {
                if (word != null)
                    word.Quit();
                throw new Exception("There were errors when printing labels");
            }
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(currControl is TextBox)
            {
                TextBox textBox = currControl as TextBox;
                // Ensure that text is selected in the text box.   
                if (textBox.SelectionLength > 0)
                {
                    // Copy the selected text to the Clipboard.
                    textBox.Copy();
                }
            }
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currControl is TextBox)
            {
                TextBox textBox = currControl as TextBox;
                // Ensure that text is currently selected in the text box.   
                if (textBox.SelectedText != string.Empty)
                {
                    // Cut the selected text in the control and paste it into the Clipboard.
                    textBox.Cut();

                    //Update text after client changed
                    UpdateTextAfterChanged(textBox);
                }
            }
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currControl is TextBox)
            {
                TextBox textBox = currControl as TextBox;
                // Determine if there is any text in the Clipboard to paste into the text box.
                if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
                {
                    // Determine if any text is selected in the text box.
                    if (textBox.SelectionLength > 0)
                    {
                        // Move selection to the point after the current selection and paste.
                        textBox.SelectionStart = textBox.SelectionStart + textBox.SelectionLength;
                    }
                    // Paste current text in Clipboard into text box.
                    textBox.Paste();
                    
                    //Update text after client changed
                    UpdateTextAfterChanged(textBox);                    
                }
            }
        }

        private void UpdateTextAfterChanged(TextBox textBox)
        {
            
            int index = tabelFlowLayoutPanel.Controls.GetChildIndex(currControl);
            int indexInClientList = index + flagFirstItem;
            _lstClientData[indexInClientList].ClientName = textBox.Text;
            _lstClientData[indexInClientList].BillingAddress = string.Empty;
        }

        public string GenerateDocumentReportOpenXML()
        {
            string toSaveFileName = string.Format("{0}LabelTemp",LblMaker.LabelSize);
            TemplateHelper templateHelper = new TemplateHelper();

            List<Source> documentBuilderSources = new List<Source>();
            List<string> labels = _lstClientData.Where(cl => !string.IsNullOrEmpty(cl.ClientName) || !string.IsNullOrEmpty(cl.BillingAddress)).Select(cl => cl.ClientName + "\r\n" + cl.BillingAddress).ToList();

            Dictionary<string, int> lstLabels = GetLabelItems(labels);

            foreach (var item in lstLabels)
            {
                string filename = "";
                WordDocumentType wordType = new WordDocumentType();
                switch (LblMaker.LabelSize)
                {
                    case "Large":
                        filename = WordTemplatePathResolver.GetTemplateFileName(WordDocumentType.LargeLabel);
                        wordType = WordDocumentType.LargeLabel;
                        break;
                    default:
                        filename = WordTemplatePathResolver.GetTemplateFileName(WordDocumentType.SmallLabel);
                        wordType = WordDocumentType.SmallLabel;
                        break;
                }

                if (!string.IsNullOrEmpty(filename))
                {
                    string url = string.Format("api/templates");
                    string savePath = WordTemplatePathResolver.GetWordTemplatePath(wordType);
                    templateHelper.DownloadTemplate(savePath, filename);
                }
            }

            foreach (var item in lstLabels)
            {
                WordDocumentBuilder wordDoc = new WordDocumentBuilder();
                wordDoc.BuildLabel(documentBuilderSources, LblMaker.LabelSize, labels, item.Value);
            }
            WmlDocument mergedDocument = DocumentBuilder.BuildDocument(documentBuilderSources);

            byte[] byteArray = mergedDocument.DocumentByteArray;

            string workingFilePath = string.Empty;
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    WordMLService.RemoveHeadersAndFooters(wordDoc);
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

        private Dictionary<string, int> GetLabelItems(List<string> labels)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            string bufferName = "Label";

            int numOfLabels = (labels == null) ? 0 : labels.Count;
            if (LblMaker.LabelSize.Equals("Large"))
            {
                for (int i = 0; i < numOfLabels; i = i + 4)
                {
                    int pageNo = ((i) / 4) + 1;
                    string reportName = string.Format(bufferName + " (Page {0})", pageNo);
                    result.Add(reportName, pageNo);
                }
            }
            else
            {
                for (int i = 0; i < numOfLabels; i = i + 30)
                {
                    int pageNo = ((i) / 30) + 1;
                    string reportName = string.Format(bufferName + " (Page {0})", pageNo);
                    result.Add(reportName, pageNo);
                }
            }
            return result;
        }


        private void txtLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (grbAvailabelAddr.Visible)
            {
                grbAvailabelAddr.Visible = false;
            }
            currControl = (Control)sender;
        }


        private void txtLabel_KeyDown(object sender, KeyEventArgs e)
        {
            UpdateTextAfterChanged((TextBox)sender);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.X:
                    if (currControl is TextBox)
                    {
                        TextBox textBox = currControl as TextBox;
                        // Ensure that text is currently selected in the text box.   
                        if (textBox.SelectedText != string.Empty)
                        {
                            // Cut the selected text in the control and paste it into the Clipboard.
                            textBox.Cut();

                            //Update text after client changed
                            UpdateTextAfterChanged(textBox);
                        }
                    }
                    return true;
                case Keys.Control | Keys.V:
                    if (currControl is TextBox)
                    {
                        TextBox textBox = currControl as TextBox;
                        // Determine if there is any text in the Clipboard to paste into the text box.
                        if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
                        {
                            // Determine if any text is selected in the text box.
                            if (textBox.SelectionLength > 0)
                            {
                                // Move selection to the point after the current selection and paste.
                                textBox.SelectionStart = textBox.SelectionStart + textBox.SelectionLength;
                            }
                            // Paste current text in Clipboard into text box.
                            textBox.Paste();

                            //Update text after client changed
                            UpdateTextAfterChanged(textBox);
                        }
                    }
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void cmbAvaiAddr_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            if (!cmb.Focused)
                return;
            ClientData client = (ClientData)cmb.SelectedItem;            
            int index = tabelFlowLayoutPanel.Controls.GetChildIndex(currControl);
            index = index + flagFirstItem;
            if (client != null)
            {
                currControl.Text = client.ClientName + "\r\n" + client.BillingAddress;

                if (_lstClientData.Count > index)
                {
                    _lstClientData[index].ClientName = client.ClientName;
                    _lstClientData[index].BillingAddress = client.BillingAddress;
                }
                else
                {
                    var clientData = new ClientGridData
                    {
                        ClientName = client.ClientName,
                        BillingAddress = client.BillingAddress
                    };
                    _lstClientData.Add(clientData);
                }
            }
        }

        private void CreateComboboxForAddLabel()
        {
            grbAvailabelAddr.Controls.Add(cmbAvaiAddr);
            grbAvailabelAddr.Visible = false;

            // Set properties of the GroupBox.
            grbAvailabelAddr.Location = new System.Drawing.Point(339, 286);
            grbAvailabelAddr.Name = "grbAvailabelAddr";
            grbAvailabelAddr.Size = new System.Drawing.Size(226, 40);
            grbAvailabelAddr.Text = "Available Address";

            // Set properties of the Combobox.
            cmbAvaiAddr.Location = new Point(5, 14);
            cmbAvaiAddr.Name = "cmbAvaiAddr";
            cmbAvaiAddr.Size = new System.Drawing.Size(220, 18);
            cmbAvaiAddr.Focus();

            //Set events of Combobox
            cmbAvaiAddr.SelectedValueChanged += new System.EventHandler(this.cmbAvaiAddr_SelectedIndexChanged);

            // Add the Groupbox to the form.
            this.Controls.Add(grbAvailabelAddr);
        }

        private void tabelFlowLayoutPanel_SizeChanged(object sender, EventArgs e)
        {
            if (tabelFlowLayoutPanel.Controls.Count > 0)
            {
                int newWidth = (tabelFlowLayoutPanel.Width - 100) / LblMaker.ItemPerRow;
                LblMaker.TextBoxSize = new Size(newWidth, LblMaker.TextBoxSize.Height);
                tabelFlowLayoutPanel.SuspendLayout();
                foreach (Control ctrl in tabelFlowLayoutPanel.Controls)
                {
                    ctrl.Width = newWidth;
                }
                tabelFlowLayoutPanel.ResumeLayout();
            }
        }

        private void tabelFlowLayoutPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if(grbAvailabelAddr.Visible == true)
            {
                grbAvailabelAddr.Visible = false;
            }
        }
    }
}
