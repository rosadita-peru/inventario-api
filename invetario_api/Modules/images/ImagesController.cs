using invetario_api.Modules.images.entity;
using invetario_api.utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace invetario_api.Modules.images
{

    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private IImagesService _imagesService;

        public ImagesController(IImagesService imagesService)
        {
            _imagesService = imagesService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> FindAll()
        {
            var result = await _imagesService.getImagess();
            return Ok(result);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(IFormFile data)
        {
            var result = await _imagesService.createImages(data);
            return Ok(result);
        }

    }
}
