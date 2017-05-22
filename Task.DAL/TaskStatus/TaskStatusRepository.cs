using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Task.Core;

namespace Task.DAL
{
    public class TaskStatusRepository : AbstractRepository<Task.Core.TaskStatus, TaskStatusCriteria>
    {
        public override TaskStatus Fetch(TaskStatusCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Core.TaskStatus> FetchAll(TaskStatusCriteria crit)
        {
            List<Core.TaskStatus> taskStatuses;

            using (var connection = ConnectionBuilder.GetOpenedConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    using (var transaction = connection.BeginTransaction())
                    {
                        command.Transaction = transaction;
                        command.CommandType = CommandType.Text;

                        command.CommandText = @"SELECT ID, Name FROM TaskStatus";

                        taskStatuses = new List<Core.TaskStatus>();                        

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var task = new Core.TaskStatus(reader.GetInt32(0), reader.GetString(1));
                                taskStatuses.Add(task);
                            }
                        }

                        transaction.Commit();
                    }
                }
            }
            return taskStatuses;
        }

        public override void Update(TaskStatus obj)
        {
            throw new NotImplementedException();
        }
    }
}
