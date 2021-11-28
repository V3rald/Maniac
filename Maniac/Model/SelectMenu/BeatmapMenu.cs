using Maniac.Model.Beatmaps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maniac.Model.SelectMenu
{
    public class BeatmapMenu
    {
        public string Query { get; set; }
        public Beatmapset Beatmapset { get; set; }

        public BeatmapMenu(string query, Beatmapset beatmapset)
        {
            Query = query;
            Beatmapset = beatmapset;
        }
    }
}
