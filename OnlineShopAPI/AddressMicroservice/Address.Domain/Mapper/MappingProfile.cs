using AutoMapper;
using DbAddress = Address.Infrastructure.Repository.Entities.Address;
using CoreAddress = Address.Domain.Models.Address;
using DbAccount = Address.Infrastructure.AccountMicroservice.Model.UserAccount;
using CoreAccount = Address.Domain.Models.UserAccount;

namespace Address.Domain.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DbAddress, CoreAddress>();

            CreateMap<DbAccount, CoreAccount>();
        }
    }
}
