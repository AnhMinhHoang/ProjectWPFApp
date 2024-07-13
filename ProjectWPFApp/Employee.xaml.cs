using Services;
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
using BusinessObject;

namespace ProjectWPFApp
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : Window
    {
        private readonly IEmployeeService iEmployeeService;

        public Employee()
        {
            InitializeComponent();
            iEmployeeService = new EmployeeService();
        }

        private void loadItem()
        {
            try
            {
                dgData.SelectionChanged -= dgData_SelectionChanged;
                var listEmployee = iEmployeeService.GetEmployees();
                dgData.ItemsSource = listEmployee;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dgData.SelectionChanged += dgData_SelectionChanged;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadItem();
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell Cell = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            String id = ((TextBlock)Cell.Content).Text;
            txtEmployeeID.Text = id;
            var employee = iEmployeeService.GetEmployeeById(Int32.Parse(id));
            txtEmployeeName.Text = employee.EmployeeName;
            txtEmployeePosition.Text = employee.EmployeePosition;
        }

        private void btnProject_Click(object sender, RoutedEventArgs e)
        {
            var project = new Project();
            project.Show();
            this.Close();
        }

        private void btnProjectDetail_Click(object sender, RoutedEventArgs e)
        {
            var detail = new ProjectDetail();
            detail.Show();
            this.Close();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtEmployeeName.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng điền tên", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (txtEmployeePosition.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng điền chức vụ", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    BusinessObject.Employee employee = new BusinessObject.Employee();
                    employee.EmployeeName = txtEmployeeName.Text;
                    employee.EmployeePosition = txtEmployeePosition.Text;
                    MessageBox.Show("Create successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    iEmployeeService.AddEmployee(employee);
                    loadItem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtEmployeeName.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng điền tên", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (txtEmployeePosition.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng điền chức vụ", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    BusinessObject.Employee employee = new BusinessObject.Employee();
                    employee.EmployeeId = Int32.Parse(txtEmployeeID.Text);
                    employee.EmployeeName = txtEmployeeName.Text;
                    employee.EmployeePosition = txtEmployeePosition.Text;
                    MessageBox.Show("Update successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    iEmployeeService.UpdateEmployee(employee);
                    loadItem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtEmployeeID.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng chọn 1 nhân viên", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    BusinessObject.Employee employee = new BusinessObject.Employee();
                    employee.EmployeeId = Int32.Parse(txtEmployeeID.Text);
                    employee.EmployeeName = txtEmployeeName.Text;
                    employee.EmployeePosition = txtEmployeePosition.Text;
                    MessageBox.Show("Delete successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    iEmployeeService.DeleteEmployee(employee);
                    loadItem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
