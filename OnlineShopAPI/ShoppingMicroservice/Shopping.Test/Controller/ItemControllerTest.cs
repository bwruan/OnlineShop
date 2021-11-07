using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Shopping.Api.Controller;
using Shopping.Domain.Models;
using Shopping.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Test.Controller
{
    [TestFixture]
    public class ItemControllerTest
    {
        private Mock<IItemService> _itemService;

        [SetUp]
        public void Setup()
        {
            _itemService = new Mock<IItemService>();
        }

        [Test]
        public async Task GetAllItems_Success()
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers["Authorization"] = "Bearer testtoken";

            _itemService.Setup(i => i.GetAllItems(It.IsAny<string>()))
                .ReturnsAsync(new List<Item>());

            var controller = new ItemController(_itemService.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };

            var response = await controller.GetAllItems();

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(OkObjectResult));

            var okObj = (OkObjectResult)response;

            Assert.AreEqual(okObj.StatusCode, 200);
        }

        [Test]
        public async Task GetAllItems_InternalServerError()
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers["Authorization"] = "Bearer testtoken";

            _itemService.Setup(i => i.GetAllItems(It.IsAny<string>()))
                .ThrowsAsync(new Exception());

            var controller = new ItemController(_itemService.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };

            var response = await controller.GetAllItems();

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }

        [Test]
        public async Task GetItemByItemId_Success()
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers["Authorization"] = "Bearer testtoken";

            _itemService.Setup(i => i.GetItemByItemId(It.IsAny<long>(), It.IsAny<string>()))
                .ReturnsAsync(new Item());

            var controller = new ItemController(_itemService.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };

            var response = await controller.GetItemByItemId(1);

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(OkObjectResult));

            var okObj = (OkObjectResult)response;

            Assert.AreEqual(okObj.StatusCode, 200);
        }

        [Test]
        public async Task GetItemByItemId_InternalServerError()
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers["Authorization"] = "Bearer testtoken";

            _itemService.Setup(i => i.GetItemByItemId(It.IsAny<long>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception());

            var controller = new ItemController(_itemService.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };

            var response = await controller.GetItemByItemId(1);

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }

        [Test]
        public async Task GetItemsByItemType_Success()
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers["Authorization"] = "Bearer testtoken";

            _itemService.Setup(i => i.GetItemsByItemType(It.IsAny<long>(), It.IsAny<string>()))
                .ReturnsAsync(new List<Item>());

            var controller = new ItemController(_itemService.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };

            var response = await controller.GetItemsByItemType(1);

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(OkObjectResult));

            var okObj = (OkObjectResult)response;

            Assert.AreEqual(okObj.StatusCode, 200);
        }

        [Test]
        public async Task GetItemsByItemType_InternalServerError()
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers["Authorization"] = "Bearer testtoken";

            _itemService.Setup(i => i.GetItemsByItemType(It.IsAny<long>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception());

            var controller = new ItemController(_itemService.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };

            var response = await controller.GetItemsByItemType(1);

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }
    }
}
