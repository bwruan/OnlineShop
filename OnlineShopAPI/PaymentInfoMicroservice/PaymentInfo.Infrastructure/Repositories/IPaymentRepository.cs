﻿using PaymentInfo.Infrastructure.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentInfo.Infrastructure.Repositories
{
    public interface IPaymentRepository
    {
        Task AddPayment(string name, string cardNum, string securtiyCode, string expDate, string billName, string billUnit, 
            string billCity, string billState, string billZip, long cardTypeId, long accountId);
        Task DeletePayment(long paymentId);
        Task<Payment> GetPaymentByPaymentId(long paymentId);
        Task<List<Payment>> GetPaymentsByAccountId(long accountId);
        Task UpdatePayment(long paymentId, string newName, string newCardNum, string newSecCode, string newExpDate,
            string newBillName, string newBillUnit, string newBillCity, string newBillState, string newBillZip, long newTypeId);
    }
}