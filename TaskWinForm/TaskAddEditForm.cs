using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Task.Core;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;

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

        private void ConfigUiElements()
        {
            gvComments.OptionsView.ShowDetailButtons = false;

            deCreatedDate.Properties.NullDate = DateTime.MinValue;
            deCreatedDate.Properties.NullText = string.Empty;

            deRequiredByDate.Properties.NullDate = DateTime.MinValue;
            deRequiredByDate.Properties.NullText = string.Empty;

            deReminderDate.Properties.NullDate = null;
            deReminderDate.Properties.NullText = string.Empty;
            deReminderDate.ReadOnly = true;
            //deReminderDate.Enabled = false;

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

            col = new GridColumn();
            var repItem = new RepositoryItemButtonEdit();
            repItem.Buttons.Clear();
            var eb = new EditorButton(ButtonPredefines.Delete);
            eb.Width = 20;
            repItem.Buttons.Add(eb);
            repItem.TextEditStyle = TextEditStyles.DisableTextEditor;
            repItem.ButtonClick += RepItem_ButtonClick;
            col.ShowButtonMode = ShowButtonModeEnum.ShowAlways;            
            col.ColumnEdit = repItem;
            col.Visible = true;
            col.Width = 30;
            col.OptionsColumn.AllowEdit = true;
            col.FieldName = "BtnDelete";
            col.Caption = " ";
            gvComments.Columns.Add(col);
        }

        private void RepItem_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var comment = gvComments.GetRow(gvComments.FocusedRowHandle) as Task.Core.Comment;
            if (comment != null)
            {
                var result = XtraMessageBox.Show(
                    this,
                    "Delete comment?",
                    "Task management",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    comment.MarkDeleted();
                    _task.Comments.Remove(comment);
                }
            }
        }

        private void SetDatabindigs()
        {            
            deCreatedDate.DataBindings.Add("EditValue", _task, nameof(Task.Core.Task.CreatedDateNonNullable))
                .DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;

            deRequiredByDate.DataBindings.Add("EditValue", _task, nameof(Task.Core.Task.RequiredByDateNonNullable))
                .DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;

            deReminderDate.DataBindings.Add("EditValue", _task, nameof(Task.Core.Task.ReminderDate))
                .DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;

            meDescription.DataBindings.Add("EditValue", _task, nameof(Task.Core.Task.Description))
                .DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;

            lueStatus.DataBindings.Add("EditValue", _task, nameof(Task.Core.Task.TaskStatusId))
                .DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;

            lueType.DataBindings.Add("EditValue", _task, nameof(Task.Core.Task.TaskTypeId))
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

        private void GvComments_DoubleClick(object sender, EventArgs e)
        {
            var view = sender as GridView;
            var comment = view.GetRow(view.FocusedRowHandle) as Task.Core.Comment;

            //TODO: Clone before provide to form
            var cloneComment = (Task.Core.Comment)comment.Clone();
            using (var frm = new CommentAddEditForm(cloneComment))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int i = _task.Comments.IndexOf(comment);
                    _task.Comments[i] = cloneComment;
                }
            }
        }

        private void TaskAddEditForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            btnSave.Focus();

            if (DialogResult == DialogResult.No)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }

            if (_task.IsDirty)
            {
                if (DialogResult == DialogResult.Cancel)
                {
                    var result = XtraMessageBox.Show(
                        this,
                        "Save changes?",
                        "Task management",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        DialogResult = DialogResult.OK;
                        _task.Update();
                    }
                    else if (result == DialogResult.No)
                    {
                        DialogResult = DialogResult.Cancel;
                        return;
                    }
                }

                if (!_task.IsValid())
                {
                    XtraMessageBox.Show(
                        this,
                        String.Concat(_task.Rules.Select(s => s.Description + Environment.NewLine)),
                        "Task management",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    e.Cancel = true;
                }
                else
                {
                    _task.Update();
                }
            }           
        }

        private void _task_DirtyStateChanged(object sender)
        {
            if (_task.IsDirty)
                this.Text = TEXT_DIRTY;
            else
                this.Text = TEXT;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCansel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            var comment = _task.CreateComment();

            using (var frm = new CommentAddEditForm(comment))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _task.Comments.Add(comment);
                    gcComments.RefreshDataSource();
                }
            }
        }
    }
}