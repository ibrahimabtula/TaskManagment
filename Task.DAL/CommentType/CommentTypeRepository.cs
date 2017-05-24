using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Task.DTO;

namespace Task.DAL
{
    public class CommentTypeRepository
    //: AbstractRepository<Core.TaskType, BusinessCollectionBase<TaskType>, TaskTypeCriteria>
    {
        public Task.DTO.CommentTypeDTO FetchByID(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task.DTO.CommentTypeDTO> FetchAll(CommentTypeCriteria criteria)
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

        public bool Update(Task.DTO.CommentTypeDTO task)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Task.DTO.CommentTypeDTO task)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task.DTO.CommentTypeDTO> ExecuteFetch(CommentTypeCriteria criteria, SqlTransaction transaction)
        {
            var taskTypes = new List<Task.DTO.CommentTypeDTO>();

            using (var command = transaction.Connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandType = CommandType.Text;

                var query = new StringBuilder(@"
SELECT 
    ID
    ,Name
FROM
    CommentType");

                command.CommandText = query.ToString();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var task = new CommentTypeDTO();

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
