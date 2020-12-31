using MVVMDemo.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DatabaseClass dbModel = SingletonClass.databaseClass;
        private DataSet ds;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StudentViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            MVVMDemo.ViewModel.StudentViewModel studentViewModelObject = new MVVMDemo.ViewModel.StudentViewModel();

            studentViewModelObject.LoadStudents();

            StudentViewControl.DataContext = studentViewModelObject;
        }

        private void btnloaddata_Click(object sender, RoutedEventArgs e)
        {

                string query = "Select CustomerID,CompanyName,Address, ContactTitle, ContactNo from customers";
                ds = dbModel.ExecuteQuery(query);
                dataGridCustomers.DataContext = ds;
                Trace.WriteLine(ds.Tables[0].Rows[0]["CompanyName"].ToString());


        }

        private void btncreatedata_Click(object sender, RoutedEventArgs e)
        {
            CreateCustomer createCustomer = new CreateCustomer();
            createCustomer.type = "Create";
            createCustomer.SubmitButton.Content = createCustomer.type;
            createCustomer.Show();
        }


        private void DataGrid_MouseRightButtonUp(object sender,
                                                  MouseButtonEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;

            // iteratively traverse the visual tree
            while ((dep != null) &&
                    !(dep is DataGridCell) &&        
                    !(dep is DataGridColumnHeader))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }

            if (dep == null)
                return;

            if (dep is DataGridColumnHeader)
            {
                DataGridColumnHeader columnHeader = dep as DataGridColumnHeader;
                // do something
            }

            if (dep is DataGridCell)
            {
                DataGridCell cell = dep as DataGridCell;

                // navigate further up the tree
                while ((dep != null) && !(dep is DataGridRow))
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }

                DataGridRow row = dep as DataGridRow;
                var rowIndex = this.FindRowIndex(row);
                CreateCustomer createCustomer = new CreateCustomer();
                createCustomer.Title = "Update Customer";
                createCustomer.type = "Update";
                createCustomer.SubmitButton.Content = createCustomer.type;
                createCustomer.CompanyNameTextBox.Text = ds.Tables[0].Rows[rowIndex]["CompanyName"].ToString();
                createCustomer.ContactTitleTextBox.Text = ds.Tables[0].Rows[rowIndex]["ContactTitle"].ToString();
                createCustomer.AddressTextBox.Text = ds.Tables[0].Rows[rowIndex]["Address"].ToString();
                createCustomer.ContactNoTextBox.Text = ds.Tables[0].Rows[rowIndex]["ContactNo"].ToString();
                createCustomer.customerId = ds.Tables[0].Rows[rowIndex]["CustomerID"].ToString();
                createCustomer.Show();
            }
        }

        private int FindRowIndex(DataGridRow row)
        {
            DataGrid dataGrid =
                ItemsControl.ItemsControlFromItemContainer(row)
                as DataGrid;

            int index = dataGrid.ItemContainerGenerator.
                IndexFromContainer(row);

            return index;
        }
    }
}
