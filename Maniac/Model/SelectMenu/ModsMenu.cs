using Maniac.Model.Beatmaps;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using static Maniac.Common.Constants;

namespace Maniac.Model.SelectMenu
{
    public class ModsMenu
    {
        public string Query { get; set; }
        public Beatmapset Beatmapset { get; set; }
        public List<string> Mods { get; set; }

        //public ModsMenu(string query, Beatmapset beatmapset, List<int> mods)
        //{
        //    Query = query;
        //    Beatmapset = beatmapset;
        //    List<string> ModsString = new List<string>();
        //    foreach (int mod in mods)
        //    {
        //        ModsString.Add(((Mods)mod).ToString());
        //    }
        //    Mods = new List<string>(ModsString);
        //}

        public ModsMenu(string query, Beatmapset beatmapset, List<string> mods)
        {
            Query = query;
            Beatmapset = beatmapset;
            Mods = mods;
        }
    }
}
