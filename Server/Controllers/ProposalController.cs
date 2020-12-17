using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Server.BusinessAbstraction;
using Server.Managers;
using Server.Models;
using Server.Models.DTO;

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
        [HttpGet("user")]
        public async Task<IActionResult> GetProposalByUserData()
        {
            JWTManager jwtManager = new JWTManager();
            string jwt = jwtManager.GetTokenFromHeader(Request.Headers["Authorization"]);
            string userName = jwtManager.GetUserNameFromJWT(jwt);
            string password = jwtManager.GetPasswordFromJWT(jwt);
            IEnumerable<Proposal> proposals = await _proposalService.GetProposalsByUserNamePasswordAsync(userName, password);
            return Ok(proposals);
        }
        [HttpPost]
        public async Task<IActionResult> PostProposal([FromBody] ProposalDTO proposal)
        {
            Proposal newProposal = new Proposal();
            newProposal.UpdateByDTO(proposal);

            JWTManager jwtManager = new JWTManager();
            string jwt = jwtManager.GetTokenFromHeader(Request.Headers["Authorization"]);
            string username = jwtManager.GetUserNameFromJWT(jwt);
            string password = jwtManager.GetPasswordFromJWT(jwt);

            await _proposalService.CreateAsync(newProposal, username, password);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutProposal([FromBody] ProposalDTO proposal)
        {
            Proposal newProposal = new Proposal();
            newProposal.UpdateByDTO(proposal);
            await _proposalService.UpdateAsync(newProposal);
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
