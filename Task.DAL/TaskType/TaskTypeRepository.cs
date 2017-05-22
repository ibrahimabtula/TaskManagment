using System;
using System.Collections.Generic;
using System.Data;
using Task.Core;

namespace Task.DAL
{
    public class TaskTypeRepository : AbstractRepository<Core.TaskType, TaskTypeCriteria>
    {
        public override Core.TaskType Fetch(TaskTypeCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Core.TaskType> FetchAll(TaskTypeCriteria crit)
        {
            List<Core.TaskType> taskTypes;

            using (var connection = ConnectionBuilder.GetOpenedConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    using (var transaction = connection.BeginTransaction())
                    {
                        command.Transaction = transaction;
                        command.CommandType = CommandType.Text;

                        command.CommandText = @"SELECT ID, Name FROM TaskType";

                        taskTypes = new List<Core.TaskType>();                        

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var task = new Core.TaskType(reader.GetInt32(0), reader.GetString(1));
                                taskTypes.Add(task);
                            }
                        }

                        transaction.Commit();
                    }
                }
            }
            return taskTypes;
        }

        public override void Update(TaskType obj)
        {
            throw new NotImplementedException();
        }
    }
}
