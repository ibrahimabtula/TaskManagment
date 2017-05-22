using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using Task.Core;
using Task.Service;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskWinForm
{
    public partial class TaskEditControl : XtraUserControl
    {
        private Task.Core.Task _task;
        private Task.Service.TaskService _taskService;
        private Task.Service.TaskStatusService _taskStatusService;
        private Task.Service.TaskTypeService _taskTypeService;
        private Task.Service.CommentService _commentService;

        private FullyObservableCollection<Task.Core.Comment> comments;

        public TaskEditControl()
        {
            InitializeComponent();

            _taskService = new TaskService();
            _taskStatusService = new TaskStatusService();
            _taskTypeService = new TaskTypeService();
            _commentService = new CommentService();
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
            col.FieldName = nameof(Task.Core.Comment.ID);
            col.Caption = "ID";
            col.OptionsColumn.AllowEdit = false;
            col.Width = 20;
            gvComments.Columns.Add(col);

            col = new GridColumn();
            col.Visible = true;
            col.FieldName = nameof(Task.Core.Comment.DateAdded);
            col.Caption = "Date added";
            gvComments.Columns.Add(col);

            col = new GridColumn();
            col.Visible = true;
            col.FieldName = nameof(Task.Core.Comment.ReminderDate);
            col.Caption = "Reminder date";
            gvComments.Columns.Add(col);


            col = new GridColumn();
            col.Visible = true;
            col.FieldName = nameof(Task.Core.Comment.Text);
            col.Caption = "Comment";
            gvComments.Columns.Add(col);
        }

        public void Init(Task.Core.Task Task)
        {
            _task = Task;
            _task.CreatedDate = DateTime.Now;
            comments = new FullyObservableCollection<Task.Core.Comment>(_task.Comments);

            ConfigUiElements();            

            SetDatabindigs();

            _task.DirtyStateChanged += _task_DirtyStateChanged;
            comments.CollectionChanged += Comments_CollectionChanged;
            comments.ItemPropertyChanged += Comments_ItemPropertyChanged;
        }

        private void _task_DirtyStateChanged(object sender)
        {
            SaveChanges();
        }

        private void Comments_ItemPropertyChanged(object sender, ItemPropertyChangedEventArgs e)
        {
            SaveChanges();
        }

        private void Comments_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           SaveChanges();
        }

        private void SaveChanges()
        {
            foreach (Task.Core.Comment comment in comments)
            {
                _commentService.Update(comment);
            }
        }

        private void SetDatabindigs()
        {
            deCreatedDate.DataBindings.Add("EditValue", _task, nameof(Task.Core.Task.CreatedDate))
                .DataSourceUpdateMode = DataSourceUpdateMode.OnValidation;
            deRequiredByDate.DataBindings.Add("EditValue", _task, nameof(Task.Core.Task.RequiredByDate))
                .DataSourceUpdateMode = DataSourceUpdateMode.OnValidation;

            meDescription.DataBindings.Add("EditValue", _task, nameof(Task.Core.Task.Description));
            lueStatus.DataBindings.Add("EditValue", _task, nameof(Task.Core.Task.TaskStatusId));
            lueType.DataBindings.Add("EditValue", _task, nameof(Task.Core.Task.TaskTypeID));

            lueStatus.Properties.DataSource = _taskStatusService.GetAll().ToList();
            lueStatus.Properties.Columns.Clear();
            lueStatus.Properties.Columns.Add(new LookUpColumnInfo(nameof(Task.Core.TaskStatus.Name)));
            lueStatus.Properties.ValueMember = nameof(Task.Core.TaskStatus.ID); 
            lueStatus.Properties.DisplayMember = nameof(Task.Core.TaskStatus.Name);

            lueType.Properties.DataSource = _taskTypeService.GetAll().ToList();
            lueType.Properties.Columns.Clear();
            lueType.Properties.Columns.Add(new LookUpColumnInfo(nameof(TaskType.Name)));
            lueType.Properties.ValueMember = nameof(TaskType.ID);
            lueType.Properties.DisplayMember = nameof(TaskType.Name);

            gcComments.DataSource = comments;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(gcComments.DataSource == null)
                return;            

            foreach (Task.Core.Comment comment in comments)
            {
                _commentService.Update(comment);
            }                
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (comments != null)
                    comments.CollectionChanged -= Comments_CollectionChanged;
            }

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
