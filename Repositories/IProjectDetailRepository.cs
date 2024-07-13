using BusinessObject;

namespace Repositories
{
    public interface IProjectDetailRepository
    {
        void AddProjectDetail(ProjectDetail p);
        void DeleteProjectDetail(int ProjectID, int EmployeeID);
        List<ProjectDetail> GetProjectDetail();
        void UpdateProjectDetail(ProjectDetail p);
    }
}