using System;
using System.ComponentModel.DataAnnotations;

namespace invetario_api.Modules.entryorder.dto;

public class EntryOrderDetailDto
{
    [Required]
    [Range(1, int.MaxValue)]
    public int productId { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int quantity { get; set; }
    [Required]
    [Range(0.01, float.MaxValue)]
    public float unitPrice { get; set; }
}
