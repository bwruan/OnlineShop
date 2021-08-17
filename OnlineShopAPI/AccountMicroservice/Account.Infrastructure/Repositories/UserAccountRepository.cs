using Account.Infrastructure.Repositories.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Account.Infrastructure.Repositories
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public UserAccountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DbConnectionString");
        }

        public async Task<UserAccount> GetAccountById(long accountId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@accountId", accountId);

                return await connection.QueryFirstOrDefaultAsync<UserAccount>("dbo.GetAccountById", param);
            }
        }

        public async Task<UserAccount> GetAccountByEmail(string email)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@email", email);

                return await connection.QueryFirstOrDefaultAsync<UserAccount>("dbo.GetAccountByEmail", param);
            }
        }

        public async Task AddAccount(string name, string email, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@name", name);
                param.Add("@email", email);
                param.Add("@password", password);
                param.Add("@createdDate", DateTime.Now);

                await connection.ExecuteAsync("dbo.CreateAccount", param);
            }
        }

        public async Task UpdateAccount(long accountId, string newName, string newEmail, string newPassword)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@accountId", accountId);
                param.Add("@newname", newName);
                param.Add("@newEmail", newEmail);
                param.Add("@newPassword", newPassword);
                param.Add("@newUpdatedDate", DateTime.Now);

                await connection.ExecuteAsync("dbo.UpdateAccount", param);
            }
        }

        public async Task UpdateStatus(string email, string password, bool status)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@email", email);
                param.Add("@password", password);
                param.Add("@status", status);

                await connection.ExecuteAsync("dbo.UpdateStatus", param);
            }
        }
    }
}
