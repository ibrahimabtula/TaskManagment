
using System;
using System.Windows.Forms;
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

            ConfigUI();
            LoadUIDatasources();
            SetDatabindings();
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
            deDateAdded.Properties.NullDate = null;
            deReminderDate.Properties.NullDate = null;
            lueType.Properties.NullText = string.Empty;
        }

        private void LoadUIDatasources()
        {
            var commentTypes = CommentTypeCollection.GetAll();
            lueType.Properties.DataSource = commentTypes;
            lueType.Properties.ValueMember = nameof(CommentType.ID);
            lueType.Properties.DisplayMember = nameof(CommentType.Name);
        }

        private void SetDatabindings()
        {
            deDateAdded.DataBindings.Add("EditValue", _comment, nameof(Comment.DateAdded));
            deReminderDate.DataBindings.Add("EditValue", _comment, nameof(Comment.ReminderDate));
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
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}