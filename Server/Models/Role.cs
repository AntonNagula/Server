using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    [Table("Role")]
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}
