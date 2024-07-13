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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository iEmployeeRepository;

        public EmployeeService()
        {
            iEmployeeRepository = new EmployeeRepository();
        }

        public List<Employee> GetEmployees() => iEmployeeRepository.GetEmployees();

        public void AddEmployee(Employee e) => iEmployeeRepository.AddEmployee(e);

        public void UpdateEmployee(Employee e) => iEmployeeRepository.UpdateEmployee(e);

        public void DeleteEmployee(Employee e) => iEmployeeRepository.DeleteEmployee(e);

        public Employee GetEmployeeById(int id) => iEmployeeRepository.GetEmployeeById(id);
    }
}
