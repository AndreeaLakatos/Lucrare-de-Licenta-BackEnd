using System.Linq;
using System.Threading.Tasks;
using AnimalAdoption.BusinessLogic.Dtos;
using AnimalAdoption.BusinessLogic.Services.Image;
using AnimalAdoption.BusinessLogic.Services.Ngo;
using AnimalAdoption.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAdoption.Web.Controllers
{
    public class NgoController : BaseApiController
    {
        private readonly INgoService _ngoService;
        private readonly IImageService _imageService;

        public NgoController(INgoService ngoService, IImageService imageService)
        {
            _ngoService = ngoService;
            _imageService = imageService;
        }

        [HttpGet("adoption-announcements/{username}")]
        public async Task<IActionResult> GetUserAdoptionAnnouncements(string username)
        {
            return Ok(await _ngoService.GetUserAdoptionAnnouncements(username));
        }

        [HttpPost]
        [Route("adoption-announcement")]
        public async Task<IActionResult> CreateAdoptionAnnouncement([FromBody] AdoptionAnnouncementDto adoptionAnnouncement)
        {
            return Ok(await _ngoService.AddAdoptionAnnouncement(adoptionAnnouncement.Username, adoptionAnnouncement));
        }

        [HttpPost("adoption-announcement/{announcementId}"), RequestSizeLimit(100_000_000)]
        public async Task<IActionResult> UploadAdoptionAnnouncementImage(int announcementId)
        {
            var formCollection = await Request.ReadFormAsync();
            var file = formCollection.Files.First();
            var uploadResult = await _imageService.SaveImageInCloudAsync(file);
            var imageDto = new PhotoDto
            {
                Url = uploadResult.SecureUrl.AbsoluteUri,
                PublicId = uploadResult.PublicId
            };

            return Ok(await _ngoService.AddAdoptionImage(announcementId, imageDto));
        }

        [HttpPost("fostering-announcements")]
        public async Task<IActionResult> GetUserFosteringAnnouncements([FromBody] GetAnnouncementsDto username)
        {
            return Ok(await _ngoService.GetUserFosteringAnnouncements(username));
        }

        [HttpPost]
        [Route("fostering-announcement")]
        public async Task<IActionResult> CreateFosteringAnnouncement([FromBody] FosteringAnnouncementDto fosteringAnnouncement)
        {
            return Ok(await _ngoService.AddFosteringAnnouncement(fosteringAnnouncement.Username, fosteringAnnouncement));
        }

        [HttpPost("fostering-announcement/{announcementId}"), RequestSizeLimit(100_000_000)]
        public async Task<IActionResult> UploadFosteringAnnouncementImage(int announcementId)
        {
            var formCollection = await Request.ReadFormAsync();
            var file = formCollection.Files.First();
            var uploadResult = await _imageService.SaveImageInCloudAsync(file);
            var imageDto = new PhotoDto
            {
                Url = uploadResult.SecureUrl.AbsoluteUri,
                PublicId = uploadResult.PublicId
            };

            return Ok(await _ngoService.AddFosteringImage(announcementId, imageDto));
        }

        [HttpDelete("adoption-announcement/{announcementId}/{username}")]
        public async Task<IActionResult> DeleteAdoptionAnnouncement(int announcementId, string username)
        {
            return Ok(await _ngoService.DeleteAdoptionAnnouncement(username, announcementId));
        }

        [HttpDelete("fostering-announcement/{announcementId}/{username}")]
        public async Task<IActionResult> DeleteFosteringAnnouncement(int announcementId, string username)
        {
            return Ok(await _ngoService.DeleteFosteringAnnouncement(username, announcementId));
        }

        [HttpPost("adoption-request")]
        public async Task<IActionResult> AddAdoptionRequest(AdoptionRequestDto adoptionRequest)
        {
            return Ok(await _ngoService.AddAdoptionRequest(adoptionRequest));
        }

        [HttpPost("fostering-request")]
        public async Task<IActionResult> AddAdoptionRequest(FosteringRequestDto fosteringRequest)
        {
            return Ok(await _ngoService.AddFosteringRequest(fosteringRequest));
        }

        [HttpGet("adoption-requests/{announcementId}")]
        public async Task<IActionResult> GetAdoptionRequest(int announcementId)
        {
            return Ok(await _ngoService.GetAdoptionRequests(announcementId));
        }

        [HttpGet("fostering-requests/{announcementId}")]
        public async Task<IActionResult> GetFosteringRequests(int announcementId)
        {
            return Ok(await _ngoService.GetFosteringRequests(announcementId));
        }

        [HttpPost("adoption-requests")]
        public async Task<IActionResult> UpdateAdoptionRequest(AdoptionRequestListModelDto adoptionAnnouncementListModelDto)
        {
            return Ok(await _ngoService.UpdateAdoptionRequest(adoptionAnnouncementListModelDto));
        }

        [HttpPost("fostering-requests")]
        public async Task<IActionResult> UpdateFosteringRequest(FosteringRequestListModelDto fosteringAnnouncementListModelDto)
        {
            return Ok(await _ngoService.UpdateFosteringRequest(fosteringAnnouncementListModelDto));
        }
    }
}
