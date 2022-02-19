using System.Collections.Generic;
using System.Threading.Tasks;
using AnimalAdoption.BusinessLogic.Dtos;

namespace AnimalAdoption.BusinessLogic.Services.Animal
{
    public interface INgoService
    {
        public Task<IEnumerable<AnimalDto>> GetAnimals(int ngoId);
    }
}
