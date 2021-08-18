using AutoMapper;
using CoreAccount = Account.Domain.Models.UserAccount;
using DbAccount = Account.Infrastructure.Repositories.Entities.UserAccount;

namespace Account.Domain.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DbAccount, CoreAccount>();
        }
    }
}
