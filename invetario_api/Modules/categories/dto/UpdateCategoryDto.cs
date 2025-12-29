using System.ComponentModel.DataAnnotations;

namespace invetario_api.Modules.categories.dto
{
    public class UpdateCategoryDto : CategoryDto
    {
        [Required]
        public bool? status { get; set; }
    }
}
