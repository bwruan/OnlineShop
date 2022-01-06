using System.Collections.Generic;
using System.Threading.Tasks;

namespace Address.Domain.Service
{
    public interface IAddressService
    {
        Task AddAddress(string customer, string unitStreet, string city, string state, string zipcode, long accountId, string token);
        Task DeleteAddress(long addressId);
        Task<Models.Address> GetAddressByAddressId(long addressId, string token);
        Task<List<Models.Address>> GetAddressesByAccountId(long accountId, string token);
        Task UpdateAddress(long addressId, string newCustomer, string newUnitStreet, string newCity, string newState, string newZipcode);
    }
}