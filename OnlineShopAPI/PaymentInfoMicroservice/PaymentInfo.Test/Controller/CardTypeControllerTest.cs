using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PaymentInfo.Api.Controllers;
using PaymentInfo.Domain.Models;
using PaymentInfo.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentInfo.Test.Controller
{
    [TestFixture]
    public class CardTypeControllerTest
    {
        private Mock<ICardTypeService> _cardTypeService;

        [SetUp]
        public void Setup()
        {
            _cardTypeService = new Mock<ICardTypeService>();
        }

        [Test]
        public async Task GetCardTypes_Success()
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers["Authorization"] = "Bearer testtoken";

            _cardTypeService.Setup(c => c.GetCardTypes())
                .ReturnsAsync(new List<CardType>());

            var controller = new CardTypeController(_cardTypeService.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };

            var response = await controller.GetCardTypes();

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(OkObjectResult));

            var okObj = (OkObjectResult)response;

            Assert.AreEqual(okObj.StatusCode, 200);
        }

        [Test]
        public async Task GetCardTypes_InternalServerError()
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers["Authorization"] = "Bearer testtoken";

            _cardTypeService.Setup(c => c.GetCardTypes())
                .ThrowsAsync(new Exception());

            var controller = new CardTypeController(_cardTypeService.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };

            var response = await controller.GetCardTypes();

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }
    }
}
