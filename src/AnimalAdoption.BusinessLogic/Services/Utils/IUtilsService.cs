using System.Collections.Generic;
using System.Threading.Tasks;
using AnimalAdoption.BusinessLogic.Dtos;

namespace AnimalAdoption.BusinessLogic.Services.Utils
{
    public interface IUtilsService
    {
        public Task<IEnumerable<CityDto>> GetCities(int countyId);
        public Task<IEnumerable<CountyDto>> GetCounties();
    }
}
