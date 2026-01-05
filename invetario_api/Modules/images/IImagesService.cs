using invetario_api.Modules.images.entity;
using invetario_api.Modules.images.response;
using invetario_api.utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace invetario_api.Modules.images
{
    public interface IImagesService
    {
        Task<List<ImageResponse>> getImagess();


        Task<ImageResponse> createImages(IFormFile data);
    }
}
