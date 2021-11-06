using AutoMapper;
using DbCart = Shopping.Infrastructure.Repository.Entities.Cart;
using CoreCart = Shopping.Domain.Models.Cart;
using DbItem = Shopping.Infrastructure.Repository.Entities.Item;
using CoreItem = Shopping.Domain.Models.Item;
using DbOrder = Shopping.Infrastructure.Repository.Entities.Order;
using CoreOrder = Shopping.Domain.Models.Order;
using DbItemType = Shopping.Infrastructure.Repository.Entities.ItemType;
using CoreItemType = Shopping.Domain.Models.ItemType;
using DbAccount = Shopping.Infrastructure.AccountMicroservice.Model.UserAccount;
using CoreAccount = Shopping.Domain.Models.UserAccount;

namespace Shopping.Domain.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DbCart, CoreCart>();

            CreateMap<DbItem, CoreItem>();

            CreateMap<DbOrder, CoreOrder>();

            CreateMap<DbItemType, CoreItemType>();
            
            CreateMap<DbAccount, CoreAccount>();
        }
    }
}
