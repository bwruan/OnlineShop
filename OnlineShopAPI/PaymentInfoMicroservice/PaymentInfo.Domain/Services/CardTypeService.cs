using AutoMapper;
using PaymentInfo.Domain.Models;
using PaymentInfo.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentInfo.Domain.Services
{
    public class CardTypeService : ICardTypeService
    {
        private readonly ICardTypeRepository _cardTypeRepository;
        private readonly IMapper _mapper;

        public CardTypeService(ICardTypeRepository cardTypeRepository, IMapper mapper)
        {
            _cardTypeRepository = cardTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<CardType>> GetCardTypes()
        {
            var typeList = new List<CardType>();

            var cardTypeList = await _cardTypeRepository.GetCardTypes();

            foreach (var type in cardTypeList)
            {
                typeList.Add(_mapper.Map<CardType>(type));
            }

            return typeList;
        }
    }
}
