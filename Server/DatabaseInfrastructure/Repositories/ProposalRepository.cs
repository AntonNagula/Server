using Server.Models;

namespace Server.DatabaseInfrastructure.Repositories
{
    public class ProposalRepository : Repository<Proposal>
    {
        public ProposalRepository(ProjectDbContext projectDbContext): base(projectDbContext)
        {

        }
    }
}
