using Address.Infrastructure.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address.Infrastructure.Repository
{
    public class AddressRepository
    {
        public async Task AddAddress(string shippingAdd, long accountId)
        {
            using(var context = new OnlineShopContext())
            {
                var address = new Entities.Address()
                {
                    Shipping = shippingAdd,
                    AccountId = accountId
                };

                context.Addresses.Add(address);

                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Entities.Address>> GetAddressesByAccountId(long accountId)
        {
            using (var context = new OnlineShopContext())
            {
                var addresses = await context.Addresses.Where(a => a.AccountId == accountId).ToListAsync();

                var addressList = new List<Entities.Address>();

                foreach (var address in addresses)
                {
                    addressList.Add(address);
                }

                return addressList;
            }
        }
    }
}
