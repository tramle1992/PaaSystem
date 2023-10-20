namespace Common.Infrastructure.CheckSpelling
{
    partial class SuggestionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuggestionForm));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.stbSpellStatus = new System.Windows.Forms.StatusBar();
            this.statusPaneWord = new System.Windows.Forms.StatusBarPanel();
            this.statusPaneCount = new System.Windows.Forms.StatusBarPanel();
            this.statusPaneIndex = new System.Windows.Forms.StatusBarPanel();
            this.lblTextBeingChecked = new System.Windows.Forms.Label();
            this.lblSuggestions = new System.Windows.Forms.Label();
            this.lblReplaceWith = new System.Windows.Forms.Label();
            this.txtReplacementWord = new System.Windows.Forms.TextBox();
            this.txtTextBeingChecked = new System.Windows.Forms.RichTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReplaceAll = new System.Windows.Forms.Button();
            this.btnIgnoreAll = new System.Windows.Forms.Button();
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnIgnore = new System.Windows.Forms.Button();
            this.lstSuggestionList = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.statusPaneWord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPaneCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPaneIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Gray;
            this.btnAdd.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdd.Location = new System.Drawing.Point(360, 84);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 25);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.BackColor = System.Drawing.Color.Gray;
            this.btnOptions.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOptions.ForeColor = System.Drawing.Color.White;
            this.btnOptions.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOptions.Location = new System.Drawing.Point(360, 292);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(75, 25);
            this.btnOptions.TabIndex = 26;
            this.btnOptions.Text = "&Options";
            this.btnOptions.UseVisualStyleBackColor = false;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // stbSpellStatus
            // 
            this.stbSpellStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.stbSpellStatus.Location = new System.Drawing.Point(0, 395);
            this.stbSpellStatus.Name = "stbSpellStatus";
            this.stbSpellStatus.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusPaneWord,
            this.statusPaneCount,
            this.statusPaneIndex});
            this.stbSpellStatus.ShowPanels = true;
            this.stbSpellStatus.Size = new System.Drawing.Size(450, 16);
            this.stbSpellStatus.TabIndex = 28;
            // 
            // statusPaneWord
            // 
            this.statusPaneWord.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusPaneWord.Name = "statusPaneWord";
            this.statusPaneWord.Width = 253;
            // 
            // statusPaneCount
            // 
            this.statusPaneCount.Name = "statusPaneCount";
            this.statusPaneCount.Text = "Word: 0 of 0";
            // 
            // statusPaneIndex
            // 
            this.statusPaneIndex.Name = "statusPaneIndex";
            this.statusPaneIndex.Text = "Index: 0";
            this.statusPaneIndex.Width = 80;
            // 
            // lblTextBeingChecked
            // 
            this.lblTextBeingChecked.AutoSize = true;
            this.lblTextBeingChecked.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextBeingChecked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTextBeingChecked.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTextBeingChecked.Location = new System.Drawing.Point(6, 6);
            this.lblTextBeingChecked.Name = "lblTextBeingChecked";
            this.lblTextBeingChecked.Size = new System.Drawing.Size(121, 16);
            this.lblTextBeingChecked.TabIndex = 15;
            this.lblTextBeingChecked.Text = "Text Being Checked:";
            // 
            // lblSuggestions
            // 
            this.lblSuggestions.AutoSize = true;
            this.lblSuggestions.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuggestions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSuggestions.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSuggestions.Location = new System.Drawing.Point(5, 172);
            this.lblSuggestions.Name = "lblSuggestions";
            this.lblSuggestions.Size = new System.Drawing.Size(79, 16);
            this.lblSuggestions.TabIndex = 19;
            this.lblSuggestions.Text = "S&uggestions:";
            // 
            // lblReplaceWith
            // 
            this.lblReplaceWith.AutoSize = true;
            this.lblReplaceWith.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplaceWith.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblReplaceWith.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblReplaceWith.Location = new System.Drawing.Point(6, 120);
            this.lblReplaceWith.Name = "lblReplaceWith";
            this.lblReplaceWith.Size = new System.Drawing.Size(82, 16);
            this.lblReplaceWith.TabIndex = 16;
            this.lblReplaceWith.Text = "Replace &with:";
            // 
            // txtReplacementWord
            // 
            this.txtReplacementWord.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.txtReplacementWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtReplacementWord.Location = new System.Drawing.Point(8, 139);
            this.txtReplacementWord.Name = "txtReplacementWord";
            this.txtReplacementWord.Size = new System.Drawing.Size(336, 24);
            this.txtReplacementWord.TabIndex = 18;
            // 
            // txtTextBeingChecked
            // 
            this.txtTextBeingChecked.BackColor = System.Drawing.SystemColors.Window;
            this.txtTextBeingChecked.DetectUrls = false;
            this.txtTextBeingChecked.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.txtTextBeingChecked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTextBeingChecked.Location = new System.Drawing.Point(8, 24);
            this.txtTextBeingChecked.Name = "txtTextBeingChecked";
            this.txtTextBeingChecked.ReadOnly = true;
            this.txtTextBeingChecked.Size = new System.Drawing.Size(336, 85);
            this.txtTextBeingChecked.TabIndex = 17;
            this.txtTextBeingChecked.TabStop = false;
            this.txtTextBeingChecked.Text = "";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(360, 323);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReplaceAll
            // 
            this.btnReplaceAll.BackColor = System.Drawing.Color.Gray;
            this.btnReplaceAll.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReplaceAll.ForeColor = System.Drawing.Color.White;
            this.btnReplaceAll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnReplaceAll.Location = new System.Drawing.Point(360, 220);
            this.btnReplaceAll.Name = "btnReplaceAll";
            this.btnReplaceAll.Size = new System.Drawing.Size(75, 45);
            this.btnReplaceAll.TabIndex = 25;
            this.btnReplaceAll.Text = "Replace A&ll";
            this.btnReplaceAll.UseVisualStyleBackColor = false;
            this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
            // 
            // btnIgnoreAll
            // 
            this.btnIgnoreAll.BackColor = System.Drawing.Color.Gray;
            this.btnIgnoreAll.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIgnoreAll.ForeColor = System.Drawing.Color.White;
            this.btnIgnoreAll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnIgnoreAll.Location = new System.Drawing.Point(360, 54);
            this.btnIgnoreAll.Name = "btnIgnoreAll";
            this.btnIgnoreAll.Size = new System.Drawing.Size(75, 25);
            this.btnIgnoreAll.TabIndex = 22;
            this.btnIgnoreAll.Text = "I&gnore All";
            this.btnIgnoreAll.UseVisualStyleBackColor = false;
            this.btnIgnoreAll.Click += new System.EventHandler(this.btnIgnoreAll_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.BackColor = System.Drawing.Color.Gray;
            this.btnReplace.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReplace.ForeColor = System.Drawing.Color.White;
            this.btnReplace.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnReplace.Location = new System.Drawing.Point(360, 191);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(75, 25);
            this.btnReplace.TabIndex = 24;
            this.btnReplace.Text = "&Replace";
            this.btnReplace.UseVisualStyleBackColor = false;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnIgnore
            // 
            this.btnIgnore.BackColor = System.Drawing.Color.Gray;
            this.btnIgnore.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIgnore.ForeColor = System.Drawing.Color.White;
            this.btnIgnore.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnIgnore.Location = new System.Drawing.Point(360, 22);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(75, 25);
            this.btnIgnore.TabIndex = 21;
            this.btnIgnore.Text = "&Ignore";
            this.btnIgnore.UseVisualStyleBackColor = false;
            this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
            // 
            // lstSuggestionList
            // 
            this.lstSuggestionList.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.lstSuggestionList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lstSuggestionList.ItemHeight = 16;
            this.lstSuggestionList.Location = new System.Drawing.Point(8, 191);
            this.lstSuggestionList.Name = "lstSuggestionList";
            this.lstSuggestionList.Size = new System.Drawing.Size(336, 196);
            this.lstSuggestionList.TabIndex = 20;
            this.lstSuggestionList.SelectedIndexChanged += new System.EventHandler(this.lstSuggestionList_SelectedIndexChanged);
            this.lstSuggestionList.DoubleClick += new System.EventHandler(this.lstSuggestionList_DoubleClick);
            // 
            // SuggestionForm
            // 
            this.AcceptButton = this.btnIgnore;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(450, 411);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.stbSpellStatus);
            this.Controls.Add(this.lblTextBeingChecked);
            this.Controls.Add(this.lblSuggestions);
            this.Controls.Add(this.lblReplaceWith);
            this.Controls.Add(this.txtReplacementWord);
            this.Controls.Add(this.txtTextBeingChecked);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReplaceAll);
            this.Controls.Add(this.btnIgnoreAll);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.btnIgnore);
            this.Controls.Add(this.lstSuggestionList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SuggestionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spell Check";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SuggestionForm_FormClosing);
            this.Load += new System.EventHandler(this.SuggestionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusPaneWord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPaneCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPaneIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.StatusBar stbSpellStatus;
        private System.Windows.Forms.StatusBarPanel statusPaneWord;
        private System.Windows.Forms.StatusBarPanel statusPaneCount;
        private System.Windows.Forms.StatusBarPanel statusPaneIndex;
        private System.Windows.Forms.Label lblTextBeingChecked;
        private System.Windows.Forms.Label lblSuggestions;
        private System.Windows.Forms.Label lblReplaceWith;
        private System.Windows.Forms.TextBox txtReplacementWord;
        private System.Windows.Forms.RichTextBox txtTextBeingChecked;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnReplaceAll;
        private System.Windows.Forms.Button btnIgnoreAll;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button btnIgnore;
        private System.Windows.Forms.ListBox lstSuggestionList;

    }
}