using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.Application.Dtos;
using SynetecAssessmentApi.Persistence;

namespace SynetecAssessmentApi.Application.Services
{
	//local interface implementation interface is shielded from external access (internal)
	public class EmployeeService : IEmployeeService
	{
		private readonly AppDbContext _dbContext;
		private readonly IMapper _mapper;

		//dependency inversion via constructor: D in SOLID
		public EmployeeService(AppDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
		{
			return await _dbContext
				.Employees
				.Include(emp => emp.Department)
				.Select(emp => _mapper.Map<EmployeeDto>(emp))
				.ToListAsync();
		}
	}
}
