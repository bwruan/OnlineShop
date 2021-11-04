using Shopping.Infrastructure.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.Repository
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllItems();
        Task<Item> GetItemByItemId(long itemId);
        Task<List<Item>> GetItemsByItemType(long itemTypeId);
    }
}