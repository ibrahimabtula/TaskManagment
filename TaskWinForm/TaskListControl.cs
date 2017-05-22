using System;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Task.Service;

namespace TaskWinForm
{
    public partial class TaskListControl : XtraUserControl
    {
        private TaskService _taskService;

        public TaskListControl()
        {
            InitializeComponent();
            InitGridColumns();

            _taskService = new TaskService();

            gvTasks.DoubleClick += GvTasks_DoubleClick;

        }

        public event EventHandler OnRowDoubleClick
        {
            add { gvTasks.DoubleClick += value; }
            remove { gvTasks.DoubleClick -= value; }
        }

        private void GvTasks_DoubleClick(object sender, EventArgs e)
        {
            var view = (sender as GridView);
            var task = view.GetRow(view.FocusedRowHandle) as Task.Core.Task;

            if (task != null)
            {
                //TODO: Open edit form
            }
        }

        private void InitGridColumns()
        {
            gvTasks.OptionsView.ColumnAutoWidth = false;
            gvTasks.OptionsBehavior.AutoPopulateColumns = false;
            gvTasks.OptionsBehavior.Editable = false;

            #region Grid columns
                       
            var col = new GridColumn();
            col.Visible = true;
            col.FieldName = "ID";
            col.Caption = "ID";
            gvTasks.Columns.Add(col);

            col = new GridColumn();
            col.Visible = true;
            col.FieldName = "CreatedDateTimes";
            col.Caption = "Created date";
            gvTasks.Columns.Add(col);

            col = new GridColumn();
            col.Visible = true;
            col.FieldName = "RequiredByDate";
            col.Caption = "Required by date";
            gvTasks.Columns.Add(col);

            col = new GridColumn();
            col.Visible = true;
            col.FieldName = "Description";
            col.ColumnEdit = new RepositoryItemMemoEdit();
            col.Caption = "Description";
            gvTasks.Columns.Add(col);

            #endregion//Grid columns
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            gcTasks.DataSource = _taskService.GetAll().ToList();

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

    }
}
