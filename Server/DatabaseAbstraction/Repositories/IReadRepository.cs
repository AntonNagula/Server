using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.DatabaseAbstraction.Repositories
{
    public interface IReadRepository<T> : IRepository
        where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
    }
}
