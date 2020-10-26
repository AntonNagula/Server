using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.BusinessAbstraction
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<IEnumerable<Payment>> GetPaymentsByProposalAsync(int id);
        Task<Payment> GetAsync(int id);
        Task CreateAsync(Payment item);
        Task UpdateAsync(Payment item);
        Task DeleteAsync(int id);
    }
}
