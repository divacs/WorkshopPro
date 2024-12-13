

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkshopPro.Data;
using WorkshopPro.DTO;
using WorkshopPro.Interfaces;
using WorkshopPro.Model;

namespace WorkshopPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        private IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Employee>))]
        public IActionResult GetEmployees()
        {
            var employees = _mapper.Map<List<EmployeeDto>>(_employeeRepository.GetEmployees());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(employees);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Employee))]
        [ProducesResponseType(400)]
        public IActionResult GetEmployee(int id)
        {
            if (!_employeeRepository.EmployeeExists(id))
                return NotFound();

            var employee = _mapper.Map<EmployeeDto>(_employeeRepository.GetEmployee(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(employee);
        }

        [HttpGet("{id}/firstName")]
        [ProducesResponseType(200, Type = typeof(Employee))]
        [ProducesResponseType(400)]
        public IActionResult GetEmployee(string firstName)
        {

            var employee = _mapper.Map<EmployeeDto>(_employeeRepository.GetEmployee(firstName));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(employee);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateEmployee([FromBody] EmployeeDto employeeCreate)
        {
            if (employeeCreate == null)
                return BadRequest(ModelState);

            var employee = _employeeRepository.GetEmployees()
                .Where(e => e.FirstName.Trim().ToUpper() == employeeCreate.FirstName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (employee != null)
            {
                ModelState.AddModelError("", "Employee already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employeeMap = _mapper.Map<Employee>(employeeCreate);
            if (!_employeeRepository.CreateEmployee(employeeMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }
        [HttpPut("{employeeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateEmployee(int employeeId, [FromBody] EmployeeDto updateEmployee)
        { 
            if(updateEmployee == null)
                return BadRequest(ModelState);

            if(employeeId != updateEmployee.EmployeeId)
                return NotFound();

            if(!_employeeRepository.EmployeeExists(employeeId))
                return NotFound();

            if(!ModelState.IsValid)
                return BadRequest();

            var employeeMap = _mapper.Map<Employee>(updateEmployee);

            if (!_employeeRepository.UpdateEmployee(employeeMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{employeeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteEmployee(int employeeId)
        {
            if(_employeeRepository.EmployeeExists(employeeId))
                return NotFound();

            var employeeToDelete = _mapper.Map<Employee>(employeeId);

            if (!ModelState.IsValid)
                return BadRequest();

            if(!_employeeRepository.DeleteEmployee(employeeToDelete))
                ModelState.AddModelError("", "Something went wrong deleting category");

            return NoContent();
        }

    }
    
}
