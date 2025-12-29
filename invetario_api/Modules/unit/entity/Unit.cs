using invetario_api.Modules.products.entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace invetario_api.Modules.unit.entity
{
    [Table("Units")]
    public class Unit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int unitId { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        public string description { get; set; }

        public bool status { get; set; } = true;


        public ICollection<Product> products { get; set; } = new List<Product>();
    }
}
