using System.Collections.Generic;
using Task.DAL;

namespace Task.Core
{
    public class TaskCollection : BusinessCollectionBase<Task>
    {
        private TaskRepository _taskRepository;

        public TaskCollection()
        {
            _taskRepository = new TaskRepository();
        }

        public TaskCollection(IEnumerable<Task> enumerable)
            : base(enumerable)
        {
            _taskRepository = new TaskRepository();
        }

        public static TaskCollection GetAll()
        {
            var taskRepository = new TaskRepository();
            var taskCollection = new TaskCollection();

            var commentsDTO = taskRepository.FetchAll(new TaskCriteria());

            foreach (DTO.TaskDTO taskDto in commentsDTO)
            {
                var task = Task.CopyFromDTO(taskDto);
                task.MarkOld();
                taskCollection.Add(task);
            }

            return taskCollection;
        }
    }
}
