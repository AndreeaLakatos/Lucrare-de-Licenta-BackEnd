using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalAdoption.BusinessLogic.Dtos;
using AnimalAdoption.Data.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AnimalAdoption.BusinessLogic.Services.Utils
{
    public class UtilsService : IUtilsService
    {
        private readonly AnimalAdoptionDbContext _dbContext;
        private readonly IMapper _mapper;

        public UtilsService(IMapper mapper, AnimalAdoptionDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CityDto>> GetCities(int countyId)
        {
            var cities = await _dbContext.City.Where(x => x.County.Id == countyId).Include(x => x.County)
                .ToListAsync();
            return _mapper.Map<List<CityDto>>(cities);
        }

        public async Task<IEnumerable<CountyDto>> GetCounties()
        {
            var counties = await _dbContext
                .County.ToListAsync();
            return _mapper.Map<List<CountyDto>>(counties);
        }
    }
}