using Task.DAL;

namespace Task.Core
{
    public class TaskTypeColelction : BusinessCollectionBase<TaskType>
    {

        public static TaskTypeColelction GetAll()
        {
            var repository = new TaskTypeRepository();
            var collection = new TaskTypeColelction();

            var colletionDTO = repository.FetchAll(new TaskTypeCriteria());

            foreach (DTO.TaskTypeDTO dto in colletionDTO)
            {
                var taskType = TaskType.CopyFromDTO(dto);
                taskType.MarkOld();
                collection.Add(taskType);
            }

            return collection;
        }
    }
}
