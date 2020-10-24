using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetsController : ControllerBase
    {
        List<Budget> budgets = new List<Budget>();
        public BudgetsController()
        {
            budgets.Add(new Budget { Id = 1, Name = "jjjj", Amount = 1000, RemainingAmount=1000 });
        }
        [HttpGet]
        public async Task<IActionResult> GetBudgets()
        {            
            return Ok(budgets);
        }
        [HttpPost("AddCollection")]
        public async Task<IActionResult> PostBudgets([FromBody] IEnumerable<Budget> postBudgets)
        {
            budgets.AddRange(postBudgets);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPayments([FromRoute] int id)
        {
            IEnumerable<Budget> budgtes2 = budgets.Where(x => x.Id == id).ToList();
            return Ok(budgtes2);
        }
    }
}
