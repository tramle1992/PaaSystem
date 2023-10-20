using PaaApplication.ExtendControls;

namespace PaaApplication.UserControls.AppExplore.GeneralInfo
{
    partial class AppMenuControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            cmbSceener.ComboBoxClear();
            cmbLocation.ComboBoxClear();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppMenuControl));
            this.tabAppContact = new System.Windows.Forms.TabControl();
            this.tabAppInfo = new System.Windows.Forms.TabPage();
            this.cmbLocation = new ImageComboBox.ImageComboBox();
            this.cmbSceener = new ImageComboBox.ImageComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblScreener = new System.Windows.Forms.Label();
            this.tabContacts = new System.Windows.Forms.TabPage();
            this.lblContactAttemp = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnDelAttempt = new System.Windows.Forms.Button();
            this.btnNewAttempt = new System.Windows.Forms.Button();
            this.txtPhoneFax = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtOtherAddr = new System.Windows.Forms.TextBox();
            this.chboxReturned = new System.Windows.Forms.CheckBox();
            this.lblCall = new System.Windows.Forms.Label();
            this.cmbAttempt = new System.Windows.Forms.ComboBox();
            this.lblRecipient = new System.Windows.Forms.Label();
            this.olvReportList = new BrightIdeasSoftware.ObjectListView();
            this.olvcolReports = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cmbPrintOptions = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecevedD = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.dtpReceivedDate = new System.Windows.Forms.DateTimePicker();
            this.btnCompleteApp = new System.Windows.Forms.Button();
            this.btnGoto = new System.Windows.Forms.Button();
            this.btnReviewComm = new System.Windows.Forms.Button();
            this.dtpCompletedDate = new System.Windows.Forms.DateTimePicker();
            this.screenerImageList = new System.Windows.Forms.ImageList(this.components);
            this.locationImageList = new System.Windows.Forms.ImageList(this.components);
            this.btnInProcessTest = new PaaApplication.ExtendControls.DoubleClickButton();
            this.btnCompleteTest = new PaaApplication.ExtendControls.DoubleClickButton();
            this.tabAppContact.SuspendLayout();
            this.tabAppInfo.SuspendLayout();
            this.tabContacts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvReportList)).BeginInit();
            this.SuspendLayout();
            // 
            // tabAppContact
            // 
            this.tabAppContact.Controls.Add(this.tabAppInfo);
            this.tabAppContact.Controls.Add(this.tabContacts);
            this.tabAppContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabAppContact.Location = new System.Drawing.Point(3, 259);
            this.tabAppContact.Name = "tabAppContact";
            this.tabAppContact.SelectedIndex = 0;
            this.tabAppContact.Size = new System.Drawing.Size(308, 328);
            this.tabAppContact.TabIndex = 0;
            // 
            // tabAppInfo
            // 
            this.tabAppInfo.Controls.Add(this.cmbLocation);
            this.tabAppInfo.Controls.Add(this.cmbSceener);
            this.tabAppInfo.Controls.Add(this.lblLocation);
            this.tabAppInfo.Controls.Add(this.lblScreener);
            this.tabAppInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabAppInfo.Location = new System.Drawing.Point(4, 24);
            this.tabAppInfo.Name = "tabAppInfo";
            this.tabAppInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabAppInfo.Size = new System.Drawing.Size(300, 300);
            this.tabAppInfo.TabIndex = 0;
            this.tabAppInfo.Text = "Applicant Info";
            this.tabAppInfo.UseVisualStyleBackColor = true;
            // 
            // cmbLocation
            // 
            this.cmbLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLocation.DisplayMember = "Text";
            this.cmbLocation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.ImageList = null;
            this.cmbLocation.Indent = 0;
            this.cmbLocation.ItemHeight = 28;
            this.cmbLocation.Location = new System.Drawing.Point(6, 129);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(288, 34);
            this.cmbLocation.TabIndex = 173;
            this.cmbLocation.ValueMember = "Item";
            this.cmbLocation.SelectionChangeCommitted += new System.EventHandler(this.cmbLocation_SelectionChangeCommitted);
            this.cmbLocation.Enter += new System.EventHandler(this.cmbLocation_Enter);
            // 
            // cmbSceener
            // 
            this.cmbSceener.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSceener.DisplayMember = "Text";
            this.cmbSceener.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbSceener.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSceener.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbSceener.FormattingEnabled = true;
            this.cmbSceener.ImageList = null;
            this.cmbSceener.Indent = 0;
            this.cmbSceener.ItemHeight = 28;
            this.cmbSceener.Location = new System.Drawing.Point(6, 51);
            this.cmbSceener.Name = "cmbSceener";
            this.cmbSceener.Size = new System.Drawing.Size(288, 34);
            this.cmbSceener.TabIndex = 172;
            this.cmbSceener.ValueMember = "Item";
            this.cmbSceener.SelectionChangeCommitted += new System.EventHandler(this.cmbSceener_SelectionChangeCommitted);
            this.cmbSceener.Enter += new System.EventHandler(this.cmbSceener_Enter);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblLocation.Location = new System.Drawing.Point(6, 109);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(64, 13);
            this.lblLocation.TabIndex = 0;
            this.lblLocation.Text = "LOCATION:";
            // 
            // lblScreener
            // 
            this.lblScreener.AutoSize = true;
            this.lblScreener.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScreener.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblScreener.Location = new System.Drawing.Point(4, 31);
            this.lblScreener.Name = "lblScreener";
            this.lblScreener.Size = new System.Drawing.Size(69, 13);
            this.lblScreener.TabIndex = 0;
            this.lblScreener.Text = "SCREENER:";
            // 
            // tabContacts
            // 
            this.tabContacts.Controls.Add(this.lblContactAttemp);
            this.tabContacts.Controls.Add(this.btnNext);
            this.tabContacts.Controls.Add(this.btnPrevious);
            this.tabContacts.Controls.Add(this.txtComment);
            this.tabContacts.Controls.Add(this.btnDelAttempt);
            this.tabContacts.Controls.Add(this.btnNewAttempt);
            this.tabContacts.Controls.Add(this.txtPhoneFax);
            this.tabContacts.Controls.Add(this.lblPhone);
            this.tabContacts.Controls.Add(this.txtOtherAddr);
            this.tabContacts.Controls.Add(this.chboxReturned);
            this.tabContacts.Controls.Add(this.lblCall);
            this.tabContacts.Controls.Add(this.cmbAttempt);
            this.tabContacts.Controls.Add(this.lblRecipient);
            this.tabContacts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabContacts.Location = new System.Drawing.Point(4, 24);
            this.tabContacts.Name = "tabContacts";
            this.tabContacts.Padding = new System.Windows.Forms.Padding(3);
            this.tabContacts.Size = new System.Drawing.Size(300, 300);
            this.tabContacts.TabIndex = 1;
            this.tabContacts.Text = "Contact Attempts";
            this.tabContacts.UseVisualStyleBackColor = true;
            // 
            // lblContactAttemp
            // 
            this.lblContactAttemp.AutoSize = true;
            this.lblContactAttemp.Location = new System.Drawing.Point(262, 15);
            this.lblContactAttemp.Name = "lblContactAttemp";
            this.lblContactAttemp.Size = new System.Drawing.Size(0, 15);
            this.lblContactAttemp.TabIndex = 180;
            // 
            // btnNext
            // 
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(239, 265);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(55, 29);
            this.btnNext.TabIndex = 179;
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Image")));
            this.btnPrevious.Location = new System.Drawing.Point(5, 265);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(55, 29);
            this.btnPrevious.TabIndex = 178;
            this.btnPrevious.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtComment.Location = new System.Drawing.Point(6, 182);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComment.Size = new System.Drawing.Size(288, 78);
            this.txtComment.TabIndex = 12;
            // 
            // btnDelAttempt
            // 
            this.btnDelAttempt.BackColor = System.Drawing.Color.Gray;
            this.btnDelAttempt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelAttempt.ForeColor = System.Drawing.Color.White;
            this.btnDelAttempt.Location = new System.Drawing.Point(159, 265);
            this.btnDelAttempt.Name = "btnDelAttempt";
            this.btnDelAttempt.Size = new System.Drawing.Size(60, 29);
            this.btnDelAttempt.TabIndex = 15;
            this.btnDelAttempt.Text = "&Delete";
            this.btnDelAttempt.UseVisualStyleBackColor = false;
            this.btnDelAttempt.Click += new System.EventHandler(this.btnDelAttempt_Click);
            // 
            // btnNewAttempt
            // 
            this.btnNewAttempt.BackColor = System.Drawing.Color.Gray;
            this.btnNewAttempt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewAttempt.ForeColor = System.Drawing.Color.White;
            this.btnNewAttempt.Location = new System.Drawing.Point(80, 265);
            this.btnNewAttempt.Name = "btnNewAttempt";
            this.btnNewAttempt.Size = new System.Drawing.Size(60, 29);
            this.btnNewAttempt.TabIndex = 14;
            this.btnNewAttempt.Text = "&New";
            this.btnNewAttempt.UseVisualStyleBackColor = false;
            this.btnNewAttempt.Click += new System.EventHandler(this.btnNewAttempt_Click);
            // 
            // txtPhoneFax
            // 
            this.txtPhoneFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneFax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPhoneFax.Location = new System.Drawing.Point(6, 151);
            this.txtPhoneFax.Name = "txtPhoneFax";
            this.txtPhoneFax.Size = new System.Drawing.Size(288, 21);
            this.txtPhoneFax.TabIndex = 11;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPhone.Location = new System.Drawing.Point(4, 131);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(122, 13);
            this.lblPhone.TabIndex = 177;
            this.lblPhone.Text = "PHONE / FAX / EMAIL:";
            // 
            // txtOtherAddr
            // 
            this.txtOtherAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtherAddr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtOtherAddr.Location = new System.Drawing.Point(6, 94);
            this.txtOtherAddr.Name = "txtOtherAddr";
            this.txtOtherAddr.Size = new System.Drawing.Size(288, 21);
            this.txtOtherAddr.TabIndex = 10;
            // 
            // chboxReturned
            // 
            this.chboxReturned.AutoSize = true;
            this.chboxReturned.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxReturned.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chboxReturned.Location = new System.Drawing.Point(6, 46);
            this.chboxReturned.Name = "chboxReturned";
            this.chboxReturned.Size = new System.Drawing.Size(165, 19);
            this.chboxReturned.TabIndex = 9;
            this.chboxReturned.Text = "Returned or Resolved";
            this.chboxReturned.UseVisualStyleBackColor = true;
            // 
            // lblCall
            // 
            this.lblCall.AutoSize = true;
            this.lblCall.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCall.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblCall.Location = new System.Drawing.Point(224, 15);
            this.lblCall.Name = "lblCall";
            this.lblCall.Size = new System.Drawing.Size(36, 15);
            this.lblCall.TabIndex = 174;
            this.lblCall.Text = "Call:";
            // 
            // cmbAttempt
            // 
            this.cmbAttempt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAttempt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbAttempt.FormattingEnabled = true;
            this.cmbAttempt.Items.AddRange(new object[] {
            "Rental Reference",
            "Employment",
            "Criminal Info.",
            "Credit/Bank Ref.",
            "Client Update"});
            this.cmbAttempt.Location = new System.Drawing.Point(6, 12);
            this.cmbAttempt.Name = "cmbAttempt";
            this.cmbAttempt.Size = new System.Drawing.Size(212, 23);
            this.cmbAttempt.TabIndex = 8;
            // 
            // lblRecipient
            // 
            this.lblRecipient.AutoSize = true;
            this.lblRecipient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecipient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRecipient.Location = new System.Drawing.Point(4, 74);
            this.lblRecipient.Name = "lblRecipient";
            this.lblRecipient.Size = new System.Drawing.Size(67, 13);
            this.lblRecipient.TabIndex = 172;
            this.lblRecipient.Text = "RECIPIENT:";
            // 
            // olvReportList
            // 
            this.olvReportList.AllColumns.Add(this.olvcolReports);
            this.olvReportList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcolReports});
            this.olvReportList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvReportList.FullRowSelect = true;
            this.olvReportList.HideSelection = false;
            this.olvReportList.IsSearchOnSortColumn = false;
            this.olvReportList.Location = new System.Drawing.Point(5, 6);
            this.olvReportList.Name = "olvReportList";
            this.olvReportList.RowHeight = 25;
            this.olvReportList.ShowFilterMenuOnRightClick = false;
            this.olvReportList.ShowGroups = false;
            this.olvReportList.ShowSortIndicators = false;
            this.olvReportList.Size = new System.Drawing.Size(576, 238);
            this.olvReportList.TabIndex = 3;
            this.olvReportList.UseCompatibleStateImageBehavior = false;
            this.olvReportList.View = System.Windows.Forms.View.Details;
            // 
            // olvcolReports
            // 
            this.olvcolReports.AspectName = "DisplayReportItem";
            this.olvcolReports.CheckBoxes = true;
            this.olvcolReports.Groupable = false;
            this.olvcolReports.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcolReports.IsEditable = false;
            this.olvcolReports.Searchable = false;
            this.olvcolReports.Sortable = false;
            this.olvcolReports.Text = "Report Name";
            this.olvcolReports.UseFiltering = false;
            this.olvcolReports.Width = 520;
            // 
            // cmbPrintOptions
            // 
            this.cmbPrintOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPrintOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrintOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPrintOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbPrintOptions.FormattingEnabled = true;
            this.cmbPrintOptions.Items.AddRange(new object[] {
            "Print Selected Pages",
            "Print All"});
            this.cmbPrintOptions.Location = new System.Drawing.Point(327, 260);
            this.cmbPrintOptions.Name = "cmbPrintOptions";
            this.cmbPrintOptions.Size = new System.Drawing.Size(188, 24);
            this.cmbPrintOptions.TabIndex = 4;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Silver;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrint.Location = new System.Drawing.Point(522, 259);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(60, 26);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(324, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "REPORT TYPE:";
            // 
            // lblRecevedD
            // 
            this.lblRecevedD.AutoSize = true;
            this.lblRecevedD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecevedD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRecevedD.Location = new System.Drawing.Point(325, 351);
            this.lblRecevedD.Name = "lblRecevedD";
            this.lblRecevedD.Size = new System.Drawing.Size(45, 13);
            this.lblRecevedD.TabIndex = 0;
            this.lblRecevedD.Text = "REC\' D:";
            // 
            // cmbReportType
            // 
            this.cmbReportType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReportType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(327, 314);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(254, 24);
            this.cmbReportType.TabIndex = 17;
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.cmbReportType_SelectedIndexChanged);
            // 
            // dtpReceivedDate
            // 
            this.dtpReceivedDate.CustomFormat = "MM / dd / yyyy hh:mm tt";
            this.dtpReceivedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReceivedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReceivedDate.Location = new System.Drawing.Point(327, 371);
            this.dtpReceivedDate.Name = "dtpReceivedDate";
            this.dtpReceivedDate.Size = new System.Drawing.Size(210, 21);
            this.dtpReceivedDate.TabIndex = 18;
            // 
            // btnCompleteApp
            // 
            this.btnCompleteApp.BackColor = System.Drawing.Color.LightGray;
            this.btnCompleteApp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnCompleteApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompleteApp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCompleteApp.Image = ((System.Drawing.Image)(resources.GetObject("btnCompleteApp.Image")));
            this.btnCompleteApp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCompleteApp.Location = new System.Drawing.Point(462, 515);
            this.btnCompleteApp.Name = "btnCompleteApp";
            this.btnCompleteApp.Size = new System.Drawing.Size(120, 72);
            this.btnCompleteApp.TabIndex = 22;
            this.btnCompleteApp.Text = "Complete App(s)";
            this.btnCompleteApp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCompleteApp.UseVisualStyleBackColor = false;
            this.btnCompleteApp.Click += new System.EventHandler(this.btnCompleteApp_Click);
            // 
            // btnGoto
            // 
            this.btnGoto.BackColor = System.Drawing.Color.LightGray;
            this.btnGoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGoto.Image = global::PaaApplication.Properties.Resources.table_icon;
            this.btnGoto.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGoto.Location = new System.Drawing.Point(461, 434);
            this.btnGoto.Name = "btnGoto";
            this.btnGoto.Size = new System.Drawing.Size(120, 75);
            this.btnGoto.TabIndex = 20;
            this.btnGoto.Text = "Goto Pickup Table";
            this.btnGoto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGoto.UseVisualStyleBackColor = false;
            this.btnGoto.Click += new System.EventHandler(this.btnGoto_Click);
            // 
            // btnReviewComm
            // 
            this.btnReviewComm.BackColor = System.Drawing.Color.LightGray;
            this.btnReviewComm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReviewComm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnReviewComm.Image = ((System.Drawing.Image)(resources.GetObject("btnReviewComm.Image")));
            this.btnReviewComm.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReviewComm.Location = new System.Drawing.Point(328, 434);
            this.btnReviewComm.Name = "btnReviewComm";
            this.btnReviewComm.Size = new System.Drawing.Size(127, 75);
            this.btnReviewComm.TabIndex = 19;
            this.btnReviewComm.Text = "Review Comments";
            this.btnReviewComm.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReviewComm.UseVisualStyleBackColor = false;
            this.btnReviewComm.Click += new System.EventHandler(this.btnReviewComm_Click);
            // 
            // dtpCompletedDate
            // 
            this.dtpCompletedDate.CustomFormat = "MM / dd / yyyy hh:mm tt";
            this.dtpCompletedDate.Enabled = false;
            this.dtpCompletedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCompletedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCompletedDate.Location = new System.Drawing.Point(383, 403);
            this.dtpCompletedDate.Name = "dtpCompletedDate";
            this.dtpCompletedDate.Size = new System.Drawing.Size(198, 21);
            this.dtpCompletedDate.TabIndex = 23;
            this.dtpCompletedDate.Visible = false;
            // 
            // screenerImageList
            // 
            this.screenerImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.screenerImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.screenerImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // locationImageList
            // 
            this.locationImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.locationImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.locationImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnInProcessTest
            // 
            this.btnInProcessTest.AutoSize = true;
            this.btnInProcessTest.FlatAppearance.BorderSize = 0;
            this.btnInProcessTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInProcessTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInProcessTest.ForeColor = System.Drawing.Color.Green;
            this.btnInProcessTest.Location = new System.Drawing.Point(384, 399);
            this.btnInProcessTest.Name = "btnInProcessTest";
            this.btnInProcessTest.Size = new System.Drawing.Size(112, 28);
            this.btnInProcessTest.TabIndex = 0;
            this.btnInProcessTest.TabStop = false;
            this.btnInProcessTest.Text = "(In-Process)";
            this.btnInProcessTest.UseVisualStyleBackColor = true;
            // 
            // btnCompleteTest
            // 
            this.btnCompleteTest.AutoSize = true;
            this.btnCompleteTest.FlatAppearance.BorderSize = 0;
            this.btnCompleteTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompleteTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompleteTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCompleteTest.Location = new System.Drawing.Point(321, 403);
            this.btnCompleteTest.Name = "btnCompleteTest";
            this.btnCompleteTest.Size = new System.Drawing.Size(57, 23);
            this.btnCompleteTest.TabIndex = 0;
            this.btnCompleteTest.TabStop = false;
            this.btnCompleteTest.Text = "COMPL:";
            this.btnCompleteTest.UseVisualStyleBackColor = true;
            // 
            // AppMenuControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CausesValidation = false;
            this.Controls.Add(this.btnInProcessTest);
            this.Controls.Add(this.btnCompleteTest);
            this.Controls.Add(this.dtpCompletedDate);
            this.Controls.Add(this.btnCompleteApp);
            this.Controls.Add(this.btnGoto);
            this.Controls.Add(this.btnReviewComm);
            this.Controls.Add(this.dtpReceivedDate);
            this.Controls.Add(this.cmbReportType);
            this.Controls.Add(this.lblRecevedD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cmbPrintOptions);
            this.Controls.Add(this.olvReportList);
            this.Controls.Add(this.tabAppContact);
            this.Name = "AppMenuControl";
            this.Size = new System.Drawing.Size(588, 594);
            this.tabAppContact.ResumeLayout(false);
            this.tabAppInfo.ResumeLayout(false);
            this.tabAppInfo.PerformLayout();
            this.tabContacts.ResumeLayout(false);
            this.tabContacts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvReportList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabAppContact;
        private System.Windows.Forms.TabPage tabAppInfo;
        private System.Windows.Forms.TabPage tabContacts;
        private BrightIdeasSoftware.ObjectListView olvReportList;
        private BrightIdeasSoftware.OLVColumn olvcolReports;
        private System.Windows.Forms.ComboBox cmbPrintOptions;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRecevedD;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.DateTimePicker dtpReceivedDate;
        private ImageComboBox.ImageComboBox cmbLocation;
        private ImageComboBox.ImageComboBox cmbSceener;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblScreener;
        private System.Windows.Forms.ComboBox cmbAttempt;
        private System.Windows.Forms.Label lblRecipient;
        private System.Windows.Forms.Label lblCall;
        private System.Windows.Forms.CheckBox chboxReturned;
        private System.Windows.Forms.TextBox txtPhoneFax;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtOtherAddr;
        private System.Windows.Forms.Button btnDelAttempt;
        private System.Windows.Forms.Button btnNewAttempt;
        private System.Windows.Forms.Button btnReviewComm;
        private System.Windows.Forms.Button btnCompleteApp;
        private System.Windows.Forms.Button btnGoto;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblContactAttemp;
        private System.Windows.Forms.DateTimePicker dtpCompletedDate;
        private System.Windows.Forms.ImageList screenerImageList;
        private System.Windows.Forms.ImageList locationImageList;
        private DoubleClickButton btnCompleteTest;
        private DoubleClickButton btnInProcessTest;
    }
}
