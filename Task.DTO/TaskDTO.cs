using System;
using System.Collections.Generic;

namespace Task.DTO
{
    public class TaskDTO
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime RequiredByDate { get; set; }
        public string Description { get; set; }
        public int TaskStatusId { get; set; }
        public int TaskTypeID { get; set; }
        public IEnumerable<TaskTypeDTO> TaskTypes { get; set; }
        public IEnumerable<TaskStatusDTO> TaskStatuses { get; set; }

    }
}
