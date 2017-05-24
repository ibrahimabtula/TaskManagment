using System.Collections.Generic;
using Task.DAL;
using Task.DTO;

namespace Task.Core
{
    public class TaskCollection : BusinessCollectionBase<Task>
    {
        public TaskCollection()
        {
        }

        public TaskCollection(IEnumerable<Task> enumerable)
            : base(enumerable)
        {
        }

        public static TaskCollection GetAll()
        {
            ITaskRepository<TaskDTO, TaskCriteria> taskRepository = new TaskRepository();
            var taskCollection = new TaskCollection();

            var commentsDTO = taskRepository.FetchAll(new TaskCriteria());

            foreach (DTO.TaskDTO taskDto in commentsDTO)
            {
                var task = Task.CreateTaskFromDTO(taskDto);
                task.MarkOld();
                taskCollection.Add(task);
            }

            return taskCollection;
        }
    }
}
