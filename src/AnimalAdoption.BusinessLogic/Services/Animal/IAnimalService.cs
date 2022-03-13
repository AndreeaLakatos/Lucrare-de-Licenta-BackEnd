using System.Collections.Generic;
using System.Threading.Tasks;
using AnimalAdoption.BusinessLogic.Dtos;

namespace AnimalAdoption.BusinessLogic.Services.Animal
{
    public interface IAnimalService
    {
        public Task<AnimalDto> Create(int ngoId, AnimalDto animalDto);
        public Task<IEnumerable<AnimalDto>> GetNgoAnimals(int ngoId);
    }
}
