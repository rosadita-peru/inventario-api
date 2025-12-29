using System.ComponentModel.DataAnnotations;

namespace invetario_api.Modules.categories.dto
{
    public class CategoryDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string name { get; set; }

        [Required]
        [MinLength(1)]
        public string description { get; set; }
    }
}
