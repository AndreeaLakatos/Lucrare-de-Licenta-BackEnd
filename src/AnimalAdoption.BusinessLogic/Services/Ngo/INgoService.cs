using System.Collections.Generic;
using AnimalAdoption.BusinessLogic.Dtos;
using System.Threading.Tasks;

namespace AnimalAdoption.BusinessLogic.Services.Ngo
{
    public interface INgoService
    {
        public Task<AdoptionAnnouncementDto> AddAdoptionAnnouncement(string username, AdoptionAnnouncementDto adoptionAnnouncement);
        public Task<IEnumerable<NgoDto>> GetNgos();
        public Task<NgoDto> GetNgo(int ngoId);
        public Task<PhotoDto> AddImage(int adoptionAdId, PhotoDto image);
    }
}
