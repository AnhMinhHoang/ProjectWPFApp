using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public List<Employee> GetEmployees() => EmployeeDAO.GetEmployees();

        public void AddEmployee(Employee e) => EmployeeDAO.AddEmployee(e);

        public void UpdateEmployee(Employee e) => EmployeeDAO.UpdateEmployee(e);

        public void DeleteEmployee(Employee e) => EmployeeDAO.DeleteEmployee(e);

        public Employee GetEmployeeById(int id) => EmployeeDAO.GetEmployeeById(id);
    }
}
