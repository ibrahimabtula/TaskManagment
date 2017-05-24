using Task.DTO;

namespace Task.Core
{
    public class TaskType : BusinessBase
    {
        public int ID { get; private set; }
        public string Name { get; private set; }

        public static TaskType CopyFromDTO(TaskTypeDTO TaskTypeDTO)
        {
            var taskType = new TaskType();

            taskType.ID = TaskTypeDTO.ID;
            taskType.Name = TaskTypeDTO.Name;

            return taskType;
        }
    }
}
