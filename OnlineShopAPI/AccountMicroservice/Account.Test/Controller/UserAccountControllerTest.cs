using Account.Domain.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
