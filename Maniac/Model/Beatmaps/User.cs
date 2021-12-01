using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Maniac.Model.Beatmaps
{
    public partial class User
    {
        [JsonProperty("avatar_url")]
        public Uri AvatarUrl { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

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

        [JsonProperty("cover_url")]
        public Uri CoverUrl { get; set; }

        [JsonProperty("discord")]
        public object Discord { get; set; }

        [JsonProperty("has_supported")]
        public bool HasSupported { get; set; }

        [JsonProperty("interests")]
        public object Interests { get; set; }

        [JsonProperty("join_date")]
        public DateTimeOffset JoinDate { get; set; }

        [JsonProperty("kudosu")]
        public Kudosu Kudosu { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("max_blocks")]
        public long MaxBlocks { get; set; }

        [JsonProperty("max_friends")]
        public long MaxFriends { get; set; }

        [JsonProperty("occupation")]
        public string Occupation { get; set; }

        [JsonProperty("playmode")]
        public string Playmode { get; set; }

        [JsonProperty("playstyle")]
        public List<string> Playstyle { get; set; }

        [JsonProperty("post_count")]
        public long PostCount { get; set; }

        [JsonProperty("profile_order")]
        public List<string> ProfileOrder { get; set; }

        [JsonProperty("title")]
        public object Title { get; set; }

        [JsonProperty("title_url")]
        public object TitleUrl { get; set; }

        [JsonProperty("twitter")]
        public object Twitter { get; set; }

        [JsonProperty("website")]
        public object Website { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("cover")]
        public Cover Cover { get; set; }

        [JsonProperty("account_history")]
        public List<object> AccountHistory { get; set; }

        [JsonProperty("active_tournament_banner")]
        public object ActiveTournamentBanner { get; set; }

        [JsonProperty("badges")]
        public List<object> Badges { get; set; }

        [JsonProperty("beatmap_playcounts_count")]
        public long BeatmapPlaycountsCount { get; set; }

        [JsonProperty("comments_count")]
        public long CommentsCount { get; set; }

        [JsonProperty("favourite_beatmapset_count")]
        public long FavouriteBeatmapsetCount { get; set; }

        [JsonProperty("follower_count")]
        public long FollowerCount { get; set; }

        [JsonProperty("graveyard_beatmapset_count")]
        public long GraveyardBeatmapsetCount { get; set; }

        [JsonProperty("groups")]
        public List<object> Groups { get; set; }

        [JsonProperty("loved_beatmapset_count")]
        public long LovedBeatmapsetCount { get; set; }

        [JsonProperty("mapping_follower_count")]
        public long MappingFollowerCount { get; set; }

        [JsonProperty("monthly_playcounts")]
        public List<Count> MonthlyPlaycounts { get; set; }

        [JsonProperty("page")]
        public Page Page { get; set; }

        [JsonProperty("pending_beatmapset_count")]
        public long PendingBeatmapsetCount { get; set; }

        [JsonProperty("previous_usernames")]
        public List<string> PreviousUsernames { get; set; }

        [JsonProperty("ranked_beatmapset_count")]
        public long RankedBeatmapsetCount { get; set; }

        [JsonProperty("replays_watched_counts")]
        public List<Count> ReplaysWatchedCounts { get; set; }

        [JsonProperty("scores_best_count")]
        public long ScoresBestCount { get; set; }

        [JsonProperty("scores_first_count")]
        public long ScoresFirstCount { get; set; }

        [JsonProperty("scores_recent_count")]
        public long ScoresRecentCount { get; set; }

        [JsonProperty("statistics")]
        public Statistics Statistics { get; set; }

        [JsonProperty("support_level")]
        public long SupportLevel { get; set; }

        [JsonProperty("user_achievements")]
        public List<UserAchievement> UserAchievements { get; set; }

        [JsonProperty("rankHistory")]
        public RankHistory RankHistory { get; set; }

        [JsonProperty("rank_history")]
        public RankHistory UserRankHistory { get; set; }

        [JsonProperty("ranked_and_approved_beatmapset_count")]
        public long RankedAndApprovedBeatmapsetCount { get; set; }

        [JsonProperty("unranked_beatmapset_count")]
        public long UnrankedBeatmapsetCount { get; set; }
    }

    public partial class Country
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Cover
    {
        [JsonProperty("custom_url")]
        public Uri CustomUrl { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("id")]
        public object Id { get; set; }
    }

    public partial class Kudosu
    {
        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("available")]
        public long Available { get; set; }
    }

    public partial class Count
    {
        [JsonProperty("start_date")]
        public DateTimeOffset StartDate { get; set; }

        [JsonProperty("count")]
        public long CountCount { get; set; }
    }

    public partial class Page
    {
        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("raw")]
        public string Raw { get; set; }
    }

    public partial class RankHistory
    {
        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("data")]
        public List<long> Data { get; set; }
    }

    public partial class Statistics
    {
        [JsonProperty("level")]
        public Level Level { get; set; }

        [JsonProperty("global_rank")]
        public long GlobalRank { get; set; }

        [JsonProperty("pp")]
        public double Pp { get; set; }

        [JsonProperty("ranked_score")]
        public long RankedScore { get; set; }

        [JsonProperty("hit_accuracy")]
        public double HitAccuracy { get; set; }

        [JsonProperty("play_count")]
        public long PlayCount { get; set; }

        [JsonProperty("play_time")]
        public long PlayTime { get; set; }

        [JsonProperty("total_score")]
        public long TotalScore { get; set; }

        [JsonProperty("total_hits")]
        public long TotalHits { get; set; }

        [JsonProperty("maximum_combo")]
        public long MaximumCombo { get; set; }

        [JsonProperty("replays_watched_by_others")]
        public long ReplaysWatchedByOthers { get; set; }

        [JsonProperty("is_ranked")]
        public bool IsRanked { get; set; }

        [JsonProperty("grade_counts")]
        public GradeCounts GradeCounts { get; set; }

        [JsonProperty("country_rank")]
        public long CountryRank { get; set; }

        [JsonProperty("rank")]
        public Rank Rank { get; set; }

        [JsonProperty("variants")]
        public List<Variant> Variants { get; set; }
    }

    public partial class GradeCounts
    {
        [JsonProperty("ss")]
        public long Ss { get; set; }

        [JsonProperty("ssh")]
        public long Ssh { get; set; }

        [JsonProperty("s")]
        public long S { get; set; }

        [JsonProperty("sh")]
        public long Sh { get; set; }

        [JsonProperty("a")]
        public long A { get; set; }
    }

    public partial class Level
    {
        [JsonProperty("current")]
        public long Current { get; set; }

        [JsonProperty("progress")]
        public long Progress { get; set; }
    }

    public partial class Rank
    {
        [JsonProperty("country")]
        public long Country { get; set; }
    }

    public partial class Variant
    {
        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("variant")]
        public string VariantVariant { get; set; }

        [JsonProperty("country_rank")]
        public long CountryRank { get; set; }

        [JsonProperty("global_rank")]
        public long GlobalRank { get; set; }

        [JsonProperty("pp")]
        public double Pp { get; set; }
    }

    public partial class UserAchievement
    {
        [JsonProperty("achieved_at")]
        public DateTimeOffset AchievedAt { get; set; }

        [JsonProperty("achievement_id")]
        public long AchievementId { get; set; }
    }

    public partial class User
    {
        public static User FromJson(string json) => JsonConvert.DeserializeObject<User>(json, UserConverter.Settings);
    }

    public static class UserSerialize
    {
        public static string ToJson(this User self) => JsonConvert.SerializeObject(self, UserConverter.Settings);
    }

    internal static class UserConverter
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