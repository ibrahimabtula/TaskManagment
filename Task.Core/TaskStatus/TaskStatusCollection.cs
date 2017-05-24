
using Task.DAL;

namespace Task.Core
{
    public class TaskStatusCollection : BusinessCollectionBase<TaskStatus>
    {

        public static TaskStatusCollection GetAll()
        {
            var repository = new TaskStatusRepository();
            var collection = new TaskStatusCollection();

            var colletionDTO = repository.FetchAll(new TaskStatusCriteria());

            foreach (DTO.TaskStatusDTO dto in colletionDTO)
            {
                var taskStatus = TaskStatus.CopyFromDTO(dto);
                taskStatus.MarkOld();
                collection.Add(taskStatus);
            }

            return collection;
        }
    }
}
