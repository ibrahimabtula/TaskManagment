using System.Collections.Generic;
using Task.DAL;

namespace Task.Service
{
    public class TaskService
    {
        private DAL.TaskRepository _taskRepository;
        private DAL.CommentRepository _commentRepository;

        public TaskService()
        {
            _taskRepository = new TaskRepository();
            _commentRepository = new CommentRepository();
        }

        public Task.Core.Task GetById(int TaskID)
        {
            var task = _taskRepository.Fetch(new TaskCriteria() {TaskID = TaskID});
            task.Comments = _commentRepository.FetchAll(new CommentCriteria() {TaskID = TaskID});
            return task;
        }

        public Task.Core.Task CreateNew()
        {
            var task = new Task.Core.Task(0);
            task.Comments = _commentRepository.FetchAll(new CommentCriteria() { TaskID = task.ID });
            return task;
        }

        public IEnumerable<Core.Task> GetAll()
        {
            return _taskRepository.FetchAll(new TaskCriteria());
        }

        public void Update(Task.Core.Task Task)
        {
            foreach (var comment in Task.Comments)
            {
                _commentRepository.Update(comment);
            }

            _taskRepository.Update(Task);            
        }
    }
}
