using invetario_api.Modules.products.entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace invetario_api.Modules.images.entity
{
    [Table("Images")]
    public class Images
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int imageId { get; set; }

        public string imageName { get; set; }

        public string imageUrl { get; set; }

        public DateTime createdAt { get; set; } = DateTime.UtcNow;

        public ICollection<Product> products { get; set; } = new List<Product>();
    }
}
