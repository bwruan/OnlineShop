using System.Collections.Generic;
using System.Threading.Tasks;

namespace Address.Infrastructure.Repository
{
    public interface IAddressRepository
    {
        Task AddAddress(string customer, string unitStreet, string city, string state, string zipcode, long accountId);
        Task DeleteAddress(long addressId);
        Task<Entities.Address> GetAddressByAddressId(long addressId);
        Task<List<Entities.Address>> GetAddressesByAccountId(long accountId);
        Task UpdateAddress(long addressId, string newCustomer, string newUnitStreet, string newCity, string newState, string newZipcode);
    }
}