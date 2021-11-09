using Maniac.Api.Api;
using Maniac.Model;
using Maniac.Model.Auth;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Maniac.Api
{
    public class BeatmapsService
    {
        private static readonly Beatmaps beatmaps;
        static BeatmapsService()
        {
            var httpClient = new HttpClient(new HttpClientDiagnosticsHandler(new HttpClientHandler())) { BaseAddress = new Uri(Bot.BaseUrl) };
            beatmaps = RestService.For<Beatmaps>(httpClient, new RefitSettings(new NewtonsoftJsonContentSerializer()));
        }

        public static BeatmapUserScore GetBeatmapUserScore(int beatmap, int user)
        {
            return beatmaps.GetBeatmapUserScore(beatmap, user).Result;
        }
    }
}
