using invetario_api.database;
using invetario_api.Exceptions;
using invetario_api.Modules.images.entity;
using invetario_api.Modules.images.response;
using invetario_api.utils;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace invetario_api.Modules.images
{
    public class ImagesService : IImagesService
    {
        private Database _db;

        public ImagesService(Database db)
        {
            _db = db;
        }

        public async Task<List<ImageResponse>> getImagess()
        {
            var images = await _db.images.ToListAsync();

            return ImageResponse.FromEntityList(images);
        }

        public async Task<ImageResponse> createImages(IFormFile data)
        {
            if (data == null || data.Length == 0)
            {
                throw new HttpException(400, "No file provided");
            }

            try
            {
                string folderDest = Path.Combine(Directory.GetCurrentDirectory(), "static", "images");
                if (!Directory.Exists(folderDest))
                {
                    Directory.CreateDirectory(folderDest);
                }

                string nameFile = $"{Guid.NewGuid()}_{data.FileName}";

                string filePath = Path.Combine(folderDest, nameFile);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await data.CopyToAsync(stream);
                }

                string urlFile = $"/static/images/{nameFile}";

                var newImage = new Images
                {
                    imageName = nameFile,
                    imageUrl = urlFile
                };
                await _db.images.AddAsync(newImage);
                await _db.SaveChangesAsync();
                return ImageResponse.FromEntity(newImage);

            }
            catch (Exception)
            {
                throw new HttpException(500, "Error uploading file");
            }
        }

    }
}
