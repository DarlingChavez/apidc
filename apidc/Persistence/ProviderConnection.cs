using Microsoft.Data.SqlClient;

namespace apidc.Persistence
{
    public class ProviderConnection
    {
        public SqlConnection ConnectionService = new SqlConnection();
        public ProviderConnection(string connectionString)
        {
            this.ConnectionString = connectionString;
            ConnectionService.ConnectionString = connectionString;
            ConnectionService.Open();
        }
        public string ConnectionString { get; set; }
        public void OpenConnection()
        {
            ConnectionService.ConnectionString = this.ConnectionString;
            ConnectionService.Open();
        }
        public void CloseConnection() 
        {
            if (ConnectionService != null) 
            { 
                if(ConnectionService.State != System.Data.ConnectionState.Closed)
                {
                    ConnectionService.Close();
                }
            }
        }
    }
}
