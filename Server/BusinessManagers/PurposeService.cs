using Server.BusinessAbstraction;
using Server.DatabaseAbstraction;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.BusinessManagers
{
    public class PurposeService : IPurposeService
    {
        private IUnitOfWork _database;
        public PurposeService(IUnitOfWork database)
        {
            _database = database;
        }
        public async Task CreateAsync(Purpose item)
        {
            await _database.Purposes.CreateAsync(item);
        }
        public async Task DeleteAsync(int id)
        {
            await _database.Purposes.DeleteAsync(id);
        }

        public async Task<IEnumerable<Purpose>> GetAllAsync()
        {
            IEnumerable<Purpose> purposes = await _database.Purposes.GetAllAsync();
            return purposes.ToList();
        }
        public async Task<IEnumerable<Purpose>> GetEnabledAsync()
        {
            IEnumerable<Purpose> purposes = await _database.Purposes.GetAllAsync();
            List<Purpose> enabledPurposes = purposes.Where(x => x.Enabled == true).ToList();
            return enabledPurposes;
        }
        public async Task<Purpose> GetAsync(int id)
        {
            Purpose purpose = await _database.Purposes.GetAsync(id);
            return purpose;
        }

        public async Task UpdateAsync(Purpose item)
        {
            Purpose purpose = await _database.Purposes.GetAsync(item.Id);
            purpose.Update(item);
            await _database.Purposes.UpdateAsync(purpose);
        }
    }
}
