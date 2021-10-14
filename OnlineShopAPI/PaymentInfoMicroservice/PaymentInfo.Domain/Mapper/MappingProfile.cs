using AutoMapper;
using DbPayment = PaymentInfo.Infrastructure.Repositories.Entities.Payment;
using CorePayment = PaymentInfo.Domain.Models.Payment;
using DbCardType = PaymentInfo.Infrastructure.Repositories.Entities.CardType;
using CoreCardType = PaymentInfo.Domain.Models.CardType;

namespace PaymentInfo.Domain.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DbPayment, CorePayment>();

            CreateMap<DbCardType, CoreCardType>();
        }
    }
}
