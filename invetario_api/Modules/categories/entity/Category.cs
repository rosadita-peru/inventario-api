using invetario_api.Modules.products.entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace invetario_api.Modules.categories.entity
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int categoryId {  get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string description { get; set; }

        public bool status { get; set; } = true;

        public ICollection<Product> products { get; set; } = new List<Product>();
    }
}
