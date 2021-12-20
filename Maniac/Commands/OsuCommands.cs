using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Maniac.Api;
using Maniac.Common;
using Maniac.Model;
using Maniac.Model.Auth;
using Maniac.Model.Beatmaps;
using Maniac.Model.SelectMenu;
using Maniac.Model.Users;
using Maniac.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Maniac.Common.Constants;

namespace Maniac.Commands
{
    class OsuCommands : BaseCommandModule
    {
        [Command("link")]
        public async Task link(CommandContext ctx, string id)
        {
            if (ulong.TryParse(id, out ulong osuUserId))
            {
                ulong discordUserId = ctx.User.Id;
                if(DB.getUser(discordUserId) == null)
                {
                    DB.addUser(discordUserId, osuUserId);
                    await ctx.Channel.SendMessageAsync("Linked!").ConfigureAwait(false);
                    return;
                }
            }

            await ctx.Channel.SendMessageAsync("bruh").ConfigureAwait(false);
        }

        [Command("pp")]
        public async Task maniapp(CommandContext ctx, double sr, float od, int score, int oc)
        {
            double m = 0;
            double l;
            double k;
            double scaler;
            scaler = 0.8;
            l = Math.Pow(5 * Math.Max(1, sr / 0.2) - 4, 2.2) / 135 * (1 + 0.1 * Math.Min(1, oc / 1500));
            k = od / 10 * 0.2 * l * Math.Pow((Math.Max(score, 960000) - 960000) / 40000, 1.1);
            if (score <= 500000)
            {
                m = 0.0 * (score / 500000);
            }
            else if (score <= 600000)
            {
                m = 0.3 * ((score - 500000) / 100000) + 0.0;
            }
            else if (score <= 700000)
            {
                m = 0.25 * ((score - 600000) / 100000) + 0.3;
            }
            else if (score <= 800000)
            {
                m = 0.2 * ((score - 700000) / 100000) + 0.55;
            }
            else if (score <= 900000)
            {
                m = 0.15 * ((score - 800000) / 100000) + 0.75;
            }
            else if (score >= 900000)
            {
                m = 0.1 * ((score - 900000) / 100000) + 0.9;
            }
            double pp = Math.Pow(Math.Pow(k, 1.1) + Math.Pow(l * m, 1.1), 1 / 1.1) * scaler;
            await ctx.Channel.SendMessageAsync($"{Math.Round(pp, 2)}").ConfigureAwait(false);
        }


        [Command("c")]
        public async Task compare(CommandContext ctx, string userNameOrId = null)
        {
            LastBeatmap lastBeatmap = DB.getLastBeatmap();
            if(lastBeatmap == null)
            {
                await ctx.Channel.SendMessageAsync("bruh").ConfigureAwait(false);
                return;
            }

            ulong id;
            User user;

            if (string.IsNullOrEmpty(userNameOrId))
            {
                ulong? getuser = DB.getUser(ctx.User.Id);
                if (!getuser.HasValue)
                {
                    await ctx.Channel.SendMessageAsync("bruh link when").ConfigureAwait(false);
                    return;
                }
                id = getuser.Value;
                user = UsersService.GetUser(Bot.Token.AccessToken, id.ToString(), "mania");
            }
            else
            {
                user = UsersService.GetUser(Bot.Token.AccessToken, userNameOrId, "mania");
                id = user.Id;
            }


            GetBeatmap beatmap = BeatmapsService.GetBeatmap(Bot.Token.AccessToken, lastBeatmap.BeatmapId);
            Model.Beatmaps.Beatmapset beatmapSet = beatmap.Beatmapset;
            BeatmapUserScore score = BeatmapsService.GetBeatmapUserScore(Bot.Token.AccessToken, lastBeatmap.BeatmapId, id, lastBeatmap.Mods);

            DiscordEmbedBuilder embedBuilder = new DiscordEmbedBuilder();
            embedBuilder.WithAuthor(String.Format("{0}: {1}pp | #{2} | {3} #{4} | [{5}]", user.Username, user.Statistics.Pp, user.Statistics.GlobalRank, user.CountryCode, user.Statistics.CountryRank, beatmap.Mode));

            embedBuilder.WithThumbnail(beatmapSet.Covers.List2X);

            embedBuilder.WithTitle(String.Format("{0} - {1} [{2}] ({3})", beatmapSet.Artist, beatmapSet.Title, beatmap.Version, beatmapSet.Creator));
            embedBuilder.WithUrl("https://www.google.com/");

            embedBuilder.AddField(String.Format("Score: {0} {1} | Acc: {2}% {3}", score.Score.Score, (string.Join("", score.Score.Mods).Length > 0 ? ("+" + string.Join("", score.Score.Mods)) : ""), Math.Round(score.Score.Accuracy * 100, 2), score.Score.Rank),
                                                String.Format("Combo: {0}x [{1}/{2}/{3}/{4}/{5}/{6}]\n", score.Score.MaxCombo,
                                                                score.Score.Statistics.Count320, score.Score.Statistics.Count300, score.Score.Statistics.Count200, score.Score.Statistics.Count100, score.Score.Statistics.Count50, score.Score.Statistics.CountMiss, false));

            embedBuilder.AddField(String.Format("BPM: {0} | OD: {1} | SR: {2}", beatmap.Bpm, beatmap.Accuracy, beatmap.DifficultyRating),
                                                    String.Format("Length: {0} | Drain: {1} | HP:{2}", beatmap.TotalLength, beatmap.HitLength, beatmap.Drain), false);

            embedBuilder.AddField(String.Format("pp: {0} / {1}", (score.Score.PP > 0 ? score.Score.PP.ToString() : "0"), "maxpp"), "_ _", false);


            //if exists
            //embedBuilder.WithFooter(String.Format("#{0} top play", "69"));

            embedBuilder.WithTimestamp(score.Score.CreatedAt);

            DiscordEmbed recentEmbed = embedBuilder.Build();
            await ctx.Channel.SendMessageAsync(recentEmbed);
        }

