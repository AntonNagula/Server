using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalController : ControllerBase
    {
        List<Proposal> proposals = new List<Proposal>();
        public ProposalController()
        {
            proposals.Add(new Proposal { id="1", name = "jjjj", status = "1", userName="vtv", bankAccount="kkkk", amount="jknk" });
            proposals.Add(new Proposal { id="2", name = "pokju", status = "2", userName="tgv" });
        }
        [HttpGet]
        public IEnumerable<Proposal> GetProposals()
        {
            return proposals;
        }
        [HttpGet("{id}")]
        public Proposal GetProposal([FromRoute] int id)
        {
            Proposal proposal = proposals.FirstOrDefault(x => x.id == id.ToString());
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
            Proposal proposal = proposals.FirstOrDefault(x => x.id==id.ToString());
            proposals.Remove(proposal);
            return proposals;

        }
    }
}
