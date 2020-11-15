using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.BusinessAbstraction
{
    public interface IPurposeService
    {
        Task<IEnumerable<Purpose>> GetAllAsync();
        Task<IEnumerable<Purpose>> GetEnabledAsync();
        Task<Purpose> GetAsync(int id);
        Task CreateAsync(Purpose item);
        Task UpdateAsync(Purpose item);
        Task DeleteAsync(int id);
    }
}
