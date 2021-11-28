using Maniac.Model;
using Maniac.Model.Auth;
using Maniac.Model.Beatmaps;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Maniac.Api.Api
{
    public interface Beatmaps
    {
        [Get("/beatmaps/{beatmap}/scores/users/{user}")]
        Task<BeatmapUserScore> GetBeatmapUserScore([Authorize("Bearer")] string token, long beatmap, ulong user, [Query(CollectionFormat.Multi), AliasAs("mods[]")] string[] mods);

        [Get("/beatmapsets/search")]
        Task<SearchBeatmap> SearchBeatmap([Authorize("Bearer")] string token, string q, string s);
    }
}