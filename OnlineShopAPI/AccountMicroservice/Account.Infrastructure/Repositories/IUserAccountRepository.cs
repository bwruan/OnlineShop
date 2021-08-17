using Account.Infrastructure.Repositories.Entities;
using System.Threading.Tasks;

namespace Account.Infrastructure.Repositories
{
    public interface IUserAccountRepository
    {
        Task AddAccount(string name, string email, string password);
        Task<UserAccount> GetAccountByEmail(string email);
        Task<UserAccount> GetAccountById(long accountId);
        Task UpdateAccount(long accountId, string newName, string newEmail, string newPassword);
        Task UpdateStatus(string email, string password, bool status);
    }
}