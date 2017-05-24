using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Task.DTO;

namespace Task.DAL
{
    public class TaskStatusRepository 
        //: AbstractRepository<Task.Core.TaskStatus,BusinessCollectionBase<TaskStatus>, TaskStatusCriteria>
    {
        public Task.DTO.TaskStatusDTO FetchByID(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task.DTO.TaskStatusDTO> FetchAll(TaskStatusCriteria criteria)
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

        public bool Update(Task.DTO.TaskStatusDTO task)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Task.DTO.TaskStatusDTO task)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task.DTO.TaskStatusDTO> ExecuteFetch(TaskStatusCriteria criteria, SqlTransaction transaction)
        {
            var taskStatuses = new List<Task.DTO.TaskStatusDTO>();

            using (var command = transaction.Connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandType = CommandType.Text;

                command.CommandText = @"
SELECT 
    ID
    ,Name
FROM
    TaskStatus";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var task = new TaskStatusDTO();

                        task.ID = reader.GetInt32(0);
                        task.Name = reader.GetString(1);

                        taskStatuses.Add(task);
                    }
                }
            }

            return taskStatuses;
        }      
    }
}
