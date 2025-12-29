using System.ComponentModel.DataAnnotations;

namespace invetario_api.Modules.unit.dto
{
    public class UpdateUnitDto : UnitDto
    {
        [Required]
        public bool? status { get; set; }

    }
}
