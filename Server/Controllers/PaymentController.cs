using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        List<Payment> payments = new List<Payment>();
        public PaymentController()
        {
            payments.Add(new Payment { PaymentId = 1, Name = "jjjj", Amount = 2000, ProposalId = 1 });
            payments.Add(new Payment { PaymentId = 2, Name = "jjjj", Amount = 2000, ProposalId = 2 });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPayments([FromRoute] int id)
        {
            IEnumerable<Payment> payments2 = payments.Where(x => x.ProposalId == id).ToList();
            return Ok(payments2);
        }
        [HttpPost]
        public async Task<IActionResult> PostPayment([FromBody] Payment payment)
        {
            payments.Add(payment);
            return Ok();
        }
    }
}
