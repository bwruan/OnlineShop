using Account.API.Controllers;
using Account.API.Models;
using Account.Domain.Models;
using Account.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Test.Controller
{
    [TestFixture]
    public class UserAccountControllerTest
    {
        private Mock<IUserAccountService> _userAccountService;
        private Mock<IConfiguration> _configuration;

        [SetUp]
        public void Setup()
        {
            _userAccountService = new Mock<IUserAccountService>();
            _configuration = new Mock<IConfiguration>();

            _configuration.Setup(g => g.GetSection(It.Is<string>(s => s.Equals("Jwt:Key"))).Value)
                .Returns("SecretKey6196BRuan");
            _configuration.Setup(g => g.GetSection(It.Is<string>(s => s.Equals("Jwt:Issuer"))).Value)
                .Returns("test.com");
        }

        [Test]
        public async Task AddAccount_Success()
        {
            _userAccountService.Setup(a => a.AddAccount(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.CompletedTask);

            var controller = new UserAccountController(_userAccountService.Object, _configuration.Object);

            var response = await controller.AddAccount(new AddAccountRequest()
            {
                Name = "name",
                Email = "email@email.com",
                Password = "password123"
            });

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(OkResult));

            var ok = (OkResult)response;

            Assert.AreEqual(ok.StatusCode, 200);
        }

        [Test]
        public async Task AddAccount_InternalServerError()
        {
            _userAccountService.Setup(a => a.AddAccount(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception());

            var controller = new UserAccountController(_userAccountService.Object, _configuration.Object);

            var response = await controller.AddAccount(new AddAccountRequest()
            {
                Name = "name",
                Email = "email@email.com",
                Password = "password123"
            });

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }

        [Test]
        public async Task GetAccountById_Success()
        {
            _userAccountService.Setup(a => a.GetAccountById(It.IsAny<long>()))
                .ReturnsAsync(new UserAccount());

            var controller = new UserAccountController(_userAccountService.Object, _configuration.Object);

            var response = await controller.GetAccountById(1);

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(OkObjectResult));

            var okObj = (OkObjectResult)response;

            Assert.AreEqual(okObj.StatusCode, 200);
        }

        [Test]
        public async Task GetAccountById_InternalServerError()
        {
            _userAccountService.Setup(a => a.GetAccountById(It.IsAny<long>()))
                .ThrowsAsync(new Exception());

            var controller = new UserAccountController(_userAccountService.Object, _configuration.Object);

            var response = await controller.GetAccountById(1);

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }

        [Test]
        public async Task GetAccountByEmail_Success()
        {
            _userAccountService.Setup(a => a.GetAccountByEmail(It.IsAny<string>()))
                .ReturnsAsync(new UserAccount());

            var controller = new UserAccountController(_userAccountService.Object, _configuration.Object);

            var response = await controller.GetAccountByEmail("test@gmail.com");

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(OkObjectResult));

            var okObj = (OkObjectResult)response;

            Assert.AreEqual(okObj.StatusCode, 200);
        }

        [Test]
        public async Task GetAccountByEmail_InternalServerError()
        {
            _userAccountService.Setup(a => a.GetAccountByEmail(It.IsAny<string>()))
                .ThrowsAsync(new Exception());

            var controller = new UserAccountController(_userAccountService.Object, _configuration.Object);

            var response = await controller.GetAccountByEmail("test@gmail.com");

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }

        [Test]
        public async Task UpdateAccount_Success()
        {
            _userAccountService.Setup(a => a.UpdateAccount(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.CompletedTask);

            var controller = new UserAccountController(_userAccountService.Object, _configuration.Object);

            var response = await controller.UpdateAccount(new UpdateAccountRequest()
            {
                AccountId = 1,
                NewName = "test",
                NewEmail = "test@gmail.com",
                NewPassword = "test1234"
            });

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(OkResult));

            var ok = (OkResult)response;

            Assert.AreEqual(ok.StatusCode, 200);
        }

        [Test]
        public async Task UpdateAccount_InternalServerError()
        {
            _userAccountService.Setup(a => a.UpdateAccount(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception());

            var controller = new UserAccountController(_userAccountService.Object, _configuration.Object);

            var response = await controller.UpdateAccount(new UpdateAccountRequest()
            {
                AccountId = 1,
                NewName = "test",
                NewEmail = "test@gmail.com",
                NewPassword = "test1234"
            });

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }

        [Test]
        public async Task LogIn_Success()
        {
            _userAccountService.Setup(a => a.LogIn(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(1);

            var controller = new UserAccountController(_userAccountService.Object, _configuration.Object);

            var response = await controller.LogIn(new LoginRequest()
            {
                Email = "email@email.com",
                Password = "password123"
            });

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(OkObjectResult));

            var ok = (OkObjectResult)response;

            Assert.AreEqual(ok.StatusCode, 200);
        }

        [Test]
        public async Task LogIn_InternalServerError()
        {
            _userAccountService.Setup(a => a.LogIn(It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception());

            var controller = new UserAccountController(_userAccountService.Object, _configuration.Object);

            var response = await controller.LogIn(new LoginRequest()
            {
                Email = "email@email.com",
                Password = "password123"
            });

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }

        [Test]
        public async Task LogOut_Success()
        {
            _userAccountService.Setup(a => a.LogOut(It.IsAny<long>()))
                .Returns(Task.CompletedTask);

            var controller = new UserAccountController(_userAccountService.Object, _configuration.Object);

            var response = await controller.LogOut(1);

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(OkResult));

            var ok = (OkResult)response;

            Assert.AreEqual(ok.StatusCode, 200);
        }

        [Test]
        public async Task LogOut_InternalServerError()
        {
            _userAccountService.Setup(a => a.LogOut(It.IsAny<long>()))
                .ThrowsAsync(new Exception());

            var controller = new UserAccountController(_userAccountService.Object, _configuration.Object);

            var response = await controller.LogOut(1);

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }
    }
}
