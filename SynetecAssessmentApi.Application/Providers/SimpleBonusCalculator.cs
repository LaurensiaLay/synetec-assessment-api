using System;

namespace SynetecAssessmentApi.Application.Providers
{
	//Implement IBonusCalculator. Abstraction is used here to accomodate potential change of bonus calculation =: S and I in SOLID, also L by the fact Calculate return bonus calculation and not unpredicted result (e.g not implemented exception etc)
	public class SimpleBonusCalculator : IBonusCalculator
	{
		public int Calculate(int totalBonusBudget, int totalSalary, int employeeSalary)
		{
			//employee salary should not be null (is illegal by law)
			if (employeeSalary < 0)
				throw new ArgumentOutOfRangeException(nameof(employeeSalary), "Employee Salary must be greater than zero");

			//total salary must greater or equal to empolyeeeSalary
			if (totalSalary <= employeeSalary)
				throw new ArgumentOutOfRangeException(nameof(totalSalary), "Total salary must be greater than employee salary");

			//totalBonusBudget can be less than zero meaning company at loss, in that case we make assumption there will be no bonus at all, the same if totalBonusBuget is zero
			if (totalBonusBudget <= 0)
				return 0;

			decimal bonusPercentage = (decimal)employeeSalary / (decimal)totalSalary;  
			int bonusAllocation = (int)(bonusPercentage * totalBonusBudget); //this always get just the integer part (not rounding), which is correct.

			return bonusAllocation;
		}
	}
}
