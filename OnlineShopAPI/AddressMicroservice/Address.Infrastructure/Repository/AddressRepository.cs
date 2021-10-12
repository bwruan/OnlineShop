using Address.Infrastructure.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address.Infrastructure.Repository
{
    public class AddressRepository : IAddressRepository
    {
        public async Task AddAddress(string customer, string unitStreet, string city, string state, string zipcode, long accountId)
        {
            using (var context = new OnlineShopContext())
            {
                var address = new Entities.Address()
                {
                    CustomerName = customer,
                    UnitStreet = unitStreet,
                    City = city,
                    State = state,
                    Zipcode = zipcode,
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

        public async Task<Entities.Address> GetAddressByAddressId(long addressId)
        {
            using (var context = new OnlineShopContext())
            {
                return await context.Addresses.FirstOrDefaultAsync(a => a.AddressId == addressId);
            }
        }

        public async Task UpdateAddress(long addressId, string newCustomer, string newUnitStreet, string newCity, string newState, string newZipcode)
        {
            using (var context = new OnlineShopContext())
            {
                var address = await context.Addresses.FirstOrDefaultAsync(a => a.AddressId == addressId);

                address.CustomerName = newCustomer;
                address.UnitStreet = newUnitStreet;
                address.City = newCity;
                address.State = newState;
                address.Zipcode = newZipcode;

                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAddress(long addressId)
        {
            using (var context = new OnlineShopContext())
            {
                var address = await context.Addresses.FirstOrDefaultAsync(a => a.AddressId == addressId);

                context.Addresses.Remove(address);

                await context.SaveChangesAsync();
            }
        }
    }
}
