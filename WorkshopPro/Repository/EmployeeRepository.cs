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

        public bool CreateEmployee(Employee employee)
        {
            _context.Add(employee);
            return Save();
        }
        public bool DeleteEmployee(Employee employee)
        {
            if (employee == null)
                return false;

            _context.Remove(employee);
            Save();
            return true;
        }
        public bool UpdateEmployee(Employee employee)
        {
            if(employee==null)
                return false;

            _context.Update(employee);
            Save();
            return true;
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
