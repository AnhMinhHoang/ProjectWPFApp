using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccessLayer
{
    public class EmployeeDAO
    {
        public static List<Employee> GetEmployees()
        {
            var listEmployees = new List<Employee>();
            try
            {
                using var db = new ProjectDbContext();
                listEmployees = db.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listEmployees;
        }

        public static void AddEmployee(Employee e)
        {
            try
            {
                using var context = new ProjectDbContext();
                context.Employees.Add(e);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static void UpdateEmployee(Employee e)
        {
            try
            {
                using var context = new ProjectDbContext();
                context.Entry<Employee>(e).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteEmployee(Employee e)
        {
            try
            {
                using var context = new ProjectDbContext();
                var p1 = context.Employees.SingleOrDefault(c => c.EmployeeId == e.EmployeeId);
                context.Employees.Remove(p1);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Employee GetEmployeeById(int id)
        {
            using var db = new ProjectDbContext();
            return db.Employees.FirstOrDefault(c => c.EmployeeId.Equals(id));
        }
    }
}
