using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Maniac.Model.Beatmaps
{
    public partial class GetBeatmap
    {
        [JsonProperty("beatmapset_id")]
        public long BeatmapsetId { get; set; }

        [JsonProperty("difficulty_rating")]
        public double DifficultyRating { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("total_length")]
        public long TotalLength { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("accuracy")]
        public double Accuracy { get; set; }

        [JsonProperty("ar")]
        public long Ar { get; set; }

        [JsonProperty("bpm")]
        public long Bpm { get; set; }

        [JsonProperty("convert")]
        public bool Convert { get; set; }

        [JsonProperty("count_circles")]
        public long CountCircles { get; set; }

        [JsonProperty("count_sliders")]
        public long CountSliders { get; set; }

        [JsonProperty("count_spinners")]
        public long CountSpinners { get; set; }

        [JsonProperty("cs")]
        public long Cs { get; set; }

        [JsonProperty("deleted_at")]
        public object DeletedAt { get; set; }

        [JsonProperty("drain")]
        public double Drain { get; set; }

        [JsonProperty("hit_length")]
        public long HitLength { get; set; }

        [JsonProperty("is_scoreable")]
        public bool IsScoreable { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("mode_int")]
        public long ModeInt { get; set; }

        [JsonProperty("passcount")]
        public long Passcount { get; set; }

        [JsonProperty("playcount")]
        public long Playcount { get; set; }

        [JsonProperty("ranked")]
        public long Ranked { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("checksum")]
        public string Checksum { get; set; }

        [JsonProperty("beatmapset")]
        public Beatmapset Beatmapset { get; set; }

        [JsonProperty("failtimes")]
        public Failtimes Failtimes { get; set; }

        [JsonProperty("max_combo")]
        public object MaxCombo { get; set; }
    }

    public partial class Failtimes
    {
        [JsonProperty("fail")]
        public List<long> Fail { get; set; }

        [JsonProperty("exit")]
        public List<long> Exit { get; set; }
    }

    public partial class GetBeatmapDeserialize
    {
        public static GetBeatmap FromJson(string json) => JsonConvert.DeserializeObject<GetBeatmap>(json, GetBeatmapConverter.Settings);
    }

    public static class GetBeatmapSerialize
    {
        public static string ToJson(this GetBeatmap self) => JsonConvert.SerializeObject(self, GetBeatmapConverter.Settings);
    }

    internal static class GetBeatmapConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
