using Maniac.Model;
using Maniac.Model.Users;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Maniac.Api.Api
{
    public interface Users
    {
        [Get("/users/{user}/{mode}")]
        Task<Model.Beatmaps.User> GetUser([Authorize("Bearer")] string token, ulong user, string mode = "mania");

        [Get("/users/{user}/recent_activity?limit=limit&offset=offset")]
        Task<RecentActivity[]> GetUserRecentActivity(ulong user, int limit = 1, int offset = 0);

        [Get("/users/{user}/scores/{type}")]
        Task<UserScore[]> GetUserScore([Authorize("Bearer")] string token, ulong user, string type, string include_fails = "1", int limit = 1);
    }
}