using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Shopping.Api.Controller;
using Shopping.Api.Models;
using Shopping.Domain.Models;
using Shopping.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Test.Controller
{
    [TestFixture]
    public class CartControllerTest
    {
        private Mock<ICartService> _cartService;

        [SetUp]
        public void Setup()
        {
            _cartService = new Mock<ICartService>();
        }

        [Test]
        public async Task AddToCart_Success()
        {
            _cartService.Setup(c => c.AddToCart(It.IsAny<long>(), It.IsAny<int>()))
                .Returns(Task.CompletedTask);

            var controller = new CartController(_cartService.Object);

            var response = await controller.AddToCart(new AddToCartRequest()
            {
                ItemId = 1,
                Amount = 1
            });

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(StatusCodeResult));

            var result = (StatusCodeResult)response;

            Assert.AreEqual(result.StatusCode, 201);
        }

        [Test]
        public async Task AddToCart_InternalServerErrpr()
        {
            _cartService.Setup(c => c.AddToCart(It.IsAny<long>(), It.IsAny<int>()))
                .ThrowsAsync(new Exception());

            var controller = new CartController(_cartService.Object);

            var response = await controller.AddToCart(new AddToCartRequest()
            {
                ItemId = 1,
                Amount = 1
            });

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }

        [Test]
        public async Task GetItemsInCart_Success()
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers["Authorization"] = "Bearer testtoken";

            _cartService.Setup(c => c.GetItemsInCart(It.IsAny<string>()))
                .ReturnsAsync(new List<Cart>());

            var controller = new CartController(_cartService.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };

            var response = await controller.GetItemsInCart();

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(OkObjectResult));

            var okObj = (OkObjectResult)response;

            Assert.AreEqual(okObj.StatusCode, 200);
        }

        [Test]
        public async Task GetItemsInCart_InternalServerError()
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers["Authorization"] = "Bearer testtoken";

            _cartService.Setup(c => c.GetItemsInCart(It.IsAny<string>()))
                .ThrowsAsync(new Exception());

            var controller = new CartController(_cartService.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };

            var response = await controller.GetItemsInCart();

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }

        [Test]
        public async Task PurchaseRemove_Success()
        {
            _cartService.Setup(c => c.PurchaseRemove())
                .Returns(Task.CompletedTask);

            var controller = new CartController(_cartService.Object);

            var response = await controller.PurchaseRemove();

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(OkResult));

            var ok = (OkResult)response;

            Assert.AreEqual(ok.StatusCode, 200);
        }

        [Test]
        public async Task PurchaseRemove_InternalServerError()
        {
            _cartService.Setup(c => c.PurchaseRemove())
                .ThrowsAsync(new Exception());

            var controller = new CartController(_cartService.Object);

            var response = await controller.PurchaseRemove();

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }
    }
}
