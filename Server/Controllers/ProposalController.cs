using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalController : ControllerBase
    {
        List<Proposal> proposals = new List<Proposal>();
        public ProposalController()
        {
            proposals.Add(new Proposal { ProposalId=1, Name = "jjjj", StatusId = 1, UserName="vtv", BankAccount="kkkk", Amount=4000 });
            proposals.Add(new Proposal { ProposalId = 1, Name = "jjjj", StatusId = 1, UserName = "vtv", BankAccount = "kkkk", Amount = 4000 });
        }
        [HttpGet]
        public IEnumerable<Proposal> GetProposals()
        {
            return proposals;
        }
        [HttpGet("{id}")]
        public Proposal GetProposal([FromRoute] int id)
        {
            Proposal proposal = proposals.FirstOrDefault(x => x.ProposalId == id);
            return proposal;
        }
        [HttpPost]
        public void PostProposal([FromBody] Proposal proposal)
        {
            List<Proposal> proposals = new List<Proposal>();
            proposals.Add(proposal);
        }
        [HttpDelete("{id}")]
        public IEnumerable<Proposal> DeleteProposal([FromRoute]int id)
        {            
            Proposal proposal = proposals.FirstOrDefault(x => x.ProposalId==id);
            proposals.Remove(proposal);
            return proposals;

        }
    }
}
