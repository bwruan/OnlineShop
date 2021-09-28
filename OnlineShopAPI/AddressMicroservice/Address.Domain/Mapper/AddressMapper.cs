using CoreAddress = Address.Domain.Models.Address;
using DbAddress = Address.Infrastructure.Repository.Entities.Address;
using CoreAccount = Address.Domain.Models.UserAccount;
using DbAccount = Address.Infrastructure.AccountMicroservice.Model.UserAccount;

namespace Address.Domain.Mapper
{
    public static class AddressMapper
    {
        public static CoreAddress DbAddressToCoreAddress(DbAddress dbAddress)
        {
            var coreAddress = new CoreAddress();

            coreAddress.AccountId = dbAddress.AccountId;
            coreAddress.AddressId = dbAddress.AddressId;
            coreAddress.Shipping = dbAddress.Shipping;
            coreAddress.User = new CoreAccount() { AccountId = dbAddress.AccountId };

            return coreAddress;
        }

        public static CoreAccount UserAccountToCoreAccount(DbAccount userAccount)
        {
            var coreAccount = new CoreAccount();

            coreAccount.AccountId = userAccount.AccountId;
            coreAccount.Name = userAccount.Name;
            coreAccount.Email = userAccount.Email;
            coreAccount.Password = userAccount.Password;
            coreAccount.Status = userAccount.Status;

            return coreAccount;
        }
    }
}
