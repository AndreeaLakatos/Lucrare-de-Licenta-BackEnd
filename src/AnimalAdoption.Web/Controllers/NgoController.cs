using System.Threading.Tasks;
using AnimalAdoption.BusinessLogic.Services.Animal;
using AnimalAdoption.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAdoption.Web.Controllers
{
    public class NgoController : BaseApiController
    {
        private readonly INgoService _ngoService;

        public NgoController(INgoService ngoService)
        {
            _ngoService = ngoService;
        }

        [HttpGet]
        [Route("/{ngoId}")]
        public async Task<IActionResult> GetAnimals(int ngoId)
        {
            return Ok(await _ngoService.GetAnimals(ngoId));
        }
    }
}
