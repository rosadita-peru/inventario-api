using System.ComponentModel.DataAnnotations;

namespace invetario_api.Modules.products.dto
{
    public class UpdateProductDto : ProductDto
    {
        [Required]
        public bool? status { get; set; }
    }
}
