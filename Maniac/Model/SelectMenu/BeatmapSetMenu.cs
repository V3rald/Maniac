using Maniac.Model.Beatmaps;
using Maniac.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maniac.Model.BeatmapSetMenu
{
    public class BeatmapSetMenu
    {
        public string Query { get; set; }
        public List<BeatmapSet> BeatmapSets { get; set; }

        public BeatmapSetMenu(string query, List<BeatmapSet> beatmapSets)
        {
            Query = query;
            BeatmapSets = beatmapSets;
        }
    }
}
