using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.Application.Dtos;
using SynetecAssessmentApi.Application.Services;

namespace SynetecAssessmentApi.Controllers
{
	//This controller is seggregated from the BonusPoolController => follow S (smaller related logical unit) and I (interface segregation) from SOLID
	[Route("api/[controller]")]
	public class EmployeeController : Controller
	{
		private readonly IEmployeeService _employeeService;

		//dependency inversion via constructor: D in SOLID
		public EmployeeController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}

		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<EmployeeDto>), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetAllEmployeers()
		{
			return Ok(await _employeeService.GetEmployeesAsync());
		}
	}
}
