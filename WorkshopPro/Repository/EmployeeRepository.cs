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

        public ICollection<Employee> GetEmployees()
        {
            return _context.Employees.OrderBy(e => e.EmployeeId).ToList();
        }
    }
}
