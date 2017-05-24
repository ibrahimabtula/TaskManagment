namespace TaskWinForm
{
    partial class CommentsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gcComments = new DevExpress.XtraGrid.GridControl();
            this.gvComments = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.lueType = new DevExpress.XtraEditors.LookUpEdit();
            this.deReminderDate = new DevExpress.XtraEditors.DateEdit();
            this.deDateAdded = new DevExpress.XtraEditors.DateEdit();
            this.lblReminderDate = new DevExpress.XtraEditors.LabelControl();
            this.lblType = new DevExpress.XtraEditors.LabelControl();
            this.lblDateAdded = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcComments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReminderDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReminderDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateAdded.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateAdded.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcComments
            // 
            this.gcComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcComments.Location = new System.Drawing.Point(181, 0);
            this.gcComments.MainView = this.gvComments;
            this.gcComments.Name = "gcComments";
            this.gcComments.Size = new System.Drawing.Size(390, 404);
            this.gcComments.TabIndex = 0;
            this.gcComments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvComments});
            // 
            // gvComments
            // 
            this.gvComments.GridControl = this.gcComments;
            this.gvComments.Name = "gvComments";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lueType);
            this.panelControl1.Controls.Add(this.deReminderDate);
            this.panelControl1.Controls.Add(this.deDateAdded);
            this.panelControl1.Controls.Add(this.lblReminderDate);
            this.panelControl1.Controls.Add(this.lblType);
            this.panelControl1.Controls.Add(this.lblDateAdded);
            this.panelControl1.Controls.Add(this.btnSearch);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(181, 404);
            this.panelControl1.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(16, 293);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(130, 87);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lueType
            // 
            this.lueType.Location = new System.Drawing.Point(16, 99);
            this.lueType.Name = "lueType";
            this.lueType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueType.Size = new System.Drawing.Size(130, 20);
            this.lueType.TabIndex = 13;
            // 
            // deReminderDate
            // 
            this.deReminderDate.EditValue = null;
            this.deReminderDate.Location = new System.Drawing.Point(16, 158);
            this.deReminderDate.Name = "deReminderDate";
            this.deReminderDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deReminderDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deReminderDate.Size = new System.Drawing.Size(130, 20);
            this.deReminderDate.TabIndex = 12;
            // 
            // deDateAdded
            // 
            this.deDateAdded.EditValue = null;
            this.deDateAdded.Location = new System.Drawing.Point(16, 45);
            this.deDateAdded.Name = "deDateAdded";
            this.deDateAdded.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateAdded.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateAdded.Size = new System.Drawing.Size(130, 20);
            this.deDateAdded.TabIndex = 11;
            // 
            // lblReminderDate
            // 
            this.lblReminderDate.Location = new System.Drawing.Point(16, 139);
            this.lblReminderDate.Name = "lblReminderDate";
            this.lblReminderDate.Size = new System.Drawing.Size(74, 13);
            this.lblReminderDate.TabIndex = 10;
            this.lblReminderDate.Text = "Reminder date:";
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(16, 80);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(28, 13);
            this.lblType.TabIndex = 9;
            this.lblType.Text = "Type:";
            // 
            // lblDateAdded
            // 
            this.lblDateAdded.Location = new System.Drawing.Point(16, 26);
            this.lblDateAdded.Name = "lblDateAdded";
            this.lblDateAdded.Size = new System.Drawing.Size(60, 13);
            this.lblDateAdded.TabIndex = 8;
            this.lblDateAdded.Text = "Date added:";
            // 
            // CommentsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcComments);
            this.Controls.Add(this.panelControl1);
            this.Name = "CommentsControl";
            this.Size = new System.Drawing.Size(571, 404);
            ((System.ComponentModel.ISupportInitialize)(this.gcComments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReminderDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReminderDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateAdded.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateAdded.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcComments;
        private DevExpress.XtraGrid.Views.Grid.GridView gvComments;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LookUpEdit lueType;
        private DevExpress.XtraEditors.DateEdit deReminderDate;
        private DevExpress.XtraEditors.DateEdit deDateAdded;
        private DevExpress.XtraEditors.LabelControl lblReminderDate;
        private DevExpress.XtraEditors.LabelControl lblType;
        private DevExpress.XtraEditors.LabelControl lblDateAdded;
    }
}
