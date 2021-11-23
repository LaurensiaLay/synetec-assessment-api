using AutoMapper;
using SynetecAssessmentApi.Application.Dtos;
using SynetecAssessmentApi.Domain;

namespace SynetecAssessmentApi.Application.Mappers
{
	public class EmployeeProfile : Profile
	{
		public EmployeeProfile()
		{
			CreateMap<Employee, EmployeeDto>();
		}
	}
}
