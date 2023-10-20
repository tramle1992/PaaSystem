namespace PaaApplication.Forms.AppExplore
{
    partial class FormZipCode
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblManagementCompanyName = new System.Windows.Forms.Label();
            this.tabSearches = new System.Windows.Forms.TabControl();
            this.tabAutoDetect = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.tabCityState = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.lblInvs = new System.Windows.Forms.Label();
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.tabCounty = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCounty_State = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCounty = new System.Windows.Forms.ComboBox();
            this.tablZipCode = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabAreaCode = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtAreaCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnFindCityStateCounty = new System.Windows.Forms.Button();
            this.btnFindZipCode = new System.Windows.Forms.Button();
            this.btnFindAreaCodes = new System.Windows.Forms.Button();
            this.btnFindTimeOfDay = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.olvZipCode = new BrightIdeasSoftware.FastObjectListView();
            this.olvColCity = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColState = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColAreaCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColZipCodeName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColCounty = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColTimeZoneName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tabSearches.SuspendLayout();
            this.tabAutoDetect.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabCityState.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabCounty.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tablZipCode.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabAreaCode.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvZipCode)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 7);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // lblManagementCompanyName
            // 
            this.lblManagementCompanyName.AutoSize = true;
            this.lblManagementCompanyName.Font = new System.Drawing.Font("Arial Unicode MS", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManagementCompanyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblManagementCompanyName.Location = new System.Drawing.Point(9, 9);
            this.lblManagementCompanyName.Name = "lblManagementCompanyName";
            this.lblManagementCompanyName.Size = new System.Drawing.Size(410, 23);
            this.lblManagementCompanyName.TabIndex = 26;
            this.lblManagementCompanyName.Text = "City / State / Zip / Area Code / Time Zone Tools";
            // 
            // tabSearches
            // 
            this.tabSearches.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabSearches.Controls.Add(this.tabAutoDetect);
            this.tabSearches.Controls.Add(this.tabCityState);
            this.tabSearches.Controls.Add(this.tabCounty);
            this.tabSearches.Controls.Add(this.tablZipCode);
            this.tabSearches.Controls.Add(this.tabAreaCode);
            this.tabSearches.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSearches.Location = new System.Drawing.Point(13, 59);
            this.tabSearches.Name = "tabSearches";
            this.tabSearches.SelectedIndex = 0;
            this.tabSearches.Size = new System.Drawing.Size(613, 137);
            this.tabSearches.TabIndex = 28;
            // 
            // tabAutoDetect
            // 
            this.tabAutoDetect.Controls.Add(this.groupBox2);
            this.tabAutoDetect.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabAutoDetect.Location = new System.Drawing.Point(4, 30);
            this.tabAutoDetect.Name = "tabAutoDetect";
            this.tabAutoDetect.Padding = new System.Windows.Forms.Padding(3);
            this.tabAutoDetect.Size = new System.Drawing.Size(605, 103);
            this.tabAutoDetect.TabIndex = 0;
            this.tabAutoDetect.Text = "Auto-Detect";
            this.tabAutoDetect.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSearchText);
            this.groupBox2.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(593, 95);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Enter Search Here:";
            // 
            // txtSearchText
            // 
            this.txtSearchText.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearchText.Location = new System.Drawing.Point(20, 30);
            this.txtSearchText.MaxLength = 250;
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(555, 25);
            this.txtSearchText.TabIndex = 18;
            this.txtSearchText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearchText_KeyUp);
            // 
            // tabCityState
            // 
            this.tabCityState.Controls.Add(this.groupBox3);
            this.tabCityState.Location = new System.Drawing.Point(4, 30);
            this.tabCityState.Name = "tabCityState";
            this.tabCityState.Padding = new System.Windows.Forms.Padding(3);
            this.tabCityState.Size = new System.Drawing.Size(605, 103);
            this.tabCityState.TabIndex = 1;
            this.tabCityState.Text = "City and/or State";
            this.tabCityState.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cboState);
            this.groupBox3.Controls.Add(this.lblInvs);
            this.groupBox3.Controls.Add(this.cboCity);
            this.groupBox3.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox3.Location = new System.Drawing.Point(6, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(593, 95);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Enter Search Here:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(126, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 31;
            this.label1.Text = "STATE:";
            // 
            // cboState
            // 
            this.cboState.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboState.FormattingEnabled = true;
            this.cboState.Location = new System.Drawing.Point(195, 58);
            this.cboState.MaxLength = 255;
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(262, 26);
            this.cboState.TabIndex = 30;
            this.cboState.SelectedIndexChanged += new System.EventHandler(this.cboState_SelectedIndexChanged);
            this.cboState.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboState_KeyPress);
            // 
            // lblInvs
            // 
            this.lblInvs.AutoSize = true;
            this.lblInvs.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblInvs.Location = new System.Drawing.Point(137, 25);
            this.lblInvs.Name = "lblInvs";
            this.lblInvs.Size = new System.Drawing.Size(38, 16);
            this.lblInvs.TabIndex = 29;
            this.lblInvs.Text = "CITY:";
            // 
            // cboCity
            // 
            this.cboCity.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboCity.FormattingEnabled = true;
            this.cboCity.Location = new System.Drawing.Point(195, 23);
            this.cboCity.MaxLength = 255;
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(262, 26);
            this.cboCity.TabIndex = 8;
            // 
            // tabCounty
            // 
            this.tabCounty.Controls.Add(this.groupBox4);
            this.tabCounty.Location = new System.Drawing.Point(4, 30);
            this.tabCounty.Name = "tabCounty";
            this.tabCounty.Size = new System.Drawing.Size(605, 103);
            this.tabCounty.TabIndex = 2;
            this.tabCounty.Text = "County";
            this.tabCounty.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.cboCounty_State);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.cboCounty);
            this.groupBox4.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox4.Location = new System.Drawing.Point(6, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(593, 95);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Enter Search Here:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(132, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 31;
            this.label2.Text = "STATE:";
            // 
            // cboCounty_State
            // 
            this.cboCounty_State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCounty_State.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCounty_State.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboCounty_State.FormattingEnabled = true;
            this.cboCounty_State.Location = new System.Drawing.Point(195, 58);
            this.cboCounty_State.MaxLength = 255;
            this.cboCounty_State.Name = "cboCounty_State";
            this.cboCounty_State.Size = new System.Drawing.Size(262, 26);
            this.cboCounty_State.TabIndex = 30;
            this.cboCounty_State.SelectedIndexChanged += new System.EventHandler(this.cboCounty_State_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(119, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 29;
            this.label3.Text = "COUNTY:";
            // 
            // cboCounty
            // 
            this.cboCounty.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCounty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboCounty.FormattingEnabled = true;
            this.cboCounty.Location = new System.Drawing.Point(195, 23);
            this.cboCounty.MaxLength = 255;
            this.cboCounty.Name = "cboCounty";
            this.cboCounty.Size = new System.Drawing.Size(262, 26);
            this.cboCounty.TabIndex = 8;
            // 
            // tablZipCode
            // 
            this.tablZipCode.Controls.Add(this.groupBox5);
            this.tablZipCode.Location = new System.Drawing.Point(4, 30);
            this.tablZipCode.Name = "tablZipCode";
            this.tablZipCode.Size = new System.Drawing.Size(605, 103);
            this.tablZipCode.TabIndex = 3;
            this.tablZipCode.Text = "Zip Code";
            this.tablZipCode.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtZipCode);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox5.Location = new System.Drawing.Point(6, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(593, 95);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Enter Search Here:";
            // 
            // txtZipCode
            // 
            this.txtZipCode.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtZipCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtZipCode.Location = new System.Drawing.Point(195, 23);
            this.txtZipCode.MaxLength = 250;
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(262, 25);
            this.txtZipCode.TabIndex = 30;
            this.txtZipCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtZipCode_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(119, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "ZIP CODE:";
            // 
            // tabAreaCode
            // 
            this.tabAreaCode.Controls.Add(this.groupBox6);
            this.tabAreaCode.Location = new System.Drawing.Point(4, 30);
            this.tabAreaCode.Name = "tabAreaCode";
            this.tabAreaCode.Size = new System.Drawing.Size(605, 103);
            this.tabAreaCode.TabIndex = 4;
            this.tabAreaCode.Text = "Area Code";
            this.tabAreaCode.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtAreaCode);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox6.Location = new System.Drawing.Point(6, 5);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(593, 95);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Enter Search Here:";
            // 
            // txtAreaCode
            // 
            this.txtAreaCode.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAreaCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAreaCode.Location = new System.Drawing.Point(204, 38);
            this.txtAreaCode.MaxLength = 250;
            this.txtAreaCode.Name = "txtAreaCode";
            this.txtAreaCode.Size = new System.Drawing.Size(262, 25);
            this.txtAreaCode.TabIndex = 31;
            this.txtAreaCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAreaCode_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(117, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 16);
            this.label6.TabIndex = 29;
            this.label6.Text = "AREA CODE:";
            // 
            // btnFindCityStateCounty
            // 
            this.btnFindCityStateCounty.BackColor = System.Drawing.Color.Gray;
            this.btnFindCityStateCounty.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFindCityStateCounty.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindCityStateCounty.ForeColor = System.Drawing.Color.White;
            this.btnFindCityStateCounty.Location = new System.Drawing.Point(143, 199);
            this.btnFindCityStateCounty.Name = "btnFindCityStateCounty";
            this.btnFindCityStateCounty.Size = new System.Drawing.Size(190, 29);
            this.btnFindCityStateCounty.TabIndex = 30;
            this.btnFindCityStateCounty.Text = "Find &City, State, County";
            this.btnFindCityStateCounty.UseVisualStyleBackColor = false;
            this.btnFindCityStateCounty.Click += new System.EventHandler(this.btnFindCityStateCounty_Click);
            // 
            // btnFindZipCode
            // 
            this.btnFindZipCode.BackColor = System.Drawing.Color.Gray;
            this.btnFindZipCode.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindZipCode.ForeColor = System.Drawing.Color.White;
            this.btnFindZipCode.Location = new System.Drawing.Point(23, 199);
            this.btnFindZipCode.Name = "btnFindZipCode";
            this.btnFindZipCode.Size = new System.Drawing.Size(116, 29);
            this.btnFindZipCode.TabIndex = 29;
            this.btnFindZipCode.Text = "Find &Zip Codes";
            this.btnFindZipCode.UseVisualStyleBackColor = false;
            this.btnFindZipCode.Click += new System.EventHandler(this.btnFindZipCode_Click);
            // 
            // btnFindAreaCodes
            // 
            this.btnFindAreaCodes.BackColor = System.Drawing.Color.Gray;
            this.btnFindAreaCodes.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFindAreaCodes.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindAreaCodes.ForeColor = System.Drawing.Color.White;
            this.btnFindAreaCodes.Location = new System.Drawing.Point(481, 199);
            this.btnFindAreaCodes.Name = "btnFindAreaCodes";
            this.btnFindAreaCodes.Size = new System.Drawing.Size(135, 29);
            this.btnFindAreaCodes.TabIndex = 32;
            this.btnFindAreaCodes.Text = "Find &Area Codes";
            this.btnFindAreaCodes.UseVisualStyleBackColor = false;
            this.btnFindAreaCodes.Click += new System.EventHandler(this.btnFindAreaCodes_Click);
            // 
            // btnFindTimeOfDay
            // 
            this.btnFindTimeOfDay.BackColor = System.Drawing.Color.Gray;
            this.btnFindTimeOfDay.Enabled = false;
            this.btnFindTimeOfDay.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindTimeOfDay.ForeColor = System.Drawing.Color.White;
            this.btnFindTimeOfDay.Location = new System.Drawing.Point(337, 199);
            this.btnFindTimeOfDay.Name = "btnFindTimeOfDay";
            this.btnFindTimeOfDay.Size = new System.Drawing.Size(141, 29);
            this.btnFindTimeOfDay.TabIndex = 31;
            this.btnFindTimeOfDay.Text = "Find &Time of Day";
            this.btnFindTimeOfDay.UseVisualStyleBackColor = false;
            this.btnFindTimeOfDay.Click += new System.EventHandler(this.btnFindTimeOfDay_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.olvZipCode);
            this.groupBox7.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox7.Location = new System.Drawing.Point(17, 233);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(714, 309);
            this.groupBox7.TabIndex = 32;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Results:";
            // 
            // olvZipCode
            // 
            this.olvZipCode.AllColumns.Add(this.olvColCity);
            this.olvZipCode.AllColumns.Add(this.olvColState);
            this.olvZipCode.AllColumns.Add(this.olvColAreaCode);
            this.olvZipCode.AllColumns.Add(this.olvColZipCodeName);
            this.olvZipCode.AllColumns.Add(this.olvColCounty);
            this.olvZipCode.AllColumns.Add(this.olvColTimeZoneName);
            this.olvZipCode.AllColumns.Add(this.olvColTime);
            this.olvZipCode.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.olvZipCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvZipCode.CellEditEnterChangesRows = true;
            this.olvZipCode.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColCity,
            this.olvColState,
            this.olvColAreaCode,
            this.olvColZipCodeName,
            this.olvColCounty,
            this.olvColTimeZoneName,
            this.olvColTime});
            this.olvZipCode.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvZipCode.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvZipCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.olvZipCode.FullRowSelect = true;
            this.olvZipCode.GridLines = true;
            this.olvZipCode.HeaderWordWrap = true;
            this.olvZipCode.HighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvZipCode.Location = new System.Drawing.Point(6, 24);
            this.olvZipCode.Name = "olvZipCode";
            this.olvZipCode.OwnerDraw = true;
            this.olvZipCode.ShowGroups = false;
            this.olvZipCode.Size = new System.Drawing.Size(702, 279);
            this.olvZipCode.SortGroupItemsByPrimaryColumn = false;
            this.olvZipCode.TabIndex = 1;
            this.olvZipCode.UseAlternatingBackColors = true;
            this.olvZipCode.UseCompatibleStateImageBehavior = false;
            this.olvZipCode.UseFiltering = true;
            this.olvZipCode.UseHotItem = true;
            this.olvZipCode.View = System.Windows.Forms.View.Details;
            // 
            // olvColCity
            // 
            this.olvColCity.AspectName = "City";
            this.olvColCity.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColCity.IsEditable = false;
            this.olvColCity.Searchable = false;
            this.olvColCity.Sortable = false;
            this.olvColCity.Text = "City";
            this.olvColCity.Width = 115;
            // 
            // olvColState
            // 
            this.olvColState.AspectName = "State";
            this.olvColState.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColState.IsEditable = false;
            this.olvColState.Text = "State";
            this.olvColState.Width = 112;
            // 
            // olvColAreaCode
            // 
            this.olvColAreaCode.AspectName = "AreaCode";
            this.olvColAreaCode.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColAreaCode.Text = "Area Code";
            this.olvColAreaCode.Width = 104;
            // 
            // olvColZipCodeName
            // 
            this.olvColZipCodeName.AspectName = "ZipCodeName";
            this.olvColZipCodeName.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColZipCodeName.IsEditable = false;
            this.olvColZipCodeName.Text = "Zip Code";
            this.olvColZipCodeName.Width = 86;
            // 
            // olvColCounty
            // 
            this.olvColCounty.AspectName = "County";
            this.olvColCounty.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColCounty.Hideable = false;
            this.olvColCounty.IsEditable = false;
            this.olvColCounty.Text = "County";
            this.olvColCounty.Width = 100;
            // 
            // olvColTimeZoneName
            // 
            this.olvColTimeZoneName.AspectName = "TimezoneName";
            this.olvColTimeZoneName.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColTimeZoneName.IsEditable = false;
            this.olvColTimeZoneName.Text = "Time Zone";
            this.olvColTimeZoneName.Width = 100;
            // 
            // olvColTime
            // 
            this.olvColTime.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColTime.IsEditable = false;
            this.olvColTime.Text = "Time";
            this.olvColTime.Width = 94;
            // 
            // FormZipCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 554);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btnFindAreaCodes);
            this.Controls.Add(this.btnFindTimeOfDay);
            this.Controls.Add(this.btnFindCityStateCounty);
            this.Controls.Add(this.btnFindZipCode);
            this.Controls.Add(this.tabSearches);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblManagementCompanyName);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormZipCode";
            this.Text = "Geo. Lookup";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormZipCode_LoadCompleted);
            this.tabSearches.ResumeLayout(false);
            this.tabAutoDetect.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabCityState.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabCounty.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tablZipCode.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabAreaCode.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvZipCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblManagementCompanyName;
        private System.Windows.Forms.TabControl tabSearches;
        private System.Windows.Forms.TabPage tabAutoDetect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage tabCityState;
        private System.Windows.Forms.TabPage tabCounty;
        private System.Windows.Forms.TabPage tablZipCode;
        private System.Windows.Forms.TabPage tabAreaCode;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboCity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboState;
        private System.Windows.Forms.Label lblInvs;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCounty_State;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCounty;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtZipCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnFindCityStateCounty;
        private System.Windows.Forms.Button btnFindZipCode;
        private System.Windows.Forms.Button btnFindAreaCodes;
        private System.Windows.Forms.Button btnFindTimeOfDay;
        private System.Windows.Forms.GroupBox groupBox7;
        private BrightIdeasSoftware.FastObjectListView olvZipCode;
        private BrightIdeasSoftware.OLVColumn olvColState;
        private BrightIdeasSoftware.OLVColumn olvColCity;
        private BrightIdeasSoftware.OLVColumn olvColZipCodeName;
        private BrightIdeasSoftware.OLVColumn olvColCounty;
        private BrightIdeasSoftware.OLVColumn olvColTimeZoneName;
        private BrightIdeasSoftware.OLVColumn olvColTime;
        private BrightIdeasSoftware.OLVColumn olvColAreaCode;
        private System.Windows.Forms.TextBox txtAreaCode;
    }
}