        [Command("r")]
        public async Task recent(CommandContext ctx, string userNameOrId=null)
        {
            if (string.IsNullOrEmpty(userNameOrId))
            {
                ulong? getuser = DB.getUser(ctx.User.Id);
                if (!getuser.HasValue)
                {
                    await ctx.Channel.SendMessageAsync("bruh link when").ConfigureAwait(false);
                    return;
                }
                userNameOrId = getuser.Value.ToString();
            }

            User user = UsersService.GetUser(Bot.Token.AccessToken, userNameOrId, "mania");
            UserScore[] recentActivity = UsersService.GetUserScore(Bot.Token.AccessToken, user.Id, "recent");

            if (recentActivity.Length >= 1)
            {
                UserScore score = recentActivity[0];
                Model.Users.Beatmap beatmap = recentActivity[0].Beatmap;
                Model.Users.Beatmapset beatmapSet = recentActivity[0].Beatmapset;

                DiscordEmbedBuilder embedBuilder = new DiscordEmbedBuilder();
                embedBuilder.WithAuthor(String.Format("{0}: {1}pp | #{2} | {3} #{4} | [{5}]", user.Username, user.Statistics.Pp, user.Statistics.GlobalRank, user.CountryCode, user.Statistics.CountryRank, score.Mode));

                embedBuilder.WithThumbnail(beatmapSet.Covers.List2X);

                embedBuilder.WithTitle(String.Format("{0} - {1} [{2}] ({3})", beatmapSet.Artist, beatmapSet.Title, beatmap.Version, beatmapSet.Creator));
                embedBuilder.WithUrl("https://www.google.com/");

                embedBuilder.AddField(String.Format("Score: {0} {1} | Acc: {2}% {3}", score.Score, (string.Join("", score.Mods).Length > 0 ? ("+" + string.Join("", score.Mods)) : ""), Math.Round(score.Accuracy * 100, 2), score.Rank),
                                                    String.Format("Combo: {0}x [{1}/{2}/{3}/{4}/{5}/{6}]\n", score.MaxCombo,
                                                                    score.Statistics.CountGeki, score.Statistics.Count300, score.Statistics.CountKatu, score.Statistics.Count100, score.Statistics.Count50, score.Statistics.CountMiss, false));

                embedBuilder.AddField(String.Format("BPM: {0} | OD: {1} | SR: {2}", beatmap.Bpm, beatmap.Accuracy, beatmap.DifficultyRating),
                                                        String.Format("Length: {0} | Drain: {1} | HP:{2}", beatmap.TotalLength, beatmap.HitLength, beatmap.Drain), false);

                embedBuilder.AddField(String.Format("pp: {0} / {1}", (score.Pp > 0 ? score.Pp.ToString() : "0"), "maxpp"), "_ _", false);


                //if exists
                //embedBuilder.WithFooter(String.Format("#{0} top play", "69"));

                embedBuilder.WithTimestamp(score.CreatedAt);

                DiscordEmbed recentEmbed = embedBuilder.Build();
                await ctx.Channel.SendMessageAsync(recentEmbed);
                DB.setLastBeatmap(new LastBeatmap(beatmap.Id, score.Mods));
            }
            else
            {
                await ctx.Channel.SendMessageAsync("Nincs recentje bruh").ConfigureAwait(false);
            }

            Console.WriteLine(ctx.User.Username + $" used command: {ctx.Command.Name} {userNameOrId}");
        }

        [Command("search")]
        public async Task search(CommandContext ctx, params string[] args)
        {
            ulong messageId = ctx.Message.Id;
            string q = string.Join(" ", args);
            List<DiscordSelectComponentOption> statusItems = new List<DiscordSelectComponentOption>();
            foreach(var status in Enum.GetValues(typeof(Status)))
            {
                statusItems.Add(new DiscordSelectComponentOption($"{status}", $"status:{(int)status}"));
            }
            var dropdown = new DiscordSelectComponent("dropdown", null, statusItems, false, 1, 1);
            var builder = new DiscordMessageBuilder().WithContent($"Search for {q}").AddComponents(dropdown);
            var interactionMessage = await ctx.Channel.SendMessageAsync(builder);

            StatusMenu data = new StatusMenu(q);
            SelectMenuUtil.Menus.Add(messageId, JsonConvert.SerializeObject(data));
            SelectMenuUtil.MessageId.Add(interactionMessage.Id, messageId);
            SelectMenuUtil.UserId.Add(interactionMessage.Id, ctx.User.Id);

            Console.WriteLine(ctx.User.Username + $" used command: {ctx.Command.Name} {q}");
        }
    }
}