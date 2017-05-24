
using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Task.Core;

namespace TaskWinForm
{
    public partial class CommentAddEditForm : DevExpress.XtraEditors.XtraForm
    {
        private const string TEXT = "Edit Comment";
        private const string TEXT_DIRTY = "Edit Comment*";
        private Comment _comment;

        public CommentAddEditForm(Comment Comment)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;

            _comment = Comment;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _comment.DirtyStateChanged += _comment_DirtyStateChanged;
            this.Closing += CommentAddEditForm_Closing;

            ConfigUI();
            LoadUIDatasources();
            SetDatabindings();
        }

        private void CommentAddEditForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            btnSave.Focus();

            if (DialogResult == DialogResult.No)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }

            if (_comment.IsDirty)
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
                    }
                    else if (result == DialogResult.No)
                    {
                        DialogResult = DialogResult.Cancel;
                        return;
                    }
                }

                if (!_comment.IsValid())
                {
                    XtraMessageBox.Show(
                        this,
                        String.Concat(_comment.Rules.Select(s => s.Description + Environment.NewLine)),
                        "Task management",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    e.Cancel = true;
                }
            }
        }

        private void _comment_DirtyStateChanged(object sender)
        {
            if (_comment.IsDirty)
                this.Text = TEXT_DIRTY;
            else
                this.Text = TEXT;
        }

        private void ConfigUI()
        {
            deDateAdded.Properties.NullDate = DateTime.MinValue;
            deReminderDate.Properties.NullDate = DateTime.MinValue;
            deDateAdded.Properties.NullText = string.Empty;
            deReminderDate.Properties.NullText = string.Empty;
            lueType.Properties.NullText = string.Empty;

        }

        private void LoadUIDatasources()
        {
            var commentTypes = CommentTypeCollection.GetAll();
            lueType.Properties.DataSource = commentTypes;
            lueType.Properties.Columns.Clear();
            lueType.Properties.Columns.Add(new LookUpColumnInfo(nameof(CommentType.Name)));
            lueType.Properties.ValueMember = nameof(CommentType.ID);
            lueType.Properties.DisplayMember = nameof(CommentType.Name);
        }

        private void SetDatabindings()
        {
            deDateAdded.DataBindings.Add("EditValue", _comment, nameof(Comment.DateAddedNonNullable));
            deReminderDate.DataBindings.Add("EditValue", _comment, nameof(Comment.ReminderDateNonNullable));
            meText.DataBindings.Add("EditValue", _comment, nameof(Comment.Text));
            lueType.DataBindings.Add("EditValue", _comment, nameof(Comment.CommentTypeId));
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}