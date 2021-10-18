using AutoMapper;
using Moq;
using NUnit.Framework;
using PaymentInfo.Domain.Services;
using PaymentInfo.Infrastructure.Repositories;
using PaymentInfo.Infrastructure.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentInfo.Test.Service
{
    [TestFixture]
    public class CardTypeServiceTest
    {
        private Mock<ICardTypeRepository> _cardTypeRepository;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void Setup()
        {
            _cardTypeRepository = new Mock<ICardTypeRepository>();
            _mapper = new Mock<IMapper>();
        }

        [Test]
        public async Task GetCardTypes_Success()
        {
            _cardTypeRepository.Setup(c => c.GetCardTypes())
                .ReturnsAsync(new List<CardType>());

            var cardTypeService = new CardTypeService(_cardTypeRepository.Object, _mapper.Object);

            await cardTypeService.GetCardTypes();

            _cardTypeRepository.Verify(c => c.GetCardTypes(), Times.Once);
        }

        [Test]
        public void GetCardTypes_Fail()
        {
            _cardTypeRepository.Setup(c => c.GetCardTypes())
                .ThrowsAsync(new Exception());

            var cardTypeService = new CardTypeService(_cardTypeRepository.Object, _mapper.Object);

            Assert.ThrowsAsync<Exception>(() => cardTypeService.GetCardTypes());
        }
    }
}
