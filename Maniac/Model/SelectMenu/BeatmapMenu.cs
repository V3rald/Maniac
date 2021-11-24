using Maniac.Model.Beatmaps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maniac.Model.SelectMenu
{
    public class BeatmapMenu
    {
        public string Query { get; set; }
        public List<SearchBeatmap.BeatmapsetObject.BeatmapObject> Beatmaps { get; set; }

        public BeatmapMenu(string query, List<SearchBeatmap.BeatmapsetObject.BeatmapObject> beatmaps)
        {
            Query = query;
            Beatmaps = beatmaps;
        }
    }
}
