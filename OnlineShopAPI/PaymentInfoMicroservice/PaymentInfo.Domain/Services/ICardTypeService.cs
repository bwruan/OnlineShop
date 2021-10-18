using PaymentInfo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentInfo.Domain.Services
{
    public interface ICardTypeService
    {
        Task<List<CardType>> GetCardTypes();
    }
}