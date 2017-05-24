using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Task.DTO;

namespace Task.DAL
{
    public class TaskRepository 
        //: AbstractRepository<Task.DTO.TaskDTO, TaskCollection, TaskCriteria>
    {
        public Task.DTO.TaskDTO FetchByID(int ID)
        {
            var tasks = FetchAll(new TaskCriteria() {TaskID = ID}).ToList();

            if(tasks == null || tasks.Count == 0)
                throw new Exception("Task not found!");

            return tasks[0];
        }

        public IEnumerable<Task.DTO.TaskDTO> FetchAll(TaskCriteria criteria)
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
            catch
            {
                return null;
            }
        }

        public bool Update(Task.DTO.TaskDTO task)
        {
            try
            {
                using (var connection = ConnectionBuilder.GetOpenedConnection())
                {
                    using (var transaction = connection.BeginTransaction())
                    {
                        ExecuteUpdate(task, transaction);
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

        public bool Insert(Task.DTO.TaskDTO task)
        {
            try
            {
                using (var connection = ConnectionBuilder.GetOpenedConnection())
                {
                    using (var transaction = connection.BeginTransaction())
                    {
                        ExecuteInsert(task, transaction);
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

        public IEnumerable<Task.DTO.TaskDTO> ExecuteFetch(TaskCriteria criteria, SqlTransaction transaction)
        {
            var tasks = new List<Task.DTO.TaskDTO>();

            using (var command = transaction.Connection.CreateCommand())
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

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var task = new TaskDTO();

                        task.CreatedDate = reader.GetDateTime(1);
                        task.RequiredByDate = reader.GetDateTime(2);
                        task.Description = reader.GetString(3);
                        task.TaskStatusId = reader.GetInt32(4);
                        task.TaskTypeID = reader.GetInt32(5);

                        tasks.Add(task);
                    }
                }
            }

            return tasks;
        }

        public void ExecuteUpdate(Task.DTO.TaskDTO task, SqlTransaction transaction)
        {
            using (var command = transaction.Connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandType = CommandType.Text;

                command.CommandText = @"
UPDATE Task
SET
    CreatedDate = @CreatedDate
    ,RequiredByDate = @RequiredByDate
    ,Description = @Description
    ,StatusID = @StatusID
    ,TypeID = @TypeID
WHERE 
    ID = @ID";

                command.Parameters.AddWithValue("ID", task.ID);         
                command.Parameters.AddWithValue("CreatedDate", task.CreatedDate);
                command.Parameters.AddWithValue("RequiredByDate", task.RequiredByDate);
                command.Parameters.AddWithValue("Description", task.Description);
                command.Parameters.AddWithValue("StatusID", task.TaskStatusId);
                command.Parameters.AddWithValue("TypeID", task.TaskTypeID);

                command.ExecuteNonQuery();
            }
        }

        public void ExecuteInsert(Task.DTO.TaskDTO task, SqlTransaction transaction)
        {
            using (var command = transaction.Connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandType = CommandType.Text;

                command.CommandText = @"
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
";

                command.Parameters.AddWithValue("CreatedDate", task.CreatedDate);
                command.Parameters.AddWithValue("RequiredByDate", task.RequiredByDate);
                command.Parameters.AddWithValue("Description", task.Description);
                command.Parameters.AddWithValue("StatusID", task.TaskStatusId);
                command.Parameters.AddWithValue("TypeID", task.TaskTypeID);

                task.ID = Convert.ToInt32(command.ExecuteScalar());
            }
        }
    }
}
