using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Task.Core;

namespace TaskWinForm
{
    public partial class TaskAddEditForm : DevExpress.XtraEditors.XtraForm
    {
        private Task.Core.Task _task;
        private const string TEXT = "Edit Task";
        private const string TEXT_DIRTY = "Edit Task*";

        public TaskAddEditForm(Task.Core.Task Task)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;

            _task = Task;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _task.DirtyStateChanged += _task_DirtyStateChanged;
            this.Closing += TaskAddEditForm_Closing;
            gvComments.DoubleClick += GvComments_DoubleClick;

            ConfigUiElements();
            SetDatabindigs();
        }

        private void GvComments_DoubleClick(object sender, EventArgs e)
        {
            var view = sender as GridView;
            var comment = view.GetRow(view.FocusedRowHandle) as Task.Core.Comment;

            //TODO: Clone before provide to form
            using (var frm = new CommentAddEditForm(comment))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //TODO: Save comment
                }
            }
        }

        private void TaskAddEditForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_task.IsDirty)
            {
                var result = XtraMessageBox.Show(
                    this, 
                    "Save changes?", 
                    "Task management", 
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes) ;
                //TODO: Save
            }
        }

        private void _task_DirtyStateChanged(object sender)
        {
            if (_task.IsDirty)
                this.Text = TEXT_DIRTY;
            else
                this.Text = TEXT;
        }

        private void ConfigUiElements()
        {
            deCreatedDate.Properties.NullDate = null;
            deRequiredByDate.Properties.NullDate = null;
            lueStatus.Properties.NullText = string.Empty;
            lueType.Properties.NullText = string.Empty;

            InitCommentsGrid();
        }

        private void InitCommentsGrid()
        {
            var col = new GridColumn();
            col.Visible = true;
            col.OptionsColumn.AllowEdit = false;
            col.FieldName = nameof(Task.Core.Comment.DateAdded);
            col.Caption = "Date added";
            gvComments.Columns.Add(col);

            col = new GridColumn();
            col.Visible = true;
            col.OptionsColumn.AllowEdit = false;
            col.FieldName = nameof(Task.Core.Comment.ReminderDate);
            col.Caption = "Reminder date";
            gvComments.Columns.Add(col);


            col = new GridColumn();
            col.Visible = true;
            col.OptionsColumn.AllowEdit = false;
            col.FieldName = nameof(Task.Core.Comment.Text);
            col.Caption = "Comment";
            gvComments.Columns.Add(col);
        }

        private void SetDatabindigs()
        {
            deCreatedDate.DataBindings.Add("EditValue", _task, nameof(Task.Core.Task.CreatedDate))
                .DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            deRequiredByDate.DataBindings.Add("EditValue", _task, nameof(Task.Core.Task.RequiredByDate))
                .DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;

            meDescription.DataBindings.Add("EditValue", _task, nameof(Task.Core.Task.Description))
                .DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            lueStatus.DataBindings.Add("EditValue", _task, nameof(Task.Core.Task.TaskStatusId))
                .DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            lueType.DataBindings.Add("EditValue", _task, nameof(Task.Core.Task.TaskTypeID))
                .DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;

            lueStatus.Properties.DataSource = TaskStatusCollection.GetAll();
            lueStatus.Properties.Columns.Clear();
            lueStatus.Properties.Columns.Add(new LookUpColumnInfo(nameof(Task.Core.TaskStatus.Name)));
            lueStatus.Properties.ValueMember = nameof(Task.Core.TaskStatus.ID);
            lueStatus.Properties.DisplayMember = nameof(Task.Core.TaskStatus.Name);

            lueType.Properties.DataSource = TaskTypeColelction.GetAll();
            lueType.Properties.Columns.Clear();
            lueType.Properties.Columns.Add(new LookUpColumnInfo(nameof(TaskType.Name)));
            lueType.Properties.ValueMember = nameof(TaskType.ID);
            lueType.Properties.DisplayMember = nameof(TaskType.Name);

            gcComments.DataSource = _task.Comments;
        }
    }
}