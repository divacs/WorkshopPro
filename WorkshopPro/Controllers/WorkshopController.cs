using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkshopPro.DTO;
using WorkshopPro.Interfaces;
using WorkshopPro.Model;
using WorkshopPro.Repository;

namespace WorkshopPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopController : Controller
    {
        private IWorkshopRepository _workshopRepository;
        IMapper _mapper;

        public WorkshopController(IWorkshopRepository workshopRepository, IMapper mapper)
        {
            _workshopRepository = workshopRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Workshop>))]
        public IActionResult GetWorkshops()
        {
            var workshop = _mapper.Map<List<ProjectDto>>(_workshopRepository.GetWorkshops());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(workshop);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Workshop))]
        [ProducesResponseType(400)]
        public IActionResult GetWorkshop(int id)
        {
            if (!_workshopRepository.WorkshopExists(id))
                return NotFound();

            var workshop = _mapper.Map<EmployeeDto>(_workshopRepository.GetWorkshop(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(workshop);
        }
        [HttpGet("{id}/name")]
        [ProducesResponseType(200, Type = typeof(Workshop))]
        [ProducesResponseType(400)]
        public IActionResult GetWorkshop(string name)
        {

            var workshop = _mapper.Map<EmployeeDto>(_workshopRepository.GetWorkshop(name));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(workshop);
        }
        [HttpGet("{id}/location")]
        [ProducesResponseType(200, Type = typeof(Workshop))]
        [ProducesResponseType(400)]
        public IActionResult GetWorkshopByLocation(string location)
        {

            var workshop = _mapper.Map<EmployeeDto>(_workshopRepository.GetWorkshopByLocation(location));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(workshop);
        }
    }
}
