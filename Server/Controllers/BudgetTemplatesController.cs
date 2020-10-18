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
        
    }
}
