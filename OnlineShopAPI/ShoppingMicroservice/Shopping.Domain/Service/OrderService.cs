using AutoMapper;
using Shopping.Domain.Models;
using Shopping.Infrastructure.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Domain.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrdersRepository ordersRepository, IItemRepository itemRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<List<Order>> GetOrdersByAccountId(long accountId, string token)
        {
            var orders = new List<Order>();
            var orderList = await _ordersRepository.GetOrdersByAccountId(accountId);

            foreach (var order in orderList)
            {
                var item = await _itemRepository.GetItemByItemId(order.ItemId);
                var coreItem = _mapper.Map<Item>(item);
                var coreOrder = _mapper.Map<Order>(order);

                coreOrder.OrderedItem = coreItem;

                orders.Add(coreOrder);
            }

            return orders;
        }

        public async Task<List<Order>> GetOrdersByOrderNum(int orderNum, string token)
        {
            var orders = new List<Order>();
            var orderList = await _ordersRepository.GetOrdersByOrderNum(orderNum);

            foreach (var order in orderList)
            {
                var item = await _itemRepository.GetItemByItemId(order.ItemId);
                var coreItem = _mapper.Map<Item>(item);
                var coreOrder = _mapper.Map<Order>(order);

                coreOrder.OrderedItem = coreItem;

                orders.Add(coreOrder);
            }

            return orders;
        }

        public async Task PurchaseOrder(long accountId, string token)
        {
            await _ordersRepository.PurchaseOrder(accountId);
        }
    }
}
