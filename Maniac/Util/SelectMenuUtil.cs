using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using Maniac.Api;
using Maniac.Model.Beatmaps;
using Maniac.Model.BeatmapSetMenu;
using Maniac.Model.SelectMenu;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Maniac.Common.Constants;

namespace Maniac.Util
{
    public class SelectMenuUtil
    {
        public static Dictionary<ulong, string> Menus = new Dictionary<ulong, string>();
        public static Dictionary<ulong, ulong> MessageId = new Dictionary<ulong, ulong>();
        public static Dictionary<ulong, ulong> UserId = new Dictionary<ulong, ulong>();

        public static async void StatusInteraction(ComponentInteractionCreateEventArgs e, ulong messageId, StatusMenu statusMenu, int selectId)
        {
            Status status = (Status)selectId;
            SearchBeatmap searchBeatmap = BeatmapsService.SearchBeatmap(Bot.Token.AccessToken, statusMenu.Query, status.ToString().ToLower());
            var filteredBeatmapSets = searchBeatmap.beatmapsets.Where(p => p.beatmaps.Any(b => b.mode == "mania")).ToList();
            List<SearchBeatmap.BeatmapsetObject> beatmapSets = new List<SearchBeatmap.BeatmapsetObject>();

            List<DiscordSelectComponentOption> menuItems = new List<DiscordSelectComponentOption>();
            for (int i = 0; i < Math.Min(25, filteredBeatmapSets.Count); i++)
            {
                var beatmapSet = filteredBeatmapSets[i];
                beatmapSets.Add(beatmapSet);
                menuItems.Add(new DiscordSelectComponentOption($"{beatmapSet.artist}: {beatmapSet.title}", $"beatmapset:{i}", $"Status: {beatmapSet.status}"));
            }

            var dropdown = new DiscordSelectComponent("dropdown", null, menuItems, false, 1, 1);

            var builder = new DiscordMessageBuilder().WithContent($"Search for {statusMenu.Query}").AddComponents(dropdown);

            await e.Message.ModifyAsync(builder).ConfigureAwait(false);

            BeatmapSetMenu data = new BeatmapSetMenu(statusMenu.Query, beatmapSets);
            Menus[messageId] = JsonConvert.SerializeObject(data);
        }

        public static async void BeatmapSetInteraction(ComponentInteractionCreateEventArgs e, ulong messageId, BeatmapSetMenu beatmapSetMenu, int selectId)
        {
            int beatmapSetId = beatmapSetMenu.BeatmapSets[selectId].id;
            var beatmaps = new List<SearchBeatmap.BeatmapsetObject.BeatmapObject>();

            foreach (var beatmapSet in beatmapSetMenu.BeatmapSets)
            {
                if (beatmapSet.id == beatmapSetId)
                {
                    beatmaps.AddRange(beatmapSet.beatmaps);
                    break;
                }
            }

            List<DiscordSelectComponentOption> menuItems = new List<DiscordSelectComponentOption>();
            for (int i = 0; i < Math.Min(25, beatmaps.Count); i++)
            {
                var beatmap = beatmaps[i];
                menuItems.Add(new DiscordSelectComponentOption($"{beatmap.version}", $"beatmap:{i}", $"id: {beatmap.id}"));
            }

            var dropdown = new DiscordSelectComponent("dropdown", null, menuItems, false, 1, 1);

            var builder = new DiscordMessageBuilder().WithContent($"Search for {beatmapSetMenu.Query}").AddComponents(dropdown);

            await e.Message.ModifyAsync(builder).ConfigureAwait(false);

            BeatmapMenu data = new BeatmapMenu(beatmapSetMenu.Query, beatmaps);
            Menus[messageId] = JsonConvert.SerializeObject(data);
        }
    }
}
