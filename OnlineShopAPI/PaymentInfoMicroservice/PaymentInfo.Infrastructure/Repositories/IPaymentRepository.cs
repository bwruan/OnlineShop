using PaymentInfo.Infrastructure.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentInfo.Infrastructure.Repositories
{
    public interface IPaymentRepository
    {
        Task AddPayment(string name, string cardNum, string securtiyCode, DateTime expDate, string billName, string billUnit, string billCity, string billState, string billZip, long cardTypeId, long accountId);
        Task DeletePayment(long paymentId);
        Task<Payment> GetPaymentByPaymentId(long paymentId);
        Task<List<Payment>> GetPayments();
        Task UpdatePayment(long paymentId, string newName, string newCardNum, string newSecCode, DateTime newExpDate, string newBillName, string newBillUnit, string newBillCity, string newBillState, string newBillZip);
    }
}