using Maniac.Model.Beatmaps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maniac.Model.BeatmapSetMenu
{
    public class BeatmapSetMenu
    {
        public string Query { get; set; }
        public List<SearchBeatmap.BeatmapsetObject> BeatmapSets { get; set; }

        public BeatmapSetMenu(string query, List<SearchBeatmap.BeatmapsetObject> beatmapSets)
        {
            Query = query;
            BeatmapSets = beatmapSets;
        }
    }
}
