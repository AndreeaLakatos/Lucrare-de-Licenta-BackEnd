using System.Collections.Generic;
using System.Threading.Tasks;
using AnimalAdoption.BusinessLogic.Dtos;
using AnimalAdoption.Data.Entities;
using AutoMapper;

namespace AnimalAdoption.BusinessLogic.Services.Animal
{
    public class NgoService: INgoService
    {
        private readonly AnimalAdoptionDbContext _dbContext;
        private readonly IMapper _mapper;

        public NgoService(AnimalAdoptionDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<IEnumerable<AnimalDto>> GetAnimals(int ngoId)
        {
            throw new System.NotImplementedException();
        }
    }
}
