using Server.Models;
using System.Threading.Tasks;

namespace Server.DatabaseAbstraction.Repositories
{
    public interface IWriteRepository<T> : IRepository
        where T : TEntity
    {
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task<bool> DeleteAsync(int id);
    }
}
