using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.BusinessAbstraction
{
    public interface IBudgetTemplateService
    {
        Task<IEnumerable<BudgetTemplate>> GetAllAsync();
        Task<BudgetTemplate> GetAsync(int id);
        Task CreateAsync(BudgetTemplate item);
        Task UpdateAsync(BudgetTemplate item);
        Task DeleteAsync(int id);
    }
}
