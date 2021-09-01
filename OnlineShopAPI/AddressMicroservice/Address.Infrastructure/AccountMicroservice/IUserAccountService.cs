using Address.Infrastructure.AccountMicroservice.Model;
using System.Threading.Tasks;

namespace Address.Infrastructure.AccountMicroservice
{
    public interface IUserAccountService
    {
        Task<UserAccount> GetAccountByAccountId(long accountId, string token);
    }
}