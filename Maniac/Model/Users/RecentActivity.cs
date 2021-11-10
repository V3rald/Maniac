using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maniac.Model
{
    public class RecentActivity
    {
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("scoreRank")]
        public string ScoreRank { get; set; }
        [JsonProperty("rank")]
        public int Rank { get; set; }
        [JsonProperty("mode")]
        public string Mode { get; set; }
        [JsonProperty("beatmap")]
        public BeatmapObject Beatmap { get; set; }
        [JsonProperty("user")]
        public UserObject User { get; set; }

        public class BeatmapObject
        {
            [JsonProperty("title")]
            public string Title { get; set; }
            [JsonProperty("url")]
            public string Url { get; set; }
        }

        public class UserObject
        {
            [JsonProperty("username")]
            public string Username { get; set; }
            [JsonProperty("url")]
            public string Url { get; set; }
        }
    }
}