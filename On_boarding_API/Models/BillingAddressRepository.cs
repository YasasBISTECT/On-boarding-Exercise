using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_boarding_API.Models
{
    public class BillingAddressRepository : IBillingAddressRepository
    {
        private readonly AppDBContext appDBContext;

        public BillingAddressRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<BillingAddress> AddBillingAddress(BillingAddress billingAddress)
        {
            var result = await appDBContext.BillingAddress.AddAsync(billingAddress);
            await appDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public void DeleteBillingAddress(int billingId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BillingAddress>> GetBillingAddresses()
        {
            return await appDBContext.BillingAddress.ToListAsync();
        }

        public async Task<BillingAddress> GetBillingAdress(int billingId)
        {
            return await appDBContext.BillingAddress.FirstOrDefaultAsync(e => e.BillingID == billingId);
        }

        public Task<BillingAddress> UpdateBillingAddress(BillingAddress billingAddress)
        {
            throw new NotImplementedException();
        }
    }
}
