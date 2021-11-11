using Microsoft.EntityFrameworkCore;
using Shopping.Infrastructure.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        public async Task PurchaseOrder(long accountId)
        {
            using (var context = new OnlineShopContext())
            {
                var cartItems = await context.Carts.Include(i => i.Item).Where(c => c.AccountId == accountId).ToListAsync();

                var rnd = new Random();
                var orderNum = rnd.Next(10000, 99999);

                foreach (var item in cartItems)
                {
                    var orders = new Order();
                    orders.PurchaseDate = DateTime.Now;
                    orders.OrderNum = orderNum;
                    orders.AccountId = accountId;
                    orders.ItemId = item.ItemId;
                    orders.Item = item.Item;
                    orders.Amount = item.Amount;

                    context.Orders.Add(orders);
                }

                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Order>> GetOrdersByAccountId(long accountId)
        {
            using (var context = new OnlineShopContext())
            {
                return await context.Orders.Include(i => i.Item.Carts).Where(o => o.AccountId == accountId).ToListAsync();
            }
        }

        public async Task<List<Order>> GetOrdersByOrderNum(int orderNum)
        {
            using (var context = new OnlineShopContext())
            {
                return await context.Orders.Include(i => i.Item).Where(o => o.OrderNum == orderNum).ToListAsync();
            }
        }
    }
}
