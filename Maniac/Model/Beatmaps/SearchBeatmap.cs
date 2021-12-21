using Maniac.Model.Common;
using Maniac.Model.Converter;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using static Maniac.Common.Constants;

namespace Maniac.Model.Beatmaps
{
    public partial class SearchBeatmap
    {
        [JsonProperty("beatmapsets")]
        public List<BeatmapSet> BeatmapSets { get; set; }

        [JsonProperty("cursor")]
        public Cursor Cursor { get; set; }

        [JsonProperty("search")]
        public Search Search { get; set; }

        [JsonProperty("recommended_difficulty")]
        public object RecommendedDifficulty { get; set; }

        [JsonProperty("error")]
        public object Error { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }
    }

    public partial class Cursor
    {
        [JsonProperty("_score")]
        public double Score { get; set; }

        [JsonProperty("_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }
    }

    public partial class Search
    {
        [JsonProperty("sort")]
        public string Sort { get; set; }
    }

    public partial class SearchBeatmap
    {
        public static SearchBeatmap FromJson(string json) => JsonConvert.DeserializeObject<SearchBeatmap>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this SearchBeatmap self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ModeConverter.Singleton,
                StatusConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
