using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVVMDemo
{
    /// <summary>
    /// Interaction logic for DBWindow.xaml
    /// </summary>
    public partial class DBWindow : Window
    {
        private string server;
        private string username;
        private string password;
        private string port;
        private string databaseName;
        public DBWindow()
        {
            InitializeComponent();
            ServerTextBox.Text = "remotemysql.com";
            UsernameTextBox.Text = "jDBpcYZaXf";
            DatabaseTextBox.Text = "jDBpcYZaXf";
            PasswordTextBox.Password = "4tjzVi1OnP";
            PortTextBox.Text = "3306";

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.connectDB();
            
        }

        private void connectDB()
        {

            server = ServerTextBox.Text;
            username = UsernameTextBox.Text;
            password = PasswordTextBox.Password;
            port = PortTextBox.Text;
            databaseName = DatabaseTextBox.Text;


            try
            {
                var connstr = "Server="+server+";Port = "+port+";Uid="+username+";Pwd="+password+";database="+databaseName+"";
                using (var conn = new MySqlConnection(connstr))
                {
                    conn.Open();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
    }
}
