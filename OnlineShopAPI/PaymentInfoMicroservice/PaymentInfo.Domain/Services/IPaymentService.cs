using PaymentInfo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentInfo.Domain.Services
{
    public interface IPaymentService
    {
        Task AddPayment(string name, string cardNum, string securtiyCode, DateTime expDate, string billName, string billUnit, string billCity, 
            string billState, string billZip, long cardTypeId, long accountId);
        Task DeletePayment(long paymentId);
        Task<Payment> GetPaymentByPaymentId(long paymentId, string token);
        Task<List<Payment>> GetPaymentsByAccountId(long accountId, string token);
        Task UpdatePayment(long paymentId, string newName, string newCardNum, string newSecCode, DateTime newExpDate, string newBillName, string newBillUnit, 
            string newBillCity, string newBillState, string newBillZip, long newTypeId);
    }
}