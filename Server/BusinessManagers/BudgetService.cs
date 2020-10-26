using Server.BusinessAbstraction;
using Server.DatabaseAbstraction;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.BusinessManagers
{
    public class BudgetService : IBudgetService
    {
        private IUnitOfWork _database;
        public BudgetService(IUnitOfWork database)
        {
            _database = database;
        }
        public async Task CreateAsync(Budget item)
        {
            await _database.Budgets.CreateAsync(item);
        }
        public async Task CreateRangeAsync()
        {
            IEnumerable<BudgetTemplate> budgetTemplates = await _database.BudgetTemplates.GetAllAsync();
            List<Budget> budgets = InitializeBudgets(budgetTemplates).ToList();
            await _database.Budgets.CreateRangeAsync(budgets);
        }
        public async Task DeleteAsync(int id)
        {
            await _database.Budgets.DeleteAsync(id);
        }

        public async Task<IEnumerable<Budget>> GetAllAsync()
        {
            IEnumerable<Budget> budgets = await _database.Budgets.GetAllAsync();
            return budgets.ToList();
        }

        public async Task<Budget> GetAsync(int id)
        {
            Budget budget = await _database.Budgets.GetAsync(id);
            return budget;
        }

        public async Task UpdateAsync(Budget item)
        {
            Budget budget = await _database.Budgets.GetAsync(item.Id);
            budget.Update(item);
            await _database.Budgets.UpdateAsync(budget);
        }
        private IEnumerable<Budget> InitializeBudgets(IEnumerable<BudgetTemplate> budgetTemplates)
        {
            foreach(BudgetTemplate budgetTemplate in budgetTemplates)
            {
                Budget budget = new Budget();
                budget.Amount = budgetTemplate.Amount;
                budget.Name = budgetTemplate.Name;
                budget.BudgetTemplateId = budgetTemplate.Id;
                yield return budget;
            }
        }
    }
}
