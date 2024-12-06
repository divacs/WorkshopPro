using System.Linq;
using WorkshopPro.Data;
using WorkshopPro.Interfaces;
using WorkshopPro.Model;

namespace WorkshopPro.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private DataContext _context;

        public EmployeeRepository(DataContext context) 
        { 
            this._context = context;
        }

        public bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }

        public Employee GetEmployee(int id)
        {
            return _context.Employees.Where(e => e.EmployeeId == id).FirstOrDefault();
        }

        public Employee GetEmployee(string firstName)
        {
            return _context.Employees.Where(e => e.FirstName == firstName).FirstOrDefault();
        }

        public ICollection<Employee> GetEmployees()
        {
            return _context.Employees.OrderBy(e => e.EmployeeId).ToList();
        }
    }
}
