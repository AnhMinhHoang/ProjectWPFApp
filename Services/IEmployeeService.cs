using BusinessObject;

namespace Services
{
    public interface IEmployeeService
    {
        void AddEmployee(Employee e);
        void DeleteEmployee(Employee e);
        Employee GetEmployeeById(int id);
        List<Employee> GetEmployees();
        void UpdateEmployee(Employee e);
    }
}