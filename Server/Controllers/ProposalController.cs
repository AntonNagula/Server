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
    public class ProposalController : ControllerBase
    {
        private IProposalService _proposalService;
        public ProposalController(IProposalService proposalService)
        {
            _proposalService = proposalService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProposals()
        {
            IEnumerable<Proposal> proposals = await _proposalService.GetAllAsync();
            return Ok(proposals);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProposal([FromRoute] int id)
        {
            Proposal proposal = await _proposalService.GetAsync(id);
            return Ok(proposal);
        }
        [HttpPost]
        public async Task<IActionResult> PostProposal([FromBody] Proposal proposal)
        {
            await _proposalService.CreateAsync(proposal);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProposal([FromRoute]int id)
        {
            await _proposalService.DeleteAsync(id);
            return Ok();
        }
    }
}
