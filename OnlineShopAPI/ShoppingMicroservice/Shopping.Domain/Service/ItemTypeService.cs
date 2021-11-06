using AutoMapper;
using Shopping.Domain.Models;
using Shopping.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain.Service
{
    public class ItemTypeService : IItemTypeService
    {
        private readonly IItemTypeRepository _itemTypeRepository;
        private readonly IMapper _mapper;

        public ItemTypeService(IItemTypeRepository itemTypeRepository, IMapper mapper)
        {
            _itemTypeRepository = itemTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<ItemType>> GetItemType()
        {
            var itemTypes = await _itemTypeRepository.GetItemType();
            var types = new List<ItemType>();

            foreach (var type in itemTypes)
            {
                var coreTypes = _mapper.Map<ItemType>(type);

                types.Add(coreTypes);
            }

            return types;
        }
    }
}
