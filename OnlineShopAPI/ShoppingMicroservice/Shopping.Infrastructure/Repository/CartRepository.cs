using Microsoft.EntityFrameworkCore;
using Shopping.Infrastructure.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.Repository
{
    public class CartRepository : ICartRepository
    {
        public async Task AddToCart(long accountId, long itemId, int amount)
        {
            using (var context = new OnlineShopContext())
            {
                var cartItem = new Cart()
                {
                    ItemId = itemId,
                    Amount = amount,
                    AccountId = accountId
                };

                context.Carts.Add(cartItem);

                await context.SaveChangesAsync();
            }
        }

        public async Task<decimal> CalculateTotalCost(long accountId)
        {
            using (var context = new OnlineShopContext())
            {
                var cartItemsPrice = await context.Carts.Include(i => i.Item).Where(c => c.AccountId == accountId).ToListAsync();
                decimal total = 0;

                foreach(var item in cartItemsPrice)
                {
                    total = total + (item.Amount * item.Item.Price);
                }

                return total;
            }
        }

        public async Task<List<Cart>> GetItemsInCartByAccountId(long accountId)
        {
            using (var context = new OnlineShopContext())
            {
                return await context.Carts.Include(i => i.Item).Where(c => c.AccountId == accountId).ToListAsync();
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

        public async Task RemoveFromCart(long itemId)
        {
            using (var context = new OnlineShopContext())
            {
                var item = await context.Carts.FirstOrDefaultAsync(c => c.ItemId == itemId);

                context.Carts.Remove(item);

                await context.SaveChangesAsync();
            }
        }
    }
}
