using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Server.Models
{
    [Table("User")]
    public class User : TEntity
    {
        [JsonPropertyName("UserId")]
        [Column("UserId")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }

    public enum Roles : int
    {
        Admin = 1,
        Client = 2,
        Submitter = 3
    }
}
