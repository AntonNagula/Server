namespace Server.Models
{
    public class Payment
    {
        public string id { get; set; }
        public string name { get; set; }
        public string amount { get; set; }
        public string proposalId { get; set; }
        public string budgetId { get; set; }
    }
}
