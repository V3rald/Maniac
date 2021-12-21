using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using Maniac.Api;
using Maniac.Model;
using Maniac.Model.Auth;
using Maniac.Model.Beatmaps;
using Maniac.Model.BeatmapSetMenu;
using Maniac.Model.Common;
using Maniac.Model.SelectMenu;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Maniac.Common.Constants;
using static Maniac.Model.Converter.ModeConverter;
using static Maniac.Model.Converter.StatusConverter;

namespace Maniac.Util
{
    public class SelectMenuUtil
    {
        public static Dictionary<ulong, string> Menus = new Dictionary<ulong, string>();
        public static Dictionary<ulong, ulong> MessageId = new Dictionary<ulong, ulong>();
        public static Dictionary<ulong, ulong> UserId = new Dictionary<ulong, ulong>();

        public static async void BeatmapSetInteraction(ComponentInteractionCreateEventArgs e, ulong messageId, BeatmapSetMenu beatmapSetMenu, int id)
        {
            List<DiscordSelectComponentOption> menuItems = new List<DiscordSelectComponentOption>();
            foreach (var mod in Enum.GetValues(typeof(Mods)))
            {
                menuItems.Add(new DiscordSelectComponentOption($"{ mod }", $"mods:{(int)mod}"));
            }

            var dropdown = new DiscordSelectComponent("dropdown", "test", menuItems, false, 1, Enum.GetValues(typeof(Mods)).Length);

            var builder = new DiscordMessageBuilder().WithContent($"Search for {beatmapSetMenu.Query}").AddComponents(dropdown);

            await e.Message.ModifyAsync(builder).ConfigureAwait(false);

            BeatmapMenu data = new BeatmapMenu(beatmapSetMenu.Query, beatmapSetMenu.BeatmapSets[id]);
            Menus[messageId] = JsonConvert.SerializeObject(data);
        }

        public static async void ModsInteraction(ComponentInteractionCreateEventArgs e, ulong messageId, BeatmapMenu beatmapMenu, List<int> ids)
        {
            List<DiscordSelectComponentOption> menuItems = new List<DiscordSelectComponentOption>();

            for (int i = 0; i < Math.Min(25, beatmapMenu.BeatmapSet.Beatmaps.Count); i++)
            {
                var beatmap = beatmapMenu.BeatmapSet.Beatmaps[i];
                menuItems.Add(new DiscordSelectComponentOption($"{beatmap.Version}", $"beatmap:{i}", $"id: {beatmap.Id}"));
            }

            var dropdown = new DiscordSelectComponent("dropdown", null, menuItems, false, 1, 1);

            var builder = new DiscordMessageBuilder().WithContent($"Search for {beatmapMenu.Query}").AddComponents(dropdown);

            await e.Message.ModifyAsync(builder).ConfigureAwait(false);

            List<string> modsString = new List<string>();
            foreach(var id in ids)
            {
                modsString.Add(((Mods)id).ToString());
            }

            ModsMenu data = new ModsMenu(beatmapMenu.Query, beatmapMenu.BeatmapSet, modsString);
            Menus[messageId] = JsonConvert.SerializeObject(data);
        }

        public static async void BeatmapInteraction(ComponentInteractionCreateEventArgs e, int id, ModsMenu modsMenu)
        {
            var builder = new DiscordMessageBuilder();
            var beatmap = modsMenu.BeatmapSet.Beatmaps[id];
            ulong? userId = DB.getUser(e.User.Id);

            if (userId.HasValue)
            {
                BeatmapUserScore score = BeatmapsService .GetBeatmapUserScore(Bot.Token.AccessToken, beatmap.Id, userId.Value, modsMenu.Mods);
                if (score == null)
                {
                    builder.WithContent("No score bruh");
                    await e.Message.ModifyAsync(builder).ConfigureAwait(false);
                    return;
                }

                string mods = string.Join(", ", score.Score.Mods);
                if (string.IsNullOrEmpty(mods)) mods = "NM";

                var embedBuilder = new DiscordEmbedBuilder();
                embedBuilder.WithTitle(modsMenu.BeatmapSet.Title + " - " + beatmap.Version);

                embedBuilder.AddField("SR", score.Score.Beatmap.DifficultyRating.ToString(), true);
                embedBuilder.AddField("HP", score.Score.Beatmap.HP.ToString(), true);
                embedBuilder.AddField("OD", score.Score.Beatmap.OD.ToString(), true);

                embedBuilder.AddField("Score", score.Score.Score.ToString(), true);
                embedBuilder.AddField("Accuracy", Math.Round(score.Score.Accuracy * 100, 2).ToString(), true);
                embedBuilder.AddField("PP", score.Score.PP.ToString(), true);


                embedBuilder.AddField("Bpm", score.Score.Beatmap.Bpm.ToString(), true);
                embedBuilder.AddField("Length", score.Score.Beatmap.TotalLength.ToString(), true);
                embedBuilder.AddField("Mods", mods, true);

                embedBuilder.AddField("320", score.Score.Statistics.Count320.ToString(), true);
                embedBuilder.AddField("300", score.Score.Statistics.Count300.ToString(), true);
                embedBuilder.AddField("200", score.Score.Statistics.Count200.ToString(), true);

                embedBuilder.AddField("100", score.Score.Statistics.Count100.ToString(), true);
                embedBuilder.AddField("50", score.Score.Statistics.Count50.ToString(), true);
                embedBuilder.AddField("Miss", score.Score.Statistics.CountMiss.ToString(), true);

                builder.WithEmbed(embedBuilder.Build());

                await e.Message.ModifyAsync(builder).ConfigureAwait(false);
                DB.setLastBeatmap(new LastBeatmap(beatmap.Id, score.Score.Mods));

                return;
            }

            builder.WithContent("Bruh link when");
            await e.Message.ModifyAsync(builder).ConfigureAwait(false);
        }

        public static async void StatusInteraction(ComponentInteractionCreateEventArgs e, ulong messageId, StatusMenu statusMenu, int selectId)
        {
            Status status = (Status)selectId;
            SearchBeatmap searchBeatmap = BeatmapsService.SearchBeatmap(Bot.Token.AccessToken, statusMenu.Query, status.ToString().ToLower());
            var filteredBeatmapSets = searchBeatmap.BeatmapSets.Where(p => p.Beatmaps.Any(b => b.Mode == Mode.Mania)).ToList();
            var beatmapSets = new List<BeatmapSet>();

            List<DiscordSelectComponentOption> menuItems = new List<DiscordSelectComponentOption>();
            for (int i = 0; i < Math.Min(25, filteredBeatmapSets.Count); i++)
            {
                var beatmapSet = filteredBeatmapSets[i];
                beatmapSets.Add(beatmapSet);
                menuItems.Add(new DiscordSelectComponentOption($"{beatmapSet.Artist}: {beatmapSet.Title}", $"beatmapset:{i}", $"Status: {beatmapSet.Status}"));
            }

            var dropdown = new DiscordSelectComponent("dropdown", null, menuItems, false, 1, 1);

            var builder = new DiscordMessageBuilder().WithContent($"Search for {statusMenu.Query}").AddComponents(dropdown);

            await e.Message.ModifyAsync(builder).ConfigureAwait(false);

            BeatmapSetMenu data = new BeatmapSetMenu(statusMenu.Query, beatmapSets);
            Menus[messageId] = JsonConvert.SerializeObject(data);
        }
    }
}
