using WorkshopPro.Model;

namespace WorkshopPro.Interfaces
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetEmployees(); // returning list of all employees

    }
}
