using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.BusinessAbstraction
{
    public interface IProposalService
    {
        Task<IEnumerable<Proposal>> GetAllAsync();
        Task<IEnumerable<Proposal>> GetProposalsByUserNamePasswordAsync(string name, string password);
        Task<Proposal> GetAsync(int id);
        Task CreateAsync(Proposal item, string username, string password);
        Task UpdateAsync(Proposal item);
        Task DeleteAsync(int id);
    }
}
