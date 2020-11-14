using System.Text.Json.Serialization;

namespace Server.Models.DTO
{
    public class ProposalDTO
    {
        [JsonPropertyName("proposalId")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Purpose { get; set; }
        public double? Amount { get; set; }
        public string BankAccount { get; set; }
        public int? StatusId { get; set; }
        public int? UserId { get; set; }
        public int? PurposeId { get; set; }
    }
}
