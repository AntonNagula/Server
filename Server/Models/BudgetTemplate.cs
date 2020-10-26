using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Server.Models
{
    [Table("BudgetTemplate")]
    public class BudgetTemplate : TEntity
    {
        [JsonPropertyName("budgetTemplateId")]
        [Column("BudgetTemplateId")]
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Amount { get; set; }
        public void Update(BudgetTemplate budgetTemplate)
        {
            Name = budgetTemplate.Name;
            Amount = budgetTemplate.Amount;
        }
    }
}
