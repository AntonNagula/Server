using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    [Table("Status")]
    public class Status
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
    }
}
