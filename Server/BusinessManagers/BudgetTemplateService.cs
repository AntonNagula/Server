using Server.BusinessAbstraction;
using Server.DatabaseAbstraction;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.BusinessManagers
{
    public class BudgetTemplateService : IBudgetTemplateService
    {
        private IUnitOfWork _database;
        public BudgetTemplateService(IUnitOfWork database)
        {
            _database = database;
        }
        public async Task CreateAsync(BudgetTemplate item)
        {
            await _database.BudgetTemplates.CreateAsync(item);
        }
        public async Task CreateRangeAsync(IEnumerable<BudgetTemplate> items)
        {
            await _database.BudgetTemplates.CreateRangeAsync(items);
        }
        public async Task DeleteAsync(int id)
        {
            await _database.BudgetTemplates.DeleteAsync(id);
        }

        public async Task<IEnumerable<BudgetTemplate>> GetAllAsync()
        {
            IEnumerable<BudgetTemplate> budgettemplates = await _database.BudgetTemplates.GetAllAsync();
            return budgettemplates.ToList();
        }

        public async Task<BudgetTemplate> GetAsync(int id)
        {
            BudgetTemplate budgetTemplate = await _database.BudgetTemplates.GetAsync(id);
            return budgetTemplate;
        }

        public async Task UpdateAsync(BudgetTemplate item)
        {
            BudgetTemplate budgetTemplate = await _database.BudgetTemplates.GetAsync(item.Id);
            budgetTemplate.Update(item);
            await _database.BudgetTemplates.UpdateAsync(budgetTemplate);
        }
    }
}
