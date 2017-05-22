using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Task.DAL
{
    public class CommentRepository : AbstractRepository<Core.Comment, CommentCriteria>
    {
        public override Core.Comment Fetch(CommentCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Core.Comment> FetchAll(CommentCriteria criteria)
        {
            List<Core.Comment> comments;

            using (var connection = ConnectionBuilder.GetOpenedConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    using (var transaction = connection.BeginTransaction())
                    {
                        command.Transaction = transaction;
                        command.CommandType = CommandType.Text;

                        var query = new StringBuilder(@"
SELECT 
    [ID]
    ,[TypeID]
    ,[DateAdded]
    ,[ReminderDate]
    ,[TaskID]
    ,[Text]
FROM 
    Comment
WHERE 1 = 1");

                        if (criteria.TaskID > 0)
                        {
                            query.Append(" AND TaskID = @TaskID");
                            command.Parameters.AddWithValue("TaskID", criteria.TaskID);
                        }

                        command.CommandText = query.ToString();

                        comments = new List<Core.Comment>();

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var comment = new Core.Comment(reader.GetInt32(0));
                                comment.CommentTypeId = reader.GetInt32(1);
                                comment.DateAdded = reader.GetDateTime(2);
                                comment.ReminderDate = reader.GetDateTime(3);
                                comment.TaskID = reader.GetInt32(4);
                                comment.Text = reader.GetString(5);
                                comment.MarkOld();

                                comments.Add(comment);
                            }
                        }

                        transaction.Commit();
                    }
                }
            }
            return comments;
        }

        public override void Update(Core.Comment comment)
        {
            if(!comment.IsDirty) return;

            using (var connection = ConnectionBuilder.GetOpenedConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    using (var transaction = connection.BeginTransaction())
                    {
                        command.Transaction = transaction;
                        command.CommandType = CommandType.Text;


                        var query = new StringBuilder();

                        if (!comment.IsNew)
                        {
                            query.Append(@"
UPDATE Comment
SET
    DateAdded = @DateAdded
    ,TypeID = @TypeID
    ,ReminderDate = @ReminderDate
    ,TaskID = @TaskID
    ,Text = @Text
WHERE 
    ID = @ID");
                            command.Parameters.AddWithValue("ID", comment.ID);

                        }
                        else
                        {
                            query.Append(@"
INSERT INTO Comment
(
    DateAdded
    ,TypeID
    ,ReminderDate
    ,TaskID
    ,Text   
)
VALUE
(
    @DateAdded
    ,@TypeID
    ,@ReminderDate
    ,@TaskID
    ,@Text 
)
SELECT @@IDENTITY
");
                        }

                        command.Parameters.AddWithValue("DateAdded", comment.DateAdded);
                        command.Parameters.AddWithValue("ReminderDate", comment.ReminderDate);
                        command.Parameters.AddWithValue("TypeID", comment.CommentTypeId);
                        command.Parameters.AddWithValue("TaskID", comment.TaskID);
                        command.Parameters.AddWithValue("Text", comment.Text);

                        command.CommandText = query.ToString();

                        if (!comment.IsNew)
                            command.ExecuteNonQuery();
                        else
                            comment.ID = Convert.ToInt32(command.ExecuteScalar());

                        transaction.Commit();
                    }
                }
            }
        }
    }
}
