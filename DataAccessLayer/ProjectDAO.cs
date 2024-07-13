using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProjectDAO
    {
        public static List<Project> GetProject()
        {
            var listProject = new List<Project>();
            try
            {
                using var db = new ProjectDbContext();
                listProject = db.Projects.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listProject;
        }

        public static void AddProject(Project p)
        {
            try
            {
                using var context = new ProjectDbContext();
                context.Projects.Add(p);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static void UpdateProject(Project p)
        {
            try
            {
                using var context = new ProjectDbContext();
                context.Entry<Project>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteProject(Project p)
        {
            try
            {
                using var context = new ProjectDbContext();
                var p1 = context.Projects.SingleOrDefault(c => c.ProjectId == p.ProjectId);
                context.Projects.Remove(p1);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Project GetProjectById(int id)
        {
            using var db = new ProjectDbContext();
            return db.Projects.FirstOrDefault(c => c.ProjectId.Equals(id));
        }
    }
}
