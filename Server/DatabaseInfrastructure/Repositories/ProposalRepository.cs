using Microsoft.EntityFrameworkCore;
using Server.DatabaseAbstraction.Repositories;
using Server.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DatabaseInfrastructure.Repositories
{
    public class ProposalRepository : Repository<Proposal>, IProposalRepository
    {
        public ProposalRepository(ProjectDbContext projectDbContext): base(projectDbContext)
        {

        }

        public async Task<IEnumerable<Proposal>> GetProposalsByUserIdAsync(int id)
        {
            List<Proposal> proposals = await _database.Set<Proposal>().Include(x => x.Status).Where(x => x.UserId == id).ToListAsync();
            return proposals;
        }
    }
}
