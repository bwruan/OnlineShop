using Shopping.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Domain.Service
{
    public interface IItemService
    {
        Task<List<Item>> GetAllItems(string token);
        Task<Item> GetItemByItemId(long itemId, string token);
        Task<List<Item>> GetItemsByItemType(long itemTypeId, string token);
    }
}