using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.BusinessAbstraction;
using Server.Models;

namespace Server.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentsByProposal([FromRoute] int id)
        {
            IEnumerable<Payment> payments = await _paymentService.GetPaymentsByProposalAsync(id);
            return Ok(payments);
        }
        [HttpPost]
        public async Task<IActionResult> PostPayment([FromBody] Payment payment)
        {
            await _paymentService.CreateAsync(payment);
            return Ok();
        }
    }
}
