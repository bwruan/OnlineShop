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
    public class OrderControllerTest
    {
        private Mock<IOrderService> _orderService;

        [SetUp]
        public void Setup()
        {
            _orderService = new Mock<IOrderService>();
        }

        [Test]
        public async Task GetOrdersByAccountId_Success()
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers["Authorization"] = "Bearer testtoken";

            _orderService.Setup(o => o.GetOrdersByAccountId(It.IsAny<long>(), It.IsAny<string>()))
                .ReturnsAsync(new List<Order>());

            var controller = new OrderController(_orderService.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };

            var response = await controller.GetOrdersByAccountId(1);

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(OkObjectResult));

            var okObj = (OkObjectResult)response;

            Assert.AreEqual(okObj.StatusCode, 200);
        }

        [Test]
        public async Task GetOrdersByAccountId_InternalServerError()
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers["Authorization"] = "Bearer testtoken";

            _orderService.Setup(o => o.GetOrdersByAccountId(It.IsAny<long>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception());

            var controller = new OrderController(_orderService.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };

            var response = await controller.GetOrdersByAccountId(1);

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }

        [Test]
        public async Task GetOrdersByOrderNum_Sucess()
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers["Authorization"] = "Bearer testtoken";

            _orderService.Setup(o => o.GetOrdersByOrderNum(It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync(new List<Order>());

            var controller = new OrderController(_orderService.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };

            var response = await controller.GetOrdersByOrderNum(12345);

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(OkObjectResult));

            var okObj = (OkObjectResult)response;

            Assert.AreEqual(okObj.StatusCode, 200);
        }

        [Test]
        public async Task GetOrdersByOrderNum_InternalServerError()
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers["Authorization"] = "Bearer testtoken";

            _orderService.Setup(o => o.GetOrdersByOrderNum(It.IsAny<int>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception());

            var controller = new OrderController(_orderService.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };

            var response = await controller.GetOrdersByOrderNum(12345);

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }

        [Test]
        public async Task PurchaseOrder_Success()
        {
            _orderService.Setup(o => o.PurchaseOrder(It.IsAny<long>(), It.IsAny<string>()))
                .Returns(Task.CompletedTask);

            var controller = new OrderController(_orderService.Object);

            var response = await controller.PurchaseOrder(new PurchaseOrderRequest()
            {
                AccountId = 1
            });

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(StatusCodeResult));

            var result = (StatusCodeResult)response;

            Assert.AreEqual(result.StatusCode, 201);
        }

        [Test]
        public async Task PurchaseOrder_InternalServerError()
        {
            _orderService.Setup(o => o.PurchaseOrder(It.IsAny<long>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception());

            var controller = new OrderController(_orderService.Object);

            var response = await controller.PurchaseOrder(new PurchaseOrderRequest()
            {
                AccountId = 1
            });

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }
    }
}
