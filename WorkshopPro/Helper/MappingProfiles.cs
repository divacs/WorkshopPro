using AutoMapper;
using WorkshopPro.DTO;
using WorkshopPro.Model;

namespace WorkshopPro.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Material, MaterialDto>();
        }
    }
}
