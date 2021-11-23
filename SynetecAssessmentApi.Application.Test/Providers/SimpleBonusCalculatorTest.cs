using System;
using SynetecAssessmentApi.Application.Providers;
using Xunit;

namespace SynetecAssessmentApi.Test
{
	public class SimpleBonusCalculatorTest
	{
		[Theory]
		[InlineData(3000, 300000, -1, "Employee Salary must be greater than zero (Parameter 'employeeSalary')")]
		[InlineData(3000, 90, 100, "Total salary must be greater than employee salary (Parameter 'totalSalary')")]
		public void Calculate_WhenArgumentInvalid_ThrowArgumentOutOfRangeException(int totalBonusBudget, int totalSalary, int salary, string expectedMessage)
		{
			Exception exception = Record.Exception(() => new SimpleBonusCalculator().Calculate(totalBonusBudget, totalSalary, salary));

			Assert.IsType<ArgumentOutOfRangeException>(exception);
			Assert.Equal(expectedMessage, exception.Message);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(-10000)]
		public void Calculate_WhenTotalBonusBugetZeroOrLessThanZero_ReturnZero(int totalBonusBudget)
		{
			var expectedBonus = new SimpleBonusCalculator().Calculate(totalBonusBudget, 100000, 20000);
			Assert.Equal(0, expectedBonus);
		}

		[Theory]
		[InlineData(100000, 10000, 1000, 10000)]
		[InlineData(32000000, 123400000, 12000, 3111)] //just get the integer part, not rounding
		public void Calculate_WhenAllArgumentsValid_ReturnExpectedSalary(int totalBonusBudget, int totalSalary, int employeeSalary, int expectedBonus)
		{
			int actualBonus = new SimpleBonusCalculator().Calculate(totalBonusBudget, totalSalary, employeeSalary);
			Assert.Equal(expectedBonus, actualBonus);
		}
	}
}
