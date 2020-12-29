using MVVMDemo.Model;
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
        public static readonly DatabaseModel databaseModel = new DatabaseModel();
        public DBWindow()
        {
            InitializeComponent();

            //
            ServerTextBox.Text = "remotemysql.com";
            UsernameTextBox.Text = "jDBpcYZaXf";
            DatabaseTextBox.Text = "jDBpcYZaXf";
            PasswordTextBox.Password = "4tjzVi1OnP";
            PortTextBox.Text = "3306";
            //
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.connectDB();
            
        }

        private void connectDB()
        {

            databaseModel.Server = ServerTextBox.Text;
            databaseModel.Username = UsernameTextBox.Text;
            databaseModel.Password = PasswordTextBox.Password;
            databaseModel.Port = PortTextBox.Text;
            databaseModel.Database = DatabaseTextBox.Text;

            bool dbConnect = databaseModel.Login();
            if (dbConnect)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            } else
            {
                MessageBox.Show("DB Error");
            }
            

            



        }
    }
}
