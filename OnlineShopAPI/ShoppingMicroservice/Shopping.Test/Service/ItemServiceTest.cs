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
    public class ItemServiceTest
    {
        private Mock<IItemRepository> _itemRepository;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void Setup()
        {
            _itemRepository = new Mock<IItemRepository>();
            _mapper = new Mock<IMapper>();
        }

        [Test]
        public async Task GetAllItems_Success()
        {
            _itemRepository.Setup(i => i.GetAllItems())
                .ReturnsAsync(new List<Item>());

            var itemService = new ItemService(_itemRepository.Object, _mapper.Object);

            await itemService.GetAllItems("SecretKey6196BRuan");

            _itemRepository.Verify(i => i.GetAllItems(), Times.Once);
        }

        [Test]
        public void GetAllItems_Fail()
        {
            _itemRepository.Setup(i => i.GetAllItems())
                .Throws(new Exception());

            var itemService = new ItemService(_itemRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<Exception>(() => itemService.GetAllItems("SecretKey6196BRuan"));
        }

        [Test]
        public async Task GetItemByItemId_Success()
        {
            _itemRepository.Setup(i => i.GetItemByItemId(It.IsAny<long>()))
                .ReturnsAsync(new Item());

            var itemService = new ItemService(_itemRepository.Object, _mapper.Object);

            await itemService.GetItemByItemId(1, "SecretKey6196BRuan");

            _itemRepository.Verify(i => i.GetItemByItemId(It.IsAny<long>()), Times.Once);
        }

        [Test]
        public void GetItemByItemId_Fail()
        {
            _itemRepository.Setup(i => i.GetItemByItemId(It.IsAny<long>()))
                .Throws(new Exception());

            var itemService = new ItemService(_itemRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<Exception>(() => itemService.GetItemByItemId(0, "SecretKey6196BRuan"));
        }

        [Test]
        public async Task GetItemsByItemType_Success()
        {
            _itemRepository.Setup(i => i.GetItemsByItemType(It.IsAny<long>()))
                .ReturnsAsync(new List<Item>());

            var itemService = new ItemService(_itemRepository.Object, _mapper.Object);

            await itemService.GetItemsByItemType(1, "SecretKey6196BRuan");

            _itemRepository.Verify(i => i.GetItemsByItemType(It.IsAny<long>()), Times.Once);
        }

        [Test]
        public void GetItemsByItemType_Fail()
        {
            _itemRepository.Setup(i => i.GetItemsByItemType(It.IsAny<long>()))
                .Throws(new Exception());

            var itemService = new ItemService(_itemRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<Exception>(() => itemService.GetItemsByItemType(0, "SecretKey6196BRuan"));
        }
    }
}
