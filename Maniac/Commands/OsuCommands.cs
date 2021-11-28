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
                DB.addUser(discordUserId, osuUserId);

                await ctx.Channel.SendMessageAsync("Linked!").ConfigureAwait(false);
            }
            else
            {
                await ctx.Channel.SendMessageAsync("bruh").ConfigureAwait(false);
            }
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