using System.Threading.Tasks;
using SynetecAssessmentApi.Application.Dtos;

namespace SynetecAssessmentApi.Application.Services
{
	//Not related method is segregated into their own interface (I in SOLID)
	public interface IBonusPoolService
	{
		Task<BonusPoolCalculatorResultDto> CalculateAsync(int bonusPoolAmount, int selectedEmployeeId);
	}
}