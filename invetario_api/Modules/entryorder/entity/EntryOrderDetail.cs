using System;
using System.ComponentModel.DataAnnotations.Schema;
using invetario_api.Modules.entryorder.enums;
using invetario_api.Modules.products.entity;

namespace invetario_api.Modules.entryorder.entity;

[Table("EntryOrderDetails")]
public class EntryOrderDetail
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int entryOrderDetailId { get; set; }

    public int entryOrderId { get; set; }

    [ForeignKey(nameof(entryOrderId))]
    public Entryorder entryorder { get; set; }

    public int productId { get; set; }

    [ForeignKey(nameof(productId))]
    public Product product { get; set; }

    public int quantity { get; set; }

    public float unitPrice { get; set; }

    public EntryOrderStatus entryOrderDetailStatus { get; set; } = EntryOrderStatus.PENDING;

    public DateTime createdAt { get; set; } = DateTime.Now;
}
