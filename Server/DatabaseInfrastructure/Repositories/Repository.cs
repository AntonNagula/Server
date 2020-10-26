using Microsoft.EntityFrameworkCore;
using Server.DatabaseAbstraction.Repositories;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DatabaseInfrastructure.Repositories
{
    public class Repository<T> : IGenericRepository<T> where T : class, TEntity
    {
        protected ProjectDbContext _database;
        public Repository(ProjectDbContext projectDbContext)
        {
            _database = projectDbContext;
        }
        public async virtual Task CreateAsync(T item)
        {
            await _database.Set<T>().AddAsync(item);
            await _database.SaveChangesAsync();
        }

        public async virtual Task<bool> DeleteAsync(int id)
        {
            T deleteObj = _database.Set<T>().FirstOrDefault(x => x.Id == id);
            if (deleteObj == null)
                return false;
            _database.Set<T>().Remove(deleteObj);
            await _database.SaveChangesAsync();
            return true;
        }

        public async virtual Task<T> GetAsync(int id)
        {
            return await _database.Set<T>().FirstOrDefaultAsync(x => x.Id == id); 
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return await _database.Set<T>().ToListAsync();
        }

        public async virtual Task UpdateAsync(T item)
        {
            _database.Set<T>().Update(item);
            await _database.SaveChangesAsync();
        }
        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
