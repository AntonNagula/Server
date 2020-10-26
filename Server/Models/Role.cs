using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Server.Models
{
    [Table("Role")]
    public class Role : TEntity
    {
        [JsonPropertyName("roleId")]
        [Column("RoleId")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
