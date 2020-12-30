using MySqlConnector;
using System;
using System.Data;

namespace MVVMDemo.Model
{
    public class DatabaseModel
    {

        public string Server { get; set; }
        public string Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }

        private MySqlConnection connection;

        public bool Login()
        {
            try
            {
                var connstr = "Server=" + this.Server + ";Port = " + this.Port + ";Uid=" + this.Username + ";Pwd=" + this.Password + ";database=" + this.Database + "";
                connection = new MySqlConnection(connstr);
                this.Connect();
                this.Disconnect();
                return true;  
                
            }
            catch (Exception ex)
            {
                /* MessageBox.Show(ex.ToString());*/
                return false;
            }
        }
        
        public DataSet ExecuteQuery(string query)
        {
            this.Connect();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "LoadDataBinding");
            this.Disconnect();
            return ds;
        }



        private void Connect() {
            connection.Open();
        }
        private void Disconnect()
        {
            connection.Close();
        }

    }

    
}
