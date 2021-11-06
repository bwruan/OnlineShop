using Shopping.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Domain.Service
{
    public interface IItemTypeService
    {
        Task<List<ItemType>> GetItemType();
    }
}