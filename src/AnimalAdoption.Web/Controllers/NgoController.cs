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

        [HttpPost("adoption-announcements")]
        public async Task<IActionResult> GetUserAdoptionAnnouncements([FromBody] GetAnnouncementsDto username)
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

            return Ok(await _ngoService.AddFosteringImage(announcementId, imageDto));
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
    }
}
