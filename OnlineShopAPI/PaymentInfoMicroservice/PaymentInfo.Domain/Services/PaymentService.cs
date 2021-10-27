using AutoMapper;
using PaymentInfo.Domain.Models;
using PaymentInfo.Infrastructure.AccountService;
using PaymentInfo.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentInfo.Domain.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUserAccountService _userAccountService;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IUserAccountService userAccountService,IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _userAccountService = userAccountService;
            _mapper = mapper;
        }

        public async Task AddPayment(string name, string cardNum, string securtiyCode, string expDate, string billName, string billUnit,
            string billCity, string billState, string billZip, long cardTypeId, long accountId)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name on Card cannot be empty.");
            }

            if (string.IsNullOrEmpty(cardNum))
            {
                throw new ArgumentException("Card Number cannot be empty.");
            }

            if (cardNum.Length != 16)
            {
                throw new ArgumentException("Card Number must be 16 digits.");
            }

            if (string.IsNullOrEmpty(securtiyCode))
            {
                throw new ArgumentException("Security code cannot be empty.");
            }

            if (string.IsNullOrEmpty(billName))
            {
                throw new ArgumentException("Name for address cannot be empty.");
            }

            if (string.IsNullOrEmpty(billUnit))
            {
                throw new ArgumentException("Address cannot be empty.");
            }

            if (string.IsNullOrEmpty(billCity))
            {
                throw new ArgumentException("City cannot be empty.");
            }

            if (string.IsNullOrEmpty(billZip))
            {
                throw new ArgumentException("Zipcode cannot be empty.");
            }

            if (string.IsNullOrEmpty(expDate))
            {
                throw new ArgumentException("Please enter card expiration date.");
            }

            await _paymentRepository.AddPayment(name, cardNum, securtiyCode, expDate, billName, billUnit, billCity, billState, billZip, cardTypeId, accountId);
        }

        public async Task<Payment> GetPaymentByPaymentId(long paymentId, string token)
        {
            return _mapper.Map<Payment>(await _paymentRepository.GetPaymentByPaymentId(paymentId));
        }

        public async Task<List<Payment>> GetPaymentsByAccountId(long accountId, string token)
        {
            var paymentList = new List<Payment>();

            var payments = await _paymentRepository.GetPaymentsByAccountId(accountId);

            foreach (var payment in payments)
            {
                var account = await _userAccountService.GetAccountByAccountId(accountId, token);
                var corePayment = _mapper.Map<Payment>(payment);

                corePayment.AccountId = account.AccountId;
                
                paymentList.Add(corePayment);
            }

            return paymentList;
        }

        public async Task UpdatePayment(long paymentId, string newName, string newCardNum, string newSecCode, string newExpDate, string newBillName, string newBillUnit,
            string newBillCity, string newBillState, string newBillZip, long newTypeId)
        {
            var payment = await _paymentRepository.GetPaymentByPaymentId(paymentId);

            if (payment == null)
            {
                throw new ArgumentException("This Payment does not exist.");
            }

            if (string.IsNullOrEmpty(newName))
            {
                throw new ArgumentException("Name on Card cannot be empty.");
            }

            if (string.IsNullOrEmpty(newCardNum))
            {
                throw new ArgumentException("Card Number cannot be empty.");
            }

            if (newCardNum.Length != 16)
            {
                throw new ArgumentException("Card Number must be 16 digits.");
            }

            if (string.IsNullOrEmpty(newSecCode))
            {
                throw new ArgumentException("Security code cannot be empty.");
            }

            if (string.IsNullOrEmpty(newBillName))
            {
                throw new ArgumentException("Name for Address cannot be empty.");
            }

            if (string.IsNullOrEmpty(newBillUnit))
            {
                throw new ArgumentException("Address cannot be empty.");
            }

            if (string.IsNullOrEmpty(newBillCity))
            {
                throw new ArgumentException("City cannot be empty.");
            }

            if (string.IsNullOrEmpty(newBillZip))
            {
                throw new ArgumentException("Zipcode cannot be empty.");
            }

            if (string.IsNullOrEmpty(newExpDate))
            {
                throw new ArgumentException("Please enter card expiration date.");
            }

            await _paymentRepository.UpdatePayment(payment.PaymentId, newName, newCardNum, newSecCode, newExpDate, newBillName, newBillUnit, newBillCity, newBillState, newBillZip, newTypeId);
        }

        public async Task DeletePayment(long paymentId)
        {
            var payment = await _paymentRepository.GetPaymentByPaymentId(paymentId);

            if (payment == null)
            {
                throw new ArgumentException("This Payment does not exist.");
            }

            await _paymentRepository.DeletePayment(payment.PaymentId);
        }
    }
}
