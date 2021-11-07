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

namespace Maniac
{
    class Bot
    {
        static void Main(string[] args)
        {
            Run().GetAwaiter().GetResult();
        }

        public static DiscordClient Client { get; private set; }
        public static CommandsNextExtension Commands { get; private set; }
        static async Task Run()
        {
            Config config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("config.json"));

            Client = new DiscordClient(new DiscordConfiguration
            {
                Token = config.token,
                TokenType = TokenType.Bot,
            });

            Client.Ready += onReady;

            Commands = Client.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { config.prefix },
                EnableDms = false
            });

            Commands.RegisterCommands<PingCommand>();

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private static Task onReady(DiscordClient client, ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
