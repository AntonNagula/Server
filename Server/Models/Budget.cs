using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Server.Models
{
    [Table("Budget")]
    public class Budget : TEntity
    {
        [JsonPropertyName("id")]
        [Column("BudgetId")]
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Amount { get; set; }
        public double? RemainingAmount { get; set; }
        public int? BudgetTemplateId { get; set; }
        public BudgetTemplate BudgetTemplate { get; set; }
        public void Update(Budget budget)
        {
            Name = budget.Name;
            Amount = budget.Amount;
            RemainingAmount = budget.RemainingAmount;
            BudgetTemplateId = budget.BudgetTemplateId;
        }
    }
}
