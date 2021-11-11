using Dapper;
using Microsoft.Extensions.Configuration;
using PaymentInfo.Infrastructure.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentInfo.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public PaymentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("OnlineShopConnection");
        }

        public async Task AddPayment(string name, string cardNum, string securityCode, string expDate, long cardTypeId, long accountId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@name", name);
                param.Add("@cardNum", cardNum);
                param.Add("@securityCode", securityCode);
                param.Add("@expDate", expDate);
                param.Add("@cardTypeId", cardTypeId);
                param.Add("@accountId", accountId);

                await connection.ExecuteAsync("dbo.AddPayment", param, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Payment> GetPaymentByPaymentId(long paymentId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@paymentId", paymentId);

                return await connection.QueryFirstOrDefaultAsync<Payment>("dbo.GetPaymentByPaymentId", param, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<List<Payment>> GetPaymentsByAccountId(long accountId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@accountId", accountId);

                return (await connection.QueryAsync<Payment>("dbo.GetPaymentsByAccountId", param, commandType: CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task UpdatePayment(long paymentId, string newName, string newCardNum, string newSecCode, string newExpDate, long newTypeId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@paymentId", paymentId);
                param.Add("@newName", newName);
                param.Add("@newCardNum", newCardNum);
                param.Add("@newSecCode", newSecCode);
                param.Add("@newExpDate", newExpDate);
                param.Add("@newTypeId", newTypeId);

                await connection.ExecuteAsync("dbo.UpdatePayment", param, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeletePayment(long paymentId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@paymentId", paymentId);

                await connection.ExecuteAsync("dbo.DeletePayment", param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
