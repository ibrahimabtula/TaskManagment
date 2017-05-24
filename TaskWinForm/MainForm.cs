using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Task.Core;
using Task.DAL;

namespace TaskWinForm
{
    public partial class MainForm : XtraForm
    {
       
        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            ConnectionBuilder.SetConnectionString(System.Configuration.ConfigurationSettings.AppSettings["DB:ConnectionString"]);

            //_taskService = new TaskService();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            btnAllTask_Click(this, new EventArgs());
        }

        private void ChangeActiveControl(Control NewControl)
        {
            if (pnlActiveControl.Controls.Count > 0 &&
                pnlActiveControl.Controls[0].GetType() == NewControl.GetType())
            {
                return;
            }

            pnlActiveControl.Controls.Clear();
            NewControl.Dock = DockStyle.Fill;
            NewControl.Visible = true;
            pnlActiveControl.Controls.Add(NewControl);
        }

        private void btnAllTask_Click(object sender, EventArgs e)
        {
            var control = new TaskListControl();
            ChangeActiveControl(control);
        }
    }
}
