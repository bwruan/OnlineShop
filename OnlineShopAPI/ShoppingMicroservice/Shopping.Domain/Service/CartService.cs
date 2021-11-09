using AutoMapper;
using Shopping.Domain.Models;
using Shopping.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Domain.Service
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, IItemRepository itemRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task AddToCart(long accountId, long itemId, int amount)
        {
            if (itemId <= 0)
            {
                throw new ArgumentException("Item does not exit");
            }

            if (amount == 0)
            {
                throw new ArgumentException("Must have a quantity of at least 1");
            }

            await _cartRepository.AddToCart(accountId, itemId, amount);
        }

        public async Task<decimal> CalculateTotalCost(long accountId)
        {
            return await _cartRepository.CalculateTotalCost(accountId);
        }

        public async Task<List<Cart>> GetItemsInCartByAccountId(long accountId, string token)
        {
            var cartItems = new List<Cart>();

            var cartList = await _cartRepository.GetItemsInCartByAccountId(accountId);

            foreach (var item in cartList)
            {
                var shopItem = await _itemRepository.GetItemByItemId(item.ItemId);
                var coreShopItem = _mapper.Map<Item>(shopItem);
                var coreCartItem = _mapper.Map<Cart>(item);

                coreCartItem.ShopItem = coreShopItem;

                cartItems.Add(coreCartItem);
            }

            return cartItems;
        }

        public async Task PurchaseRemove()
        {
            await _cartRepository.PurchaseRemove();
        }

        public async Task RemoveFromCart(long itemId)
        {
            await _cartRepository.RemoveFromCart(itemId);
        }
    }
}
