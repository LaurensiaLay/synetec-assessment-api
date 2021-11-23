using System.Linq;
using SynetecAssessmentApi.Application.Dtos;
using SynetecAssessmentApi.Persistence;

namespace SynetecAssessmentApi.Application.Validators
{
	public class CalculateBonusDtoValidator
	{
		private readonly AppDbContext _dbContext;
		public CalculateBonusDtoValidator(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public ValidationCode Validate(CalculateBonusDto calculateBonusDto)
		{
			return _dbContext.Employees.Any(emp => emp.Id == calculateBonusDto.SelectedEmployeeId) ? ValidationCode.Success
				: ValidationCode.EmployeeNotFound;
		}
	}
}
