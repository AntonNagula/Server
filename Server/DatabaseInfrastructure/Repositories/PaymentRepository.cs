using Microsoft.EntityFrameworkCore;
using Server.DatabaseAbstraction.Repositories;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DatabaseInfrastructure.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ProjectDbContext projectDbContext) : base(projectDbContext) { }
        public async Task<IEnumerable<Payment>> GetPaymentsByProposalAsync(int id)
        {
            List<Payment> payments = await _database.Set<Payment>().Where(x => x.ProposalId == id).ToListAsync();
            return payments;
        }
    }
}
