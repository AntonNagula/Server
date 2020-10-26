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

        private Repository<Proposal> _proposals;
        private Repository<Payment> _payments;
        private Repository<Budget> _budgets;
        private Repository<BudgetTemplate> _budgettemplates;
        private Repository<User> _users;

        public UnitOfWork(ProjectDbContext db)
        {
            _database = db;
        }
        public IGenericRepository<Proposal> Proposals
        {
            get
            {
                if (_proposals == null)
                    _proposals = new Repository<Proposal>(_database);
                return _proposals;
            }
        }

        public IGenericRepository<User> Users
        {
            get
            {
                if (_users == null)
                    _users = new Repository<User>(_database);
                return _users;
            }
        }
              
        public IGenericRepository<Payment> Payments
        {
            get
            {
                if (_payments == null)
                    _payments = new Repository<Payment>(_database);
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

        public IGenericRepository<Budget> Budgets
        {
            get
            {
                if (_budgets == null)
                    _budgets = new Repository<Budget>(_database);
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
