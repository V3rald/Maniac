using Maniac.Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Maniac.Api;
using Maniac.Model;
using Maniac.Model.Auth;
using System.Net.Http;
using Refit;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Enums;
using Maniac.Model.Beatmaps;
using DSharpPlus.Entities;

namespace Maniac
{
    class Bot
    {
        static void Main(string[] args)
        {
            Run().GetAwaiter().GetResult();
        }
        public static string BaseUrl = "https://osu.ppy.sh";
        public static string BaseUrlV2 = "https://osu.ppy.sh/api/v2";
        public static DiscordClient Client { get; private set; }
        public static CommandsNextExtension Commands { get; private set; }
        public static Config Config { get; private set; }
        public static Token Token { get; private set; }
        static async Task Run()
        {
            Config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("config.json"));

            Token = AuthService.GetToken(new GetToken(Config.ClientId, Config.ClientSecret, "client_credentials", "public"));

            Client = new DiscordClient(new DiscordConfiguration
            {
                Token = Config.token,
                TokenType = TokenType.Bot,
            });

            Client.Ready += onReady;

            Client.UseInteractivity(new InteractivityConfiguration()
            {
                PollBehaviour = PollBehaviour.KeepEmojis,
            });

            Client.ComponentInteractionCreated += OnComponentInteractionCreated;

            Commands = Client.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { Config.prefix },
                EnableDms = false
            });

            Commands.RegisterCommands<PingCommand>();
            Commands.RegisterCommands<OsuCommands>();

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private static async Task OnComponentInteractionCreated(DiscordClient sender, ComponentInteractionCreateEventArgs e)
        {
            var response = JsonConvert.DeserializeObject<Dictionary<string, string>>(e.Values[0]);
            var type = response["type"];
            switch (type)
            {
                case "beatmapset":
                    var q = response["q"];
                    var beatmapId = response["b"];
                    SearchBeatmap searchBeatmap = BeatmapsService.SearchBeatmap(Token.AccessToken, q);
                    var beatmaps = new List<SearchBeatmap.BeatmapsetObject.BeatmapObject>();
                    foreach (var beatmapSet in searchBeatmap.beatmapsets)
                    {
                        if (beatmapSet.id.ToString() == beatmapId)
                        {
                            beatmaps.AddRange(beatmapSet.beatmaps);
                            break;
                        }
                    }

                    List<DiscordSelectComponentOption> menuItems = new List<DiscordSelectComponentOption>();
                    for (int i = 0; i < Math.Min(25, beatmaps.Count); i++)
                    {
                        var beatmap = beatmaps[i];
                        Dictionary<string, string> id = new Dictionary<string, string>()
                        {
                            { "type", "beatmap" },
                            { "i", i.ToString() },
                            { "b", beatmap.id.ToString() }
                        };
                        string json = JsonConvert.SerializeObject(id);
                        menuItems.Add(new DiscordSelectComponentOption($"{beatmap.version}", $"{json}", $"id: {beatmap.beatmapset_id}"));
                    }

                    var dropdown = new DiscordSelectComponent("dropdown", null, menuItems, false, 1, 1);

                    var builder = new DiscordMessageBuilder().WithContent($"Search for {q}").AddComponents(dropdown);

                    await e.Message.ModifyAsync(builder).ConfigureAwait(false);
                    break;
                case "beatmap":
                    var selectedBuilder = new DiscordMessageBuilder().WithContent("Selected!");
                    await e.Message.ModifyAsync(selectedBuilder).ConfigureAwait(false);
                    break;
            }

            await e.Interaction.CreateResponseAsync(InteractionResponseType.DeferredMessageUpdate);
        }

        private static Task onReady(DiscordClient client, ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}