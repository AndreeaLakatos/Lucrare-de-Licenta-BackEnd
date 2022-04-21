using AnimalAdoption.BusinessLogic.Dtos;
using AnimalAdoption.BusinessLogic.Exceptions;
using AnimalAdoption.Data.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoption.BusinessLogic.Services.Animal
{
    public class AnimalService: IAnimalService
    {
        private readonly AnimalAdoptionDbContext _dbContext;
        private readonly IMapper _mapper;

        public AnimalService(AnimalAdoptionDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<AnimalDto> Create(string ngoId, AnimalDto animalDto)
        {
            var ngo = await _dbContext.Ngos.FirstOrDefaultAsync(ngo => ngo.Id == ngoId);
            var animal = _mapper.Map<Data.Entities.Animal>(animalDto);
            ngo.Animal.Add(animal);

            if(!(await _dbContext.SaveChangesAsync() > 0))
            {
                throw new AddException(ErrorCode.AddAnimalFailed, "Add animal failed!");
            }

            return _mapper.Map<AnimalDto>(animal);
        }

        public async Task<IEnumerable<AnimalDto>> GetNgoAnimals(string ngoId)
        {
            var animals = await _dbContext.Animals.Where(animal => animal.NgoId == ngoId).ToListAsync();
            return _mapper.Map<List<AnimalDto>>(animals);
        }
    }
}
