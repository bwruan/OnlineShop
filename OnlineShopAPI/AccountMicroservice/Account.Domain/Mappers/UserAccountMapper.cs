using CoreAccount = Account.Domain.Models.UserAccount;
using DbAccount = Account.Infrastructure.Repositories.Entities.UserAccount;

namespace Account.Domain.Mappers
{
    public class UserAccountMapper
    {
        public static CoreAccount DbAccountToCoreAccount(DbAccount dbAccount)
        {
            var coreAccount = new CoreAccount();

            coreAccount.AccountId = dbAccount.AccountId;
            coreAccount.Name = dbAccount.Name;
            coreAccount.Email = dbAccount.Email;
            coreAccount.Password = dbAccount.Password;
            coreAccount.Status = dbAccount.Status;
            coreAccount.CreatedDate = dbAccount.CreatedDate;
            coreAccount.UpdatedDate = dbAccount.UpdatedDate;

            return coreAccount;
        }
    }
}
