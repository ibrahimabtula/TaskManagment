using System;

namespace Task.DTO
{
    public class TaskDTO
    {
        public int ID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? RequiredByDate { get; set; }
        public DateTime? ReminderDate { get; set; }
        public string Description { get; set; }
        public int TaskStatusId { get; set; }
        public int TaskTypeID { get; set; }
        public string TaskStatusName { get; set; }
        public string TaskTypeName { get; set; }
    }
}
