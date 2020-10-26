using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Server.Models
{
    [Table("Payment")]
    public class Payment : TEntity
    {
        [JsonPropertyName("paymentId")]
        [Column("PaymentId")]
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Amount { get; set; }
        public int? ProposalId { get; set; }
        public Proposal Proposal { get; set; }
        public int? BudgetId { get; set; }
        public Budget Budget { get; set; }
    }
}
