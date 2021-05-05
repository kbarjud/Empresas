using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Empresas.Infra.Data.DataContexts
{
    public class DataContext : IDisposable
    {
        public MySqlConnection Connection { get; set; }

        public DataContext(AppSettings appSettings)
        {
            try
            {
                Connection = new MySqlConnection(appSettings.ConnectionString);
                Connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            try
            {
                if (Connection.State != ConnectionState.Closed)
                    Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
