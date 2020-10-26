using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Server.Models
{
    [Table("Proposal")]
    public class Proposal : TEntity
    {
        [JsonPropertyName("ProposalId")]
        [Column("ProposalId")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Purpose { get; set; }
        public double? Amount { get; set; }
        public string BankAccount { get; set; }
        public int? StatusId { get; set; }
        public Status Status { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
    public enum Statuses:int
    {        
        Draft = 1,
        Sent = 2,
        Approved = 3
    }
}
