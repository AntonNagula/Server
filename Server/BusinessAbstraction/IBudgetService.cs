using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.BusinessAbstraction
{
    public interface IBudgetService
    {
        Task<IEnumerable<Budget>> GetAllAsync();
        Task<Budget> GetAsync(int id);
        Task CreateRangeAsync();
        Task CreateAsync(Budget item);
        Task UpdateAsync(Budget item);
        Task DeleteAsync(int id);
    }
}
