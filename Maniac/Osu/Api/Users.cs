using Maniac.Model;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Maniac.Api.Api
{
    public interface Users
    {
        [Get("/users/{user}/recent_activity?limit=limit&offset=offset")]
        Task<RecentActivity[]> GetUserRecentActivity(ulong user, int limit = 1, int offset = 0);
    }
}