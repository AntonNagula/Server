using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    [Table("BudgetTemplate")]
    public class BudgetTemplate
    {
        public int BudgetTemplateId { get; set; }
        public string Name { get; set; }
        public int? Amount { get; set; }
    }
}
