using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Maniac.Api;
using Maniac.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Maniac.Commands
{
    class RecentCommand : BaseCommandModule
    {
        [Command("recent")]
        public async Task recent(CommandContext ctx, string userId)
        {
            if(int.TryParse(userId, out int id))
            {
                Users users = new Users();
                Recent[] recent = users.getRecent(id).Result;
                if(recent.Length >= 1)
                {
                    Recent play = recent[0];
                    Beatmaps beatmaps = new Beatmaps();

                    Regex rx = new Regex(@"\d+");
                    Match match = rx.Match(play.Beatmap.Url);

                    BeatmapUserScore beatmapUserScore = await beatmaps.getUserBeatmapScore(id, int.Parse(match.Value));
                    BeatmapUserScore.ScoreObject score = beatmapUserScore.Score;
                    await ctx.Channel.SendMessageAsync("Beatmap: " + play.Beatmap.Title + "\n" +
                        "Accuracy: " + Math.Round(score.Accuracy * 100, 2) + "\n" +
                        "Bpm: " + score.Beatmap.Bpm + "\n" +
                        "SR: " + score.Beatmap.difficulty_rating + "\n" +
                        "HP: " + score.Beatmap.Hp + "\n" +
                        "OD: " + score.Beatmap.Od + "\n" +
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
    }
}
