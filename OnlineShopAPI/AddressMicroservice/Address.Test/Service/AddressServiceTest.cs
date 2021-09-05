using Address.Domain.Service;
using Address.Infrastructure.AccountMicroservice;
using Address.Infrastructure.Repository;
using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DbAddress = Address.Infrastructure.Repository.Entities.Address;
using Account = Address.Infrastructure.AccountMicroservice.Model.UserAccount;

namespace Address.Test.Service
{
    [TestFixture]
    public class AddressServiceTest
    {
        private Mock<IAddressRepository> _addressRepository;
        private Mock<IUserAccountService> _userAccountService;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void Setup()
        {
            _addressRepository = new Mock<IAddressRepository>();
            _userAccountService = new Mock<IUserAccountService>();
            _mapper = new Mock<IMapper>();
        }

        [Test]
        public async Task AddAddress_Success()
        {
            _addressRepository.Setup(a => a.AddAddress(It.IsAny<string>(), It.IsAny<long>()))
                .Returns(Task.CompletedTask);

            var addressService = new AddressService(_addressRepository.Object, _userAccountService.Object, _mapper.Object);

            await addressService.AddAddress("123 A St CityTown State 99999", 1);

            _addressRepository.Verify(a => a.AddAddress(It.IsAny<string>(), It.IsAny<long>()), Times.Once);
        }

        [Test]
        public void AddAddress_AddressEmpty()
        {
            _addressRepository.Setup(a => a.AddAddress(It.IsAny<string>(), It.IsAny<long>()))
                .Returns(Task.CompletedTask);

            var addressService = new AddressService(_addressRepository.Object, _userAccountService.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => addressService.AddAddress("", 1));
        }

        [Test]
        public void AddAddress_AddressNull()
        {
            _addressRepository.Setup(a => a.AddAddress(It.IsAny<string>(), It.IsAny<long>()))
                .Returns(Task.CompletedTask);

            var addressService = new AddressService(_addressRepository.Object, _userAccountService.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => addressService.AddAddress(null, 1));
        }

        [Test]
        public async Task GetAddressesByAccountId_Success()
        {
            _addressRepository.Setup(a => a.GetAddressesByAccountId(It.IsAny<long>()))
                .ReturnsAsync(new List<DbAddress>());

            _userAccountService.Setup(a => a.GetAccountByAccountId(It.IsAny<long>(), It.IsAny<string>()))
                .ReturnsAsync(new Account());

            var addressService = new AddressService(_addressRepository.Object, _userAccountService.Object, _mapper.Object);

            await addressService.GetAddressesByAccountId(1, It.IsAny<string>());

            _addressRepository.Verify(a => a.GetAddressesByAccountId(It.IsAny<long>()), Times.Once);
        }

        [Test]
        public void GetAddressesByAccountId_Fail()
        {
            _addressRepository.Setup(a => a.GetAddressesByAccountId(It.IsAny<long>()))
                .ThrowsAsync(new ArgumentException());

            var addressService = new AddressService(_addressRepository.Object, _userAccountService.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => addressService.GetAddressesByAccountId(1, It.IsAny<string>()));
        }

        [Test]
        public async Task GetAddressByAddressId_Success()
        {
            _addressRepository.Setup(a => a.GetAddressByAddressId(It.IsAny<long>()))
                .ReturnsAsync(new DbAddress());

            var addressService = new AddressService(_addressRepository.Object, _userAccountService.Object, _mapper.Object);

            await addressService.GetAddressByAddressId(1, "SecretKey6196BRuan");

            _addressRepository.Verify(a => a.GetAddressByAddressId(It.IsAny<long>()), Times.Once);
        }

        [Test]
        public void GetAddressByAddressId_Fail()
        {
            _addressRepository.Setup(a => a.GetAddressByAddressId(It.IsAny<long>()))
                .ThrowsAsync(new ArgumentException());

            var addressService = new AddressService(_addressRepository.Object, _userAccountService.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => addressService.GetAddressByAddressId(1, "SecretKey6196BRuan"));
        }

        [Test]
        public async Task UpdateAddress_Success()
        {
            _addressRepository.Setup(a => a.UpdateAddress(It.IsAny<long>(), It.IsAny<string>()))
                .Returns(Task.CompletedTask);

            var addressService = new AddressService(_addressRepository.Object, _userAccountService.Object, _mapper.Object);

            await addressService.UpdateAddress(1, "123 new Address");

            _addressRepository.Verify(a => a.UpdateAddress(It.IsAny<long>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void UpdateAddress_InternalServerError()
        {
            _addressRepository.Setup(a => a.UpdateAddress(It.IsAny<long>(), It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException());

            var addressService = new AddressService(_addressRepository.Object, _userAccountService.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => addressService.UpdateAddress(1, It.IsAny<string>()));
        }

        [Test]
        public async Task DeleteAddress_Success()
        {
            _addressRepository.Setup(a => a.DeleteAddress(It.IsAny<long>()))
                .Returns(Task.CompletedTask);

            var addressService = new AddressService(_addressRepository.Object, _userAccountService.Object, _mapper.Object);

            await addressService.DeleteAddress(1);

            _addressRepository.Verify(a => a.DeleteAddress(It.IsAny<long>()), Times.Once);
        }

        [Test]
        public void DeleteAddress_InternalServerError()
        {
            _addressRepository.Setup(a => a.DeleteAddress(It.IsAny<long>()))
                .ThrowsAsync(new ArgumentException());

            var addressService = new AddressService(_addressRepository.Object, _userAccountService.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => addressService.DeleteAddress(1));
        }
    }
}
