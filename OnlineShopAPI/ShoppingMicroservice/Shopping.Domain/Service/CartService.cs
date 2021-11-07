using AutoMapper;
using Shopping.Domain.Models;
using Shopping.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain.Service
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task AddToCart(long itemId, int amount)
        {
            if (itemId <= 0)
            {
                throw new ArgumentException("Item does not exit");
            }

            if (amount == 0)
            {
                throw new ArgumentException("Must have a quantity of at least 1");
            }

            await _cartRepository.AddToCart(itemId, amount);
        }

        public async Task<List<Cart>> GetItemsInCart(string token)
        {
            var cartItems = new List<Cart>();

            var cartList = await _cartRepository.GetItemsInCart();

            foreach (var item in cartList)
            {
                cartItems.Add(_mapper.Map<Cart>(item));
            }

            return cartItems;
        }

        public async Task PurchaseRemove()
        {
            await _cartRepository.PurchaseRemove();
        }
    }
}
