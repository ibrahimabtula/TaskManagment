using System;
using System.Collections.Generic;

namespace Task.Core
{
    public class Task : BusinessBase
    {

        private int _id;
        private DateTime? _createdDate;
        private DateTime? _requiredDate;
        private string _description;
        private int _taskStatusId;
        private int _taslTypeId;
        private IEnumerable<User> _assignedUsers;
        private IEnumerable<Comment> _comments;

        public IEnumerable<Comment> Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }


        public Task()
        {
            
        }

        public Task(int ID)
            :this()
        {
            this.ID = ID;
        }

        public IEnumerable<User> AssignedUsers
        {
            get { return _assignedUsers; }
            set
            {
                _assignedUsers = value; 
                MarkDirty();
            }
        }


        public int TaskTypeID
        {
            get { return _taslTypeId; }
            set
            {
                if(_taslTypeId == value) return;;
                _taslTypeId = value;
                MarkDirty();
                OnPropertyChanged();
            }
        }


        public int TaskStatusId
        {
            get { return _taskStatusId; }
            set
            {
                if(_taskStatusId == value) return;
                _taskStatusId = value;
                MarkDirty();
                OnPropertyChanged();
            }
        }


        public string Description
        {
            get { return _description; }
            set
            {
                if(_description == value) return;
                _description = value;
                MarkDirty();
                OnPropertyChanged();
            }
        }


        public DateTime? RequiredByDate
        {
            get { return _requiredDate; }
            set
            {
                if(_requiredDate == value) return;
                _requiredDate = value;
                MarkDirty();
                OnPropertyChanged();
            }
        }


        public DateTime? CreatedDate
        {
            get { return _createdDate; }
            set
            {
                if(_createdDate == value) return;
                _createdDate = value;
                MarkDirty();
                OnPropertyChanged();
            }
        }


        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

    }
}
