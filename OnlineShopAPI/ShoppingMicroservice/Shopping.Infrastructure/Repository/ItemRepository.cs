using Microsoft.EntityFrameworkCore;
using Shopping.Infrastructure.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.Repository
{
    public class ItemRepository : IItemRepository
    {
        public async Task<List<Item>> GetAllItems()
        {
            using (var context = new OnlineShopContext())
            {
                return await context.Items.ToListAsync();
            }
        }

        public async Task<List<Item>> GetItemsByItemType(long itemTypeId)
        {
            using (var context = new OnlineShopContext())
            {
                return await context.Items.Where(i => i.ItemTypeId == itemTypeId).ToListAsync();
            }
        }

        public async Task<Item> GetItemByItemId(long itemId)
        {
            using (var context = new OnlineShopContext())
            {
                return await context.Items.FirstOrDefaultAsync(i => i.ItemId == itemId);
            }
        }
    }
}
