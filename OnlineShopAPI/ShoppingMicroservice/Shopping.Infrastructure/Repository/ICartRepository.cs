using Shopping.Infrastructure.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.Repository
{
    public interface ICartRepository
    {
        Task AddToCart(long accountId, long itemId, int amount);
        Task<List<Cart>> GetItemsInCartByAccountId(long accountId);
        Task PurchaseRemove();
        Task<decimal> CalculateTotalCost(long accountId);
        Task RemoveFromCart(long itemId);
    }
}