using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maniac.Model.Auth
{
    public class BeatmapUserScore
    {
        [JsonProperty("score")]
        public ScoreObject Score { get; set; }

        public class ScoreObject
        {
            [JsonProperty("accuracy")]
            public float Accuracy { get; set; }
            [JsonProperty("mods")]
            public List<string> Mods { get; set; }
            [JsonProperty("score")]
            public float Score { get; set; }
            [JsonProperty("max_combo")]
            public int MaxCombo { get; set; }
            [JsonProperty("passed")]
            public bool Passed { get; set; }
            [JsonProperty("perfect")]
            public bool Perfect { get; set; }
            [JsonProperty("statistics")]
            public StatisticsObject Statistics { get; set; }
            [JsonProperty("rank")]
            public string Rank { get; set; }
            [JsonProperty("pp")]
            public float? PP { get; set; }
            [JsonProperty("beatmap")]
            public BeatmapObject Beatmap { get; set; }
            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }

            public class StatisticsObject
            {
                [JsonProperty("count_50")]
                public int Count50 { get; set; }
                [JsonProperty("count_100")]
                public int Count100 { get; set; }
                [JsonProperty("count_katu")]
                public int Count200 { get; set; }
                [JsonProperty("count_300")]
                public int Count300 { get; set; }
                [JsonProperty("count_geki")]
                public int Count320 { get; set; }
                [JsonProperty("count_miss")]
                public int CountMiss { get; set; }
            }

            public class BeatmapObject
            {
                [JsonProperty("difficulty_rating")]
                public float DifficultyRating { get; set; }
                [JsonProperty("status")]
                public string Status { get; set; }
                [JsonProperty("total_length")]
                public int TotalLength { get; set; }
                [JsonProperty("accuracy")]
                public float OD { get; set; }
                [JsonProperty("drain")]
                public float HP { get; set; }
                [JsonProperty("bpm")]
                public float Bpm { get; set; }
            }
        }
    }
}