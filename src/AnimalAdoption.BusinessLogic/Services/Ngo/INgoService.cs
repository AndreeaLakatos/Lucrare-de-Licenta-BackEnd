using System.Collections.Generic;
using AnimalAdoption.BusinessLogic.Dtos;
using System.Threading.Tasks;

namespace AnimalAdoption.BusinessLogic.Services.Ngo
{
    public interface INgoService
    {
        public Task<NgoDto> Create(NgoDto ngoDto);
        public Task<IEnumerable<NgoDto>> GetNgos();
        public Task<NgoDto> GetNgo(int ngoId);
    }
}
