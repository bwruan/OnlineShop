using AutoMapper;
using Shopping.Domain.Models;
using Shopping.Infrastructure.AccountMicroservice;
using Shopping.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IUserAccountService _userAccountService;
        private readonly IMapper _mapper;

        public OrderService(IOrdersRepository ordersRepository, IUserAccountService userAccountService, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _userAccountService = userAccountService;
            _mapper = mapper;
        }

        public async Task<List<Order>> GetOrdersByAccountId(long accountId, string token)
        {
            var orders = new List<Order>();
            var orderList = await _ordersRepository.GetOrdersByAccountId(accountId);

            foreach (var order in orderList)
            {
                var account = await _userAccountService.GetAccountByAccountId(order.AccountId, token);
                var coreAccount = _mapper.Map<UserAccount>(account);
                var coreOrder = _mapper.Map<Order>(order);

                coreOrder.AccountId = coreAccount.AccountId;

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
                orders.Add(_mapper.Map<Order>(order));
            }

            return orders;
        }

        public async Task PurchaseOrder(long accountId)
        {
            await _ordersRepository.PurchaseOrder(accountId);
        }
    }
}
