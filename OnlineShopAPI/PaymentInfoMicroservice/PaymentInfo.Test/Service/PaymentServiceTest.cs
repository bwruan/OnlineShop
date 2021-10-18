using AutoMapper;
using Moq;
using NUnit.Framework;
using PaymentInfo.Domain.Services;
using PaymentInfo.Infrastructure.AccountService;
using PaymentInfo.Infrastructure.AccountService.Model;
using PaymentInfo.Infrastructure.Repositories;
using PaymentInfo.Infrastructure.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentInfo.Test.Service
{
    [TestFixture]
    public class PaymentServiceTest
    {
        private Mock<IPaymentRepository> _paymentRepository;
        private Mock<IUserAccountService> _userAccountService;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void Setup()
        {
            _paymentRepository = new Mock<IPaymentRepository>();
            _userAccountService = new Mock<IUserAccountService>();
            _mapper = new Mock<IMapper>();
        }

        [Test]
        public async Task AddPayment_Success()
        {
            _paymentRepository.Setup(p => p.AddPayment(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<string>(),
                 It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>(), It.IsAny<long>()))
                .Returns(Task.CompletedTask);

            var paymentService = new PaymentService(_paymentRepository.Object, _userAccountService.Object, _mapper.Object);

            await paymentService.AddPayment("Test User", "1234567898765432", "123", DateTime.Parse("10/2023"), "Test User", "123 A St",
                "CityTown", "AA", "99999", 1, 1);

            _paymentRepository.Verify(p => p.AddPayment(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<string>(),
                 It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>(), It.IsAny<long>()), Times.Once);
        }

        [Test]
        public void AddPayment_Fail()
        {
            _paymentRepository.Setup(p => p.AddPayment(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<string>(),
                 It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>(), It.IsAny<long>()))
                .ThrowsAsync(new ArgumentException());

            var paymentService = new PaymentService(_paymentRepository.Object, _userAccountService.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => paymentService.AddPayment("", "", "", DateTime.Parse("10/2023"), null, "123 A St",
                "CityTown", "AA", "99999", 1, 1));
        }

        [Test]
        public async Task GetPaymentByPaymentId_Success()
        {
            _paymentRepository.Setup(p => p.GetPaymentByPaymentId(It.IsAny<long>()))
                .ReturnsAsync(new Payment());

            var paymentService = new PaymentService(_paymentRepository.Object, _userAccountService.Object, _mapper.Object);

            await paymentService.GetPaymentByPaymentId(1, It.IsAny<string>());

            _paymentRepository.Verify(p => p.GetPaymentByPaymentId(It.IsAny<long>()), Times.Once);
        }

        [Test]
        public void GetPaymentByPaymentId_Fail()
        {
            _paymentRepository.Setup(p => p.GetPaymentByPaymentId(It.IsAny<long>()))
                .ThrowsAsync(new ArgumentException());

            var paymentService = new PaymentService(_paymentRepository.Object, _userAccountService.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => paymentService.GetPaymentByPaymentId(1, "SecretKey6196BRuan"));
        }

        [Test]
        public async Task GetPaymentsByAccountId_Success()
        {
            _paymentRepository.Setup(p => p.GetPaymentsByAccountId(It.IsAny<long>()))
                .ReturnsAsync(new List<Payment>());

            _userAccountService.Setup(a => a.GetAccountByAccountId(It.IsAny<long>(), It.IsAny<string>()))
                .ReturnsAsync(new UserAccount());

            var paymentService = new PaymentService(_paymentRepository.Object, _userAccountService.Object, _mapper.Object);

            await paymentService.GetPaymentsByAccountId(1, It.IsAny<string>());

            _paymentRepository.Verify(p => p.GetPaymentsByAccountId(It.IsAny<long>()), Times.Once);
        }

        [Test]
        public void GetPaymentsByAccountId_Fail()
        {
            _paymentRepository.Setup(p => p.GetPaymentsByAccountId(It.IsAny<long>()))
                .ThrowsAsync(new ArgumentException());

            _userAccountService.Setup(a => a.GetAccountByAccountId(It.IsAny<long>(), It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException());

            var paymentService = new PaymentService(_paymentRepository.Object, _userAccountService.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => paymentService.GetPaymentsByAccountId(1, "SecretKey6196BRuan"));
        }

        [Test]
        public async Task UpdatePayment_Success()
        {
            _paymentRepository.Setup(p => p.GetPaymentByPaymentId(It.IsAny<long>()))
                .ReturnsAsync(new Payment());

            _paymentRepository.Setup(p => p.UpdatePayment(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>()))
                .Returns(Task.CompletedTask);

            var paymentService = new PaymentService(_paymentRepository.Object, _userAccountService.Object, _mapper.Object);

            await paymentService.UpdatePayment(1, "Test User", "1234567898765432", "123", DateTime.Parse("10/2023"),
                "Test User", "123 A St", "CityTown", "AA", "99999", 1);

            _paymentRepository.Verify(p => p.UpdatePayment(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<string>(),
                 It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>()), Times.Once);
        }

        [Test]
        public void UpdatePayment_Fail()
        {
            _paymentRepository.Setup(p => p.GetPaymentByPaymentId(It.IsAny<long>()))
                .ThrowsAsync(new ArgumentException());

            _paymentRepository.Setup(p => p.UpdatePayment(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<string>(),
                 It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>()))
                .ThrowsAsync(new ArgumentException());

            var paymentService = new PaymentService(_paymentRepository.Object, _userAccountService.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => paymentService.UpdatePayment(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<string>(),
                 It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>()));
        }

        [Test]
        public async Task DeletePayment_Success()
        {
            _paymentRepository.Setup(p => p.GetPaymentByPaymentId(It.IsAny<long>()))
                .ReturnsAsync(new Payment());

            _paymentRepository.Setup(p => p.DeletePayment(It.IsAny<long>()))
                .Returns(Task.CompletedTask);

            var paymentService = new PaymentService(_paymentRepository.Object, _userAccountService.Object, _mapper.Object);

            await paymentService.DeletePayment(1);

            _paymentRepository.Verify(p => p.DeletePayment(It.IsAny<long>()), Times.Once);
        }

        [Test]
        public void DeletePayment_Fail()
        {
            _paymentRepository.Setup(p => p.GetPaymentByPaymentId(It.IsAny<long>()))
                .ThrowsAsync(new ArgumentException());

            _paymentRepository.Setup(p => p.DeletePayment(It.IsAny<long>()))
                .ThrowsAsync(new ArgumentException());

            var paymentService = new PaymentService(_paymentRepository.Object, _userAccountService.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => paymentService.DeletePayment(It.IsAny<long>()));
        }
    }
}
