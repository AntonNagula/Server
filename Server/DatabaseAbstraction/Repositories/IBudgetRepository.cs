using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DatabaseAbstraction.Repositories
{
    public interface IBudgetRepository : IGenericRepository<Budget>
    {
        Task<IEnumerable<Budget>> GetEnabledBudgets();
    }
}
