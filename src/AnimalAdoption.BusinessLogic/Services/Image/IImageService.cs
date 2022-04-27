using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AnimalAdoption.BusinessLogic.Services.Image
{
    public interface IImageService
    {
        Task<ImageUploadResult> SaveImageInCloudAsync(IFormFile fileImage);
        Task<DeletionResult> DeletePhoto(string publicId);
    }
}
