using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Task.Core;

namespace TaskWinForm
{
    public partial class TaskListControl : XtraUserControl
    {
        private TaskCollection _taskCollection;

        public TaskListControl()
        {
            InitializeComponent();
            InitGridColumns();

            _taskCollection = TaskCollection.GetAll();

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
                var taskFull = Task.Core.Task.GetByID(task.ID);
                using (var frm = new TaskAddEditForm(taskFull))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        //TODO: Update
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
            col.FieldName = nameof(Task.Core.Task.ID);
            col.Caption = "ID";
            gvTasks.Columns.Add(col);

            col = new GridColumn();
            col.Visible = true;
            col.FieldName = nameof(Task.Core.Task.CreatedDate);
            col.Caption = "Created date";
            gvTasks.Columns.Add(col);

            col = new GridColumn();
            col.Visible = true;
            col.FieldName = nameof(Task.Core.Task.RequiredByDate);
            col.Caption = "Required by date";
            gvTasks.Columns.Add(col);

            col = new GridColumn();
            col.Visible = true;
            col.FieldName = nameof(Task.Core.Task.Description);
            col.ColumnEdit = new RepositoryItemMemoEdit();
            col.Caption = "Description";
            gvTasks.Columns.Add(col);

            #endregion//Grid columns
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            gcTasks.DataSource = _taskCollection;

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
