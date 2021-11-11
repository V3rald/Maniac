﻿using Maniac.Model;
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
        Task<BeatmapUserScore> GetBeatmapUserScore([Authorize("Bearer")] string token, int beatmap, int user);

        [Get("/beatmapsets/search")]
        Task<SearchBeatmap> SearchBeatmap([Authorize("Bearer")] string token, string q);
    }
}