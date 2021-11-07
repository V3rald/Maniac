using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Maniac.Api;
using Maniac.Model;
using System;
using System.Collections.Generic;
using System.Text;
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
                    await ctx.Channel.SendMessageAsync(play.User.Username + ": " + play.Beatmap.Title).ConfigureAwait(false);
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
