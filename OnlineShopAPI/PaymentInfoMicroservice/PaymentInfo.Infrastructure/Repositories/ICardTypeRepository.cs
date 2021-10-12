using PaymentInfo.Infrastructure.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentInfo.Infrastructure.Repositories
{
    public interface ICardTypeRepository
    {
        Task<List<CardType>> GetCardTypes();
    }
}