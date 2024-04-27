using AutoMapper;
using Microsoft.EntityFrameworkCore.Design;
using RequestPermission.Api.Dtos.Department;
using RequestPermission.Api.Dtos.Employee;
using RequestPermission.Api.Entity;

namespace RequestPermission.Api.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // i want to map from assembly

        //employee
        CreateMap<EmployeeAddDto, EmployeeDto>().ReverseMap();
        CreateMap<EmployeeDto, EmployeeUpdateDto>().ReverseMap();
        CreateMap<EmployeeDto, Employee>().ReverseMap()
          .ForMember(source => source.Id, opt => opt.MapFrom(dest => dest.E_ID))
          .ForMember(source => source.Name, opt => opt.MapFrom(dest => dest.E_NAME))
          .ForMember(source => source.Surname, opt => opt.MapFrom(dest => dest.E_SURNAME))
          .ForMember(source => source.Department, opt => opt.MapFrom(dest => dest.E_DEPARTMENT))
          .ForMember(source => source.Title, opt => opt.MapFrom(dest => dest.E_TITLE));
        ///

        CreateMap<Department, DepartmentDto>().ReverseMap()
            .ForMember(src => src.D_ID, opt => opt.MapFrom(dest => dest.Id))
            .ForMember(src => src.D_IS_ACTIVE, opt => opt.MapFrom(dest => dest.IsActive))
            .ForMember(src => src.EMPLOYEES, opt => opt.MapFrom(dest => dest.Employees))
            .ForMember(src => src.D_NAME, opt => opt.MapFrom(dest => dest.Name));

        CreateMap<DepartmentDto, DepartmentListDto>().ReverseMap();
        CreateMap<DepartmentDto, DepartmentInsertDto>().ReverseMap();
        CreateMap<DepartmentDto, DepartmentModifyDto>().ReverseMap();
    }
}
