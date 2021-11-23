using AutoMapper;
using SynetecAssessmentApi.Application.Dtos;
using SynetecAssessmentApi.Domain;

namespace SynetecAssessmentApi.Application.Mappers
{
	public class DepartmentProfile : Profile
	{
		public DepartmentProfile()
		{
			CreateMap<Department, DepartmentDto>();
		}
	}
}
