using System.Threading.Tasks;

namespace Server.DatabaseAbstraction.Repositories
{
    public interface IWriteRepository<T> : IRepository
        where T : class
    {
        Task Create(T item);
        Task Update(T item);
        Task<bool> Delete(int id);
    }
}
