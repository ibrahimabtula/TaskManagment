using System;
using System.Data.SqlClient;
using Task.DAL;
using Task.DTO;

namespace Task.Core
{
    public class Comment : BusinessBase
    {
        #region Private fields
        private int _id;
        private DateTime? _dateAdded;
        private string _text;
        private int _commentTypeId;
        private DateTime? _reminderDate;
        private int _taskId;
        #endregion//Private fields

        #region Constructors
        public Comment()
            : base()
        {
        }

        public Comment(int ID)
            : this()
        {
            this.ID = ID;
        }
        #endregion//Costructors

        #region Public properties
        public int TaskID
        {
            get { return _taskId; }
            set { _taskId = value; }
        }

        public DateTime? ReminderDate
        {
            get { return _reminderDate; }
            set
            {
                if(value == _reminderDate) return;
                _reminderDate = value;
                MarkDirty();
                OnPropertyChanged();
            }
        }


        public int CommentTypeId
        {
            get { return _commentTypeId; }
            set
            {
                if(value == _commentTypeId) return;
                _commentTypeId = value;
                MarkDirty();
            }
        }


        public string Text
        {
            get { return _text; }
            set
            {
                if(value == _text) return;
                _text = value;
                MarkDirty();
                OnPropertyChanged();
            }
        }


        public DateTime? DateAdded
        {
            get { return _dateAdded; }
            set
            {
                if(value == _dateAdded) return;
                _dateAdded = value;
                OnPropertyChanged();
                MarkDirty();
            }
        }

        public DateTime DateAddedNonNullable
        {
            get { return DateAdded.HasValue ? DateAdded.Value : DateTime.MinValue; }
            set { DateAdded = value; }
        }

        public DateTime ReminderDateNonNullable
        {
            get { return ReminderDate.HasValue ? ReminderDate.Value : DateTime.MinValue; }
            set { ReminderDate = value; }
        }


        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion//Public properties

        #region Public methods

        public void Update(SqlTransaction transaction)
        {
            if (!IsDirty) return;
            if (!IsValid()) return;

            var _commentRepository = new CommentRepository();

            var commentDTO = Core.Comment.CreateDTOFromComment(this);

            if (IsDeleted)
            {
                _commentRepository.ExecuteDelete(commentDTO.ID, transaction);
            }
            else
            {

                if (IsNew)
                    _commentRepository.ExecuteInsert(commentDTO, transaction);
                else
                    _commentRepository.ExecuteUpdate(commentDTO, transaction);
            }
        }

        public void Update()
        {
            if (!IsDirty) return;
            if (!IsValid()) return;

            var _commentRepository = new CommentRepository();

            var commentDTO = Core.Comment.CreateDTOFromComment(this);

            if (IsNew)
                _commentRepository.Insert(commentDTO);
            else
                _commentRepository.Update(commentDTO);

        }

        public bool IsValid()
        {
            Rules.Clear();

            if (_taskId == 0) 
                Rules.Add(new BusinesRule(nameof(Comment.TaskID), "Task is required!"));
            if (_commentTypeId == 0)
                Rules.Add(new BusinesRule(nameof(Comment.CommentTypeId), "Type is required!"));

            return Rules.Count == 0;
        }

        #endregion

        #region Static methods
        public static Comment GetByID(int ID)
        {
            var repository = new CommentRepository();
            var taskDTO = repository.FetchByID(ID);
            var comment = CreateCommentFromDTO(taskDTO);
            comment.MarkOld();
            return comment;
        }

        public static Comment CreateCommentFromDTO(CommentDTO taskDTO)
        {
            var task = new Comment();

            task._id = taskDTO.ID;
            task._dateAdded = taskDTO.DateAdded;
            task._reminderDate = taskDTO.ReminderDate;
            task._commentTypeId = taskDTO.CommentTypeID;
            task._text = taskDTO.Text;            
            task._taskId = taskDTO.TaskID;

            return task;
        }

        public static CommentDTO CreateDTOFromComment(Comment Comment)
        {
            var dto = new CommentDTO();

            dto.ID = Comment._id;
            dto.CommentTypeID = Comment._commentTypeId;
            dto.TaskID = Comment._taskId;
            dto.DateAdded = Comment._dateAdded;
            dto.ReminderDate = Comment._reminderDate;
            dto.Text = Comment._text;

            return dto;
        }

        #endregion//Static methods`

    }
}
