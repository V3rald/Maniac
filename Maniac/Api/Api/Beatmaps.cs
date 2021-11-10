using Maniac.Model;
using Maniac.Model.Auth;
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
        Task<BeatmapUserScore> GetBeatmapUserScore(int beatmap, int user);
    }
}