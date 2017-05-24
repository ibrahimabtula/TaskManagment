using System;
using System.Data.SqlClient;

namespace Task.DAL
{
    public class TransactionUtil
    {
        public static void DoTransactional(Action<SqlTransaction> action)
        {
            try
            {
                using (var connection = ConnectionBuilder.GetOpenedConnection())
                {
                    using (var transaction = connection.BeginTransaction())
                    {
                        action.Invoke(transaction);
                        transaction.Commit();
                    }
                }
            }
            catch (Exception e)
            {
                //TODO: Log
                throw;
            }
        }
    }
}
