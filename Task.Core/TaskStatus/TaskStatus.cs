
using System;
using Task.DTO;

namespace Task.Core
{
    public class TaskStatus : BusinessBase
    {

        public int ID { get; private set; }
        public string Name { get; private set; }

        internal static TaskStatus CopyFromDTO(TaskStatusDTO dto)
        {
            var taskStatus = new TaskStatus();

            taskStatus.ID = dto.ID;
            taskStatus.Name = dto.Name;

            return taskStatus;
        }
    }
}
