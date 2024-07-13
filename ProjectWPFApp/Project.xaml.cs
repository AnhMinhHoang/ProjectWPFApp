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
    /// Interaction logic for Project.xaml
    /// </summary>
    public partial class Project : Window
    {
        IProjectService iProjectService;

        public Project()
        {
            InitializeComponent();
            iProjectService = new ProjectService();
        }

        private void loadItem()
        {
            try
            {
                dgData.SelectionChanged -= dgData_SelectionChanged;
                var listProject = iProjectService.GetProject();
                dgData.ItemsSource = listProject;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
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
            txtProjectID.Text = id;
            var project = iProjectService.GetProjectById(Int32.Parse(id));
            txtProjectName.Text = project.ProjectName;
            txtProjectDescription.Text = project.ProjectDescription;
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            var employee = new Employee();
            employee.Show();
            this.Close();
        }

        private void btnProjectDetail_Click(object sender, RoutedEventArgs e)
        {
            var projectDetail = new ProjectDetail();
            projectDetail.Show();
            this.Close();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(txtProjectName.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng điền tên dự án", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if(txtProjectDescription.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng điền mô tả dự án", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else{
                    var project = new BusinessObject.Project();
                    project.ProjectName = txtProjectName.Text;
                    project.ProjectDescription = txtProjectDescription.Text;
                    iProjectService.AddProject(project);
                    MessageBox.Show("Create successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtProjectName.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng điền tên dự án", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (txtProjectDescription.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng điền mô tả dự án", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var project = new BusinessObject.Project();
                    project.ProjectId = Int32.Parse(txtProjectID.Text);
                    project.ProjectName = txtProjectName.Text;
                    project.ProjectDescription = txtProjectDescription.Text;
                    iProjectService.UpdateProject(project);
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

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtProjectID.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng chọn 1 dự án", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var project = new BusinessObject.Project();
                    project.ProjectId = Int32.Parse(txtProjectID.Text);
                    project.ProjectName = txtProjectName.Text;
                    project.ProjectDescription = txtProjectDescription.Text;
                    iProjectService.DeleteProject(project);
                    MessageBox.Show("Delete successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
