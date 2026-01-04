using invetario_api.Modules.store.entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace invetario_api.Modules.products.entity
{
    [Table("Product_Store")]
    public class ProductStore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productStoreId { get; set; }

        public int productId { get; set; }

        [ForeignKey(nameof(productId))]
        public Product product { get; set; }

        public int storeId { get; set; }

        [ForeignKey(nameof(storeId))]
        public Store store { get; set; }
    }
}
