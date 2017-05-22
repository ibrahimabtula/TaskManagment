using System;

namespace Task.Core
{
    public class Comment : BusinessBase
    {

        private int _id;
        private DateTime _dateAdded;
        private string _text;
        private int _commentTypeId;
        private DateTime _reminderDate;
        private int _taskId;

        public int TaskID
        {
            get { return _taskId; }
            set { _taskId = value; }
        }


        public Comment()
            : base()
        {
            
        }

        public Comment(int ID)
            : this()
        {
            this.ID = ID;
        }

        public DateTime ReminderDate
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


        public DateTime DateAdded
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

    }
}
