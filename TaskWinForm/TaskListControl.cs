using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Task.Core;
using Task.DAL;
using Task.DTO;

namespace TaskWinForm
{
    public partial class TaskListControl : XtraUserControl
    {
        //private TaskCollection _taskCollection;
        private BindingList<Task.DTO.TaskDTO> _taskList;
        private TaskRepository _taskRepository;

        public TaskListControl()
        {
            InitializeComponent();
            InitGridColumns();

            _taskRepository = new TaskRepository();
            _taskList = new BindingList<TaskDTO>(_taskRepository.FetchAll(new TaskCriteria()).ToList());

            //_taskCollection = TaskCollection.GetAll();

            gvTasks.DoubleClick += GvTasks_DoubleClick;

        }

        private void GvTasks_DoubleClick(object sender, EventArgs e)
        {
            var view = (sender as GridView);
            var taskDTO = view.GetRow(view.FocusedRowHandle) as Task.DTO.TaskDTO;

            if (taskDTO != null)
            {
                var task = Task.Core.Task.GetByID(taskDTO.ID);
                using (var frm = new TaskAddEditForm(task))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        //Update grid
                        UpdateGrid();
                        //int i = _taskList.IndexOf(taskDTO);
                        //_taskList[i] = Task.Core.Task.CreateDTOFromTask(task);   
                        //gcTasks.RefreshDataSource();                     
                    }
                }
            }
        }

        private void InitGridColumns()
        {
            gvTasks.OptionsView.ColumnAutoWidth = false;
            gvTasks.OptionsBehavior.AutoPopulateColumns = false;
            gvTasks.OptionsBehavior.Editable = false;
            gvTasks.OptionsView.ShowDetailButtons = false;

            #region Grid columns                                  

            var col = new GridColumn();
            col.Visible = true;
            col.FieldName = nameof(Task.DTO.TaskDTO.CreatedDate);
            col.Caption = "Created date";
            gvTasks.Columns.Add(col);

            col = new GridColumn();
            col.Visible = true;
            col.FieldName = nameof(Task.DTO.TaskDTO.RequiredByDate);
            col.Caption = "Required by date";
            gvTasks.Columns.Add(col);

            col = new GridColumn();
            col.Visible = true;
            col.FieldName = nameof(Task.DTO.TaskDTO.ReminderDate);
            col.Caption = "Reminder date";
            gvTasks.Columns.Add(col);

            col = new GridColumn();
            col.Visible = true;
            col.FieldName = nameof(Task.DTO.TaskDTO.Description);
            col.ColumnEdit = new RepositoryItemMemoEdit();
            col.Caption = "Description";
            gvTasks.Columns.Add(col);

            col = new GridColumn();
            col.Visible = true;
            col.FieldName = nameof(Task.DTO.TaskDTO.TaskStatusName);
            col.ColumnEdit = new RepositoryItemMemoEdit();
            col.Caption = "Status name";
            gvTasks.Columns.Add(col);

            col = new GridColumn();
            col.Visible = true;
            col.FieldName = nameof(Task.DTO.TaskDTO.TaskTypeName);
            col.ColumnEdit = new RepositoryItemMemoEdit();
            col.Caption = "Type name";
            gvTasks.Columns.Add(col);

            #endregion//Grid columns
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            gcTasks.DataSource = _taskList;

        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                gvTasks.DoubleClick -= GvTasks_DoubleClick;
            }

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void UpdateGrid()
        {
            gvTasks.BeginUpdate();

            _taskList = new BindingList<TaskDTO>(_taskRepository.FetchAll(new TaskCriteria()).ToList());
            gcTasks.DataSource = _taskList;

            gvTasks.EndUpdate();
        }
    }
}
