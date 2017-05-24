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
        //: AbstractRepository<Core.Comment, CommentCollection, CommentCriteria>
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

        public bool Update(Task.DTO.CommentDTO comment)
        {
            try
            {
                using (var connection = ConnectionBuilder.GetOpenedConnection())
                {
                    using (var transaction = connection.BeginTransaction())
                    {
                        ExecuteUpdate(comment, transaction);
                        //TODO:
                        transaction.Commit();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Insert(Task.DTO.CommentDTO comment)
        {
            try
            {
                using (var connection = ConnectionBuilder.GetOpenedConnection())
                {
                    using (var transaction = connection.BeginTransaction())
                    {
                        ExecuteInsert(comment, transaction);
                        //TODO:
                        transaction.Commit();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
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
    [ID]
    ,[DateAdded]
    ,[TypeID]
    ,[ReminderDate]
    ,[TaskID]
    ,[Text]
FROM
    Comment
WHERE 1 = 1");

                if (criteria.TaskID != 0)
                {
                    query.Append(" AND TaskID = @TaskID");
                    command.Parameters.AddWithValue("TaskID", criteria.TaskID);
                }

                command.CommandText = query.ToString();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var comment = new CommentDTO();

                        comment.ID = reader.GetInt32(0);
                        comment.DateAdded = reader.GetDateTime(1);
                        comment.CommentTypeID = reader.GetInt32(2);
                        comment.ReminderDate = reader.GetDateTime(3);
                        comment.TaskID = reader.GetInt32(4);
                        comment.Text = reader.GetString(5);

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
                command.Parameters.AddWithValue("DateAdded", comment.DateAdded);
                command.Parameters.AddWithValue("TypeID", comment.CommentTypeID);
                command.Parameters.AddWithValue("ReminderDate", comment.ReminderDate);
                command.Parameters.AddWithValue("TaskID", comment.TaskID);
                command.Parameters.AddWithValue("Text", comment.Text);

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
    ,DateAdded
    ,TypeID
    ,ReminderDate
    ,TaskID
    ,Text
)
VALUE
(
    ,@DateAdded
    ,@TypeID
    ,@ReminderDate
    ,@TaskID
    ,@Text
)
SELECT @@IDENTITY
";

                command.Parameters.AddWithValue("DateAdded", comment.DateAdded);
                command.Parameters.AddWithValue("TypeID", comment.CommentTypeID);
                command.Parameters.AddWithValue("ReminderDate", comment.ReminderDate);
                command.Parameters.AddWithValue("TaskID", comment.TaskID);
                command.Parameters.AddWithValue("Text", comment.Text);

                comment.ID = Convert.ToInt32(command.ExecuteScalar());
            }
        }
    }
}
