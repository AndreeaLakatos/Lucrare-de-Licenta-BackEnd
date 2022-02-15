using AnimalAdoption.BusinessLogic.Services.Utils;
using AnimalAdoption.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AnimalAdoption.Web.Controllers
{
    public class UtilsController : BaseApiController
    {
        private readonly IUtilsService _utilsService;

        public UtilsController(IUtilsService utilsService)
        {
            _utilsService = utilsService;
        }

        [HttpGet]
        [Route("{countyId}/cities")]
        public async Task<IActionResult> GetCities(int countyId) => Ok(await _utilsService.GetCities(countyId));

        [HttpGet]
        [Route("counties")]
        public async Task<IActionResult> GetCounties() => Ok(await _utilsService.GetCounties());
    }
}
