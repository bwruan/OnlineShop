using Shopping.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Domain.Service
{
    public interface ICartService
    {
        Task AddToCart(long itemId, int amount);
        Task<List<Cart>> GetItemsInCart(string token);
        Task PurchaseRemove();
    }
}