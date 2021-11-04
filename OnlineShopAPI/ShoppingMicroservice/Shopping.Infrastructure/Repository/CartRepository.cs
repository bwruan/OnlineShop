using Microsoft.EntityFrameworkCore;
using Shopping.Infrastructure.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.Repository
{
    public class CartRepository : ICartRepository
    {
        public async Task AddToCart(long itemId, int amount)
        {
            using (var context = new OnlineShopContext())
            {
                var cartItem = new Cart()
                {
                    ItemId = itemId,
                    Amount = amount
                };

                context.Carts.Add(cartItem);

                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Cart>> GetItemsInCart()
        {
            using (var context = new OnlineShopContext())
            {
                return await context.Carts.ToListAsync();
            }
        }

        public async Task PurchaseRemove()
        {
            using (var context = new OnlineShopContext())
            {
                context.RemoveRange(context.Carts);

                await context.SaveChangesAsync();
            }
        }
    }
}
