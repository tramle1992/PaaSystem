namespace PaaApplication.Forms.ClientInfo
{
    partial class FormClientEditSpecialPrice
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
            this.components = new System.ComponentModel.Container();
            this.btnDone = new System.Windows.Forms.Button();
            this.txtDefaultPrice = new System.Windows.Forms.TextBox();
            this.lblDefaultPrice = new System.Windows.Forms.Label();
            this.nudSpecialPrice = new System.Windows.Forms.NumericUpDown();
            this.lblSpecialPrice = new System.Windows.Forms.Label();
            this.lblReportTypeName = new System.Windows.Forms.Label();
            this.lblReportTypes = new System.Windows.Forms.Label();
            this.errpdSpecialPrice = new System.Windows.Forms.ErrorProvider(this.components);
            this.lstReportTypes = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpecialPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errpdSpecialPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.Color.Gray;
            this.btnDone.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.ForeColor = System.Drawing.Color.White;
            this.btnDone.Location = new System.Drawing.Point(261, 251);
            this.btnDone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(69, 34);
            this.btnDone.TabIndex = 4;
            this.btnDone.Text = "&Done";
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // txtDefaultPrice
            // 
            this.txtDefaultPrice.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDefaultPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDefaultPrice.Location = new System.Drawing.Point(210, 155);
            this.txtDefaultPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDefaultPrice.Name = "txtDefaultPrice";
            this.txtDefaultPrice.ReadOnly = true;
            this.txtDefaultPrice.Size = new System.Drawing.Size(120, 24);
            this.txtDefaultPrice.TabIndex = 3;
            // 
            // lblDefaultPrice
            // 
            this.lblDefaultPrice.AutoSize = true;
            this.lblDefaultPrice.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefaultPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDefaultPrice.Location = new System.Drawing.Point(207, 131);
            this.lblDefaultPrice.Name = "lblDefaultPrice";
            this.lblDefaultPrice.Size = new System.Drawing.Size(99, 15);
            this.lblDefaultPrice.TabIndex = 100;
            this.lblDefaultPrice.Text = "DEFAULT  PRICE:";
            // 
            // nudSpecialPrice
            // 
            this.nudSpecialPrice.DecimalPlaces = 2;
            this.nudSpecialPrice.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSpecialPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.errpdSpecialPrice.SetIconPadding(this.nudSpecialPrice, 5);
            this.nudSpecialPrice.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudSpecialPrice.Location = new System.Drawing.Point(210, 94);
            this.nudSpecialPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudSpecialPrice.Name = "nudSpecialPrice";
            this.nudSpecialPrice.Size = new System.Drawing.Size(120, 24);
            this.nudSpecialPrice.TabIndex = 2;
            this.nudSpecialPrice.ValueChanged += new System.EventHandler(this.nudSpecialPrice_ValueChanged);
            this.nudSpecialPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudSpecialPrice_KeyPress);
            this.nudSpecialPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudSpecialPrice_KeyUp);
            // 
            // lblSpecialPrice
            // 
            this.lblSpecialPrice.AutoSize = true;
            this.lblSpecialPrice.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpecialPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSpecialPrice.Location = new System.Drawing.Point(207, 70);
            this.lblSpecialPrice.Name = "lblSpecialPrice";
            this.lblSpecialPrice.Size = new System.Drawing.Size(94, 15);
            this.lblSpecialPrice.TabIndex = 100;
            this.lblSpecialPrice.Text = "SPECIAL  PRICE:";
            // 
            // lblReportTypeName
            // 
            this.lblReportTypeName.AutoSize = true;
            this.lblReportTypeName.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportTypeName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblReportTypeName.Location = new System.Drawing.Point(207, 38);
            this.lblReportTypeName.Name = "lblReportTypeName";
            this.lblReportTypeName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblReportTypeName.Size = new System.Drawing.Size(73, 20);
            this.lblReportTypeName.TabIndex = 100;
            this.lblReportTypeName.Text = "[TName]";
            this.lblReportTypeName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblReportTypes
            // 
            this.lblReportTypes.AutoSize = true;
            this.lblReportTypes.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportTypes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblReportTypes.Location = new System.Drawing.Point(43, 16);
            this.lblReportTypes.Name = "lblReportTypes";
            this.lblReportTypes.Size = new System.Drawing.Size(94, 15);
            this.lblReportTypes.TabIndex = 100;
            this.lblReportTypes.Text = "REPORT  TYPES";
            // 
            // errpdSpecialPrice
            // 
            this.errpdSpecialPrice.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errpdSpecialPrice.ContainerControl = this.nudSpecialPrice;
            // 
            // lstReportTypes
            // 
            this.lstReportTypes.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.lstReportTypes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lstReportTypes.FormattingEnabled = true;
            this.lstReportTypes.ItemHeight = 16;
            this.lstReportTypes.Location = new System.Drawing.Point(45, 41);
            this.lstReportTypes.Name = "lstReportTypes";
            this.lstReportTypes.Size = new System.Drawing.Size(137, 244);
            this.lstReportTypes.TabIndex = 1;
            this.lstReportTypes.SelectedIndexChanged += new System.EventHandler(this.lstReportTypes_SelectedIndexChanged);
            // 
            // FormClientEditSpecialPrice
            // 
            this.AcceptButton = this.btnDone;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(372, 310);
            this.Controls.Add(this.lstReportTypes);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.txtDefaultPrice);
            this.Controls.Add(this.lblDefaultPrice);
            this.Controls.Add(this.nudSpecialPrice);
            this.Controls.Add(this.lblSpecialPrice);
            this.Controls.Add(this.lblReportTypeName);
            this.Controls.Add(this.lblReportTypes);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormClientEditSpecialPrice";
            this.Text = "Prices for: [Customer Name]";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormClientEditSpecialPrice_LoadCompleted);
            ((System.ComponentModel.ISupportInitialize)(this.nudSpecialPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errpdSpecialPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReportTypes;
        private System.Windows.Forms.Label lblReportTypeName;
        private System.Windows.Forms.Label lblSpecialPrice;
        private System.Windows.Forms.NumericUpDown nudSpecialPrice;
        private System.Windows.Forms.Label lblDefaultPrice;
        private System.Windows.Forms.TextBox txtDefaultPrice;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.ErrorProvider errpdSpecialPrice;
        private System.Windows.Forms.ListBox lstReportTypes;
    }
}