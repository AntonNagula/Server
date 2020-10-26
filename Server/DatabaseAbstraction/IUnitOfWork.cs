using Server.DatabaseAbstraction.Repositories;
using Server.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Server.DatabaseAbstraction
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Proposal> Proposals { get; }
        IGenericRepository<User> Users { get; }
        IPaymentRepository Payments { get; }
        IGenericRepository<Budget> Budgets { get; }
        IGenericRepository<BudgetTemplate> BudgetTemplates { get; }

        bool HasChanges();
        Task CommitAsync(CancellationToken cancellationToken = default);

    }
}
