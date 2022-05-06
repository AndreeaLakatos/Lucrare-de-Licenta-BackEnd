using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace AnimalAdoption.BusinessLogic.Services.Image
{
    public class ImageService : IImageService
    {
        private readonly Cloudinary _cloudinary;

        public ImageService(IOptions<CloudinaryOptions> options)
        {
            var account = new Account
            {
                Cloud = options.Value.CloudName,
                ApiKey = options.Value.ApiKey,
                ApiSecret = options.Value.ApiSecret
            };

            _cloudinary = new Cloudinary(account)
            {
                Api =
                {
                    Secure = true
                }
            };
        }


        public async Task<ImageUploadResult> SaveImageInCloudAsync(IFormFile fileImage)
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(fileImage.FileName, fileImage.OpenReadStream()),
                Transformation = new Transformation().Width(700).Height(400)
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhoto(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);

            var result = await _cloudinary.DestroyAsync(deleteParams);

            return result;
        }
    }
}
