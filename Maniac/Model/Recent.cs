using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maniac.Model
{
    class Recent
    {
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; private set; }
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("type")]
        public string Type { get; private set; }
        [JsonProperty("scoreRank")]
        public string ScoreRank { get; private set; }
        [JsonProperty("rank")]
        public int Rank { get; private set; }
        [JsonProperty("mode")]
        public string Mode { get; private set; }
        [JsonProperty("beatmap")]
        public BeatmapObject Beatmap { get; private set; }
        [JsonProperty("user")]
        public UserObject User { get; private set; }

        public class BeatmapObject
        {
            [JsonProperty("title")]
            public string Title { get; private set; }
            [JsonProperty("url")]
            public string Url { get; private set; }
        }

        public class UserObject
        {
            [JsonProperty("username")]
            public string Username { get; private set; }
            [JsonProperty("url")]
            public string Url { get; private set; }
        }
    }
}
