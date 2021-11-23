namespace SynetecAssessmentApi.Application.Validators
{
	public enum ValidationCode
	{
		Success,
		EmployeeNotFound,
		Unknown //ValidationCode can be just a boolean flag in this scenario, however for general case, this can be more than a boolean (e.g, if validation is required for total bonus pool amount)
	}
}
