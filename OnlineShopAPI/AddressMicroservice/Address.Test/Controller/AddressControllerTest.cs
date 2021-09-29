using Address.Api.Controller;
using Address.Api.Models;
using Address.Domain.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Address.Test.Controller
{
    [TestFixture]
    public class AddressControllerTest
    {
        private Mock<IAddressService> _addressService;
        
        [SetUp]
        public void Setup()
        {
            _addressService = new Mock<IAddressService>();
        }

        [Test]
        public async Task AddAddress_Success()
        {
            _addressService.Setup(a => a.AddAddress(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>()))
                .Returns(Task.CompletedTask);

            var controller = new AddressController(_addressService.Object);

            var response = await controller.AddAddress(new AddAddressRequest()
            {
                AccountId = 1,
                CustomerName = "Test User",
                UnitStreet = "123 A St",
                City = "CityTown",
                State = "AA",
                Zipcode = "99999"
            });

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(StatusCodeResult));

            var result = (StatusCodeResult)response;

            Assert.AreEqual(result.StatusCode, 201);
        }

        [Test]
        public async Task AddAddress_InternalServerError()
        {
            _addressService.Setup(a => a.AddAddress(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>()))
                .ThrowsAsync(new Exception());

            var controller = new AddressController(_addressService.Object);

            var response = await controller.AddAddress(new AddAddressRequest()
            {
                AccountId = 1,
                CustomerName = "Test User",
                UnitStreet = "123 A St",
                City = "CityTown",
                State = "AA",
                Zipcode = "99999"
            });

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }

        [Test]
        public async Task GetAddressesByAccountId_Success()
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers["Authorization"] = "Bearer testtoken";

            _addressService.Setup(a => a.GetAddressesByAccountId(It.IsAny<long>(), It.IsAny<string>()))
                .ReturnsAsync(new List<Domain.Models.Address>());

            var controller = new AddressController(_addressService.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };

            var response = await controller.GetAddressesByAccountId(1);

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(OkObjectResult));

            var okObj = (OkObjectResult)response;

            Assert.AreEqual(okObj.StatusCode, 200);
        }

        [Test]
        public async Task GetAddressesByAccountId_InternalServerError()
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers["Authorization"] = "Bearer testtoken";

            _addressService.Setup(a => a.GetAddressesByAccountId(It.IsAny<long>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception());

            var controller = new AddressController(_addressService.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };

            var response = await controller.GetAddressesByAccountId(1);

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }

        [Test]
        public async Task GetAddressByAddressId_Success()
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers["Authorization"] = "Bearer testtoken";

            _addressService.Setup(a => a.GetAddressByAddressId(It.IsAny<long>(), It.IsAny<string>()))
                .ReturnsAsync(new Domain.Models.Address());

            var controller = new AddressController(_addressService.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };

            var response = await controller.GetAddressByAddressId(1);

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(OkObjectResult));

            var okObj = (OkObjectResult)response;

            Assert.AreEqual(okObj.StatusCode, 200);
        }

        [Test]
        public async Task GetAddressByAddressId_InternalServerError()
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers["Authorization"] = "Bearer testtoken";

            _addressService.Setup(a => a.GetAddressByAddressId(It.IsAny<long>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception());

            var controller = new AddressController(_addressService.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };

            var response = await controller.GetAddressByAddressId(1);

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }

        [Test]
        public async Task UpdateAddress_Success()
        {
            _addressService.Setup(a => a.UpdateAddress(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.CompletedTask);

            var controller = new AddressController(_addressService.Object);

            var response = await controller.UpdateAddress(new UpdateAddressRequest()
            {
                AddressId = 1,
                NewCustomer = "Test User",
                NewUnitStreet = "123 A St",
                NewCity = "CityTown",
                NewState = "AA",
                NewZipcode = "99999"
            });

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(OkResult));

            var ok = (OkResult)response;

            Assert.AreEqual(ok.StatusCode, 200);
        }

        [Test]
        public async Task UpdateAddress_InternalServerError()
        {
            _addressService.Setup(a => a.UpdateAddress(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception());

            var controller = new AddressController(_addressService.Object);

            var response = await controller.UpdateAddress(new UpdateAddressRequest()
            {
                AddressId = 1,
                NewCustomer = "Test User",
                NewUnitStreet = "123 A St",
                NewCity = "CityTown",
                NewState = "AA",
                NewZipcode = "99999"
            });

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }

        [Test]
        public async Task DeleteAddress_Success()
        {
            _addressService.Setup(a => a.DeleteAddress(It.IsAny<long>()))
                .Returns(Task.CompletedTask);

            var controller = new AddressController(_addressService.Object);

            var response = await controller.DeleteAddress(1);

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(OkResult));

            var ok = (OkResult)response;

            Assert.AreEqual(ok.StatusCode, 200);
        }

        [Test]
        public async Task DeleteAddress_InternalServerError()
        {
            _addressService.Setup(a => a.DeleteAddress(It.IsAny<long>()))
                .ThrowsAsync(new Exception());

            var controller = new AddressController(_addressService.Object);

            var response = await controller.DeleteAddress(1);

            Assert.NotNull(response);
            Assert.AreEqual(response.GetType(), typeof(ObjectResult));

            var obj = (ObjectResult)response;

            Assert.AreEqual(obj.StatusCode, 500);
        }
    }
}
