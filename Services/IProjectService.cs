using BusinessObject;

namespace Services
{
    public interface IProjectService
    {
        void AddProject(Project p);
        void DeleteProject(Project p);
        List<Project> GetProject();
        Project GetProjectById(int id);
        void UpdateProject(Project p);
    }
}