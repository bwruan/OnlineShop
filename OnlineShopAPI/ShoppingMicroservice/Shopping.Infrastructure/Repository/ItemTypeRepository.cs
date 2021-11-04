using Microsoft.EntityFrameworkCore;
using Shopping.Infrastructure.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.Repository
{
    public class ItemTypeRepository : IItemTypeRepository
    {
        public async Task<List<ItemType>> GetItemType()
        {
            using (var context = new OnlineShopContext())
            {
                return await context.ItemTypes.ToListAsync();
            }
        }
    }
}
