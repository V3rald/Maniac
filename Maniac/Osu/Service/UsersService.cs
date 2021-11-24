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
    public class UsersService
    {
        private static readonly Users users;
        static UsersService()
        {
            users = RestService.For<Users>(Bot.BaseUrl, new RefitSettings(new NewtonsoftJsonContentSerializer()));
        }

        public static RecentActivity[] GetUserRecentActivity(int user, int limit = 1, int offset = 0)
        {
            return users.GetUserRecentActivity(user, limit, offset).Result;
        }
    }
}