using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Task.Core;
using Task.DAL;
using Task.DTO;

namespace TaskWinForm
{
    public partial class CommentsControl : XtraUserControl
    {
        //private TaskCollection _taskCollection;
        private BindingList<Task.DTO.CommentDTO> _commentList;
        private CommentRepository _commentRepository;

        public CommentsControl()
        {
            InitializeComponent();
            InitGridColumns();

            _commentRepository = new CommentRepository();
            _commentList = new BindingList<CommentDTO>(_commentRepository.FetchAll(new CommentCriteria()).ToList());

            //_taskCollection = TaskCollection.GetAll();

            gvComments.DoubleClick += GvTasks_DoubleClick;

        }

        private void GvTasks_DoubleClick(object sender, EventArgs e)
        {
            var view = (sender as GridView);
            var commentDto = view.GetRow(view.FocusedRowHandle) as Task.DTO.CommentDTO;

            if (commentDto != null)
            {
                var task = Task.Core.Task.GetByID(commentDto.TaskID);
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
            gvComments.OptionsView.ColumnAutoWidth = false;
            gvComments.OptionsBehavior.AutoPopulateColumns = false;
            gvComments.OptionsBehavior.Editable = false;
            gvComments.OptionsView.ShowDetailButtons = false;

            #region Grid columns                                  

            var col = new GridColumn();
            col.Visible = true;
            col.FieldName = nameof(Task.DTO.CommentDTO.DateAdded);
            col.Caption = "Date added";
            gvComments.Columns.Add(col);

            col = new GridColumn();
            col.Visible = true;
            col.FieldName = nameof(Task.DTO.CommentDTO.ReminderDate);
            col.Caption = "Reminder date";
            gvComments.Columns.Add(col);

            col = new GridColumn();
            col.Visible = true;
            col.FieldName = nameof(Task.DTO.CommentDTO.CommentTypeName);
            col.Caption = "Type";
            gvComments.Columns.Add(col);

            col = new GridColumn();
            col.Visible = true;
            col.FieldName = nameof(Task.DTO.CommentDTO.Text);
            col.Caption = "Comment";
            gvComments.Columns.Add(col);

            #endregion//Grid columns
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            gcComments.DataSource = _commentList;

            var commentTypes = CommentTypeCollection.GetAll();
            //To be able to remove filter
            commentTypes.Insert(0, new CommentType());
            lueType.EditValue = 0;
            lueType.Properties.DataSource = commentTypes;
            lueType.Properties.Columns.Clear();
            lueType.Properties.Columns.Add(new LookUpColumnInfo(nameof(CommentType.Name)));
            lueType.Properties.ValueMember = nameof(CommentType.ID);
            lueType.Properties.DisplayMember = nameof(CommentType.Name);

        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                gvComments.DoubleClick -= GvTasks_DoubleClick;
            }

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void UpdateGrid()
        {
            gvComments.BeginUpdate();

            _commentList = new BindingList<CommentDTO>(_commentRepository.FetchAll(new CommentCriteria()).ToList());
            gcComments.DataSource = _commentList;

            gvComments.EndUpdate();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            gvComments.BeginUpdate();

            var crit = new CommentCriteria();

            if (deReminderDate.EditValue != null)
                crit.ReminderDate = deReminderDate.DateTime;
            if (deDateAdded.EditValue != null)
                crit.DateAdded = deDateAdded.DateTime;

            if (lueType.EditValue != null && lueType.EditValue is int)
                crit.CommentTypeID = Convert.ToInt32(lueType.EditValue);

            _commentList = new BindingList<CommentDTO>(_commentRepository.FetchAll(crit).ToList());
            gcComments.DataSource = _commentList;

            gvComments.EndUpdate();
        }
    }
}
