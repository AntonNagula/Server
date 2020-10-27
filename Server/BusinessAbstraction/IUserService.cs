using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.BusinessAbstraction
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetAsync(int id);
        Task<User> GetUserByNamePasswordAsync(string name, string password);
        Task CreateAsync(User item);
        Task UpdateAsync(User item);
        Task DeleteAsync(int id);
    }
}
