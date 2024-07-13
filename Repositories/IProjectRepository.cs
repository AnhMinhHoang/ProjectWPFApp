using BusinessObject;

namespace Repositories
{
    public interface IProjectRepository
    {
        void AddProject(Project p);
        void DeleteProject(Project p);
        List<Project> GetProject();
        Project GetProjectById(int id);
        void UpdateProject(Project p);
    }
}