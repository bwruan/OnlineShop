using Account.Domain.Services;
using Account.Infrastructure.Repositories;
using Account.Infrastructure.Repositories.Entities;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Test.Service
{
    [TestFixture]
    public class UserAccountServiceTest
    {
        private Mock<IUserAccountRepository> _userAccountRepository;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void Setup()
        {
            _userAccountRepository = new Mock<IUserAccountRepository>();
            _mapper = new Mock<IMapper>();
        }

        [Test]

        public async Task AddAccount_Success()
        {
            _userAccountRepository.Setup(a => a.AddAccount(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.CompletedTask);

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            await userAccountService.AddAccount("test", "test@gmail.com", "test1234");

            _userAccountRepository.Verify(a => a.AddAccount(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void AddAccount_NameEmpty()
        {
            _userAccountRepository.Setup(a => a.AddAccount(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException());

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => userAccountService.AddAccount("", "test@gmail.com", "test1234"));
        }

        [Test]
        public void AddAccount_NameNull()
        {
            _userAccountRepository.Setup(a => a.AddAccount(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException());

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => userAccountService.AddAccount(null, "test@gmail.com", "test1234"));
        }

        [Test]
        public void AddAccount_EmailEmpty()
        {
            _userAccountRepository.Setup(a => a.AddAccount(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException());

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => userAccountService.AddAccount("test", "", "test1234"));
        }

        [Test]
        public void AddAccount_EmailNull()
        {
            _userAccountRepository.Setup(a => a.AddAccount(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException());

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => userAccountService.AddAccount("test", null, "test1234"));
        }

        [Test]
        public void AddAccount_PassWordEmpty()
        {
            _userAccountRepository.Setup(a => a.AddAccount(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException());

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => userAccountService.AddAccount("test", "test@gmail.com", ""));
        }

        [Test]
        public void AddAccount_PassWordNull()
        {
            _userAccountRepository.Setup(a => a.AddAccount(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException());

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => userAccountService.AddAccount("test", "test@gmail.com", null));
        }

        [Test]
        public void AddAccount_PassWordLessThanMinLength()
        {
            _userAccountRepository.Setup(a => a.AddAccount(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException());

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => userAccountService.AddAccount("test", "test@gmail.com", "test"));
        }

        [Test]
        public void AddAccount_PassWordGreaterThanMaxLength()
        {
            _userAccountRepository.Setup(a => a.AddAccount(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException());

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => userAccountService.AddAccount("test", "test@gmail.com", "test12345678901234567890123456789"));
        }

        [Test]
        public void GetAccountById_AccountDoesNotExist()
        {
            _userAccountRepository.Setup(a => a.GetAccountById(It.IsAny<long>()))
                .ThrowsAsync(new ArgumentException());

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => userAccountService.GetAccountById(1));
        }

        [Test]
        public async Task GetAccountById_Success()
        {
            _userAccountRepository.Setup(a => a.GetAccountById(It.IsAny<long>()))
                .ReturnsAsync(new UserAccount());

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            await userAccountService.GetAccountById(1);

            _userAccountRepository.Verify(a => a.GetAccountById(It.IsAny<long>()), Times.Once);
        }

        [Test]
        public void GetAccountByEmail_AccountDoesNotExist()
        {
            _userAccountRepository.Setup(a => a.GetAccountByEmail(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException());

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => userAccountService.GetAccountByEmail("test@gmail.com"));
        }

        [Test]
        public async Task GetAccountByEmail_Success()
        {
            _userAccountRepository.Setup(a => a.GetAccountByEmail(It.IsAny<string>()))
                .ReturnsAsync(new UserAccount());

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            await userAccountService.GetAccountByEmail("test@gmail.com");

            _userAccountRepository.Verify(a => a.GetAccountByEmail(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task UpdateAccount_Success()
        {
            _userAccountRepository.Setup(a => a.GetAccountById(It.IsAny<long>()))
                .ReturnsAsync(new UserAccount());

            _userAccountRepository.Setup(a => a.UpdateAccount(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.CompletedTask);

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            await userAccountService.UpdateAccount(1, "test2", "test2@gmail.com", "test12345");

            _userAccountRepository.Verify(a => a.UpdateAccount(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void UpdateAccount_NewNameEmpty()
        {
            _userAccountRepository.Setup(a => a.UpdateAccount(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException());

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => userAccountService.UpdateAccount(1, "", "test2@gmail.com", "test12345"));
        }

        [Test]
        public void UpdateAccount_NewNameNull()
        {
            _userAccountRepository.Setup(a => a.UpdateAccount(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException());

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => userAccountService.UpdateAccount(1, null, "test2@gmail.com", "test12345"));
        }

        [Test]
        public void UpdateAccount_NewEmailEmpty()
        {
            _userAccountRepository.Setup(a => a.UpdateAccount(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException());

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => userAccountService.UpdateAccount(1, "test2", "", "test12345"));
        }

        [Test]
        public void UpdateAccount_NewEmailNull()
        {
            _userAccountRepository.Setup(a => a.UpdateAccount(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException());

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => userAccountService.UpdateAccount(1, "test2", null, "test12345"));
        }

        [Test]
        public void UpdateAccount_NewPasswordEmpty()
        {
            _userAccountRepository.Setup(a => a.UpdateAccount(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException());

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => userAccountService.UpdateAccount(1, "test2", "test2@gmail.com", ""));
        }

        [Test]
        public void UpdateAccount_NewPasswordNull()
        {
            _userAccountRepository.Setup(a => a.UpdateAccount(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException());

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => userAccountService.UpdateAccount(1, "test2", "test2@gmail.com", null));
        }

        [Test]
        public void UpdateAccount_NewPasswordLessThanMinLength()
        {
            _userAccountRepository.Setup(a => a.UpdateAccount(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException());

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => userAccountService.UpdateAccount(1, "test2", "test2@gmail.com", "test"));
        }

        [Test]
        public void UpdateAccount_NewPasswordGreaterThanMaxLength()
        {
            _userAccountRepository.Setup(a => a.UpdateAccount(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException());

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => userAccountService.UpdateAccount(1, "test2", "test2@gmail.com", "test12345678901234567890123456789"));
        }

        [Test]
        public async Task LogIn_Success()
        {
            _userAccountRepository.Setup(a => a.GetAccountByEmail(It.IsAny<string>()))
                .ReturnsAsync(new UserAccount());

            _userAccountRepository.Setup(a => a.UpdateStatus(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(Task.CompletedTask);

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            await userAccountService.LogIn("test@gmail.com", "test1234");

            _userAccountRepository.Verify(a => a.UpdateStatus(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>()), Times.Once);
        }

        [Test]
        public void LogIn_Fail()
        {
            _userAccountRepository.Setup(a => a.GetAccountByEmail(It.IsAny<string>()))
                .ReturnsAsync(new UserAccount() { Status = true });

            _userAccountRepository.Setup(a => a.UpdateStatus(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(Task.CompletedTask);

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => userAccountService.LogIn("test@gmail.com", "test1234"));
        }

        [Test]
        public async Task LogOut_Success()
        {
            _userAccountRepository.Setup(a => a.GetAccountById(It.IsAny<long>()))
                .ReturnsAsync(new UserAccount() { Status = true });

            _userAccountRepository.Setup(a => a.UpdateStatus(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(Task.CompletedTask);

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            await userAccountService.LogOut(1);

            _userAccountRepository.Verify(a => a.UpdateStatus(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>()), Times.Once);
        }

        [Test]
        public void LogOut_Fail()
        {
            _userAccountRepository.Setup(a => a.GetAccountById(It.IsAny<long>()))
                .ReturnsAsync(new UserAccount());

            _userAccountRepository.Setup(a => a.UpdateStatus(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(Task.CompletedTask);

            var userAccountService = new UserAccountService(_userAccountRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => userAccountService.LogOut(1));
        }
    }
}
