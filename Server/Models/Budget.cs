namespace Server.Models
{
    public class Budget
    {
        public string id { get; set; }
        public string name { get; set; }
        public string amount { get; set; }
        public string remainingAmount { get; set; }
        public string budgetTemplateId { get; set; }
    }
}
