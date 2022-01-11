using Shopping.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Domain.Service
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrdersByAccountId(long accountId, string token);
        Task<List<Order>> GetOrdersByOrderNum(int orderNum, string token);
        Task PurchaseOrder(long accountId, string token);
    }
}