using Server.BusinessAbstraction;
using Server.DatabaseAbstraction;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.BusinessManagers
{
    public class UserService : IUserService
    {
        private IUnitOfWork _database;
        public UserService(IUnitOfWork database)
        {
            _database = database;
        }
        public async Task CreateAsync(User item)
        {
            await _database.Users.CreateAsync(item);
        }
        public async Task CreateRangeAsync(IEnumerable<User> items)
        {
            await _database.Users.CreateRangeAsync(items);
        }
        public async Task DeleteAsync(int id)
        {
            await _database.Users.DeleteAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            IEnumerable<User> users = await _database.Users.GetAllAsync();
            return users.ToList();
        }

        public async Task<User> GetAsync(int id)
        {
            User user = await _database.Users.GetAsync(id);
            return user;
        }

        public async Task<User> GetUserByNamePasswordAsync(string name, string password)
        {
            User user = await _database.Users.GetUserByNamePasswordAsync(name, password);
            return user;
        }

        public async Task UpdateAsync(User item)
        {
            User user = await _database.Users.GetAsync(item.Id);
            user.Update(item);
            await _database.Users.UpdateAsync(user);
        }
    }
}
