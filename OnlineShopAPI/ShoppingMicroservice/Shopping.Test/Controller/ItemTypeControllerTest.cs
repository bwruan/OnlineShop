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
    public class ItemTypeControllerTest
    {
        private Mock<IItemTypeService> _itemTypeService;

        [SetUp]
        public void Setup()
        {
            _itemTypeService = new Mock<IItemTypeService>();
        }

        [Test]
        public async Task GetItemType_Success()
        {
            _itemTypeService.Setup(i => i.GetItemType())
                .ReturnsAsync(new List<ItemType>());

            var controller = new ItemTypeController(_itemTypeService.Object);

            var response = await controller.GetItemType();

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(OkObjectResult));

            var okObj = (OkObjectResult)response;

            Assert.AreEqual(okObj.StatusCode, 200);
        }

        [Test]
        public async Task GetItemType_InternalServerError()
        {
            _itemTypeService.Setup(i => i.GetItemType())
                .ThrowsAsync(new Exception());

            var controller = new ItemTypeController(_itemTypeService.Object);

            var response = await controller.GetItemType();

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }
    }
}
