using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PaymentInfo.Api.Controllers;
using PaymentInfo.Api.Models;
using PaymentInfo.Domain.Models;
using PaymentInfo.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentInfo.Test.Controller
{
    [TestFixture]
    public class PaymentControllerTest
    {
        private Mock<IPaymentService> _paymentService;

        [SetUp]
        public void Setup()
        {
            _paymentService = new Mock<IPaymentService>();
        }

        [Test]
        public async Task AddPayment_Success()
        {
            _paymentService.Setup(p => p.AddPayment(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>(), It.IsAny<long>(), It.IsAny<string>()))
                .Returns(Task.CompletedTask);

            var controller = new PaymentController(_paymentService.Object);

            var response = await controller.AddPayment(new AddPaymentRequest()
            {
                NameOnCard = "Test User",
                CardNumber = "1234567898765432",
                SecurityCode = "123",
                ExpDate = "10/2023",
                CardTypeId = 1,
                AccountId = 1
            });

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(StatusCodeResult));

            var result = (StatusCodeResult)response;

            Assert.AreEqual(result.StatusCode, 201);
        }

        [Test]
        public async Task AddPayment_InternalServerError()
        {
            _paymentService.Setup(p => p.AddPayment(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>(), It.IsAny<long>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception());

            var controller = new PaymentController(_paymentService.Object);

            var response = await controller.AddPayment(new AddPaymentRequest()
            {
                NameOnCard = "Test User",
                CardNumber = "1234567898765432",
                SecurityCode = "123",
                ExpDate = "10/2023",
                CardTypeId = 1,
                AccountId = 1
            });

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }

        [Test]
        public async Task GetPaymentByPaymentId_Success()
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers["Authorization"] = "Bearer testtoken";

            _paymentService.Setup(p => p.GetPaymentByPaymentId(It.IsAny<long>(), It.IsAny<string>()))
                .ReturnsAsync(new Payment());

            var controller = new PaymentController(_paymentService.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };

            var response = await controller.GetPaymentByPaymentId(1);

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(OkObjectResult));

            var okObj = (OkObjectResult)response;

            Assert.AreEqual(okObj.StatusCode, 200);
        }

        [Test]
        public async Task GetPaymentByPaymentId_InternalServerError()
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers["Authorization"] = "Bearer testtoken";

            _paymentService.Setup(p => p.GetPaymentByPaymentId(It.IsAny<long>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception());

            var controller = new PaymentController(_paymentService.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };

            var response = await controller.GetPaymentByPaymentId(1);

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }

        [Test]
        public async Task GetPaymentsByAccountId_Success()
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers["Authorization"] = "Bearer testtoken";

            _paymentService.Setup(p => p.GetPaymentsByAccountId(It.IsAny<long>(), It.IsAny<string>()))
                .ReturnsAsync(new List<Payment>());

            var controller = new PaymentController(_paymentService.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };

            var response = await controller.GetPaymentsByAccountId(1);

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(OkObjectResult));

            var okObj = (OkObjectResult)response;

            Assert.AreEqual(okObj.StatusCode, 200);
        }

        [Test]
        public async Task GetPaymentsByAccountId_InternalServerError()
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers["Authorization"] = "Bearer testtoken";

            _paymentService.Setup(p => p.GetPaymentsByAccountId(It.IsAny<long>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception());

            var controller = new PaymentController(_paymentService.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };

            var response = await controller.GetPaymentsByAccountId(1);

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }

        [Test]
        public async Task UpdatePayment_Success()
        {
            _paymentService.Setup(p => p.UpdatePayment(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>()))
                .Returns(Task.CompletedTask);

            var controller = new PaymentController(_paymentService.Object);

            var response = await controller.UpdatePayment(new UpdatePaymentRequest()
            {
                PaymentId = 1,
                NewNameOnCard = "Test User",
                NewCardNumber = "1234567898765432",
                NewSecurityCode = "123",
                NewExpDate = "10/2023",
                NewCardTypeId = 1
            });

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(OkResult));

            var ok = (OkResult)response;

            Assert.AreEqual(ok.StatusCode, 200);
        }

        [Test]
        public async Task UpdatePayment_InternalServerError()
        {
            _paymentService.Setup(p => p.UpdatePayment(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>()))
                .ThrowsAsync(new Exception());

            var controller = new PaymentController(_paymentService.Object);

            var response = await controller.UpdatePayment(new UpdatePaymentRequest()
            {
                PaymentId = 1,
                NewNameOnCard = "Test User",
                NewCardNumber = "1234567898765432",
                NewSecurityCode = "123",
                NewExpDate = "10/2023",
                NewCardTypeId = 1
            });

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }
        
        [Test]
        public async Task DeletePayment_Success()
        {
            _paymentService.Setup(p => p.DeletePayment(It.IsAny<long>()))
                .Returns(Task.CompletedTask);

            var controller = new PaymentController(_paymentService.Object);

            var response = await controller.DeletePayment(1);

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(OkResult));

            var ok = (OkResult)response;

            Assert.AreEqual(ok.StatusCode, 200);
        }

        [Test]
        public async Task DeletePayment_InternalServerError()
        {
            _paymentService.Setup(p => p.DeletePayment(It.IsAny<long>()))
                .ThrowsAsync(new Exception());

            var controller = new PaymentController(_paymentService.Object);

            var response = await controller.DeletePayment(1);

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }
    }
}
