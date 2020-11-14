using Server.DatabaseAbstraction.Repositories;
using Server.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Server.DatabaseAbstraction
{
    public interface IUnitOfWork : IDisposable
    {
        IProposalRepository Proposals { get; }
        IUserRepository Users { get; }
        IPaymentRepository Payments { get; }
        IBudgetRepository Budgets { get; }
        IGenericRepository<BudgetTemplate> BudgetTemplates { get; }
        IGenericRepository<Purpose> Purposes { get; }

        bool HasChanges();
        Task CommitAsync(CancellationToken cancellationToken = default);

    }
}
