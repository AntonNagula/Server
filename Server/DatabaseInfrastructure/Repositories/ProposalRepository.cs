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
        public async override Task<IEnumerable<Proposal>> GetAllAsync()
        {
            return await _database.Set<Proposal>().Include(x => x.User).Include(x => x.Status).Include(x => x.Purpose).Where(x => x.StatusId != 1).ToListAsync();
        }
        public async override Task<Proposal> GetAsync(int id)
        {
            return await _database.Set<Proposal>().Include(x => x.Status).Include(x => x.User).Include(x => x.Purpose).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
