using Shopping.Infrastructure.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.Repository
{
    public interface IItemTypeRepository
    {
        Task<List<ItemType>> GetItemType();
    }
}