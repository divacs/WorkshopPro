

using Microsoft.AspNetCore.Mvc;
using WorkshopPro.Data;
using WorkshopPro.Interfaces;
using WorkshopPro.Model;

namespace WorkshopPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository) 
        { 
            _employeeRepository = employeeRepository;           
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Employee>))]
        public IActionResult GetEmployees()
        { 
            var employees = _employeeRepository.GetEmployees();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(employees);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Employee))]
        [ProducesResponseType(400)]
        public IActionResult GetEmployee(int id)
        {
            if(!_employeeRepository.EmployeeExists(id))
                return NotFound();

            var employee = _employeeRepository.GetEmployee(id);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(employee);
        }

        [HttpGet("{id}/firstName")]
        [ProducesResponseType(200, Type = typeof(Employee))]
        [ProducesResponseType(400)]
        public IActionResult GetEmployee(string firstName)
        {

            var employee = _employeeRepository.GetEmployee(firstName);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(employee);
        }

    }
    
}
