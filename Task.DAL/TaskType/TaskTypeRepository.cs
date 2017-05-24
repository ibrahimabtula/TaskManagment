using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Task.DTO;

namespace Task.DAL
{
    public class TaskTypeRepository 
        : ITaskRepository<TaskTypeDTO, TaskTypeCriteria>  
    {
        public Task.DTO.TaskTypeDTO FetchByID(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task.DTO.TaskTypeDTO> FetchAll(TaskTypeCriteria criteria)
        {
            IEnumerable<Task.DTO.TaskTypeDTO> result = null;

            TransactionUtil.DoTransactional(t =>
            {
                result = ExecuteFetch(criteria, t);
            });

            return result;
        }

        public void Update(Task.DTO.TaskTypeDTO task)
        {
            throw new NotImplementedException();
        }

        public void Insert(Task.DTO.TaskTypeDTO task)
        {
            throw new NotImplementedException();
        }

        public void Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task.DTO.TaskTypeDTO> ExecuteFetch(TaskTypeCriteria criteria, SqlTransaction transaction)
        {
            var taskTypes = new List<Task.DTO.TaskTypeDTO>();

            using (var command = transaction.Connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandType = CommandType.Text;

                var query = new StringBuilder(@"
SELECT 
    ID
    ,Name
FROM
    TaskType");

                command.CommandText = query.ToString();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var task = new TaskTypeDTO();

                        task.ID = reader.GetInt32(0);
                        task.Name = reader.GetString(1);

                        taskTypes.Add(task);
                    }
                }
            }

            return taskTypes;
        }
    }
}
