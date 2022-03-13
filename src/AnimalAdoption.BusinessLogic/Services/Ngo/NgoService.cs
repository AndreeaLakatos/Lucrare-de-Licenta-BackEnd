using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalAdoption.BusinessLogic.Dtos;
using AnimalAdoption.Data.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AnimalAdoption.BusinessLogic.Services.Ngo
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

        public async Task<NgoDto> Create(NgoDto ngoDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<NgoDto>> GetNgos()
        {
            throw new System.NotImplementedException();
        }

        public Task<NgoDto> GetNgo(int ngoId)
        {
            throw new System.NotImplementedException();
        }
    }
}
