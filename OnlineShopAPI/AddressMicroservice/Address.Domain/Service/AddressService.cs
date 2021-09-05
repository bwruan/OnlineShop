using Address.Infrastructure.AccountMicroservice;
using Address.Infrastructure.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Address.Domain.Service
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IUserAccountService _userAccountService;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IUserAccountService userAccountService, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _userAccountService = userAccountService;
            _mapper = mapper;
        }

        public async Task AddAddress(string shippingAdd, long accountId)
        {
            if (string.IsNullOrEmpty(shippingAdd))
            {
                throw new ArgumentException("Please enter an address");
            }

            await _addressRepository.AddAddress(shippingAdd, accountId);
        }

        public async Task<List<Models.Address>> GetAddressesByAccountId(long accountId, string token)
        {
            var addressList = new List<Models.Address>();

            var addresses = await _addressRepository.GetAddressesByAccountId(accountId);

            foreach (var address in addresses)
            {
                var account = await _userAccountService.GetAccountByAccountId(address.AccountId, token);
                var coreAddress = _mapper.Map<Models.Address>(address);

                coreAddress.User = _mapper.Map<Models.UserAccount>(account);

                addressList.Add(coreAddress);
            }

            return addressList;
        }

        public async Task<Models.Address> GetAddressByAddressId(long addressId, string token)
        {
            var address = await _addressRepository.GetAddressByAddressId(addressId);

            if (address == null)
            {
                throw new ArgumentException("Address does not exist.");
            }

            var coreAddress = _mapper.Map<Models.Address>(address);

            return coreAddress;
        }

        public async Task UpdateAddress(long addressId, string newShipping)
        {
            var address = _addressRepository.GetAddressByAddressId(addressId);

            if (address == null)
            {
                throw new ArgumentException("Address does not exist.");
            }

            if (string.IsNullOrEmpty(newShipping))
            {
                throw new ArgumentException("Please enter an address.");
            }

            await _addressRepository.UpdateAddress(addressId, newShipping);
        }

        public async Task DeleteAddress(long addressId)
        {
            await _addressRepository.DeleteAddress(addressId);
        }
    }
}
