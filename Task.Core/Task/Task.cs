using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        #endregion//Private fields

        #region Constructors
        public Task()
        {
            _comments = new CommentCollection();
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
            set
            {
                if (_comments != null)
                    _comments.CollectionChanged -= _comments_CollectionChanged;

                _comments = value;

                if (_comments != null)
                    _comments.CollectionChanged += _comments_CollectionChanged;

            }
        }

        public int TaskTypeId
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

        public DateTime? ReminderDate { get; set; }

        public DateTime RequiredByDateNonNullable
        {
            get { return _requiredDate.HasValue ? _requiredDate.Value : DateTime.MinValue; }
            set { RequiredByDate = value; }
        }

        public DateTime CreatedDateNonNullable
        {
            get { return _createdDate.HasValue ? _createdDate.Value : DateTime.MinValue; }
            set { CreatedDate = value; }
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

        #region Public methods

        public Comment CreateComment()
        {
            return new Comment()
            {
                TaskID = _id
            };
        }

        public void Update()
        {
            if (!IsDirty) return;
            if(!IsValid()) return;

            var _taskRepository = new TaskRepository();

            var dto = CreateDTOFromTask(this);

            TransactionUtil.DoTransactional(t =>
            {
                if (IsDeleted)
                {
                    foreach (Comment comment in Comments)
                    {
                        comment.MarkDeleted();
                        comment.Update(t);
                    }

                    _taskRepository.ExecuteDelete(dto.ID, t);
                }
                else
                {
                    if (IsNew)
                        _taskRepository.ExecuteInsert(dto, t);
                    else
                        _taskRepository.ExecuteUpdate(dto, t);
                }

                foreach (Comment comment in Comments)
                    comment.Update(t);
            });
        }

        public bool IsValid()
        {
            Rules.Clear();

            if (_taslTypeId == 0) 
                Rules.Add(new BusinesRule(nameof(Task.TaskTypeId), "Task type is required!"));
            if (_taskStatusId == 0)
                Rules.Add(new BusinesRule(nameof(Task.TaskStatusId), "Task status is required!"));

            foreach (Comment comment in Comments)
            {
                if (!comment.IsValid())
                    return false;

            }

            return Rules.Count == 0;
        }

        #endregion//Public methods

        #region Static methods
        public static Task GetByID(int ID)
        {
            var repository = new TaskRepository();

            var taskDTO = repository.FetchByID(ID);

            var task = CreateTaskFromDTO(taskDTO);

            task.Comments = CommentCollection.GetByTaskID(task.ID);

            task.MarkOld();

            return task;
        }

        private void _comments_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add ||
                e.Action == NotifyCollectionChangedAction.Remove ||
                e.Action == NotifyCollectionChangedAction.Replace)
            {
                MarkDirty();
            }
        }

        public static Task CreateTaskFromDTO(TaskDTO TaskDTO)
        {
            var task = new Task();

            task._id = TaskDTO.ID;
            task._createdDate = TaskDTO.CreatedDate;
            task._requiredDate = TaskDTO.RequiredByDate;
            task._description = TaskDTO.Description;
            task._taskStatusId = TaskDTO.TaskStatusId;
            task._taslTypeId = TaskDTO.TaskTypeID;
            task.ReminderDate = TaskDTO.ReminderDate;

            return task;
        }

        public static TaskDTO CreateDTOFromTask(Task Task)
        {
            var dto = new TaskDTO();

            dto.ID = Task._id;
            dto.CreatedDate = Task._createdDate;
            dto.RequiredByDate = Task._requiredDate;
            dto.TaskStatusId = Task._taskStatusId;
            dto.TaskTypeID = Task._taslTypeId;
            dto.Description = Task._description;
            dto.ReminderDate = Task.ReminderDate;

            return dto;
        }
        #endregion//Static methods

        ~Task()
        {
            if (_comments != null)
                _comments.CollectionChanged -= _comments_CollectionChanged;
        }
    }
}
