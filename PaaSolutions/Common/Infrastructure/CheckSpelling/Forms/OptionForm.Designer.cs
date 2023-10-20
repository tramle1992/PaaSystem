namespace Common.Infrastructure.CheckSpelling.Forms
{
    partial class OptionForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkIgnoreHtml = new System.Windows.Forms.CheckBox();
            this.lblMaxSuggestionCount = new System.Windows.Forms.Label();
            this.txtMaxSuggestions = new System.Windows.Forms.TextBox();
            this.chkIgnoreUpper = new System.Windows.Forms.CheckBox();
            this.chkIgnoreDigits = new System.Windows.Forms.CheckBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(160, 145);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.Gray;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(65, 145);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkIgnoreHtml
            // 
            this.chkIgnoreHtml.Checked = true;
            this.chkIgnoreHtml.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIgnoreHtml.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIgnoreHtml.Location = new System.Drawing.Point(65, 75);
            this.chkIgnoreHtml.Name = "chkIgnoreHtml";
            this.chkIgnoreHtml.Size = new System.Drawing.Size(200, 24);
            this.chkIgnoreHtml.TabIndex = 2;
            this.chkIgnoreHtml.Text = "   Ignore HTML Tags";
            // 
            // lblMaxSuggestionCount
            // 
            this.lblMaxSuggestionCount.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxSuggestionCount.Location = new System.Drawing.Point(90, 107);
            this.lblMaxSuggestionCount.Name = "lblMaxSuggestionCount";
            this.lblMaxSuggestionCount.Size = new System.Drawing.Size(175, 16);
            this.lblMaxSuggestionCount.TabIndex = 4;
            this.lblMaxSuggestionCount.Text = "Maximum &Suggestion Count";
            // 
            // txtMaxSuggestions
            // 
            this.txtMaxSuggestions.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorProvider.SetIconAlignment(this.txtMaxSuggestions, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.errorProvider.SetIconPadding(this.txtMaxSuggestions, 10);
            this.txtMaxSuggestions.Location = new System.Drawing.Point(62, 104);
            this.txtMaxSuggestions.MaxLength = 2;
            this.txtMaxSuggestions.Name = "txtMaxSuggestions";
            this.txtMaxSuggestions.Size = new System.Drawing.Size(24, 24);
            this.txtMaxSuggestions.TabIndex = 3;
            this.txtMaxSuggestions.Text = "25";
            this.txtMaxSuggestions.TextChanged += new System.EventHandler(this.txtMaxSuggestions_TextChanged);
            this.txtMaxSuggestions.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxSuggestions_KeyPress);
            // 
            // chkIgnoreUpper
            // 
            this.chkIgnoreUpper.Checked = true;
            this.chkIgnoreUpper.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIgnoreUpper.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIgnoreUpper.Location = new System.Drawing.Point(65, 49);
            this.chkIgnoreUpper.Name = "chkIgnoreUpper";
            this.chkIgnoreUpper.Size = new System.Drawing.Size(200, 24);
            this.chkIgnoreUpper.TabIndex = 1;
            this.chkIgnoreUpper.Text = "   Ignore Words in all &Upper Case";
            // 
            // chkIgnoreDigits
            // 
            this.chkIgnoreDigits.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIgnoreDigits.Location = new System.Drawing.Point(65, 23);
            this.chkIgnoreDigits.Name = "chkIgnoreDigits";
            this.chkIgnoreDigits.Size = new System.Drawing.Size(200, 24);
            this.chkIgnoreDigits.TabIndex = 0;
            this.chkIgnoreDigits.Text = "   Ignore Words with &Digits";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // OptionForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(294, 197);
            this.Controls.Add(this.chkIgnoreHtml);
            this.Controls.Add(this.lblMaxSuggestionCount);
            this.Controls.Add(this.txtMaxSuggestions);
            this.Controls.Add(this.chkIgnoreUpper);
            this.Controls.Add(this.chkIgnoreDigits);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.OptionForm_LoadCompleted);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkIgnoreHtml;
        private System.Windows.Forms.Label lblMaxSuggestionCount;
        private System.Windows.Forms.TextBox txtMaxSuggestions;
        private System.Windows.Forms.CheckBox chkIgnoreUpper;
        private System.Windows.Forms.CheckBox chkIgnoreDigits;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}