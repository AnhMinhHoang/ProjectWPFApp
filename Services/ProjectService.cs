using BusinessObject;
using DataAccessLayer;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository iProjectRepository;

        public ProjectService()
        {
            iProjectRepository = new ProjectRepository();
        }

        public List<Project> GetProject() => iProjectRepository.GetProject();

        public void AddProject(Project p) => iProjectRepository.AddProject(p);

        public void UpdateProject(Project p) => iProjectRepository.UpdateProject(p);

        public void DeleteProject(Project p) => iProjectRepository?.DeleteProject(p);

        public Project GetProjectById(int id) => iProjectRepository.GetProjectById(id);
    }
}
