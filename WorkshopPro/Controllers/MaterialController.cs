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
    public class MaterialController : Controller
    {
        IMaterialRepository _materialRepository;
        IMapper _mapper;

        public MaterialController(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Material>))]
        public IActionResult GetMaterials() 
        {
            var materials = _mapper.Map<List<MaterialDto>>(_materialRepository.GetMaterials());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(materials);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Employee))]
        [ProducesResponseType(400)]
        public IActionResult GetMaterial(int id)
        {
            if (!_materialRepository.MaterialExists(id))
                return NotFound();

            var employee = _mapper.Map<EmployeeDto>(_materialRepository.GetMaterial(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(employee);
        }
     
    }
}
