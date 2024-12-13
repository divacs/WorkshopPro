using WorkshopPro.Model;

namespace WorkshopPro.Interfaces
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetEmployees(); // returning list of all employees
        Employee GetEmployee(int id); // get employee by id
        Employee GetEmployee(string firstName); // get employee by name
        bool EmployeeExists(int id); // checking if employee with certan id exists
        bool CreateEmployee(Employee employee);
        bool DeleteEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool Save();

    }
}
