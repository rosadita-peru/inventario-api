using System;
using invetario_api.Modules.entryorder.enums;
using invetario_api.Modules.products.response;

namespace invetario_api.Modules.entryorder.response;

public class EntryOrderDetailResponse
{
    public int entryOrderDetailId { get; set; }
    public ProductResponse product { get; set; }

    public int quantity { get; set; }

    public float unitPrice { get; set; }

    public EntryOrderStatus entryOrderDetailStatus { get; set; }
    public DateTime createdAt { get; set; }

    public static EntryOrderDetailResponse fromEntity(entity.EntryOrderDetail entryOrderDetail)
    {
        return new EntryOrderDetailResponse
        {
            entryOrderDetailId = entryOrderDetail.entryOrderDetailId,
            product = ProductResponse.fromEntity(entryOrderDetail.product),
            quantity = entryOrderDetail.quantity,
            unitPrice = entryOrderDetail.unitPrice,
            entryOrderDetailStatus = entryOrderDetail.entryOrderDetailStatus,
            createdAt = entryOrderDetail.createdAt
        };
    }

    public static List<EntryOrderDetailResponse> fromEntityList(List<entity.EntryOrderDetail> entryOrderDetails)
    {
        return entryOrderDetails.Select(detail => fromEntity(detail)).ToList();
    }
}
