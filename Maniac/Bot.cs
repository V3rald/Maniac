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
using Maniac.Util;
using Maniac.Model.SelectMenu;
using System.Linq;
using Maniac.Model.BeatmapSetMenu;
using DSharpPlus.Exceptions;

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
                Timeout = TimeSpan.FromSeconds(60),
                ResponseMessage = "asd"
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
            var interactionId = e.Message.Id;
            var userId = SelectMenuUtil.UserId[interactionId];
            if (userId != e.User.Id)
            {
                try
                {
                    await e.Interaction.CreateResponseAsync(InteractionResponseType.DeferredMessageUpdate);
                }
                catch (NotFoundException e2)
                {

                }
                return;
            }

            var messageId = SelectMenuUtil.MessageId[interactionId];
            var json = SelectMenuUtil.Menus[messageId];

            var type = e.Values[0].Split(':')[0];
            List<int> selectId = new List<int>();
            foreach(var value in e.Values)
            {
                selectId.Add(int.Parse(value.Split(':')[1]));
            }

            switch (type)
            {
                case "status":
                    SelectMenuUtil.StatusInteraction(e, messageId, JsonConvert.DeserializeObject<StatusMenu>(json), selectId[0]);
                    break;
                case "beatmapset":
                    SelectMenuUtil.BeatmapSetInteraction(e, messageId, JsonConvert.DeserializeObject<BeatmapSetMenu>(json), selectId[0]);
                    break;
                case "mods":
                    SelectMenuUtil.ModsInteraction(e, messageId, JsonConvert.DeserializeObject<BeatmapMenu>(json), selectId);
                    break;
                case "beatmap":
                    SelectMenuUtil.BeatmapInteraction(e, selectId[0], JsonConvert.DeserializeObject<ModsMenu>(json));
                    break;
            }

            try
            {
                await e.Interaction.CreateResponseAsync(InteractionResponseType.DeferredMessageUpdate);
            }catch(NotFoundException e2)
            {

            }
        }

        private static Task onReady(DiscordClient client, ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}