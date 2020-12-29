using System;
using System.Collections.Generic;
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
    /// Interaction logic for CreateCustomer.xaml
    /// </summary>
    public partial class CreateCustomer : Window
    {
        public string customerId { get; set; }
        public string companyName { get; set; }
        public string contactTitle { get; set; }
        public string address { get; set; }
        public string contactNo { get; set; }
        public string type { get; set; }
public CreateCustomer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            companyName = CompanyNameTextBox.Text;
            contactTitle = ContactTitleTextBox.Text;
            address = AddressTextBox.Text;
            contactNo = ContactNoTextBox.Text;

            string query = "INSERT INTO customers (CompanyName, ContactTitle, Address, ContactNo) VALUES('"+companyName+"', '"+contactTitle+"', '"+address+"', '"+contactNo+"') ";
            if(type == "Update")
            {
                query = "UPDATE customers SET CompanyName = '"+companyName+"', ContactTitle = '"+contactTitle+"', Address = '"+address+"', ContactNo = '"+contactNo+"' WHERE CustomerID = "+customerId+";";
            }
            DBWindow.databaseModel.ExecuteQuery(query);
            this.Close();
            
        }
    }
}
