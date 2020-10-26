using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Server.Models
{
    [Table("BudgetTemplate")]
    public class BudgetTemplate : TEntity
    {
        [JsonPropertyName("BudgetTemplateId")]
        [Column("BudgetTemplateId")]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Amount { get; set; }
    }
}
