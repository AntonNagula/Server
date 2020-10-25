using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DatabaseAbstraction.Repositories
{
    public interface IGenericRepository<T> : IReadRepository<T>, IWriteRepository<T>
        where T : class
    {

    }
}
