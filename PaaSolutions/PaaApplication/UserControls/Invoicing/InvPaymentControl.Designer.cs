namespace PaaApplication.UserControls.Invoicing
{
    partial class InvPaymentControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvPaymentControl));
            this.grpPayment = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAcceptPayment = new System.Windows.Forms.Button();
            this.olvPayments = new BrightIdeasSoftware.ObjectListView();
            this.olvColDelete = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColAmount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColCheck = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.btnNewPayment = new System.Windows.Forms.Button();
            this.grpPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // grpPayment
            // 
            this.grpPayment.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grpPayment.Controls.Add(this.btnCancel);
            this.grpPayment.Controls.Add(this.btnAcceptPayment);
            this.grpPayment.Controls.Add(this.olvPayments);
            this.grpPayment.Controls.Add(this.btnNewPayment);
            this.grpPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpPayment.Location = new System.Drawing.Point(4, 1);
            this.grpPayment.Name = "grpPayment";
            this.grpPayment.Size = new System.Drawing.Size(597, 353);
            this.grpPayment.TabIndex = 2;
            this.grpPayment.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(513, 315);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 29);
            this.btnCancel.TabIndex = 50;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            // 
            // btnAcceptPayment
            // 
            this.btnAcceptPayment.BackColor = System.Drawing.Color.Gray;
            this.btnAcceptPayment.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcceptPayment.ForeColor = System.Drawing.Color.White;
            this.btnAcceptPayment.Location = new System.Drawing.Point(328, 315);
            this.btnAcceptPayment.Name = "btnAcceptPayment";
            this.btnAcceptPayment.Size = new System.Drawing.Size(179, 29);
            this.btnAcceptPayment.TabIndex = 49;
            this.btnAcceptPayment.Text = "Accept These Payments";
            this.btnAcceptPayment.UseVisualStyleBackColor = false;
            this.btnAcceptPayment.Visible = false;
            // 
            // olvPayments
            // 
            this.olvPayments.AllColumns.Add(this.olvColDelete);
            this.olvPayments.AllColumns.Add(this.olvColAmount);
            this.olvPayments.AllColumns.Add(this.olvColDate);
            this.olvPayments.AllColumns.Add(this.olvColCheck);
            this.olvPayments.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.olvPayments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColDelete,
            this.olvColAmount,
            this.olvColDate,
            this.olvColCheck});
            this.olvPayments.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvPayments.FullRowSelect = true;
            this.olvPayments.HideSelection = false;
            this.olvPayments.Location = new System.Drawing.Point(7, 56);
            this.olvPayments.MultiSelect = false;
            this.olvPayments.Name = "olvPayments";
            this.olvPayments.OwnerDraw = true;
            this.olvPayments.SelectColumnsOnRightClick = false;
            this.olvPayments.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.olvPayments.ShowFilterMenuOnRightClick = false;
            this.olvPayments.ShowGroups = false;
            this.olvPayments.Size = new System.Drawing.Size(584, 250);
            this.olvPayments.SmallImageList = this.imgList;
            this.olvPayments.TabIndex = 49;
            this.olvPayments.UseCompatibleStateImageBehavior = false;
            this.olvPayments.UseFiltering = true;
            this.olvPayments.View = System.Windows.Forms.View.Details;
            this.olvPayments.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.olvPayments_CellEditFinishing);
            this.olvPayments.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.olvPayments_CellEditStarting);
            this.olvPayments.CellEditValidating += new BrightIdeasSoftware.CellEditEventHandler(this.olvPayments_CellEditValidating);
            this.olvPayments.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.olvPayments_CellClick);
            // 
            // olvColDelete
            // 
            this.olvColDelete.IsEditable = false;
            this.olvColDelete.Searchable = false;
            this.olvColDelete.Sortable = false;
            this.olvColDelete.Text = "";
            this.olvColDelete.UseFiltering = false;
            this.olvColDelete.Width = 30;
            // 
            // olvColAmount
            // 
            this.olvColAmount.AspectName = "Amount";
            this.olvColAmount.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColAmount.Text = "Amount";
            this.olvColAmount.Width = 150;
            // 
            // olvColDate
            // 
            this.olvColDate.AspectName = "Date";
            this.olvColDate.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColDate.Text = "Date";
            this.olvColDate.Width = 150;
            // 
            // olvColCheck
            // 
            this.olvColCheck.AspectName = "Check";
            this.olvColCheck.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColCheck.Text = "Check";
            this.olvColCheck.Width = 200;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "delete.png");
            this.imgList.Images.SetKeyName(1, "editing-icon15.png");
            // 
            // btnNewPayment
            // 
            this.btnNewPayment.BackColor = System.Drawing.Color.Gray;
            this.btnNewPayment.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewPayment.ForeColor = System.Drawing.Color.White;
            this.btnNewPayment.Location = new System.Drawing.Point(7, 18);
            this.btnNewPayment.Name = "btnNewPayment";
            this.btnNewPayment.Size = new System.Drawing.Size(98, 29);
            this.btnNewPayment.TabIndex = 48;
            this.btnNewPayment.Text = "New Payment";
            this.btnNewPayment.UseVisualStyleBackColor = false;
            this.btnNewPayment.Click += new System.EventHandler(this.btnNewPayment_Click);
            // 
            // InvPaymentControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.grpPayment);
            this.Name = "InvPaymentControl";
            this.Size = new System.Drawing.Size(604, 357);
            this.Load += new System.EventHandler(this.InvPaymentControl_Load);
            this.grpPayment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvPayments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPayment;
        private BrightIdeasSoftware.ObjectListView olvPayments;
        private System.Windows.Forms.Button btnNewPayment;
        private System.Windows.Forms.Button btnAcceptPayment;
        private System.Windows.Forms.Button btnCancel;
        private BrightIdeasSoftware.OLVColumn olvColDelete;
        private BrightIdeasSoftware.OLVColumn olvColAmount;
        private BrightIdeasSoftware.OLVColumn olvColDate;
        private BrightIdeasSoftware.OLVColumn olvColCheck;
        private System.Windows.Forms.ImageList imgList;
    }
}
