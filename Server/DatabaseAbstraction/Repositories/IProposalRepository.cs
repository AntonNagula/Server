using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.DatabaseAbstraction.Repositories
{
    public interface IProposalRepository : IGenericRepository<Proposal>
    {
        Task<IEnumerable<Proposal>> GetProposalsByUserIdAsync(int id);
    }
}
