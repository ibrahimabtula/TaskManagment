using System;
using System.Collections.Generic;
using Task.DAL;
using Task.DTO;

namespace Task.Core
{
    public class Task : BusinessBase
    {

        #region Private fields
        private int _id;
        private DateTime? _createdDate;
        private DateTime? _requiredDate;
        private string _description;
        private int _taskStatusId;
        private int _taslTypeId;
        private IEnumerable<User> _assignedUsers;
        private CommentCollection _comments;
        private TaskRepository _taskRepository;
        #endregion//Private fields

        #region Constructors
        public Task()
        {         
            _taskRepository = new TaskRepository();;   
        }
        #endregion//Costructors

        #region Public properties
        public IEnumerable<User> AssignedUsers
        {
            get { return _assignedUsers; }
            set
            {
                _assignedUsers = value; 
                MarkDirty();
            }
        }

        public CommentCollection Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        public int TaskTypeID
        {
            get { return _taslTypeId; }
            set
            {
                if(_taslTypeId == value) return;
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

        #endregion//Public properties

        #region Static methods
        public static Task GetByID(int ID)
        {
            var repository = new TaskRepository();

            var taskDTO = repository.FetchByID(ID);

            var task = CopyFromDTO(taskDTO);

            task._comments = CommentCollection.GetByTaskID(task.ID);

            task.MarkOld();

            return task;
        }

        public static Task CopyFromDTO(TaskDTO taskDTO)
        {
            var task = new Task();

            task._id = taskDTO.ID;
            task._createdDate = taskDTO.CreatedDate;
            task._requiredDate = taskDTO.RequiredByDate;
            task._description = taskDTO.Description;
            task._taskStatusId = taskDTO.TaskStatusId;
            task._taslTypeId = taskDTO.TaskTypeID;

            return task;
        }
        #endregion//Static methods
    }
}
