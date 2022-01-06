using Address.Infrastructure.AccountMicroservice;
using Address.Infrastructure.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
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

        public async Task AddAddress(string customer, string unitStreet, string city, string state, string zipcode, long accountId, string token)
        {
            if (string.IsNullOrEmpty(customer))
            {
                throw new ArgumentException("Please enter name");
            }

            if (string.IsNullOrEmpty(unitStreet))
            {
                throw new ArgumentException("Please enter address unit and street");
            }

            if (string.IsNullOrEmpty(city))
            {
                throw new ArgumentException("Please enter city");
            }

            if (string.IsNullOrEmpty(state))
            {
                throw new ArgumentException("Please select a state");
            }

            if (string.IsNullOrEmpty(zipcode))
            {
                throw new ArgumentException("Please enter zipcode");
            }

            await _addressRepository.AddAddress(customer, unitStreet, city, state, zipcode, accountId);
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

        public async Task UpdateAddress(long addressId, string newCustomer, string newUnitStreet, string newCity, string newState, string newZipcode)
        {
            var address = _addressRepository.GetAddressByAddressId(addressId);

            if (address == null)
            {
                throw new ArgumentException("Address does not exist.");
            }

            if (string.IsNullOrEmpty(newCustomer))
            {
                throw new ArgumentException("Please enter name");
            }

            if (string.IsNullOrEmpty(newUnitStreet))
            {
                throw new ArgumentException("Please enter address unit and street");
            }

            if (string.IsNullOrEmpty(newCity))
            {
                throw new ArgumentException("Please enter city");
            }

            if (string.IsNullOrEmpty(newState))
            {
                throw new ArgumentException("Please select a state");
            }

            if (string.IsNullOrEmpty(newZipcode))
            {
                throw new ArgumentException("Please enter zipcode");
            }

            await _addressRepository.UpdateAddress(addressId, newCustomer, newUnitStreet, newCity, newState, newZipcode);
        }

        public async Task DeleteAddress(long addressId)
        {
            await _addressRepository.DeleteAddress(addressId);
        }
    }
}
