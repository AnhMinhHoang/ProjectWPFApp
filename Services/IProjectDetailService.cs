using BusinessObject;

namespace Services
{
    public interface IProjectDetailService
    {
        void AddProjectDetail(ProjectDetail p);
        void DeleteProjectDetail(int ProjectID, int EmployeeID);
        List<ProjectDetail> GetProjectDetail();
        void UpdateProjectDetail(ProjectDetail p);
    }
}