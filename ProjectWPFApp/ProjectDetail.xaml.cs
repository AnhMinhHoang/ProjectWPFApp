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

namespace ProjectWPFApp
{
    /// <summary>
    /// Interaction logic for ProjectDetail.xaml
    /// </summary>
    public partial class ProjectDetail : Window
    {
        private readonly IProjectDetailService iProjectDetailService;
        private readonly IEmployeeService iEmployeeService;
        private readonly IProjectService iProjectService;

        private void loadItem()
        {
            try
            {
                dgData.SelectionChanged -= dgData_SelectionChanged;
                var listProjectDetail = iProjectDetailService.GetProjectDetail();
                foreach (var item in listProjectDetail)
                {
                    item.Project = iProjectService.GetProjectById(item.ProjectId);
                    item.Employee = iEmployeeService.GetEmployeeById(item.EmployeeId);
                }
                dgData.ItemsSource = listProjectDetail;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dgData.SelectionChanged += dgData_SelectionChanged;
            }
        }

        public ProjectDetail()
        {
            InitializeComponent();
            iProjectDetailService = new ProjectDetailService();
            iEmployeeService = new EmployeeService();
            iProjectService = new ProjectService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadItem();
        }

        private void employee_Click(object sender, RoutedEventArgs e)
        {
            var employee = new Employee();
            employee.Show();
            this.Close();
        }

        private void project_Click(object sender, RoutedEventArgs e)
        {
            var project = new Project();
            project.Show();
            this.Close();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtProjectID.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng điền projectID", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (txtEmployeeID.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng điền EmployeeID", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (txtRole.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng điền Vai trò", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var projectDetail = new BusinessObject.ProjectDetail();
                    projectDetail.ProjectId = Int32.Parse(txtProjectID.Text);
                    projectDetail.EmployeeId = Int32.Parse(txtEmployeeID.Text);
                    projectDetail.Role = txtRole.Text;
                    iProjectDetailService.AddProjectDetail(projectDetail);
                    MessageBox.Show("Create successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                loadItem();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(txtProjectID.Text.Length == 0 || txtEmployeeID.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng chọn 1", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var projectDetail = new BusinessObject.ProjectDetail();
                    projectDetail.ProjectId = Int32.Parse(txtProjectID.Text);
                    projectDetail.EmployeeId = Int32.Parse(txtEmployeeID.Text);
                    iProjectDetailService.DeleteProjectDetail(projectDetail.ProjectId, projectDetail.EmployeeId);
                    MessageBox.Show("Delete successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                loadItem();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtProjectID.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng điền projectID", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if(txtEmployeeID.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng điền EmployeeID", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if(txtRole.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng điền Vai trò", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var projectDetail = new BusinessObject.ProjectDetail();
                    projectDetail.ProjectId = Int32.Parse(txtProjectID.Text);
                    projectDetail.EmployeeId = Int32.Parse(txtEmployeeID.Text);
                    projectDetail.Role = txtRole.Text;
                    iProjectDetailService.UpdateProjectDetail(projectDetail);
                    MessageBox.Show("Update successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                loadItem();
            }
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem is BusinessObject.ProjectDetail selectedDetail)
            {
                txtEmployeeID.Text = selectedDetail.EmployeeId.ToString();
                txtProjectID.Text = selectedDetail.ProjectId.ToString();
                txtRole.Text = selectedDetail.Role;
            }
        }
    }
}
