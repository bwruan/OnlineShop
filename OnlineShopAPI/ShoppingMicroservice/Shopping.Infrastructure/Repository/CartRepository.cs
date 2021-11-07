﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Cart>> GetItemsInCartByAccountId(long accountId)
        {
            using (var context = new OnlineShopContext())
            {
                return await context.Carts.Where(c => c.AccountId == accountId).ToListAsync();
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
