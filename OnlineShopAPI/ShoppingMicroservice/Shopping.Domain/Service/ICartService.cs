using Shopping.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Domain.Service
{
    public interface ICartService
    {
        Task AddToCart(long accountId, long itemId, int amount);
        Task<List<Cart>> GetItemsInCartByAccountId(long accountId, string token);
        Task PurchaseRemove();
        Task<decimal> CalculateTotalCost(long accountId);
    }
}