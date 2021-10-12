using Dapper;
using Microsoft.Extensions.Configuration;
using PaymentInfo.Infrastructure.Repositories.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentInfo.Infrastructure.Repositories
{
    public class CardTypeRepository : ICardTypeRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public CardTypeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("OnlineShopConnection");
        }

        public async Task<List<CardType>> GetCardTypes()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return (await connection.QueryAsync<CardType>("dbo.GetCardTypes", commandType: CommandType.StoredProcedure)).ToList();
            }
        }
    }
}
