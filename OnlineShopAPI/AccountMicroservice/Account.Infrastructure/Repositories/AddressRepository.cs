using Dapper;
using Microsoft.Extensions.Configuration;
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
    }
}
