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
    public class ProjectController : Controller
    {
        private IProjectRepository _projectRepository;
        private IMapper _mapper;

        public ProjectController(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Project>))]
        public IActionResult GetEmployees()
        {
            var project = _mapper.Map<List<ProjectDto>>(_projectRepository.GetProjects());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(project);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Project))]
        [ProducesResponseType(400)]
        public IActionResult GetProject(int id)
        {
            if (!_projectRepository.ProjectExists(id))
                return NotFound();

            var project = _mapper.Map<EmployeeDto>(_projectRepository.GetProject(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(project);
        }
        [HttpGet("{id}/name")]
        [ProducesResponseType(200, Type = typeof(Project))]
        [ProducesResponseType(400)]
        public IActionResult GetProject(string firstName)
        {

            var project = _mapper.Map<EmployeeDto>(_projectRepository.GetProject(firstName));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(project);
        }
    }
}
