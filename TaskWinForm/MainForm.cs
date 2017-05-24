using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Task.DAL;

namespace TaskWinForm
{
    public partial class MainForm : XtraForm
    {
        private TaskListControl _taskListControl;
        private CommentsControl _comeControl;

        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            ConnectionBuilder.SetConnectionString(System.Configuration.ConfigurationSettings.AppSettings["DB:ConnectionString"]);

            _taskListControl = new TaskListControl();
            _taskListControl.Dock = DockStyle.Fill;
            _taskListControl.Visible = true;
            pnlActiveControl.Controls.Add(_taskListControl);

            _comeControl = new CommentsControl();
            _comeControl.Dock = DockStyle.Fill;
            _comeControl.Visible = true;
            pnlActiveControl.Controls.Add(_taskListControl);
            //_taskService = new TaskService();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            btnAllTask_Click(this, new EventArgs());
        }

        private void btnAllTask_Click(object sender, EventArgs e)
        {
            pnlActiveControl.Controls.Clear();
            pnlActiveControl.Controls.Add(_taskListControl);
            _taskListControl.UpdateGrid();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            var task = new Task.Core.Task();

            using (var frm = new TaskAddEditForm(task))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _taskListControl.UpdateGrid();
                }                
            }
        }

        private void btnComments_Click(object sender, EventArgs e)
        {
            pnlActiveControl.Controls.Clear();
            pnlActiveControl.Controls.Add(_comeControl);
        }
    }
}
