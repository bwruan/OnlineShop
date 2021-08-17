using Account.Domain.Models;
using System.Threading.Tasks;

namespace Account.Domain.Services
{
    public interface IUserAccountService
    {
        Task AddAccount(string name, string email, string password);
        Task<UserAccount> GetAccountByEmail(string email);
        Task<UserAccount> GetAccountById(long accountId);
        Task LogIn(string email, string password, bool status);
        Task LogOut(long accountId);
        Task UpdateAccount(long accountId, string newName, string newEmail, string newPassword);
    }
}