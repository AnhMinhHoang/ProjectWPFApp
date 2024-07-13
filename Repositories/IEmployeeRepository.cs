using BusinessObject;

namespace Repositories
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee e);
        void DeleteEmployee(Employee e);
        Employee GetEmployeeById(int id);
        List<Employee> GetEmployees();
        void UpdateEmployee(Employee e);
    }
}