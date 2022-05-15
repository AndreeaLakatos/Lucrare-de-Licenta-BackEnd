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
        public Task<IEnumerable<AdoptionAnnouncementListModelDto>> GetUserAdoptionAnnouncements(string username);
        public Task<PhotoDto> AddFosteringImage(int fostyeringAdId, PhotoDto image);
        public Task<IEnumerable<FosteringAnnouncementListModelDto>> GetUserFosteringAnnouncements(GetAnnouncementsDto username);
        Task<int> DeleteAdoptionAnnouncement(string username, int adoptionAnnouncementId);
        Task<int> DeleteFosteringAnnouncement(string username, int fosteringAnnouncementId);
        Task<AdoptionRequestDto> AddAdoptionRequest(AdoptionRequestDto adoptionRequest);
        Task<FosteringRequestDto> AddFosteringRequest(FosteringRequestDto fosteringRequest);
        Task<List<AdoptionRequestListModelDto>> GetAdoptionRequests(int announcementId);
        Task<List<FosteringRequestListModelDto>> GetFosteringRequests(int announcementId);
        Task<AdoptionRequestListModelDto> UpdateAdoptionRequest(AdoptionRequestListModelDto adoptionRequest);
        Task<FosteringRequestListModelDto> UpdateFosteringRequest(FosteringRequestListModelDto fosteringRequest);
    }
}
