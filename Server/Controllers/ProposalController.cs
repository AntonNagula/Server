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
    public class ProposalController : ControllerBase
    {
        public ProposalController()
        {

        }
        [HttpGet]
        public IEnumerable<Proposal> GetProposals()
        {
            List<Proposal> proposals = new List<Proposal>();
            proposals.Add(new Proposal { Amount="90", Name="jjjj" });
            proposals.Add(new Proposal { Amount="100", Name="pokju" });
            return proposals;
        }
    }
}
