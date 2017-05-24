namespace TaskWinForm
{
    partial class TaskListControl
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
            this.gcTasks = new DevExpress.XtraGrid.GridControl();
            this.gvTasks = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gcTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTasks
            // 
            this.gcTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTasks.Location = new System.Drawing.Point(0, 0);
            this.gcTasks.MainView = this.gvTasks;
            this.gcTasks.Name = "gcTasks";
            this.gcTasks.Size = new System.Drawing.Size(571, 404);
            this.gcTasks.TabIndex = 0;
            this.gcTasks.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTasks});
            // 
            // gvTasks
            // 
            this.gvTasks.GridControl = this.gcTasks;
            this.gvTasks.Name = "gvTasks";
            // 
            // TaskListControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcTasks);
            this.Name = "TaskListControl2";
            this.Size = new System.Drawing.Size(571, 404);
            ((System.ComponentModel.ISupportInitialize)(this.gcTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTasks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcTasks;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTasks;
    }
}
