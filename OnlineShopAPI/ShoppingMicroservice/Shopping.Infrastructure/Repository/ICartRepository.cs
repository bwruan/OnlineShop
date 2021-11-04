using Shopping.Infrastructure.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.Repository
{
    public interface ICartRepository
    {
        Task AddToCart(long itemId, int amount);
        Task<List<Cart>> GetItemsInCart();
        Task PurchaseRemove();
    }
}