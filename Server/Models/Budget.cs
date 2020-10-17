using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Budget
    {
        public string id { get; set; }
        public string name { get; set; }
        public string amount { get; set; }
        public string remainingAmount { get; set; }
    }
}
