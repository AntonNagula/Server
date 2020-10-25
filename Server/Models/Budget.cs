using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    [Table("Budget")]
    public class Budget
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Amount { get; set; }
        public double? RemainingAmount { get; set; }
        public int? BudgetTemplateId { get; set; }
        public BudgetTemplate BudgetTemplate { get; set; }
    }
}
