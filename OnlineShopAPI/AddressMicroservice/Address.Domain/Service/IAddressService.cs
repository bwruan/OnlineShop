using System.Collections.Generic;
using System.Threading.Tasks;

namespace Address.Domain.Service
{
    public interface IAddressService
    {
        Task AddAddress(string shippingAdd, long accountId);
        Task DeleteAddress(long addressId);
        Task<Models.Address> GetAddressByAddressId(long addressId, string token);
        Task<List<Models.Address>> GetAddressesByAccountId(long accountId, string token);
        Task UpdateAddress(long addressId, string newShipping);
    }
}