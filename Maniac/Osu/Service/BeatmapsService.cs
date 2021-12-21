using Maniac.Api.Api;
using Maniac.Model;
using Maniac.Model.Auth;
using Maniac.Model.Beatmaps;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Maniac.Api
{
    public class BeatmapsService
    {
        private static readonly Beatmaps beatmaps;
        private static readonly Beatmaps beatmapsMulti;
        static BeatmapsService()
        {
            var httpClient = new HttpClient(new HttpClientDiagnosticsHandler(new HttpClientHandler())) { BaseAddress = new Uri(Bot.BaseUrlV2) };

            beatmaps = RestService.For<Beatmaps>(httpClient, new RefitSettings(new NewtonsoftJsonContentSerializer()));
        }

        public static BeatmapUserScore GetBeatmapUserScore(string token, long beatmap, ulong user, List<string> mods)
        {
            try
            {
                return beatmaps.GetBeatmapUserScore(Bot.Token.AccessToken, beatmap, user, mods.ToArray()).Result;
            }
            catch (AggregateException e)
            {
                return null;
            }
        }

        public static SearchBeatmap SearchBeatmap(string token, string q, string s)
        {
            return beatmaps.SearchBeatmap(token, q, s).Result;
        }

        public static GetBeatmap GetBeatmap(string token, long beatmapId)
        {
            return beatmaps.GetBeatmap(token, beatmapId).Result;
        }
    }
}