using Maniac.Api.Api;
using Maniac.Model;
using Maniac.Model.Auth;
using Maniac.Model.Beatmaps;
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
            var httpClient = new HttpClient(new HttpClientDiagnosticsHandler(new HttpClientHandler())) { BaseAddress = new Uri(Bot.BaseUrlV2) };
            beatmaps = RestService.For<Beatmaps>(httpClient, new RefitSettings(new NewtonsoftJsonContentSerializer()));
        }

        public static BeatmapUserScore GetBeatmapUserScore(string token, int beatmap, int user)
        {
            return beatmaps.GetBeatmapUserScore(token, beatmap, user).Result;
        }

        public static SearchBeatmap SearchBeatmap(string token, string q)
        {
            return beatmaps.SearchBeatmap(token, q).Result;
        }
    }
}