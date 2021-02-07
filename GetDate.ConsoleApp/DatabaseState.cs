using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace GetDate.ConsoleApp
{
    class DatabaseState : IDisposable
    {
        protected SqlConnection _connection;
        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);                          // In dispose call
            GC.SuppressFinalize(this);      // Let GC know that cleaned up resource
        }

        protected virtual void Dispose(bool disposing)
        {
            // Best practice
            //  Send a booling to indicate the resource is being disposed
            if (_disposed)
            {

                // The object was previously disposed
                return;
            }

            if (disposing)
            {
                if (_connection != null)
                {
                    _connection.Dispose();
                    _connection = null;

                }
                _disposed = false;
            }
        }

        public virtual string GetDate()
        {
            // Check if the object has been disposed
            if (_disposed)
            {
                throw new ObjectDisposedException("DatabaseState");
            }


            if (_connection == null)
            {
               
                var connectionString = ConfigurationManager.ConnectionStrings["master"];
                _connection = new SqlConnection(connectionString.ConnectionString);
                _connection.Open();
            }

            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select getdate()";
                return command.ExecuteScalar().ToString();
            }
        }

         
    }
}
