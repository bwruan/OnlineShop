using Account.Domain.Mappers;
using Account.Domain.Models;
using Account.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Domain.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public UserAccountService(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<UserAccount> GetAccountById(long accountId)
        {
            var account = await _userAccountRepository.GetAccountById(accountId);

            if (account == null)
            {
                throw new ArgumentException("Account does not exist.");
            }

            return UserAccountMapper.DbAccountToCoreAccount(account);
        }

        public async Task<UserAccount> GetAccountByEmail(string email)
        {
            var account = await _userAccountRepository.GetAccountByEmail(email);

            if (account == null)
            {
                throw new ArgumentException("Account does not exist.");
            }

            return UserAccountMapper.DbAccountToCoreAccount(account);
        }

        public async Task AddAccount(string name, string email, string password)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name field blank.");
            }

            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email field blank.");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password field blank.");
            }

            if (password.Length < 8 || password.Length > 32)
            {
                throw new ArgumentException("Password length not met.");
            }

            await _userAccountRepository.AddAccount(name, email, password);
        }

        public async Task UpdateAccount(long accountId, string newName, string newEmail, string newPassword)
        {
            var account = await _userAccountRepository.GetAccountById(accountId);

            if (string.IsNullOrEmpty(newName))
            {
                throw new ArgumentException("Name field blank.");
            }

            if (string.IsNullOrEmpty(newEmail))
            {
                throw new ArgumentException("Email field blank.");
            }

            if (string.IsNullOrEmpty(newPassword))
            {
                throw new ArgumentException("Password field blank.");
            }

            if (newPassword.Length < 8 || newPassword.Length > 32)
            {
                throw new ArgumentException("Password length not met.");
            }

            await _userAccountRepository.UpdateAccount(account.AccountId, newName, newEmail, newPassword);
        }

        public async Task LogIn(string email, string password, bool status)
        {
            var account = await _userAccountRepository.GetAccountByEmail(email);

            if (account.Status == true)
            {
                throw new ArgumentException("Account already online");
            }

            await _userAccountRepository.UpdateStatus(email, password, true);
        }

        public async Task LogOut(long accountId)
        {
            var account = await _userAccountRepository.GetAccountById(accountId);

            if (account.Status == false)
            {
                throw new ArgumentException("Account already offline");
            }

            await _userAccountRepository.UpdateStatus(account.Email, account.Password, false);
        }
    }
}
