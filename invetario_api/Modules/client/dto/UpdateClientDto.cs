using System.ComponentModel.DataAnnotations;

namespace invetario_api.Modules.client.dto
{
    public class UpdateClientDto : ClientDto
    {
        [Required]
        public bool? status { get; set; }
    }
}
