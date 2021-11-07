using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maniac.Model
{
    class BeatmapUserScore
    {
        [JsonProperty("score")]
        public ScoreObject Score { get; private set; }

        public class ScoreObject
        {
            [JsonProperty("accuracy")]
            public float Accuracy { get; private set; }
            [JsonProperty("mods")]
            public List<string> Mods { get; private set; }
            [JsonProperty("score")]
            public float Score { get; private set; }
            [JsonProperty("max_combo")]
            public int MaxCombo { get; private set; }
            [JsonProperty("passed")]
            public bool Passed { get; private set; }
            [JsonProperty("perfect")]
            public bool Perfect { get; private set; }
            [JsonProperty("statistics")]
            public StatisticsObject Statistics { get; private set; }
            [JsonProperty("rank")]
            public string Rank { get; private set; }
            [JsonProperty("pp")]
            public float? PP { get; private set; }
            [JsonProperty("beatmap")]
            public BeatmapObject Beatmap { get; private set; }

            public class StatisticsObject
            {
                [JsonProperty("count_50")]
                public int Count50 { get; private set; }
                [JsonProperty("count_100")]
                public int Count100 { get; private set; }
                [JsonProperty("count_katu")]
                public int Count200 { get; private set; }
                [JsonProperty("count_300")]
                public int Count300 { get; private set; }
                [JsonProperty("count_geki")]
                public int Count320 { get; private set; }
                [JsonProperty("count_miss")]
                public int CountMiss { get; private set; }
            }

            public class BeatmapObject
            {
                [JsonProperty("difficulty_rating")]
                public float difficulty_rating { get; private set; }
                [JsonProperty("status")]
                public string Status { get; private set; }
                [JsonProperty("total_length")]
                public int TotalLength { get; private set; }
                [JsonProperty("accuracy")]
                public float Od { get; private set; }
                [JsonProperty("drain")]
                public float Hp { get; private set; }
                [JsonProperty("bpm")]
                public float Bpm { get; private set; }
            }
        }
    }
}
