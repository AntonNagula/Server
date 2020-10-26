using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Server.Models
{
    [Table("Status")]
    public class Status : TEntity
    {
        [JsonPropertyName("StatusId")]
        [Column("StatusId")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
