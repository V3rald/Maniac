using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maniac.Model.Beatmaps
{
    public class SearchBeatmap
    {
        public List<BeatmapsetObject> beatmapsets { get; set; }
        public object cursor { get; set; }
        public SearchObject search { get; set; }
        public object recommended_difficulty { get; set; }
        public object error { get; set; }
        public int total { get; set; }

        public class BeatmapsetObject
        {
            public string artist { get; set; }
            public string artist_unicode { get; set; }
            public CoversObject covers { get; set; }
            public string creator { get; set; }
            public int favourite_count { get; set; }
            public object hype { get; set; }
            public int id { get; set; }
            public bool nsfw { get; set; }
            public int play_count { get; set; }
            public string preview_url { get; set; }
            public string source { get; set; }
            public string status { get; set; }
            public string title { get; set; }
            public string title_unicode { get; set; }
            public object track_id { get; set; }
            public int user_id { get; set; }
            public bool video { get; set; }
            public AvailabilityObject availability { get; set; }
            public int bpm { get; set; }
            public bool can_be_hyped { get; set; }
            public bool discussion_enabled { get; set; }
            public bool discussion_locked { get; set; }
            public bool is_scoreable { get; set; }
            public DateTime last_updated { get; set; }
            public string legacy_thread_url { get; set; }
            public NominationsSummaryObject nominations_summary { get; set; }
            public int ranked { get; set; }
            public DateTime ranked_date { get; set; }
            public bool storyboard { get; set; }
            public DateTime submitted_date { get; set; }
            public string tags { get; set; }
            public List<BeatmapObject> beatmaps { get; set; }

            public class CoversObject
            {
                public string cover { get; set; }

                [JsonProperty("cover@2x")]
                public string Cover2x { get; set; }
                public string card { get; set; }

                [JsonProperty("card@2x")]
                public string Card2x { get; set; }
                public string list { get; set; }

                [JsonProperty("list@2x")]
                public string List2x { get; set; }
                public string slimcover { get; set; }

                [JsonProperty("slimcover@2x")]
                public string Slimcover2x { get; set; }
            }

            public class AvailabilityObject
            {
                public bool download_disabled { get; set; }
                public object more_information { get; set; }
            }

            public class NominationsSummaryObject
            {
                public int current { get; set; }
                public int required { get; set; }
            }

            public class BeatmapObject
            {
                public int beatmapset_id { get; set; }
                public double difficulty_rating { get; set; }
                public int id { get; set; }
                public string mode { get; set; }
                public string status { get; set; }
                public int total_length { get; set; }
                public int user_id { get; set; }
                public string version { get; set; }
                public double accuracy { get; set; }
                public double ar { get; set; }
                public int bpm { get; set; }
                public bool convert { get; set; }
                public int count_circles { get; set; }
                public int count_sliders { get; set; }
                public int count_spinners { get; set; }
                public double cs { get; set; }
                public object deleted_at { get; set; }
                public double drain { get; set; }
                public int hit_length { get; set; }
                public bool is_scoreable { get; set; }
                public DateTime last_updated { get; set; }
                public int mode_int { get; set; }
                public int passcount { get; set; }
                public int playcount { get; set; }
                public int ranked { get; set; }
                public string url { get; set; }
                public string checksum { get; set; }
                public int? MaxCombo { get; set; }
            }
        }

        public class SearchObject
        {
            public string sort { get; set; }
        }
    }
}
