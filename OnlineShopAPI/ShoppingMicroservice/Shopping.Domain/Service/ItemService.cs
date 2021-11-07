using AutoMapper;
using Shopping.Domain.Models;
using Shopping.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain.Service
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<List<Item>> GetAllItems(string token)
        {
            var items = new List<Item>();

            var itemList = await _itemRepository.GetAllItems();

            foreach (var item in itemList)
            {
                items.Add(_mapper.Map<Item>(item));
            }

            return items;
        }

        public async Task<Item> GetItemByItemId(long itemId, string token)
        {
            var item = await _itemRepository.GetItemByItemId(itemId);

            if (item == null)
            {
                throw new ArgumentException("Item does not exist.");
            }

            return _mapper.Map<Item>(item);
        }

        public async Task<List<Item>> GetItemsByItemType(long itemTypeId, string token)
        {
            var items = new List<Item>();

            var itemsList = await _itemRepository.GetItemsByItemType(itemTypeId);

            foreach (var item in itemsList)
            {
                items.Add(_mapper.Map<Item>(item));
            }

            return items;
        }
    }
}
