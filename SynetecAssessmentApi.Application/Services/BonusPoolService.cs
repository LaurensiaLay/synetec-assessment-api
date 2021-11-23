using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Application.Dtos;
using SynetecAssessmentApi.Persistence;
using System.Linq;
using System.Threading.Tasks;
using SynetecAssessmentApi.Application.Providers;
using AutoMapper;

namespace SynetecAssessmentApi.Application.Services
{
	//local interface implementation is shielded from external access (internal)
	public class BonusPoolService : IBonusPoolService
	{
		private readonly AppDbContext _dbContext;
		private readonly IBonusCalculator _bonusCalculator;
		private readonly IMapper _mapper;

		//dependency inversion via constructor: D in SOLID
		public BonusPoolService(AppDbContext appDbContext, IBonusCalculator bonusCalculator, IMapper mapper )
		{
			_dbContext = appDbContext;
			_bonusCalculator = bonusCalculator;
			_mapper = mapper;
		}

		public async Task<BonusPoolCalculatorResultDto> CalculateAsync(int bonusPoolAmount, int selectedEmployeeId)
		{
			//load the details of the selected employee using the Id
			Employee employee = await _dbContext.Employees
				.Include(e => e.Department)
				.SingleAsync(item => item.Id == selectedEmployeeId);  //there should be only employee per a valid id, otherwise the db state is invalid, so should use SingleAsync instead of FirstOrDefaultAsync (we don't want to proceed if there are multiple employee match or no employee match, note the validation already happen before making the call)

			//get the total salary budget for the company
			int totalSalary = (int)_dbContext.Employees.Sum(item => item.Salary);

			//calculate the bonus allocation for the employee
			int employeeBonus = _bonusCalculator.Calculate(bonusPoolAmount, totalSalary, employee.Salary);

			return new BonusPoolCalculatorResultDto
			{
				Employee = _mapper.Map<EmployeeDto>(employee),
				Amount = employeeBonus
			};
		}
	}
}
