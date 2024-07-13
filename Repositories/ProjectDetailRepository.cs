using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProjectDetailRepository : IProjectDetailRepository
    {
        public List<ProjectDetail> GetProjectDetail() => ProjectDetailDAO.GetProjectDetail();

        public void AddProjectDetail(ProjectDetail p) => ProjectDetailDAO.AddProjectDetail(p);

        public void UpdateProjectDetail(ProjectDetail p) => ProjectDetailDAO.UpdateProjectDetail(p);

        public void DeleteProjectDetail(int ProjectID, int EmployeeID) => ProjectDetailDAO.DeleteProjectDetail(ProjectID, EmployeeID);
    }
}
