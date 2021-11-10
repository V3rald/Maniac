using Maniac.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Maniac.Api
{
    class Beatmaps
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        public async Task<BeatmapUserScore> getUserBeatmapScore(int userId, int beatmapId, string gameMode = "mania")
        {
            return JsonConvert.DeserializeObject<BeatmapUserScore>(await HttpClient.GetStringAsync($"https://osu.ppy.sh/beatmaps/{beatmapId}/scores/users/{userId}?mode={gameMode}"));
        }
    }
}
