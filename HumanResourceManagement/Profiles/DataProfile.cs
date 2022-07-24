using AutoMapper;
using HumanResourceManagement.Dtos;
using HumanResourceManagement.Models;

namespace HumanResourceManagement.Profiles
{
    public class DataProfile : Profile
    {

        public DataProfile()
        {
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeeEditRequestDto>();
        }
    }
}
