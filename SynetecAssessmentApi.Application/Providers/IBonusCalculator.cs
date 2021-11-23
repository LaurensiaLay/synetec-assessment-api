namespace SynetecAssessmentApi.Application.Providers
{
	//Abstraction of bonus calculation
	public interface IBonusCalculator
	{
		int Calculate(int totalBudget, int totalSalary, int salary);
	}
}