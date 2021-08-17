using Account.Infrastructure.Repositories.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Account.Infrastructure.Repositories
{
    public class AddressRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public AddressRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DbConnectionString");
        }

        public async Task AddAddress(string shipping, long accountId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@shipping", shipping);
                param.Add("@accountId", accountId);

                await connection.ExecuteAsync("dbo.AddAddress", param);
            }
        }

        public async Task DeleteAddress(long addressId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@addressId", addressId);

                await connection.ExecuteAsync("dbo.DeleteShippingAddress", param);
            }
        }

        public async Task UpdateAddress(long addressId, string newShipping, long accountId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@addressId", addressId);
                param.Add("@shipping", newShipping);
                param.Add("@accountId", accountId);

                await connection.ExecuteAsync("dbo.UpdateShippingAddress", param);
            }
        }

        public async Task<IEnumerable<Address>> GetShippingAddressesByAccountId(long accountId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@accountId", accountId);

                return await connection.QueryAsync<Address>("dbo.GetShippingAddressesByAccountId", param);
            }
        }

        public async Task<Address> GetShippingAddressByAddressId(long addressId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@addressId", addressId);

                return await connection.QueryFirstOrDefaultAsync<Address>("dbo.GetShippingAddressByAddressId", param);
            }
        }
    }
}
