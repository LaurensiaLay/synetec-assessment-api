using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.Application.Dtos;
using SynetecAssessmentApi.Application.Services;
using System.Threading.Tasks;
using SynetecAssessmentApi.Application.Validators;
using Microsoft.AspNetCore.Http;

namespace SynetecAssessmentApi.Controllers
{
    [Route("api/[controller]")]
    public class BonusPoolController : Controller
    {
        private readonly IBonusPoolService _bonusPoolService;
        private readonly CalculateBonusDtoValidator _validator;
        

        //dependency inversion via constructor: D in SOLID
        public BonusPoolController(IBonusPoolService bonusPoolService, CalculateBonusDtoValidator validator)
		{
            _bonusPoolService = bonusPoolService;
            _validator = validator;
		}

        [HttpPost()]
        [ProducesResponseType(typeof(BonusPoolCalculatorResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CalculateBonus([FromBody] CalculateBonusDto request)
        {
            //the external input need to be validated first
            //in this case, the error can be accomodated using a validationCode without resorting using an exception, in  more complex case, we may need to introduce 
            //a custom exception in application layer, and exception handlling in the api layer which can be implemented as filter. 
            ValidationCode code = _validator.Validate(request);

            return code == ValidationCode.Success ? Ok(await _bonusPoolService.CalculateAsync(request.TotalBonusPoolAmount, request.SelectedEmployeeId))
                : code == ValidationCode.EmployeeNotFound ? BadRequest("SelectedEmployeeId is not specified or the employee is not found")
                : StatusCode(StatusCodes.Status500InternalServerError); 
        }
    }
}
