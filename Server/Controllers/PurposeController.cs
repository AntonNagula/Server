using System.Collections.Generic;
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
    public class PurposeController : ControllerBase
    {
        private IPurposeService _purposeService;
        public PurposeController(IPurposeService purposeService)
        {
            _purposeService = purposeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPurposes()
        {
            IEnumerable<Purpose> purposes = await _purposeService.GetAllAsync();
            return Ok(purposes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPurpose([FromRoute] int id)
        {
            Purpose purpose = await _purposeService.GetAsync(id);
            return Ok(purpose);
        }
        [HttpPost]
        public async Task<IActionResult> PostPurpose([FromBody] Purpose purpose)
        {
            await _purposeService.CreateAsync(purpose);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurpose([FromBody] Purpose purpose)
        {
            await _purposeService.UpdateAsync(purpose);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            await _purposeService.DeleteAsync(id);
            return Ok();
        }
    }
}
