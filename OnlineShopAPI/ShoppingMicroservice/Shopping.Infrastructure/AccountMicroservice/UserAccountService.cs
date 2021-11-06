using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Shopping.Infrastructure.AccountMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.AccountMicroservice
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IConfiguration _config;
        private readonly string _url;

        public UserAccountService(IConfiguration config)
        {
            _config = config;
            _url = _config.GetSection("Services:AccountMicroservice").Value;
        }

        public async Task<UserAccount> GetAccountByAccountId(long accountId, string token)
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await httpClient.GetAsync(_url + "/api/userAccount/" + accountId);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserAccount>(result);
        }
    }
}
