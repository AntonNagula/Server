using Server.BusinessAbstraction;
using Server.DatabaseAbstraction;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.BusinessManagers
{
    public class PaymentService : IPaymentService
    {
        private IUnitOfWork _database;
        public PaymentService(IUnitOfWork database)
        {
            _database = database;
        }
        public async Task CreateAsync(Payment item)
        {
            Budget budget = await _database.Budgets.GetAsync(item.BudgetId.Value);
            budget.RemainingAmount = budget.Amount - item.Amount;
            await _database.Budgets.UpdateAsync(budget);
            await _database.Payments.CreateAsync(item);
        }
        public async Task CreateRangeAsync(IEnumerable<Payment> items)
        {            
            await _database.Payments.CreateRangeAsync(items);
        }
        public async Task DeleteAsync(int id)
        {
            await _database.Payments.DeleteAsync(id);
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            IEnumerable<Payment> payments = await _database.Payments.GetAllAsync();
            return payments.ToList();
        }
        public async Task<IEnumerable<Payment>> GetPaymentsByProposalAsync(int id)
        {
            IEnumerable<Payment> payments = await _database.Payments.GetPaymentsByProposalAsync(id);
            return payments.ToList();
        }

        public async Task<Payment> GetAsync(int id)
        {
            Payment payment = await _database.Payments.GetAsync(id);
            return payment;
        }

        public async Task UpdateAsync(Payment item)
        {
            Payment payment = await _database.Payments.GetAsync(item.Id);
            payment.Update(item);
            await _database.Payments.UpdateAsync(payment);
        }
    }
}
