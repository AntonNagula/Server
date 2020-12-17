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
    public class BudgetsController : ControllerBase
    {
        private IBudgetService _budgetService;
        public BudgetsController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }
        [HttpGet]
        public async Task<IActionResult> GetBudgets()
        {
            IEnumerable<Budget> budgets = await _budgetService.GetEnabledBudgets();
            return Ok(budgets);
        }
        [HttpGet("payment")]
        public async Task<IActionResult> GetBudgetsPayment()
        {
            IEnumerable<Budget> budgets = await _budgetService.GetEnabledBudgets();
            List<Budget> budgets1 = budgets.ToList();
            for(int i=0;i<budgets1.Count;i++)
            {
                budgets1[i].Name = Budget.ToPayment(budgets1[i]);
            }
            return Ok(budgets);
        }
        [HttpPost("AddCollection")]
        public async Task<IActionResult> PostBudgets()
        {
            await _budgetService.CreateRangeAsync();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBudgets([FromRoute] int id)
        {
            IEnumerable<Budget> budgets = await _budgetService.GetAllAsync();
            return Ok(budgets);
        }
        [HttpPut]
        public async Task<IActionResult> PutBudget([FromBody] Budget budget)
        {
            await _budgetService.UpdateAsync(budget);
            return Ok();
        }
    }
}
