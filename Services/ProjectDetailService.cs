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
    public class ProjectDetailService : IProjectDetailService
    {
        private readonly IProjectDetailRepository iProjectDetailRepository;

        public ProjectDetailService()
        {
            iProjectDetailRepository = new ProjectDetailRepository();
        }

        public List<ProjectDetail> GetProjectDetail() => iProjectDetailRepository.GetProjectDetail();

        public void AddProjectDetail(ProjectDetail p) => iProjectDetailRepository.AddProjectDetail(p);

        public void UpdateProjectDetail(ProjectDetail p) => iProjectDetailRepository.UpdateProjectDetail(p);

        public void DeleteProjectDetail(int ProjectID, int EmployeeID) => iProjectDetailRepository.DeleteProjectDetail(ProjectID, EmployeeID);
    }
}
