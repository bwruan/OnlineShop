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
    public class ItemTypeServiceTest
    {
        private Mock<IItemTypeRepository> _itemTypeRepository;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void Setup()
        {
            _itemTypeRepository = new Mock<IItemTypeRepository>();
            _mapper = new Mock<IMapper>();
        }

        [Test]
        public async Task GetItemType_Success()
        {
            _itemTypeRepository.Setup(i => i.GetItemType())
                .ReturnsAsync(new List<ItemType>());

            var itemTypeService = new ItemTypeService(_itemTypeRepository.Object, _mapper.Object);

            await itemTypeService.GetItemType();

            _itemTypeRepository.Verify(i => i.GetItemType(), Times.Once);
        }

        [Test]
        public async Task GetItemType_Fail()
        {
            _itemTypeRepository.Setup(i => i.GetItemType())
                .ThrowsAsync(new Exception());

            var itemTypeService = new ItemTypeService(_itemTypeRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<Exception>(() => itemTypeService.GetItemType());
        }
    }
}
