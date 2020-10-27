using Microsoft.EntityFrameworkCore;
using Server.DatabaseAbstraction.Repositories;
using Server.Models;
using System.Threading.Tasks;

namespace Server.DatabaseInfrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ProjectDbContext projectDbContext) : base(projectDbContext)
        {

        }

        public async Task<User> GetUserByNamePasswordAsync(string name, string password)
        {
            User user = await _database.Set<User>().Include(x => x.Role).FirstOrDefaultAsync(x => x.Email == name && x.Password == password);
            return user;
        }
    }
}
