using Microsoft.EntityFrameworkCore;
using Shopping.Infrastructure.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        public async Task PurchaseOrder(long accountId)
        {
            using (var context = new OnlineShopContext())
            {
                var orders = new Order();
                var cartItems = await context.Carts.ToListAsync();

                var rnd = new Random();
                var orderNum = rnd.Next(10000, 99999);

                foreach (var item in cartItems)
                {
                    orders.CartId = item.CartId;
                    orders.PurchaseDate = DateTime.Now;
                    orders.OrderNum = orderNum;
                    orders.AccountId = accountId;

                    context.Orders.Add(orders);
                }

                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Order>> GetOrdersByAccountId(long accountId)
        {
            using (var context = new OnlineShopContext())
            {
                return await context.Orders.Where(o => o.AccountId == accountId).ToListAsync();
            }
        }

        public async Task<List<Order>> GetOrdersByOrderNum(int orderNum)
        {
            using (var context = new OnlineShopContext())
            {
                return await context.Orders.Where(o => o.OrderNum == orderNum).ToListAsync();
            }
        }
    }
}
