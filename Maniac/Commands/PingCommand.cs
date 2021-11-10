using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Maniac.Commands
{
    class PingCommand : BaseCommandModule
    {
        [Command("ping")]
        public async Task ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync(ctx.Client.Ping + " ms").ConfigureAwait(false);

            Console.WriteLine(ctx.User.Username + $" used command: {ctx.Command.Name}");
        }
    }
}
