using Shopping.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Domain.Service
{
    public interface IItemService
    {
        Task<List<Item>> GetAllItems();
        Task<Item> GetItemByItemId(long itemId);
        Task<List<Item>> GetItemsByItemType(long itemTypeId);
    }
}