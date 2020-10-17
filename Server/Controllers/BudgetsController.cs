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
    public class BudgetsController : ControllerBase
    {
        List<Budget> budgets = new List<Budget>();
        public BudgetsController()
        {
            budgets.Add(new Budget { id = "1", name = "jjjj", amount = "jknk", remainingAmount="jhg" });
            budgets.Add(new Budget { id = "2", name = "pokju", amount = "olkiuj", remainingAmount="kjhjg" });
        }
        [HttpGet]
        public async Task<IActionResult> GetPayments()
        {            
            return Ok(budgets);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPayments([FromRoute] int id)
        {
            IEnumerable<Budget> budgtes2 = budgets.Where(x => x.id == id.ToString()).ToList();
            return Ok(budgtes2);
        }
    }
}
