using Maniac.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Maniac.Api
{
    class Users
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public async Task<Recent[]> getRecent(int userId, int limit=1, int offset=0)
        {
            return JsonConvert.DeserializeObject<Recent[]>(await HttpClient.GetStringAsync($"https://osu.ppy.sh/users/{userId}/recent_activity?limit={limit}&offset={offset}"));
        }
    }
}
