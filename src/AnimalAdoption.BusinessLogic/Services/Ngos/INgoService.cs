using System.Collections.Generic;
using AnimalAdoption.BusinessLogic.Dtos;
using System.Threading.Tasks;
using AnimalAdoption.BusinessLogic.Helpers.PagedList;

namespace AnimalAdoption.BusinessLogic.Services.Ngos
{
    public interface INgoService
    {
        public Task<AdoptionAnnouncementDto> AddAdoptionAnnouncement(string username, AdoptionAnnouncementDto adoptionAnnouncement);
        public Task<FosteringAnnouncementDto> AddFosteringAnnouncement(string username, FosteringAnnouncementDto adoptionAnnouncement);
        public Task<PhotoDto> AddAdoptionImage(int adoptionAdId, PhotoDto image);
        Task<PagedEntity<AdoptionAnnouncementListModelDto>> GetUserAdoptionAnnouncements(PaginationEntity paginationEntity, string username);
        public Task<PhotoDto> AddFosteringImage(int fostyeringAdId, PhotoDto image);
        Task<PagedEntity<FosteringAnnouncementListModelDto>> GetUserFosteringAnnouncements(PaginationEntity paginationEntity, string username);
        Task<int> DeleteAdoptionAnnouncement(string username, int adoptionAnnouncementId);
        Task<int> DeleteFosteringAnnouncement(string username, int fosteringAnnouncementId);
        Task<AdoptionRequestDto> AddAdoptionRequest(AdoptionRequestDto adoptionRequest);
        Task<FosteringRequestDto> AddFosteringRequest(FosteringRequestDto fosteringRequest);
        Task<List<AdoptionRequestListModelDto>> GetAdoptionRequests(int announcementId);
        Task<List<FosteringRequestListModelDto>> GetFosteringRequests(int announcementId);
        Task<AdoptionRequestListModelDto> UpdateAdoptionRequest(AdoptionRequestListModelDto adoptionRequest);
        Task<FosteringRequestListModelDto> UpdateFosteringRequest(FosteringRequestListModelDto fosteringRequest);
        Task<UserAdoptionRequestDto> GetUserAdoptionRequest(int announcementId, string username);
        Task<UserFosteringRequestDto> GetUserFosteringRequest(int announcementId, string username);
        Task<StatisticsDto> GetStatistics(string username);

    }
}
