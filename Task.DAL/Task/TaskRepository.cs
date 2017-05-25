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
        : ITaskRepository<TaskDTO, TaskCriteria>
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
            catch(Exception e)
            {
                throw;
                //return null;
            }
        }

        public void Update(Task.DTO.TaskDTO task)
        {
            TransactionUtil.DoTransactional(t => ExecuteUpdate(task, t));
        }

        public void Insert(Task.DTO.TaskDTO task)
        {
            TransactionUtil.DoTransactional(t=> ExecuteInsert(task, t));
        }

        public void Delete(int ID)
        {
            TransactionUtil.DoTransactional(t => ExecuteDelete(ID, t));
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
    Task.[ID]
    ,Task.[CreatedDate]
    ,Task.[RequiredByDate]
    ,Task.[Description]
    ,Task.[StatusID]
    ,Task.[TypeID]
    ,TaskStatus.Name AS TaskStatusName
    ,TaskType.Name AS TaskTypeName
    ,Max_Comment.ReminderDate
FROM 
    Task
    LEFT JOIN TaskStatus ON TaskStatus.ID = StatusID
    LEFT JOIN TaskType ON TaskType.ID = TypeID
    LEFT JOIN
	(	
		SELECT MAX(TaskID) AS TaskID, ReminderDate 
		FROM Comment 
		WHERE ReminderDate IS NOT NULL
		GROUP BY ReminderDate
	) AS Max_Comment ON Max_Comment.TaskID = Task.ID
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

                        task.ID = reader.GetInt32(0);
                        task.CreatedDate = reader.GetNullabelDateTime(1);
                        task.RequiredByDate = reader.GetNullabelDateTime(2);
                        task.Description = reader.GetString(3);
                        task.TaskStatusId = reader.GetInt32(4);
                        task.TaskTypeID = reader.GetInt32(5);
                        task.TaskStatusName = reader.GetString(6);
                        task.TaskTypeName = reader.GetString(7);
                        task.ReminderDate = reader.GetNullabelDateTime(8);

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

                //CreatedDate
                if (task.CreatedDate.HasValue)                 
                    command.Parameters.AddWithValue("CreatedDate", task.CreatedDate);
                else
                    command.Parameters.AddWithValue("CreatedDate", DBNull.Value);
                
                //RequiredByDate
                if (task.RequiredByDate.HasValue)
                    command.Parameters.AddWithValue("RequiredByDate", task.RequiredByDate);
                else
                    command.Parameters.AddWithValue("RequiredByDate", DBNull.Value);

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
VALUES
(
    @CreatedDate
    ,@RequiredByDate
    ,@Description
    ,@StatusID
    ,@TypeID 
)
SELECT @@IDENTITY
";
                if(task.CreatedDate.HasValue)
                    command.Parameters.AddWithValue("CreatedDate", task.CreatedDate);
                else
                    command.Parameters.AddWithValue("CreatedDate", DBNull.Value);

                if (task.RequiredByDate.HasValue)
                    command.Parameters.AddWithValue("RequiredByDate", task.RequiredByDate);
                else
                    command.Parameters.AddWithValue("RequiredByDate", DBNull.Value);

                command.Parameters.AddWithValue("Description", task.Description);
                command.Parameters.AddWithValue("StatusID", task.TaskStatusId);
                command.Parameters.AddWithValue("TypeID", task.TaskTypeID);

                task.ID = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void ExecuteDelete(int ID, SqlTransaction transaction)
        {
            using (var command = transaction.Connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandType = CommandType.Text;

                command.CommandText = @"DELETE FROM Task Where ID = @ID";
                command.Parameters.AddWithValue("ID", ID);

                command.ExecuteNonQuery();
            }
        }
    }
}
