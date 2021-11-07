using AutoMapper;
using Moq;
using NUnit.Framework;
using Shopping.Domain.Service;
using Shopping.Infrastructure.AccountMicroservice;
using Shopping.Infrastructure.AccountMicroservice.Model;
using Shopping.Infrastructure.Repository;
using Shopping.Infrastructure.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Test.Service
{
    [TestFixture]
    public class OrderServiceTest
    {
        private Mock<IOrdersRepository> _ordersRepository;
        private Mock<IUserAccountService> _userAccountService;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void Setup()
        {
            _ordersRepository = new Mock<IOrdersRepository>();
            _userAccountService = new Mock<IUserAccountService>();
            _mapper = new Mock<IMapper>();
        }

        [Test]
        public async Task GetOrdersByAccountId_Success()
        {
            _ordersRepository.Setup(o => o.GetOrdersByAccountId(It.IsAny<long>()))
                .ReturnsAsync(new List<Order>());

            _userAccountService.Setup(a => a.GetAccountByAccountId(It.IsAny<long>(), It.IsAny<string>()))
                .ReturnsAsync(new UserAccount());

            var orderService = new OrderService(_ordersRepository.Object, _userAccountService.Object, _mapper.Object);

            await orderService.GetOrdersByAccountId(1, "SecretKey6196BRuan");

            _ordersRepository.Verify(o => o.GetOrdersByAccountId(It.IsAny<long>()), Times.Once);
        }

        [Test]
        public void GetOrdersByAccountId_Fail()
        {
            _ordersRepository.Setup(o => o.GetOrdersByAccountId(It.IsAny<long>()))
               .ThrowsAsync(new Exception());

            _userAccountService.Setup(a => a.GetAccountByAccountId(It.IsAny<long>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception());

            var orderService = new OrderService(_ordersRepository.Object, _userAccountService.Object, _mapper.Object);

            Assert.ThrowsAsync<Exception>(() => orderService.GetOrdersByAccountId(0, "SecretKey6196BRuan"));
        }

        [Test]
        public async Task GetOrdersByOrderNum_Success()
        {
            _ordersRepository.Setup(o => o.GetOrdersByOrderNum(It.IsAny<int>()))
                .ReturnsAsync(new List<Order>());

            var orderService = new OrderService(_ordersRepository.Object, _userAccountService.Object, _mapper.Object);

            await orderService.GetOrdersByOrderNum(12345, "SecretKey6196BRuan");

            _ordersRepository.Verify(o => o.GetOrdersByOrderNum(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void GetOrdersByOrderNum_Fail()
        {
            _ordersRepository.Setup(o => o.GetOrdersByOrderNum(It.IsAny<int>()))
               .ThrowsAsync(new Exception());

            var orderService = new OrderService(_ordersRepository.Object, _userAccountService.Object, _mapper.Object);

            Assert.ThrowsAsync<Exception>(() => orderService.GetOrdersByOrderNum(0, "SecretKey6196BRuan"));
        }

        [Test]
        public async Task PurchaseOrder_Success()
        {
            _ordersRepository.Setup(o => o.PurchaseOrder(It.IsAny<long>()))
                .Returns(Task.CompletedTask);

            var orderService = new OrderService(_ordersRepository.Object, _userAccountService.Object, _mapper.Object);

            await orderService.PurchaseOrder(1);

            _ordersRepository.Verify(o => o.PurchaseOrder(It.IsAny<long>()), Times.Once);
        }

        [Test]
        public void PurchaseOrder_Fail()
        {
            _ordersRepository.Setup(o => o.PurchaseOrder(It.IsAny<long>()))
               .ThrowsAsync(new Exception());

            var orderService = new OrderService(_ordersRepository.Object, _userAccountService.Object, _mapper.Object);

            Assert.ThrowsAsync<Exception>(() => orderService.PurchaseOrder(0));
        }
    }
}
