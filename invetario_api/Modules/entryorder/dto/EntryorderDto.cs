using System.ComponentModel.DataAnnotations;
using invetario_api.Modules.entryorder.enums;
using invetario_api.Modules.provider.entity;
using invetario_api.Validations;

namespace invetario_api.Modules.entryorder.dto
{
  public class EntryorderDto
  {
    [Required]
    [Range(1, int.MaxValue)]
    public int providerId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int storeId { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    [PastDateAttribute]
    public DateTime entryDate { get; set; }

    [Required]
    [EnumDataType(typeof(EntryOrderType))]
    public EntryOrderType? entryOrderType { get; set; }

    [Required]
    [MinLength(1)]
    public string typeMoney { get; set; }

    [Required]
    [EnumDataType(typeof(PayCondition))]
    public PayCondition? payCondition { get; set; }

    [Required]
    [Range(0, float.MaxValue)]
    public float tax { get; set; }

    public string observation { get; set; } = string.Empty;

    [Required]
    [MinLength(1)]
    public List<EntryOrderDetailDto> entryOrderDetails { get; set; }
  }
}
