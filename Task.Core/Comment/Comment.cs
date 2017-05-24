using System;
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
                MarkDirty();
            }
        }


        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion//Public properties

        #region Static methods
        public static Comment GetByID(int ID)
        {
            var repository = new CommentRepository();
            var taskDTO = repository.FetchByID(ID);
            var comment = CopyFromDTO(taskDTO);
            comment.MarkOld();
            return comment;
        }

        public static Comment CopyFromDTO(CommentDTO taskDTO)
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
        #endregion//Static methods`

    }
}
