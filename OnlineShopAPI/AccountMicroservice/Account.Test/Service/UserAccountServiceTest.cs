using Account.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Test.Service
{
    [TestFixture]
    public class UserAccountServiceTest
    {
        private Mock<IUserAccountRepository> _userAccountRepository;

        [SetUp]
        public void Setup()
        {
            _userAccountRepository = new Mock<IUserAccountRepository>();
        }
    }
}
