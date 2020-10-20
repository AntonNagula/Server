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
    public class BudgetTemplatesController : ControllerBase
    {
        List<BudgetTemplate> budgetTemplates = new List<BudgetTemplate>();
        public BudgetTemplatesController()
        {
            budgetTemplates.Add(new BudgetTemplate { id = "1", name = "jjjj", amount = "jknk" });
            budgetTemplates.Add(new BudgetTemplate { id = "2", name = "pokju", amount = "olkiuj" });
        }
        [HttpGet]
        public async Task<IActionResult> GetBudgetTemplates()
        {
            return Ok(budgetTemplates);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBudgetTemplate([FromRoute]int id)
        {
            BudgetTemplate bt = budgetTemplates.FirstOrDefault(x => x.id == id.ToString());
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
