using Microsoft.EntityFrameworkCore;
using Server.DatabaseAbstraction.Repositories;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DatabaseInfrastructure.Repositories
{
    public class BudgetRepository : Repository<Budget>, IBudgetRepository
    {
        public BudgetRepository(ProjectDbContext projectDbContext) : base(projectDbContext) { }

        public async Task<IEnumerable<Budget>> GetEnabledBudgets()
        {
            List<Budget> budgets = await _database.Set<Budget>().Where(x => x.Enabled == true).ToListAsync();
            return budgets;
        }
    }
}
