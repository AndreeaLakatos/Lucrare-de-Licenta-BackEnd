using System.Collections.Generic;
using AnimalAdoption.BusinessLogic.Dtos;
using System.Threading.Tasks;

namespace AnimalAdoption.BusinessLogic.Services.Ngo
{
    public interface INgoService
    {
        public Task<AdoptionAnnouncementDto> AddAdoptionAnnouncement(string username, AdoptionAnnouncementDto adoptionAnnouncement);
        public Task<FosteringAnnouncementDto> AddFosteringAnnouncement(string username, FosteringAnnouncementDto adoptionAnnouncement);
        public Task<PhotoDto> AddAdoptionImage(int adoptionAdId, PhotoDto image);
        public Task<IEnumerable<AdoptionAnnouncementListModelDto>> GetUserAdoptionAnnouncements(GetAnnouncementsDto username);
        public Task<PhotoDto> AddFosteringImage(int fostyeringAdId, PhotoDto image);
        public Task<IEnumerable<FosteringAnnouncementListModelDto>> GetUserFosteringAnnouncements(GetAnnouncementsDto username);
    }
}
