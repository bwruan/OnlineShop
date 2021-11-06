using Shopping.Infrastructure.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.Repository
{
    public interface IOrdersRepository
    {
        Task<List<Order>> GetOrdersByAccountId(long accountId);
        Task<List<Order>> GetOrdersByOrderNum(int orderNum);
        Task PurchaseOrder(long accountId);
    }
}