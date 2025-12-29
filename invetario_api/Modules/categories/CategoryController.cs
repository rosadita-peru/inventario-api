
using invetario_api.Modules.categories.dto;
using invetario_api.Modules.categories.entity;
using invetario_api.utils;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace invetario_api.Modules.categories
{

    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> FindAll() {

            var result = await _categoryService.getCategories();
            return Ok(result);
        }

        [HttpGet("{categoryId:int}")]
        public async Task<IActionResult> FindById(int categoryId) {

            var result = await _categoryService.getCategoryById(categoryId);

            if(result == null)
            {
                return BadRequest(ResponseApi<object>.NotFound(404, "Category Not Found"));
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryDto data)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }


            var result = await _categoryService.createCategory(data);

            return Ok(result);
        }

        [HttpPut("{categoryId:int}")]
        public async Task<IActionResult> update(int categoryId, [FromBody] UpdateCategoryDto data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _categoryService.updateCategory(categoryId, data);

            if (result == null)
            {
                return BadRequest(ResponseApi<object>.NotFound(404, "Category Not Found"));
            }

            return Ok(result);
        }


        [HttpDelete("{categoryId:int}")]
        public async Task<IActionResult> delete(int categoryId)
        {
            var result = await _categoryService.deleteCategory(categoryId);

            if (result == null)
            {
                return BadRequest(ResponseApi<object>.NotFound(404, "Category Not Found"));
            }

            return Ok(result);
        }
    }
}
