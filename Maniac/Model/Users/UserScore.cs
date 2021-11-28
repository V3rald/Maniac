using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using static Maniac.Common.Constants;

namespace Maniac.Model.Users
{
    public partial class UserScore
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("accuracy")]
        public double Accuracy { get; set; }

        [JsonProperty("mods")]
        public List<string> Mods { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }

        [JsonProperty("max_combo")]
        public long MaxCombo { get; set; }

        [JsonProperty("passed")]
        public bool Passed { get; set; }

        [JsonProperty("perfect")]
        public bool Perfect { get; set; }

        [JsonProperty("statistics")]
        public Statistics Statistics { get; set; }

        [JsonProperty("rank")]
        public string Rank { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("best_id")]
        public long? BestId { get; set; }

        [JsonProperty("pp")]
        public double? Pp { get; set; }

        [JsonProperty("mode")]
        public Mode Mode { get; set; }

        [JsonProperty("mode_int")]
        public long ModeInt { get; set; }

        [JsonProperty("replay")]
        public bool Replay { get; set; }

        [JsonProperty("beatmap")]
        public Beatmap Beatmap { get; set; }

        [JsonProperty("beatmapset")]
        public Beatmapset Beatmapset { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
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
        public object Hype { get; set; }

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
        public object TrackId { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("video")]
        public bool Video { get; set; }
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

    public partial class Statistics
    {
        [JsonProperty("count_50")]
        public long Count50 { get; set; }

        [JsonProperty("count_100")]
        public long Count100 { get; set; }

        [JsonProperty("count_300")]
        public long Count300 { get; set; }

        [JsonProperty("count_geki")]
        public long CountGeki { get; set; }

        [JsonProperty("count_katu")]
        public long CountKatu { get; set; }

        [JsonProperty("count_miss")]
        public long CountMiss { get; set; }
    }

    public partial class User
    {
        [JsonProperty("avatar_url")]
        public Uri AvatarUrl { get; set; }

        [JsonProperty("country_code")]
        public CountryCode CountryCode { get; set; }

        [JsonProperty("default_group")]
        public string DefaultGroup { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("is_bot")]
        public bool IsBot { get; set; }

        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("is_online")]
        public bool IsOnline { get; set; }

        [JsonProperty("is_supporter")]
        public bool IsSupporter { get; set; }

        [JsonProperty("last_visit")]
        public DateTimeOffset LastVisit { get; set; }

        [JsonProperty("pm_friends_only")]
        public bool PmFriendsOnly { get; set; }

        [JsonProperty("profile_colour")]
        public object ProfileColour { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public enum Rank { X, S, A, B, C, D, F };

    public enum CountryCode { Hu };

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

    internal class RankConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Rank) || t == typeof(Rank?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "X":
                    return Rank.X;
                case "S":
                    return Rank.S;
                case "A":
                    return Rank.A;
                case "B":
                    return Rank.B;
                case "C":
                    return Rank.C;
                case "D":
                    return Rank.D;
                case "F":
                    return Rank.F;
            }
            throw new Exception("Cannot unmarshal type Rank");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Rank)untypedValue;
            switch (value)
            {
                case Rank.X:
                    serializer.Serialize(writer, "X");
                    return;
                case Rank.S:
                    serializer.Serialize(writer, "S");
                    return;
                case Rank.A:
                    serializer.Serialize(writer, "A");
                    return;
                case Rank.B:
                    serializer.Serialize(writer, "B");
                    return;
                case Rank.C:
                    serializer.Serialize(writer, "C");
                    return;
                case Rank.D:
                    serializer.Serialize(writer, "D");
                    return;
                case Rank.F:
                    serializer.Serialize(writer, "F");
                    return;
            }
            throw new Exception("Cannot marshal type Rank");
        }

        public static readonly RankConverter Singleton = new RankConverter();
    }

    internal class CountryCodeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CountryCode) || t == typeof(CountryCode?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "HU")
            {
                return CountryCode.Hu;
            }
            throw new Exception("Cannot unmarshal type CountryCode");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CountryCode)untypedValue;
            if (value == CountryCode.Hu)
            {
                serializer.Serialize(writer, "HU");
                return;
            }
            throw new Exception("Cannot marshal type CountryCode");
        }

        public static readonly CountryCodeConverter Singleton = new CountryCodeConverter();
    }

    public partial class UserScore
    {
        public static List<UserScore> FromJson(string json) => JsonConvert.DeserializeObject<List<UserScore>>(json, Converter.Settings);
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
                RankConverter.Singleton,
                CountryCodeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
