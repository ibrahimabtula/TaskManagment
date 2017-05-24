namespace TaskWinForm
{
    partial class CommentAddEditForm
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
            this.lblDateAdded = new DevExpress.XtraEditors.LabelControl();
            this.lblType = new DevExpress.XtraEditors.LabelControl();
            this.lblReminderDate = new DevExpress.XtraEditors.LabelControl();
            this.lblComment = new DevExpress.XtraEditors.LabelControl();
            this.deDateAdded = new DevExpress.XtraEditors.DateEdit();
            this.deReminderDate = new DevExpress.XtraEditors.DateEdit();
            this.meText = new DevExpress.XtraEditors.MemoEdit();
            this.lueType = new DevExpress.XtraEditors.LookUpEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.deDateAdded.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateAdded.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReminderDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReminderDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDateAdded
            // 
            this.lblDateAdded.Location = new System.Drawing.Point(27, 32);
            this.lblDateAdded.Name = "lblDateAdded";
            this.lblDateAdded.Size = new System.Drawing.Size(60, 13);
            this.lblDateAdded.TabIndex = 0;
            this.lblDateAdded.Text = "Date added:";
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(27, 68);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(28, 13);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "Type:";
            // 
            // lblReminderDate
            // 
            this.lblReminderDate.Location = new System.Drawing.Point(27, 104);
            this.lblReminderDate.Name = "lblReminderDate";
            this.lblReminderDate.Size = new System.Drawing.Size(74, 13);
            this.lblReminderDate.TabIndex = 2;
            this.lblReminderDate.Text = "Reminder date:";
            // 
            // lblComment
            // 
            this.lblComment.Location = new System.Drawing.Point(27, 139);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(49, 13);
            this.lblComment.TabIndex = 3;
            this.lblComment.Text = "Comment:";
            // 
            // deDateAdded
            // 
            this.deDateAdded.EditValue = null;
            this.deDateAdded.Location = new System.Drawing.Point(120, 29);
            this.deDateAdded.Name = "deDateAdded";
            this.deDateAdded.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateAdded.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateAdded.Size = new System.Drawing.Size(130, 20);
            this.deDateAdded.TabIndex = 4;
            // 
            // deReminderDate
            // 
            this.deReminderDate.EditValue = null;
            this.deReminderDate.Location = new System.Drawing.Point(120, 101);
            this.deReminderDate.Name = "deReminderDate";
            this.deReminderDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deReminderDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deReminderDate.Size = new System.Drawing.Size(130, 20);
            this.deReminderDate.TabIndex = 5;
            // 
            // meText
            // 
            this.meText.Location = new System.Drawing.Point(27, 158);
            this.meText.Name = "meText";
            this.meText.Size = new System.Drawing.Size(223, 96);
            this.meText.TabIndex = 6;
            // 
            // lueType
            // 
            this.lueType.Location = new System.Drawing.Point(120, 68);
            this.lueType.Name = "lueType";
            this.lueType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueType.Size = new System.Drawing.Size(130, 20);
            this.lueType.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(183, 262);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(26, 262);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CommentAddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 297);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lueType);
            this.Controls.Add(this.meText);
            this.Controls.Add(this.deReminderDate);
            this.Controls.Add(this.deDateAdded);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.lblReminderDate);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblDateAdded);
            this.Name = "CommentAddEditForm";
            this.Text = "Edit comment";
            ((System.ComponentModel.ISupportInitialize)(this.deDateAdded.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateAdded.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReminderDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReminderDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblDateAdded;
        private DevExpress.XtraEditors.LabelControl lblType;
        private DevExpress.XtraEditors.LabelControl lblReminderDate;
        private DevExpress.XtraEditors.LabelControl lblComment;
        private DevExpress.XtraEditors.DateEdit deDateAdded;
        private DevExpress.XtraEditors.DateEdit deReminderDate;
        private DevExpress.XtraEditors.MemoEdit meText;
        private DevExpress.XtraEditors.LookUpEdit lueType;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}