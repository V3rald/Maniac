using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Maniac.Api;
using Maniac.Common;
using Maniac.Model;
using Maniac.Model.Auth;
using Maniac.Model.Beatmaps;
using Maniac.Model.SelectMenu;
using Maniac.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
                if(DB.getUser(discordUserId) != null)
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

        [Command("recent")]
        public async Task recent(CommandContext ctx, string userId)
        {
            if (ulong.TryParse(userId, out ulong id))
            {
                RecentActivity[] recentActivity = UsersService.GetUserRecentActivity(id);
                if (recentActivity.Length >= 1)
                {
                    //RecentActivity play = recentActivity[0];

                    //Regex rx = new Regex(@"\d+");
                    //Match match = rx.Match(play.Beatmap.Url);

                    //BeatmapUserScore beatmapUserScore = BeatmapsService.GetBeatmapUserScore(Bot.Token.AccessToken, long.Parse(match.Value), id);
                    //BeatmapUserScore.ScoreObject score = beatmapUserScore.Score;
                    //await ctx.Channel.SendMessageAsync("Beatmap: " + play.Beatmap.Title + "\n" +
                    //    "Accuracy: " + Math.Round(score.Accuracy * 100, 2) + "\n" +
                    //    "Bpm: " + score.Beatmap.Bpm + "\n" +
                    //    "SR: " + score.Beatmap.DifficultyRating + "\n" +
                    //    "HP: " + score.Beatmap.HP + "\n" +
                    //    "OD: " + score.Beatmap.OD + "\n" +
                    //    "Status: " + score.Beatmap.Status + "\n" +
                    //    "Length: " + score.Beatmap.TotalLength + "\n" +
                    //    "Max Combo: " + score.MaxCombo + "\n" +
                    //    "Mods: " + string.Join(", ", score.Mods) + "\n" +
                    //    "PP: " + score.PP + "\n" +
                    //    "Score: " + score.Score + "\n" +
                    //    "Miss: " + score.Statistics.CountMiss + "\n" +
                    //    "50: " + score.Statistics.Count50 + "\n" +
                    //    "100: " + score.Statistics.Count100 + "\n" +
                    //    "200: " + score.Statistics.Count200 + "\n" +
                    //    "300: " + score.Statistics.Count300 + "\n" +
                    //    "320: " + score.Statistics.Count320
                    //    ).ConfigureAwait(false);
                }
                else
                {
                    await ctx.Channel.SendMessageAsync("Nincs recentje bruh").ConfigureAwait(false);
                }

                Console.WriteLine(ctx.User.Username + $" used command: {ctx.Command.Name} {userId}");
            }
            else
            {
                await ctx.Channel.SendMessageAsync("bruh").ConfigureAwait(false);
            }
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