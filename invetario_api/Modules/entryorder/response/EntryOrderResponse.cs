using System;
using invetario_api.Modules.entryorder.entity;
using invetario_api.Modules.entryorder.enums;
using invetario_api.Modules.products.response;
using invetario_api.Modules.provider.response;
using invetario_api.Modules.store.response;

namespace invetario_api.Modules.entryorder.response;

public class EntryOrderResponse
{
    public int entryOrderId { get; set; }
    public ProviderResponseSingle provider { get; set; }

    public StoreResponse store { get; set; }

    public DateTime entryDate { get; set; }

    public DateTime createdAt { get; set; } = DateTime.Now;

    public EntryOrderType entryOrderType { get; set; }

    public string typeMoney { get; set; }

    public string payCondition { get; set; }

    public float tax { get; set; }

    public string entryOrderStatus { get; set; }

    public string observation { get; set; }

    public List<EntryOrderDetailResponse> entryOrderDetails { get; set; }

    public static EntryOrderResponse fromEntity(Entryorder entryorder)
    {
        return new EntryOrderResponse
        {
            entryOrderId = entryorder.entryOrderId,
            provider = ProviderResponseSingle.fromEntity(entryorder.provider),
            store = StoreResponse.fromEntity(entryorder.store),
            entryDate = entryorder.entryDate,
            createdAt = entryorder.createdAt,
            entryOrderType = entryorder.entryOrderType,
            typeMoney = entryorder.typeMoney,
            payCondition = entryorder.payCondition.ToString(),
            tax = entryorder.tax,
            entryOrderStatus = entryorder.entryOrderStatus.ToString(),
            observation = entryorder.observation,
            entryOrderDetails = EntryOrderDetailResponse.fromEntityList(entryorder.entryOrderDetails.ToList())
        };
    }

    public static List<EntryOrderResponse> fromEntityList(List<Entryorder> entryorders)
    {
        List<EntryOrderResponse> responseList = new List<EntryOrderResponse>();
        foreach (var entryorder in entryorders)
        {
            responseList.Add(fromEntity(entryorder));
        }
        return responseList;
    }
}
