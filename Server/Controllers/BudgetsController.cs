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
            IEnumerable<Budget> budgets = await _budgetService.GetAllAsync();
            return Ok(budgets);
        }
        [HttpPost("AddCollection")]
        public async Task<IActionResult> PostBudgets()
        {
            await _budgetService.CreateRangeAsync();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPayments([FromRoute] int id)
        {
            IEnumerable<Budget> budgets = await _budgetService.GetAllAsync();
            return Ok(budgets);
        }
    }
}
