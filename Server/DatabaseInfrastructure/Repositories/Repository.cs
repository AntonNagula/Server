using Server.DatabaseAbstraction.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DatabaseInfrastructure.Repositories
{
    public class Repository<T> : IGenericRepository<T> where T : class
    {
        private ProjectDbContext _database;
        public Repository(ProjectDbContext projectDbContext)
        {
            _database = projectDbContext;
        }
        public async Task Create(T item)
        {
            await _database.Set<T>().AddAsync(item);
            await _database.SaveChangesAsync();
        }

        public virtual Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public virtual Task<T> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            List<T> items = _database.Set<T>().ToList();
            return items;
        }

        public virtual Task Update(T item)
        {
            throw new System.NotImplementedException();
        }
    }
}
