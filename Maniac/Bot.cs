using Maniac.Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
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

namespace Maniac
{
    class Bot
    {
        static void Main(string[] args)
        {
            Run().GetAwaiter().GetResult();
        }
        public static string BaseUrl = "https://osu.ppy.sh";
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

            Commands = Client.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { Config.prefix },
                EnableDms = false
            });

            Commands.RegisterCommands<PingCommand>();
            Commands.RegisterCommands<RecentCommand>();

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private static Task onReady(DiscordClient client, ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
