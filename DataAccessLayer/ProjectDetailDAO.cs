using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProjectDetailDAO
    {
        public static List<ProjectDetail> GetProjectDetail()
        {
            var listProjectDetail = new List<ProjectDetail>();
            try
            {
                using var db = new ProjectDbContext();
                listProjectDetail = db.ProjectDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listProjectDetail;
        }

        public static void AddProjectDetail(ProjectDetail p)
        {
            try
            {
                using var context = new ProjectDbContext();
                context.ProjectDetails.Add(p);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static void UpdateProjectDetail (ProjectDetail p)
        {
            try
            {
                using var context = new ProjectDbContext();
                context.Entry<ProjectDetail>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteProjectDetail (int ProjectID, int EmployeeID)
        {
            try
            {
                using var context = new ProjectDbContext();
                var p1 = context.ProjectDetails.SingleOrDefault(c => c.ProjectId == ProjectID && c.EmployeeId == EmployeeID);
                context.ProjectDetails.Remove(p1);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
