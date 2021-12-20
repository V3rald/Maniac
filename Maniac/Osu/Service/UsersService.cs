using Maniac.Api.Api;
using Maniac.Model;
using Maniac.Model.Auth;
using Maniac.Model.Users;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Maniac.Api
{
    public class UsersService
    {
        private static readonly Users users;
        static UsersService()
        {
            var httpClient = new HttpClient(new HttpClientDiagnosticsHandler(new HttpClientHandler())) { BaseAddress = new Uri(Bot.BaseUrlV2) };
            users = RestService.For<Users>(httpClient, new RefitSettings(new NewtonsoftJsonContentSerializer()));
        }

        public static User GetUser(string token, string userNameOrId, string mode = "mania")
        {
            return users.GetUser(token, userNameOrId, mode).Result;
        }
        public static RecentActivity[] GetUserRecentActivity(ulong user, int limit = 1, int offset = 0)
        {
            return users.GetUserRecentActivity(user, limit, offset).Result;
        }

        public static UserScore[] GetUserScore(string token, ulong userId, string type)
        {
            return users.GetUserScore(token, userId, type).Result;
        }
    }
}