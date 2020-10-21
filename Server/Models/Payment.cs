namespace Server.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public int ProposalId { get; set; }
        public int BudgetId { get; set; }
    }
}
