namespace Server.Models
{
    public class Proposal
    {
        public string id { get; set; }
        public string name { get; set; }
        public string userName { get; set; }
        public string userSurname { get; set; }
        public string purpose { get; set; }
        public string amount { get; set; }
        public string bankAccount { get; set; }
        public string status { get; set; }  
    }
    public enum Statuses:int
    {
        Draft,
        Sent,
        Approved
    }
}
