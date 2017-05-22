using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Task.DAL
{
    public class TaskRepository : AbstractRepository<Core.Task, TaskCriteria>
    {
        public override Core.Task Fetch(TaskCriteria criteria)
        {
            var tasks = FetchAll(criteria).ToList();
            if (tasks != null && tasks.Count > 0)
                return tasks[0];

            return null;
        }

        public override IEnumerable<Core.Task> FetchAll(TaskCriteria criteria)
        {
            List<Core.Task> tasks;

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
    ,[CreatedDate]
    ,[RequiredByDate]
    ,[Description]
    ,[StatusID]
    ,[TypeID]
FROM 
    Task
WHERE 1 = 1");

                        if (criteria.TaskID > 0)
                        {
                            query.Append(" AND Task.ID = @TaskID");
                            command.Parameters.AddWithValue("TaskID", criteria.TaskID);
                        }

                        command.CommandText = query.ToString();

                        tasks = new List<Core.Task>();

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var task = new Core.Task(reader.GetInt32(0));

                                task.CreatedDate = reader.GetDateTime(1);
                                task.RequiredByDate = reader.GetDateTime(2);
                                task.Description = reader.GetString(3);
                                task.TaskStatusId = reader.GetInt32(4);
                                task.TaskTypeID = reader.GetInt32(5);

                                task.MarkOld();

                                tasks.Add(task);
                            }
                        }

                        transaction.Commit();
                    }
                }
            }
            return tasks;
        }

        public override void Update(Core.Task task)
        {
            if (!task.IsDirty) return;

            using (var connection = ConnectionBuilder.GetOpenedConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    using (var transaction = connection.BeginTransaction())
                    {
                        command.Transaction = transaction;
                        command.CommandType = CommandType.Text;


                        var query = new StringBuilder();

                        if (!task.IsNew)
                        {
                            query.Append(@"
UPDATE Task
SET
    CreatedDate = @CreatedDate
    ,RequiredByDate = @RequiredByDate
    ,Description = @Description
    ,StatusID = @StatusID
    ,TypeID = @TypeID
WHERE 
    ID = @ID");
                            command.Parameters.AddWithValue("ID", task.ID);

                        }
                        else
                        {
                            query.Append(@"
INSERT INTO Task
(
    CreatedDate
    ,RequiredByDate
    ,Description
    ,StatusID
    ,TypeID   
)
VALUE
(
    @CreatedDate
    ,@RequiredByDate
    ,@Description
    ,@StatusID
    ,@TypeID 
)
SELECT @@IDENTITY
");
                        }

                        command.Parameters.AddWithValue("DateAdded", task.CreatedDate);
                        command.Parameters.AddWithValue("DateAdded", task.RequiredByDate);
                        command.Parameters.AddWithValue("DateAdded", task.Description);
                        command.Parameters.AddWithValue("DateAdded", task.TaskStatusId);
                        command.Parameters.AddWithValue("DateAdded", task.TaskTypeID);

                        command.CommandText = query.ToString();

                        if (!task.IsNew)
                            command.ExecuteNonQuery();
                        else
                            task.ID = Convert.ToInt32(command.ExecuteScalar());

                        transaction.Commit();
                    }
                }
            }
        }
    }
}
