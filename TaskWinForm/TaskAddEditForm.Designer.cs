namespace TaskWinForm
{
    partial class TaskAddEditForm
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
            this.gcComments = new DevExpress.XtraGrid.GridControl();
            this.gvComments = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnCansel = new DevExpress.XtraEditors.SimpleButton();
            this.lueType = new DevExpress.XtraEditors.LookUpEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.lueStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.meDescription = new DevExpress.XtraEditors.MemoEdit();
            this.deRequiredByDate = new DevExpress.XtraEditors.DateEdit();
            this.deCreatedDate = new DevExpress.XtraEditors.DateEdit();
            this.lblType = new DevExpress.XtraEditors.LabelControl();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.lblDescription = new DevExpress.XtraEditors.LabelControl();
            this.lblRequiredByDate = new DevExpress.XtraEditors.LabelControl();
            this.lblCreatedDate = new DevExpress.XtraEditors.LabelControl();
            this.lblReminderDate = new DevExpress.XtraEditors.LabelControl();
            this.deReminderDate = new DevExpress.XtraEditors.DateEdit();
            this.btnAddComment = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcComments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRequiredByDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRequiredByDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreatedDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreatedDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReminderDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReminderDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcComments
            // 
            this.gcComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcComments.Location = new System.Drawing.Point(12, 310);
            this.gcComments.MainView = this.gvComments;
            this.gcComments.Name = "gcComments";
            this.gcComments.Size = new System.Drawing.Size(295, 122);
            this.gcComments.TabIndex = 36;
            this.gcComments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvComments});
            // 
            // gvComments
            // 
            this.gvComments.GridControl = this.gcComments;
            this.gvComments.Name = "gvComments";
            this.gvComments.OptionsView.ShowGroupPanel = false;
            // 
            // btnCansel
            // 
            this.btnCansel.Location = new System.Drawing.Point(12, 455);
            this.btnCansel.Name = "btnCansel";
            this.btnCansel.Size = new System.Drawing.Size(75, 37);
            this.btnCansel.TabIndex = 25;
            this.btnCansel.Text = "Cancel";
            this.btnCansel.Click += new System.EventHandler(this.btnCansel_Click);
            // 
            // lueType
            // 
            this.lueType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lueType.Location = new System.Drawing.Point(131, 249);
            this.lueType.Name = "lueType";
            this.lueType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueType.Size = new System.Drawing.Size(176, 20);
            this.lueType.TabIndex = 35;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(232, 455);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 37);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lueStatus
            // 
            this.lueStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lueStatus.Location = new System.Drawing.Point(131, 213);
            this.lueStatus.Name = "lueStatus";
            this.lueStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueStatus.Size = new System.Drawing.Size(176, 20);
            this.lueStatus.TabIndex = 34;
            // 
            // meDescription
            // 
            this.meDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.meDescription.Location = new System.Drawing.Point(12, 135);
            this.meDescription.Name = "meDescription";
            this.meDescription.Size = new System.Drawing.Size(295, 55);
            this.meDescription.TabIndex = 33;
            // 
            // deRequiredByDate
            // 
            this.deRequiredByDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deRequiredByDate.EditValue = null;
            this.deRequiredByDate.Location = new System.Drawing.Point(131, 44);
            this.deRequiredByDate.Name = "deRequiredByDate";
            this.deRequiredByDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deRequiredByDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deRequiredByDate.Size = new System.Drawing.Size(176, 20);
            this.deRequiredByDate.TabIndex = 32;
            // 
            // deCreatedDate
            // 
            this.deCreatedDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deCreatedDate.EditValue = null;
            this.deCreatedDate.Location = new System.Drawing.Point(131, 8);
            this.deCreatedDate.Name = "deCreatedDate";
            this.deCreatedDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deCreatedDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deCreatedDate.Size = new System.Drawing.Size(176, 20);
            this.deCreatedDate.TabIndex = 31;
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(12, 252);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(28, 13);
            this.lblType.TabIndex = 30;
            this.lblType.Text = "Type:";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(12, 216);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 29;
            this.lblStatus.Text = "Status:";
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(12, 116);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(57, 13);
            this.lblDescription.TabIndex = 28;
            this.lblDescription.Text = "Description:";
            // 
            // lblRequiredByDate
            // 
            this.lblRequiredByDate.Location = new System.Drawing.Point(12, 47);
            this.lblRequiredByDate.Name = "lblRequiredByDate";
            this.lblRequiredByDate.Size = new System.Drawing.Size(87, 13);
            this.lblRequiredByDate.TabIndex = 27;
            this.lblRequiredByDate.Text = "Required by date:";
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.Location = new System.Drawing.Point(12, 11);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(68, 13);
            this.lblCreatedDate.TabIndex = 26;
            this.lblCreatedDate.Text = "Created date:";
            // 
            // lblReminderDate
            // 
            this.lblReminderDate.Location = new System.Drawing.Point(12, 81);
            this.lblReminderDate.Name = "lblReminderDate";
            this.lblReminderDate.Size = new System.Drawing.Size(74, 13);
            this.lblReminderDate.TabIndex = 37;
            this.lblReminderDate.Text = "Reminder date:";
            // 
            // deReminderDate
            // 
            this.deReminderDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deReminderDate.EditValue = null;
            this.deReminderDate.Location = new System.Drawing.Point(131, 78);
            this.deReminderDate.Name = "deReminderDate";
            this.deReminderDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deReminderDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deReminderDate.Size = new System.Drawing.Size(176, 20);
            this.deReminderDate.TabIndex = 38;
            // 
            // btnAddComment
            // 
            this.btnAddComment.Location = new System.Drawing.Point(12, 283);
            this.btnAddComment.Name = "btnAddComment";
            this.btnAddComment.Size = new System.Drawing.Size(75, 25);
            this.btnAddComment.TabIndex = 39;
            this.btnAddComment.Text = "Add comment";
            this.btnAddComment.Click += new System.EventHandler(this.btnAddComment_Click);
            // 
            // TaskAddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 509);
            this.Controls.Add(this.btnAddComment);
            this.Controls.Add(this.deReminderDate);
            this.Controls.Add(this.lblReminderDate);
            this.Controls.Add(this.gcComments);
            this.Controls.Add(this.btnCansel);
            this.Controls.Add(this.lueType);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lueStatus);
            this.Controls.Add(this.meDescription);
            this.Controls.Add(this.deRequiredByDate);
            this.Controls.Add(this.deCreatedDate);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblRequiredByDate);
            this.Controls.Add(this.lblCreatedDate);
            this.Name = "TaskAddEditForm";
            this.Text = "Edit Task";
            ((System.ComponentModel.ISupportInitialize)(this.gcComments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRequiredByDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRequiredByDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreatedDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreatedDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReminderDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReminderDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcComments;
        private DevExpress.XtraGrid.Views.Grid.GridView gvComments;
        private DevExpress.XtraEditors.SimpleButton btnCansel;
        private DevExpress.XtraEditors.LookUpEdit lueType;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LookUpEdit lueStatus;
        private DevExpress.XtraEditors.MemoEdit meDescription;
        private DevExpress.XtraEditors.DateEdit deRequiredByDate;
        private DevExpress.XtraEditors.DateEdit deCreatedDate;
        private DevExpress.XtraEditors.LabelControl lblType;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.LabelControl lblDescription;
        private DevExpress.XtraEditors.LabelControl lblRequiredByDate;
        private DevExpress.XtraEditors.LabelControl lblCreatedDate;
        private DevExpress.XtraEditors.LabelControl lblReminderDate;
        private DevExpress.XtraEditors.DateEdit deReminderDate;
        private DevExpress.XtraEditors.SimpleButton btnAddComment;
    }
}