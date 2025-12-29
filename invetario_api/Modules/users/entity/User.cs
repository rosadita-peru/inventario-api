using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace invetario_api.Modules.users.entity
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }

        [Required]
        public string email { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string password { get; set; }
        
        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public Role role { get; set; }

        [Required]
        public bool status { get; set; }
    }
}
