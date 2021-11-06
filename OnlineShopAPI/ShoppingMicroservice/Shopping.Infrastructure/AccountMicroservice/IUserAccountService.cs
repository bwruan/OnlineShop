using Shopping.Infrastructure.AccountMicroservice.Model;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.AccountMicroservice
{
    public interface IUserAccountService
    {
        Task<UserAccount> GetAccountByAccountId(long accountId, string token);
    }
}