using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Task.DTO;

namespace Task.DAL
{
    public class CommentRepository
        : ITaskRepository<Task.DTO.CommentDTO, CommentCriteria>
    {
        public Task.DTO.CommentDTO FetchByID(int ID)
        {
            var comments = FetchAll(new CommentCriteria() { TaskID = ID }).ToList();

            if (comments == null || comments.Count == 0)
                throw new Exception("Task not found!");

            return comments[0];
        }

        public IEnumerable<Task.DTO.CommentDTO> FetchAll(CommentCriteria criteria)
        {
            try
            {
                using (var connection = ConnectionBuilder.GetOpenedConnection())
                {
                    using (var transaction = connection.BeginTransaction())
                    {
                        var result = ExecuteFetch(criteria, transaction);
                        transaction.Commit();
                        return result;
                    }
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public void Update(Task.DTO.CommentDTO comment)
        {
            TransactionUtil.DoTransactional(t => ExecuteUpdate(comment, t));
        }

        public void Insert(Task.DTO.CommentDTO comment)
        {
            TransactionUtil.DoTransactional(t=> ExecuteInsert(comment, t));            
        }

        public void Delete(int ID)
        {
            TransactionUtil.DoTransactional(t=>ExecuteDelete(ID, t));
        }

        public IEnumerable<Task.DTO.CommentDTO> ExecuteFetch(CommentCriteria criteria, SqlTransaction transaction)
        {
            var comments = new List<Task.DTO.CommentDTO>();

            using (var command = transaction.Connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandType = CommandType.Text;

                var query = new StringBuilder(@"
SELECT 
    Comment.[ID]
    ,Comment.[DateAdded]
    ,Comment.[TypeID]
    ,Comment.[ReminderDate]
    ,Comment.[TaskID]
    ,Comment.[Text]
    ,CommentType.Name AS CommentTypeName
FROM
    Comment
    LEFT JOIN CommentType ON CommentType.ID = TypeID
WHERE 1 = 1");

                if (criteria.TaskID != 0)
                {
                    query.Append(" AND TaskID = @TaskID");
                    command.Parameters.AddWithValue("TaskID", criteria.TaskID);
                }

                if (criteria.ReminderDate != null)
                {
                    query.Append(" AND Comment.ReminderDate = @ReminderDate");
                    command.Parameters.AddWithValue("ReminderDate", criteria.ReminderDate);
                }

                if (criteria.DateAdded != null)
                {
                    query.Append(" AND Comment.DateAdded = @DateAdded");
                    command.Parameters.AddWithValue("DateAdded", criteria.DateAdded);
                }

                if (criteria.CommentTypeID != 0)
                {
                    query.Append(" AND Comment.TypeID = @TypeID");
                    command.Parameters.AddWithValue("TypeID", criteria.CommentTypeID);
                }

                command.CommandText = query.ToString();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var comment = new CommentDTO();

                        comment.ID = reader.GetInt32(0);
                        comment.DateAdded = reader.GetNullabelDateTime(1);
                        comment.CommentTypeID = reader.GetInt32(2);
                        comment.ReminderDate = reader.GetNullabelDateTime(3);
                        comment.TaskID = reader.GetInt32(4);
                        comment.Text = reader.GetNullabelString(5);
                        comment.CommentTypeName = reader.GetNullabelString(6);

                        comments.Add(comment);
                    }
                }
            }

            return comments;
        }


        public void ExecuteUpdate(Task.DTO.CommentDTO comment, SqlTransaction transaction)
        {
            using (var command = transaction.Connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandType = CommandType.Text;

                command.CommandText = @"
UPDATE Comment
SET
    DateAdded = @DateAdded
    ,TypeID = @TypeID
    ,ReminderDate = @ReminderDate
    ,TaskID = @TaskID
    ,Text = @Text
WHERE 
    ID = @ID";

                command.Parameters.AddWithValue("ID", comment.ID);
                AddParameters(command.Parameters, comment);                

                command.ExecuteNonQuery();
            }
        }

        public void ExecuteInsert(Task.DTO.CommentDTO comment, SqlTransaction transaction)
        {
            using (var command = transaction.Connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandType = CommandType.Text;

                command.CommandText = @"
INSERT INTO Comment
(
    DateAdded
    ,TypeID
    ,ReminderDate
    ,TaskID
    ,Text
)
VALUES
(
    @DateAdded
    ,@TypeID
    ,@ReminderDate
    ,@TaskID
    ,@Text
)
SELECT @@IDENTITY
";

                AddParameters(command.Parameters, comment);

                comment.ID = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private void AddParameters(SqlParameterCollection Parameters, CommentDTO comment)
        {
            //DateAdded
            if (comment.DateAdded.HasValue)
                Parameters.AddWithValue("DateAdded", comment.DateAdded);
            else
                Parameters.AddWithValue("DateAdded", DBNull.Value);

            //ReminderDate
            if (comment.ReminderDate.HasValue)
                Parameters.AddWithValue("ReminderDate", comment.ReminderDate);
            else
                Parameters.AddWithValue("ReminderDate", DBNull.Value);

            Parameters.AddWithValue("TypeID", comment.CommentTypeID);
            Parameters.AddWithValue("TaskID", comment.TaskID);

            if(comment.Text != null)
                Parameters.AddWithValue("Text", comment.Text);
            else
                Parameters.AddWithValue("Text", DBNull.Value);
        }

        public void ExecuteDelete(int ID, SqlTransaction transaction)
        {
            using (var command = transaction.Connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandType = CommandType.Text;

                command.CommandText = @"DELETE FROM Comment Where ID = @ID";
                command.Parameters.AddWithValue("ID", ID);

                command.ExecuteNonQuery();
            }
        }
    }
}
