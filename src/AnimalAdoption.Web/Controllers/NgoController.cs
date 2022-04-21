using System.Threading.Tasks;
using AnimalAdoption.BusinessLogic.Services.Animal;
using AnimalAdoption.BusinessLogic.Services.Ngo;
using AnimalAdoption.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAdoption.Web.Controllers
{
    public class NgoController : BaseApiController
    {
        private readonly INgoService _ngoService;
        private readonly IAnimalService _animalService;

        public NgoController(INgoService ngoService, IAnimalService animalService)
        {
            _ngoService = ngoService;
            _animalService = animalService;
        }

        [HttpGet]
        [Route("/{ngoId}")]
        public async Task<IActionResult> GetNgoAnimals(string ngoId)
        {
            return Ok(await _animalService.GetNgoAnimals(ngoId));
        }
    }
}
