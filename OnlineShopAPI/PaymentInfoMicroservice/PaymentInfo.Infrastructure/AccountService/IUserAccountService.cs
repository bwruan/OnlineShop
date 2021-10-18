using PaymentInfo.Infrastructure.AccountService.Model;
using System.Threading.Tasks;

namespace PaymentInfo.Infrastructure.AccountService
{
    public interface IUserAccountService
    {
        Task<UserAccount> GetAccountByAccountId(long accountId, string token);
    }
}