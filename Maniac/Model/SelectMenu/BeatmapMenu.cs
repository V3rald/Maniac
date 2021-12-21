using Maniac.Model.Beatmaps;
using Maniac.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maniac.Model.SelectMenu
{
    public class BeatmapMenu
    {
        public string Query { get; set; }
        public BeatmapSet BeatmapSet { get; set; }

        public BeatmapMenu(string query, BeatmapSet beatmapset)
        {
            Query = query;
            BeatmapSet = beatmapset;
        }
    }
}
