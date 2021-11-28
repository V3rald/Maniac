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
            //var httpClient = new HttpClient(new HttpClientDiagnosticsHandler(new HttpClientHandler())) { BaseAddress = new Uri(Bot.BaseUrlV2) };
            users = RestService.For<Users>(Bot.BaseUrlV2, new RefitSettings(new NewtonsoftJsonContentSerializer()));
        }

        public static RecentActivity[] GetUserRecentActivity(ulong user, int limit = 1, int offset = 0)
        {
            return users.GetUserRecentActivity(user, limit, offset).Result;
        }

        public static UserScore[] GetUserScore(string token, ulong user, string type)
        {
            return users.GetUserScore(token, user, type).Result;
        }
    }
}