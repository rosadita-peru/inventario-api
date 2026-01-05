using invetario_api.Modules.entryorder.enums;
using invetario_api.Modules.products.entity;
using invetario_api.Modules.provider.entity;
using invetario_api.Modules.store.entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace invetario_api.Modules.entryorder.entity
{
    [Table("EntryOrders")]
    public class Entryorder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int entryOrderId { get; set; }

        public int providerId { get; set; }

        [ForeignKey(nameof(providerId))]
        public Provider provider { get; set; }

        public int storeId { get; set; }

        [ForeignKey(nameof(storeId))]
        public Store store { get; set; }

        public DateTime entryDate { get; set; }

        public DateTime createdAt { get; set; } = DateTime.Now;

        public EntryOrderType entryOrderType { get; set; }

        public string typeMoney { get; set; }

        public PayCondition payCondition { get; set; }

        public float tax { get; set; }

        public EntryOrderStatus entryOrderStatus { get; set; } = EntryOrderStatus.PENDING;

        public string observation { get; set; }

        public ICollection<EntryOrderDetail> entryOrderDetails { get; set; } = new List<EntryOrderDetail>();
    }
}
