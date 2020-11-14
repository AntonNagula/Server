using Server.Models.DTO;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Server.Models
{
    [Table("Proposal")]
    public class Proposal : TEntity
    {
        [JsonPropertyName("proposalId")]
        [Column("ProposalId")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string purpose { get; set; }
        public double? Amount { get; set; }
        public string BankAccount { get; set; }
        public int? StatusId { get; set; }
        public Status Status { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? PurposeId { get; set; }
        [JsonIgnore]
        public Purpose Purpose { get; set; }

        public void Update(Proposal proposal)
        {
            Name = proposal.Name;
            purpose = proposal.purpose;
            Amount = proposal.Amount;
            BankAccount = proposal.BankAccount;
            StatusId = proposal.StatusId;
            UserId = proposal.UserId;
            PurposeId = proposal.PurposeId;
        }
        public void UpdateByDTO(ProposalDTO proposal)
        {
            Id = proposal.Id;
            Name = proposal.Name;
            purpose = proposal.Purpose;
            Amount = proposal.Amount;
            BankAccount = proposal.BankAccount;
            StatusId = proposal.StatusId;
            UserId = proposal.UserId;
            PurposeId = proposal.PurposeId;
        }
    }
    public enum Statuses:int
    {        
        Draft = 1,
        Sent = 2,
        Approved = 3
    }
}
