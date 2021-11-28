using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Maniac.Model.Beatmaps
{
    public partial class SearchBeatmap
    {
        [JsonProperty("beatmapsets")]
        public List<Beatmapset> Beatmapsets { get; set; }

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

    public partial class Beatmapset
    {
        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("artist_unicode")]
        public string ArtistUnicode { get; set; }

        [JsonProperty("covers")]
        public Covers Covers { get; set; }

        [JsonProperty("creator")]
        public string Creator { get; set; }

        [JsonProperty("favourite_count")]
        public long FavouriteCount { get; set; }

        [JsonProperty("hype")]
        public NominationsSummary Hype { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nsfw")]
        public bool Nsfw { get; set; }

        [JsonProperty("play_count")]
        public long PlayCount { get; set; }

        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("title_unicode")]
        public string TitleUnicode { get; set; }

        [JsonProperty("track_id")]
        public long? TrackId { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("video")]
        public bool Video { get; set; }

        [JsonProperty("availability")]
        public Availability Availability { get; set; }

        [JsonProperty("bpm")]
        public double Bpm { get; set; }

        [JsonProperty("can_be_hyped")]
        public bool CanBeHyped { get; set; }

        [JsonProperty("discussion_enabled")]
        public bool DiscussionEnabled { get; set; }

        [JsonProperty("discussion_locked")]
        public bool DiscussionLocked { get; set; }

        [JsonProperty("is_scoreable")]
        public bool IsScoreable { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("legacy_thread_url")]
        public Uri LegacyThreadUrl { get; set; }

        [JsonProperty("nominations_summary")]
        public NominationsSummary NominationsSummary { get; set; }

        [JsonProperty("ranked")]
        public long Ranked { get; set; }

        [JsonProperty("ranked_date")]
        public DateTimeOffset? RankedDate { get; set; }

        [JsonProperty("storyboard")]
        public bool Storyboard { get; set; }

        [JsonProperty("submitted_date")]
        public DateTimeOffset SubmittedDate { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("beatmaps")]
        public List<Beatmap> Beatmaps { get; set; }
    }

    public partial class Availability
    {
        [JsonProperty("download_disabled")]
        public bool DownloadDisabled { get; set; }

        [JsonProperty("more_information")]
        public object MoreInformation { get; set; }
    }

    public partial class Beatmap
    {
        [JsonProperty("beatmapset_id")]
        public long BeatmapsetId { get; set; }

        [JsonProperty("difficulty_rating")]
        public double DifficultyRating { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("mode")]
        public Mode Mode { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("total_length")]
        public long TotalLength { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("accuracy")]
        public double Accuracy { get; set; }

        [JsonProperty("ar")]
        public double Ar { get; set; }

        [JsonProperty("bpm")]
        public double Bpm { get; set; }

        [JsonProperty("convert")]
        public bool Convert { get; set; }

        [JsonProperty("count_circles")]
        public long CountCircles { get; set; }

        [JsonProperty("count_sliders")]
        public long CountSliders { get; set; }

        [JsonProperty("count_spinners")]
        public long CountSpinners { get; set; }

        [JsonProperty("cs")]
        public double Cs { get; set; }

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

        [JsonProperty("max_combo")]
        public long? MaxCombo { get; set; }
    }

    public partial class Covers
    {
        [JsonProperty("cover")]
        public Uri Cover { get; set; }

        [JsonProperty("cover@2x")]
        public Uri Cover2X { get; set; }

        [JsonProperty("card")]
        public Uri Card { get; set; }

        [JsonProperty("card@2x")]
        public Uri Card2X { get; set; }

        [JsonProperty("list")]
        public Uri List { get; set; }

        [JsonProperty("list@2x")]
        public Uri List2X { get; set; }

        [JsonProperty("slimcover")]
        public Uri Slimcover { get; set; }

        [JsonProperty("slimcover@2x")]
        public Uri Slimcover2X { get; set; }
    }

    public partial class NominationsSummary
    {
        [JsonProperty("current")]
        public long Current { get; set; }

        [JsonProperty("required")]
        public long NominationsSummaryRequired { get; set; }
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

    public enum Mode { Fruits, Mania, Osu, Taiko };

    public enum Status { Ranked, Loved, Graveyard, Pending, Approved, Qualified, Wip, Any };

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

    internal class ModeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Mode) || t == typeof(Mode?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "fruits":
                    return Mode.Fruits;
                case "mania":
                    return Mode.Mania;
                case "osu":
                    return Mode.Osu;
                case "taiko":
                    return Mode.Taiko;
            }
            throw new Exception("Cannot unmarshal type Mode");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Mode)untypedValue;
            switch (value)
            {
                case Mode.Fruits:
                    serializer.Serialize(writer, "fruits");
                    return;
                case Mode.Mania:
                    serializer.Serialize(writer, "mania");
                    return;
                case Mode.Osu:
                    serializer.Serialize(writer, "osu");
                    return;
                case Mode.Taiko:
                    serializer.Serialize(writer, "taiko");
                    return;
            }
            throw new Exception("Cannot marshal type Mode");
        }

        public static readonly ModeConverter Singleton = new ModeConverter();
    }

    internal class StatusConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Status) || t == typeof(Status?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ranked":
                    return Status.Ranked;
                case "loved":
                    return Status.Loved;
                case "graveyard":
                    return Status.Graveyard;
                case "pending":
                    return Status.Pending;
                case "approved":
                    return Status.Approved;
                case "qualified":
                    return Status.Qualified;
                case "wip":
                    return Status.Wip;
                case "any":
                    return Status.Any;
            }
            throw new Exception("Cannot unmarshal type Status");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Status)untypedValue;
            switch (value)
            {
                case Status.Ranked:
                    serializer.Serialize(writer, "ranked");
                    return;
                case Status.Loved:
                    serializer.Serialize(writer, "loved");
                    return;
                case Status.Graveyard:
                    serializer.Serialize(writer, "graveyard");
                    return;
                case Status.Pending:
                    serializer.Serialize(writer, "pending");
                    return;
                case Status.Approved:
                    serializer.Serialize(writer, "approved");
                    return;
                case Status.Qualified:
                    serializer.Serialize(writer, "qualified");
                    return;
                case Status.Wip:
                    serializer.Serialize(writer, "wip");
                    return;
                case Status.Any:
                    serializer.Serialize(writer, "any");
                    return;
            }
            throw new Exception("Cannot marshal type Status");
        }

        public static readonly StatusConverter Singleton = new StatusConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
