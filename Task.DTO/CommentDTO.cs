using System;

namespace Task.DTO
{
    public class CommentDTO
    {
        public int ID { get; set; }
        public DateTime? DateAdded { get; set; }
        public int CommentTypeID { get; set; }
        public string CommentTypeName { get; set; }
        public DateTime? ReminderDate { get; set; }
        public int TaskID { get; set; }
        public string Text { get; set; }
    }
}
