using System;

namespace Task.DAL
{
    public class CommentCriteria : ICriteria
    {
        public int TaskID { get; set; }
        public DateTime? ReminderDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public int CommentTypeID { get; set; }
    }
}
