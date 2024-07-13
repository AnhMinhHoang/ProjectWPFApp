using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public List<Project> GetProject() => ProjectDAO.GetProject();

        public void AddProject(Project p) => ProjectDAO.AddProject(p);

        public void UpdateProject(Project p) => ProjectDAO.UpdateProject(p);

        public void DeleteProject(Project p) => ProjectDAO.DeleteProject(p);

        public Project GetProjectById(int id) => ProjectDAO.GetProjectById(id);
    }
}
