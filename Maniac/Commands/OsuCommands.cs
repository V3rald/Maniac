using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Maniac.Api;
using Maniac.Model;
using Maniac.Model.Auth;
using Maniac.Model.Beatmaps;
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
        [Command("recent")]
        public async Task recent(CommandContext ctx, string userId)
        {
            if (int.TryParse(userId, out int id))
            {
                RecentActivity[] recentActivity = UsersService.GetUserRecentActivity(id);
                if (recentActivity.Length >= 1)
                {
                    RecentActivity play = recentActivity[0];

                    Regex rx = new Regex(@"\d+");
                    Match match = rx.Match(play.Beatmap.Url);

                    BeatmapUserScore beatmapUserScore = BeatmapsService.GetBeatmapUserScore(Bot.Token.AccessToken, int.Parse(match.Value), id);
                    BeatmapUserScore.ScoreObject score = beatmapUserScore.Score;
                    await ctx.Channel.SendMessageAsync("Beatmap: " + play.Beatmap.Title + "\n" +
                        "Accuracy: " + Math.Round(score.Accuracy * 100, 2) + "\n" +
                        "Bpm: " + score.Beatmap.Bpm + "\n" +
                        "SR: " + score.Beatmap.DifficultyRating + "\n" +
                        "HP: " + score.Beatmap.HP + "\n" +
                        "OD: " + score.Beatmap.OD + "\n" +
                        "Status: " + score.Beatmap.Status + "\n" +
                        "Length: " + score.Beatmap.TotalLength + "\n" +
                        "Max Combo: " + score.MaxCombo + "\n" +
                        "Mods: " + string.Join(", ", score.Mods) + "\n" +
                        "PP: " + score.PP + "\n" +
                        "Score: " + score.Score + "\n" +
                        "Miss: " + score.Statistics.CountMiss + "\n" +
                        "50: " + score.Statistics.Count50 + "\n" +
                        "100: " + score.Statistics.Count100 + "\n" +
                        "200: " + score.Statistics.Count200 + "\n" +
                        "300: " + score.Statistics.Count300 + "\n" +
                        "320: " + score.Statistics.Count320
                        ).ConfigureAwait(false);
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
        public async Task search(CommandContext ctx, string q)
        {
            SearchBeatmap searchBeatmap = BeatmapsService.SearchBeatmap(Bot.Token.AccessToken, q);
            var filteredBeatmapSets = searchBeatmap.beatmapsets.Where(p => p.beatmaps.Any(b => b.mode == "mania")).ToList();

            List<DiscordSelectComponentOption> menuItems = new List<DiscordSelectComponentOption>();
            for (int i = 0; i < Math.Min(25, filteredBeatmapSets.Count); i++)
            {
                var beatmapSet = filteredBeatmapSets[i];
                string json = JsonConvert.SerializeObject(new Dictionary<string, string>()
                {
                    { "type", "beatmapset" },
                    { "i", i.ToString() },
                    { "q", q },
                    { "b", beatmapSet.id.ToString() }
                });
                menuItems.Add(new DiscordSelectComponentOption($"{beatmapSet.artist}: {beatmapSet.title}", $"{json}", $"Status: {beatmapSet.status}"));
            }

            var dropdown = new DiscordSelectComponent("dropdown", null, menuItems, false, 1, 1);

            var builder = new DiscordMessageBuilder().WithContent($"Search for {q}").AddComponents(dropdown);

            await ctx.Channel.SendMessageAsync(builder);

            Console.WriteLine(ctx.User.Username + $" used command: {ctx.Command.Name} {q}");
        }
    }
}