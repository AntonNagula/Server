using Server.DatabaseAbstraction;
using Server.DatabaseAbstraction.Repositories;
using Server.DatabaseInfrastructure.Repositories;
using Server.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Server.DatabaseInfrastructure
{
    public class UnitOfWork : IUnitOfWork
    {      
        private ProjectDbContext _database;

        private ProposalRepository _proposals;
        private PaymentRepository _payments;
        private BudgetRepository _budgets;
        private Repository<BudgetTemplate> _budgettemplates;
        private Repository<Purpose> _purposes;

        private UserRepository _users;

        public UnitOfWork(ProjectDbContext db)
        {
            _database = db;
        }
        public IGenericRepository<Purpose> Purposes 
        {
            get
            {
                if (_purposes == null)
                    _purposes = new Repository<Purpose>(_database);
                return _purposes;
            }
        }

        public IProposalRepository Proposals
        {
            get
            {
                if (_proposals == null)
                    _proposals = new ProposalRepository(_database);
                return _proposals;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (_users == null)
                    _users = new UserRepository(_database);
                return _users;
            }
        }
              
        public IPaymentRepository Payments
        {
            get
            {
                if (_payments == null)
                    _payments = new PaymentRepository(_database);
                return _payments;
            }
        }
        public IGenericRepository<BudgetTemplate> BudgetTemplates
        {
            get
            {
                if (_budgettemplates == null)
                    _budgettemplates = new Repository<BudgetTemplate>(_database);
                return _budgettemplates;
            }
        }

        public IBudgetRepository Budgets
        {
            get
            {
                if (_budgets == null)
                    _budgets = new BudgetRepository(_database);
                return _budgets;
            }
        }
        public bool HasChanges() => _database.ChangeTracker.HasChanges();
        public async Task CommitAsync(CancellationToken cancellationToken = default) => await _database.SaveChangesAsync(cancellationToken);
        public virtual void Dispose()
        {            
            GC.SuppressFinalize(this);
        }
    }
}
