using Server.BusinessAbstraction;
using Server.DatabaseAbstraction;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.BusinessManagers
{
    public class ProposalService : IProposalService
    {
        private IUnitOfWork _database;
        public ProposalService(IUnitOfWork database)
        {
            _database = database;
        }

        public async Task CreateAsync(Proposal item)
        {
            await _database.Proposals.CreateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            await _database.Proposals.DeleteAsync(id);
        }

        public async Task<IEnumerable<Proposal>> GetAllAsync()
        {
            IEnumerable<Proposal> proposals = await _database.Proposals.GetAllAsync();
            return proposals.ToList();
        }
        public async Task<IEnumerable<Proposal>> GetProposalsByUserNamePasswordAsync(string name, string password)
        {
            User user = await _database.Users.GetUserByNamePasswordAsync(name, password);
            IEnumerable<Proposal> proposals = await _database.Proposals.GetProposalsByUserIdAsync(user.Id);
            return proposals.ToList();
        }
        public async Task<Proposal> GetAsync(int id)
        {
            Proposal proposal = await _database.Proposals.GetAsync(id);
            return proposal;
        }

        public async Task UpdateAsync(Proposal item)
        {
            Proposal proposal = await _database.Proposals.GetAsync(item.Id);
            proposal.Update(item);
            await _database.Proposals.UpdateAsync(proposal);
        }
    }
}
