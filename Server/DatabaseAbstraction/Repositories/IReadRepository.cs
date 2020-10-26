using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.DatabaseAbstraction.Repositories
{
    public interface IReadRepository<T> : IRepository
        where T : TEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
    }
}
