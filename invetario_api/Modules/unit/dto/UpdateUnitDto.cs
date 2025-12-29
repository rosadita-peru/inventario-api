namespace invetario_api.Modules.unit.dto
{
    public class UnitDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string name { get; set; }

        [Required]
        [MinLength(1)]
        public string description { get; set; }
    }
}
