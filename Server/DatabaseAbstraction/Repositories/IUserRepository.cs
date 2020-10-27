using Server.DatabaseAbstraction.Repositories;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DatabaseAbstraction.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByNamePasswordAsync(string name, string password);
    }
}
