using AutoMapper;
using Moq;
using NUnit.Framework;
using Shopping.Domain.Service;
using Shopping.Infrastructure.Repository;
using Shopping.Infrastructure.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Test.Service
{
    [TestFixture]
    public class CartServiceTest
    {
        private Mock<ICartRepository> _cartRepository;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void Setup()
        {
            _cartRepository = new Mock<ICartRepository>();
            _mapper = new Mock<IMapper>();
        }

        [Test]
        public async Task AddToCart_Success()
        {
            _cartRepository.Setup(c => c.AddToCart(It.IsAny<long>(), It.IsAny<long>(), It.IsAny<int>()))
                .Returns(Task.CompletedTask);

            var cartService = new CartService(_cartRepository.Object, _mapper.Object);

            await cartService.AddToCart(1,1, 1);

            _cartRepository.Verify(c => c.AddToCart(It.IsAny<long>(), It.IsAny<long>(), It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void AddToCart_Fail()
        {
            _cartRepository.Setup(c => c.AddToCart(It.IsAny<long>(), It.IsAny<long>(), It.IsAny<int>()))
                .ThrowsAsync(new Exception());

            var cartService = new CartService(_cartRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<ArgumentException>(() => cartService.AddToCart(0, 0, 0));
        }

        [Test]
        public async Task GetItemsInCart_Success()
        {
            _cartRepository.Setup(c => c.GetItemsInCartByAccountId(It.IsAny<long>()))
                .ReturnsAsync(new List<Cart>());

            var cartService = new CartService(_cartRepository.Object, _mapper.Object);

            await cartService.GetItemsInCartByAccountId(1, "SecretKey6196BRuan");

            _cartRepository.Verify(c => c.GetItemsInCartByAccountId(It.IsAny<long>()), Times.Once);
        }

        [Test]
        public void GetItemsInCart_Fail()
        {
            _cartRepository.Setup(c => c.GetItemsInCartByAccountId(It.IsAny<long>()))
                .ThrowsAsync(new Exception());

            var cartService = new CartService(_cartRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<Exception>(() => cartService.GetItemsInCartByAccountId(0, "SecretKey6196BRuan"));
        }

        [Test]
        public async Task PurchaseRemove_Success()
        {
            _cartRepository.Setup(c => c.PurchaseRemove())
                .Returns(Task.CompletedTask);

            var cartService = new CartService(_cartRepository.Object, _mapper.Object);

            await cartService.PurchaseRemove();

            _cartRepository.Verify(c => c.PurchaseRemove(), Times.Once);
        }

        [Test]
        public void PurchaseRemove_Fail()
        {
            _cartRepository.Setup(c => c.PurchaseRemove())
                .ThrowsAsync(new Exception());

            var cartService = new CartService(_cartRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<Exception>(() => cartService.PurchaseRemove());
        }
    }
}
