using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Task.Core;
using Task.DAL;
using Task.Service;

namespace TaskWinForm
{
    public partial class MainForm : XtraForm
    {
        private TaskService _taskService;

        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            ConnectionBuilder.SetConnectionString(System.Configuration.ConfigurationSettings.AppSettings["DB:ConnectionString"]);

            _taskService = new TaskService();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
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
            control.OnRowDoubleClick += Control_OnRowDoubleClick;
            ChangeActiveControl(control);
        }

        private void Control_OnRowDoubleClick(object sender, EventArgs e)
        {
            var view = (sender as GridView);
            var task = view.GetRow(view.FocusedRowHandle) as Task.Core.Task;

            if (task != null)
            {
                var control = new TaskEditControl();
                control.Init(_taskService.GetById(task.ID));
                ChangeActiveControl(control);
            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            var control = new TaskEditControl();
            control.Init(_taskService.CreateNew());
            ChangeActiveControl(control);
        }
    }
}
