using System;
using System.ComponentModel.DataAnnotations;
using invetario_api.Modules.store.entity;

namespace invetario_api.Modules.store.dto;

public class UpdateStoreProductDto : StoreProductDto
{
    [Required]
    public bool? status { get; set; }
}
