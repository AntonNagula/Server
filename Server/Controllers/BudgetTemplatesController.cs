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
    public class BudgetTemplatesController : ControllerBase
    {
        private IBudgetTemplateService _budgetTemplateService;
        public BudgetTemplatesController(IBudgetTemplateService budgetTemplateService)
        {
            _budgetTemplateService = budgetTemplateService;
        }
        [HttpGet]
        public async Task<IActionResult> GetBudgetTemplates()
        {
            IEnumerable<BudgetTemplate> budgetTemplates = await _budgetTemplateService.GetAllAsync();
            return Ok(budgetTemplates);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBudgetTemplate([FromRoute]int id)
        {
            BudgetTemplate bt = await _budgetTemplateService.GetAsync(id);
            return Ok(bt);
        }
        [HttpPost]
        public async Task<IActionResult> PostBT([FromBody] BudgetTemplate budgetTemplate)
        {
            await _budgetTemplateService.CreateAsync(budgetTemplate);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBT([FromBody] BudgetTemplate budgetTemplate)
        {
            await _budgetTemplateService.UpdateAsync(budgetTemplate);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBT([FromRoute] int id)
        {
            await _budgetTemplateService.DeleteAsync(id);
            return Ok();
        }
    }
}
