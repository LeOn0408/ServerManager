using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerManager.Data.User
{
    [Table("sm_user")]
    public class UserDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
        public Group Group { get; set; }
        public string Password { get; set; } = null!;
    }
    public enum Group
    {
       ServerAdministrator,
       PortalAdministrator
    }
}
