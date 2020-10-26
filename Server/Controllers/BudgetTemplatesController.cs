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
    public class BudgetTemplatesController : ControllerBase
    {
        List<BudgetTemplate> budgetTemplates = new List<BudgetTemplate>();
        public BudgetTemplatesController()
        {
            budgetTemplates.Add(new BudgetTemplate { Id = 1, Name = "jjjj", Amount = 2000 });
        }
        [HttpGet]
        public async Task<IActionResult> GetBudgetTemplates()
        {
            return Ok(budgetTemplates);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBudgetTemplate([FromRoute]int id)
        {
            BudgetTemplate bt = budgetTemplates.FirstOrDefault(x => x.Id == id);
            return Ok(bt);
        }
        [HttpPost]
        public async Task<IActionResult> PostBT([FromBody] BudgetTemplate budgetTemplate)
        {
            budgetTemplates.Add(budgetTemplate);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBT([FromBody] BudgetTemplate budgetTemplate)
        {
            budgetTemplates.Add(budgetTemplate);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBT([FromRoute] int id)
        {            
            return Ok();
        }
    }
}
