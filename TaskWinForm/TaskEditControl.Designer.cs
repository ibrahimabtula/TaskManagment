namespace TaskWinForm
{
    partial class TaskEditControl
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
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCansel = new DevExpress.XtraEditors.SimpleButton();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.gcComments = new DevExpress.XtraGrid.GridControl();
            this.gvComments = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lueType = new DevExpress.XtraEditors.LookUpEdit();
            this.lueStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.meDescription = new DevExpress.XtraEditors.MemoEdit();
            this.deRequiredByDate = new DevExpress.XtraEditors.DateEdit();
            this.deCreatedDate = new DevExpress.XtraEditors.DateEdit();
            this.lblType = new DevExpress.XtraEditors.LabelControl();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.lblDescription = new DevExpress.XtraEditors.LabelControl();
            this.lblRequiredByDate = new DevExpress.XtraEditors.LabelControl();
            this.lblCreatedDate = new DevExpress.XtraEditors.LabelControl();
            this.xtraScrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcComments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRequiredByDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRequiredByDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreatedDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreatedDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(234, 518);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 37);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCansel
            // 
            this.btnCansel.Location = new System.Drawing.Point(14, 518);
            this.btnCansel.Name = "btnCansel";
            this.btnCansel.Size = new System.Drawing.Size(75, 37);
            this.btnCansel.TabIndex = 11;
            this.btnCansel.Text = "Cancel";
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.gcComments);
            this.xtraScrollableControl1.Controls.Add(this.btnCansel);
            this.xtraScrollableControl1.Controls.Add(this.lueType);
            this.xtraScrollableControl1.Controls.Add(this.btnSave);
            this.xtraScrollableControl1.Controls.Add(this.lueStatus);
            this.xtraScrollableControl1.Controls.Add(this.meDescription);
            this.xtraScrollableControl1.Controls.Add(this.deRequiredByDate);
            this.xtraScrollableControl1.Controls.Add(this.deCreatedDate);
            this.xtraScrollableControl1.Controls.Add(this.lblType);
            this.xtraScrollableControl1.Controls.Add(this.lblStatus);
            this.xtraScrollableControl1.Controls.Add(this.lblDescription);
            this.xtraScrollableControl1.Controls.Add(this.lblRequiredByDate);
            this.xtraScrollableControl1.Controls.Add(this.lblCreatedDate);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(327, 585);
            this.xtraScrollableControl1.TabIndex = 13;
            // 
            // gcComments
            // 
            this.gcComments.Location = new System.Drawing.Point(14, 274);
            this.gcComments.MainView = this.gvComments;
            this.gcComments.Name = "gcComments";
            this.gcComments.Size = new System.Drawing.Size(295, 229);
            this.gcComments.TabIndex = 23;
            this.gcComments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvComments});
            // 
            // gvComments
            // 
            this.gvComments.GridControl = this.gcComments;
            this.gvComments.Name = "gvComments";
            this.gvComments.OptionsView.ShowGroupPanel = false;
            // 
            // lueType
            // 
            this.lueType.Location = new System.Drawing.Point(133, 248);
            this.lueType.Name = "lueType";
            this.lueType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueType.Size = new System.Drawing.Size(176, 20);
            this.lueType.TabIndex = 22;
            // 
            // lueStatus
            // 
            this.lueStatus.Location = new System.Drawing.Point(133, 211);
            this.lueStatus.Name = "lueStatus";
            this.lueStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueStatus.Size = new System.Drawing.Size(176, 20);
            this.lueStatus.TabIndex = 21;
            // 
            // meDescription
            // 
            this.meDescription.Location = new System.Drawing.Point(14, 124);
            this.meDescription.Name = "meDescription";
            this.meDescription.Size = new System.Drawing.Size(295, 75);
            this.meDescription.TabIndex = 20;
            // 
            // deRequiredByDate
            // 
            this.deRequiredByDate.EditValue = null;
            this.deRequiredByDate.Location = new System.Drawing.Point(133, 59);
            this.deRequiredByDate.Name = "deRequiredByDate";
            this.deRequiredByDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deRequiredByDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deRequiredByDate.Size = new System.Drawing.Size(176, 20);
            this.deRequiredByDate.TabIndex = 19;
            // 
            // deCreatedDate
            // 
            this.deCreatedDate.EditValue = null;
            this.deCreatedDate.Location = new System.Drawing.Point(133, 23);
            this.deCreatedDate.Name = "deCreatedDate";
            this.deCreatedDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deCreatedDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deCreatedDate.Size = new System.Drawing.Size(176, 20);
            this.deCreatedDate.TabIndex = 18;
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(14, 251);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(28, 13);
            this.lblType.TabIndex = 17;
            this.lblType.Text = "Type:";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(14, 219);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 16;
            this.lblStatus.Text = "Status:";
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(14, 105);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(57, 13);
            this.lblDescription.TabIndex = 15;
            this.lblDescription.Text = "Description:";
            // 
            // lblRequiredByDate
            // 
            this.lblRequiredByDate.Location = new System.Drawing.Point(14, 62);
            this.lblRequiredByDate.Name = "lblRequiredByDate";
            this.lblRequiredByDate.Size = new System.Drawing.Size(87, 13);
            this.lblRequiredByDate.TabIndex = 14;
            this.lblRequiredByDate.Text = "Required by date:";
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.Location = new System.Drawing.Point(14, 26);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(68, 13);
            this.lblCreatedDate.TabIndex = 13;
            this.lblCreatedDate.Text = "Created date:";
            // 
            // TaskEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraScrollableControl1);
            this.Name = "TaskEditControl";
            this.Size = new System.Drawing.Size(327, 585);
            this.xtraScrollableControl1.ResumeLayout(false);
            this.xtraScrollableControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcComments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRequiredByDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRequiredByDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreatedDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreatedDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCansel;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraGrid.GridControl gcComments;
        private DevExpress.XtraGrid.Views.Grid.GridView gvComments;
        private DevExpress.XtraEditors.LookUpEdit lueType;
        private DevExpress.XtraEditors.LookUpEdit lueStatus;
        private DevExpress.XtraEditors.MemoEdit meDescription;
        private DevExpress.XtraEditors.DateEdit deRequiredByDate;
        private DevExpress.XtraEditors.DateEdit deCreatedDate;
        private DevExpress.XtraEditors.LabelControl lblType;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.LabelControl lblDescription;
        private DevExpress.XtraEditors.LabelControl lblRequiredByDate;
        private DevExpress.XtraEditors.LabelControl lblCreatedDate;
    }
}
