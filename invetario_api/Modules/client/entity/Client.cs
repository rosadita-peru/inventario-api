using invetario_api.Modules.products.entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace invetario_api.Modules.client.entity
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int clientId { get; set; }

        public ClientType clientType { get; set; } = ClientType.NATURAL;

        public string name { get; set; }

        public string typeDocument { get; set; }

        public string documentNumber { get; set; }

        public string phone { get; set; }

        public string email { get; set; }

        public bool status { get; set; } = true;

        public DateTime createdAt { get; set; } = DateTime.UtcNow;
    }
}
