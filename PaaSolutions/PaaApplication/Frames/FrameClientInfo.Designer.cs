using System.Drawing;
using System.Windows.Forms;
namespace PaaApplication.Frames
{
    partial class FrameClientInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrameClientInfo));
            this.tabpgService = new System.Windows.Forms.TabPage();
            this.btnMgtWideInfo = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblMgtCompany = new System.Windows.Forms.Label();
            this.lblClientName = new System.Windows.Forms.Label();
            this.lblCusNo = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddressPre = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.tabpgClientInfo = new System.Windows.Forms.TabPage();
            this.tabpgInvDivision = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblBillingAdress = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.tabClientInfo = new System.Windows.Forms.TabControl();
            this.pnlClientInfoRight = new System.Windows.Forms.Panel();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.olvclmClientName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tabpgInvDivision.SuspendLayout();
            this.tabClientInfo.SuspendLayout();
            this.pnlClientInfoRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabpgService
            // 
            this.tabpgService.Location = new System.Drawing.Point(4, 22);
            this.tabpgService.Name = "tabpgService";
            this.tabpgService.Padding = new System.Windows.Forms.Padding(3);
            this.tabpgService.Size = new System.Drawing.Size(412, 376);
            this.tabpgService.TabIndex = 2;
            this.tabpgService.Text = "Services";
            this.tabpgService.UseVisualStyleBackColor = true;
            // 
            // btnMgtWideInfo
            // 
            this.btnMgtWideInfo.BackColor = System.Drawing.Color.Gray;
            this.btnMgtWideInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMgtWideInfo.ForeColor = System.Drawing.Color.White;
            this.btnMgtWideInfo.Location = new System.Drawing.Point(291, 62);
            this.btnMgtWideInfo.Name = "btnMgtWideInfo";
            this.btnMgtWideInfo.Size = new System.Drawing.Size(130, 24);
            this.btnMgtWideInfo.TabIndex = 7;
            this.btnMgtWideInfo.Text = "Mgmt-Wide Info Update";
            this.btnMgtWideInfo.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(4, 64);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(275, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // lblMgtCompany
            // 
            this.lblMgtCompany.AutoSize = true;
            this.lblMgtCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMgtCompany.Location = new System.Drawing.Point(2, 49);
            this.lblMgtCompany.Name = "lblMgtCompany";
            this.lblMgtCompany.Size = new System.Drawing.Size(128, 12);
            this.lblMgtCompany.TabIndex = 5;
            this.lblMgtCompany.Text = "MANAGEMENT COMPANY:";
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientName.Location = new System.Drawing.Point(3, 4);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(72, 12);
            this.lblClientName.TabIndex = 1;
            this.lblClientName.Text = "CLIENT NAME:";
            // 
            // lblCusNo
            // 
            this.lblCusNo.AutoSize = true;
            this.lblCusNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusNo.Location = new System.Drawing.Point(329, 4);
            this.lblCusNo.Name = "lblCusNo";
            this.lblCusNo.Size = new System.Drawing.Size(54, 12);
            this.lblCusNo.TabIndex = 3;
            this.lblCusNo.Text = " CUST. NO:";
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.Location = new System.Drawing.Point(367, 141);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 24);
            this.button3.TabIndex = 53;
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox3.Location = new System.Drawing.Point(213, 30);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(195, 21);
            this.textBox3.TabIndex = 52;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox2.Location = new System.Drawing.Point(213, 58);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(195, 65);
            this.textBox2.TabIndex = 51;
            this.textBox2.Text = "8xgroup";
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox9.Location = new System.Drawing.Point(213, 332);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(195, 20);
            this.textBox9.TabIndex = 50;
            // 
            // textBox8
            // 
            this.textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox8.Location = new System.Drawing.Point(4, 332);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(195, 20);
            this.textBox8.TabIndex = 49;
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox7.Location = new System.Drawing.Point(213, 287);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(195, 20);
            this.textBox7.TabIndex = 48;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(212, 317);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 12);
            this.label7.TabIndex = 44;
            this.label7.Text = "CUSTOMER SINCE:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(2, 317);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 12);
            this.label6.TabIndex = 43;
            this.label6.Text = "EMAIL:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(211, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 12);
            this.label5.TabIndex = 42;
            this.label5.Text = "FAX:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 41;
            this.label4.Text = "PHONE:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(2, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 12);
            this.label9.TabIndex = 40;
            this.label9.Text = "ADDITIONAL BILLING INFO:";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox4.Location = new System.Drawing.Point(4, 119);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox4.Size = new System.Drawing.Size(195, 65);
            this.textBox4.TabIndex = 39;
            this.textBox4.Text = "8xgroup";
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 12);
            this.label3.TabIndex = 38;
            this.label3.Text = "MISCELLANEOUS COMMENTS:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(211, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 12);
            this.label2.TabIndex = 37;
            this.label2.Text = "OTHER ADDRESSES:";
            // 
            // btnAddressPre
            // 
            this.btnAddressPre.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAddressPre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddressPre.Image = ((System.Drawing.Image)(resources.GetObject("btnAddressPre.Image")));
            this.btnAddressPre.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddressPre.Location = new System.Drawing.Point(214, 141);
            this.btnAddressPre.Name = "btnAddressPre";
            this.btnAddressPre.Size = new System.Drawing.Size(40, 24);
            this.btnAddressPre.TabIndex = 36;
            this.btnAddressPre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddressPre.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox6.Location = new System.Drawing.Point(4, 287);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(195, 20);
            this.textBox6.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(325, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "1 of 1";
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox5.Location = new System.Drawing.Point(4, 208);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(404, 55);
            this.textBox5.TabIndex = 24;
            // 
            // tabpgClientInfo
            // 
            this.tabpgClientInfo.Location = new System.Drawing.Point(4, 22);
            this.tabpgClientInfo.Name = "tabpgClientInfo";
            this.tabpgClientInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabpgClientInfo.Size = new System.Drawing.Size(412, 376);
            this.tabpgClientInfo.TabIndex = 0;
            this.tabpgClientInfo.Text = "Client Infomation";
            this.tabpgClientInfo.UseVisualStyleBackColor = true;
            // 
            // tabpgInvDivision
            // 
            this.tabpgInvDivision.Controls.Add(this.button5);
            this.tabpgInvDivision.Controls.Add(this.button4);
            this.tabpgInvDivision.Controls.Add(this.button3);
            this.tabpgInvDivision.Controls.Add(this.textBox3);
            this.tabpgInvDivision.Controls.Add(this.textBox2);
            this.tabpgInvDivision.Controls.Add(this.textBox9);
            this.tabpgInvDivision.Controls.Add(this.textBox8);
            this.tabpgInvDivision.Controls.Add(this.textBox7);
            this.tabpgInvDivision.Controls.Add(this.label7);
            this.tabpgInvDivision.Controls.Add(this.label6);
            this.tabpgInvDivision.Controls.Add(this.label5);
            this.tabpgInvDivision.Controls.Add(this.label4);
            this.tabpgInvDivision.Controls.Add(this.label9);
            this.tabpgInvDivision.Controls.Add(this.textBox4);
            this.tabpgInvDivision.Controls.Add(this.label3);
            this.tabpgInvDivision.Controls.Add(this.label2);
            this.tabpgInvDivision.Controls.Add(this.btnAddressPre);
            this.tabpgInvDivision.Controls.Add(this.textBox6);
            this.tabpgInvDivision.Controls.Add(this.label1);
            this.tabpgInvDivision.Controls.Add(this.textBox5);
            this.tabpgInvDivision.Controls.Add(this.lblBillingAdress);
            this.tabpgInvDivision.Controls.Add(this.textBox1);
            this.tabpgInvDivision.Location = new System.Drawing.Point(4, 22);
            this.tabpgInvDivision.Name = "tabpgInvDivision";
            this.tabpgInvDivision.Padding = new System.Windows.Forms.Padding(3);
            this.tabpgInvDivision.Size = new System.Drawing.Size(412, 376);
            this.tabpgInvDivision.TabIndex = 1;
            this.tabpgInvDivision.Text = "Inv. Divisions & Contacts";
            this.tabpgInvDivision.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Gray;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(311, 141);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(48, 24);
            this.button5.TabIndex = 55;
            this.button5.Text = "Delete";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Gray;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(260, 141);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(45, 24);
            this.button4.TabIndex = 54;
            this.button4.Text = "Add";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // lblBillingAdress
            // 
            this.lblBillingAdress.AutoSize = true;
            this.lblBillingAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillingAdress.Location = new System.Drawing.Point(2, 15);
            this.lblBillingAdress.Name = "lblBillingAdress";
            this.lblBillingAdress.Size = new System.Drawing.Size(92, 12);
            this.lblBillingAdress.TabIndex = 19;
            this.lblBillingAdress.Text = "BILLING ADDRESS:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.Location = new System.Drawing.Point(4, 30);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(195, 65);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = "8xgroup";
            // 
            // textBox11
            // 
            this.textBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.Location = new System.Drawing.Point(332, 19);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(88, 20);
            this.textBox11.TabIndex = 54;
            // 
            // textBox10
            // 
            this.textBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox10.Location = new System.Drawing.Point(4, 19);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(315, 20);
            this.textBox10.TabIndex = 53;
            // 
            // tabClientInfo
            // 
            this.tabClientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabClientInfo.Controls.Add(this.tabpgClientInfo);
            this.tabClientInfo.Controls.Add(this.tabpgInvDivision);
            this.tabClientInfo.Controls.Add(this.tabpgService);
            this.tabClientInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabClientInfo.Location = new System.Drawing.Point(5, 91);
            this.tabClientInfo.Name = "tabClientInfo";
            this.tabClientInfo.SelectedIndex = 0;
            this.tabClientInfo.Size = new System.Drawing.Size(420, 402);
            this.tabClientInfo.TabIndex = 8;
            // 
            // pnlClientInfoRight
            // 
            this.pnlClientInfoRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlClientInfoRight.Controls.Add(this.textBox11);
            this.pnlClientInfoRight.Controls.Add(this.textBox10);
            this.pnlClientInfoRight.Controls.Add(this.tabClientInfo);
            this.pnlClientInfoRight.Controls.Add(this.btnMgtWideInfo);
            this.pnlClientInfoRight.Controls.Add(this.comboBox1);
            this.pnlClientInfoRight.Controls.Add(this.lblMgtCompany);
            this.pnlClientInfoRight.Controls.Add(this.lblClientName);
            this.pnlClientInfoRight.Controls.Add(this.lblCusNo);
            this.pnlClientInfoRight.Location = new System.Drawing.Point(538, 24);
            this.pnlClientInfoRight.Name = "pnlClientInfoRight";
            this.pnlClientInfoRight.Size = new System.Drawing.Size(428, 485);
            this.pnlClientInfoRight.TabIndex = 1;
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.olvclmClientName);
            this.objectListView1.AllColumns.Add(this.olvColumn1);
            this.objectListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvclmClientName,
            this.olvColumn1});
            this.objectListView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.objectListView1.Location = new System.Drawing.Point(5, 31);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(529, 480);
            this.objectListView1.TabIndex = 2;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.SelectedIndexChanged += new System.EventHandler(this.objectListView1_SelectedIndexChanged);
            // 
            // olvclmClientName
            // 
            this.olvclmClientName.CellPadding = null;
            this.olvclmClientName.Text = "Client Name";
            // 
            // olvColumn1
            // 
            this.olvColumn1.CellPadding = null;
            // 
            // FrameClientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.objectListView1);
            this.Controls.Add(this.pnlClientInfoRight);
            this.Name = "FrameClientInfo";
            this.Size = new System.Drawing.Size(969, 513);
            this.tabpgInvDivision.ResumeLayout(false);
            this.tabpgInvDivision.PerformLayout();
            this.tabClientInfo.ResumeLayout(false);
            this.pnlClientInfoRight.ResumeLayout(false);
            this.pnlClientInfoRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabPage tabpgService;
        private Button btnMgtWideInfo;
        private ComboBox comboBox1;
        private Label lblMgtCompany;
        private Label lblClientName;
        private Label lblCusNo;
        private Button button3;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox9;
        private TextBox textBox8;
        private TextBox textBox7;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label9;
        private TextBox textBox4;
        private Label label3;
        private Label label2;
        private Button btnAddressPre;
        private TextBox textBox6;
        private Label label1;
        private TextBox textBox5;
        private TabPage tabpgClientInfo;
        private TabPage tabpgInvDivision;
        private TextBox textBox11;
        private TextBox textBox10;
        private TabControl tabClientInfo;
        private Panel pnlClientInfoRight;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn olvclmClientName;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private TextBox textBox1;
        private Label lblBillingAdress;
        private Button button5;
        private Button button4;





    }
}
