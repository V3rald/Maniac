using Maniac.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Maniac.Api
{
    class Authentication
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        public async Task<Token> getToken()
        {
            Config config = Bot.Config;
            var body = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "client_id", config.ClientId },
                { "client_secret", config.ClientSecret },
                { "grant_type", "client_credentials" },
                { "scope", "public" }
            });

            var response = await HttpClient.PostAsync("https://osu.ppy.sh/oauth/token", body);

            return JsonConvert.DeserializeObject<Token>(await response.Content.ReadAsStringAsync());
        }
    }
}
