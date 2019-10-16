using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace DiscordBot.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {
        [Command("echo")]
        public async Task Echo([Remainder]string message)
        {
            var embed = new EmbedBuilder();
            embed.WithTitle(Utilities.GetAlert("ECHO"));
            embed.WithDescription(message);
            embed.WithColor(new Color(0, 255, 0));

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }

        [Command("roll")]
        public async Task Roll([Remainder]string message)
        {
            var options = message.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var rand = new Random();
            var output = rand.Next(int.Parse(options[0]), int.Parse(options[1])+1).ToString();

            var embed = new EmbedBuilder();
            embed.WithTitle(Utilities.GetAlert("&NAME_ROLL", Context.User.Username));
            embed.WithDescription(output);
            embed.WithColor(new Color(250, 135, 236));
            embed.WithThumbnailUrl(Context.User.GetAvatarUrl());

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }

        [Command("pickone")]
        public async Task PickOne([Remainder]string message)
        {
            var options = message.Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);

            var rand = new Random();
            var selection = options[rand.Next(0, options.Length)];

            var embed = new EmbedBuilder();
            embed.WithTitle(Utilities.GetAlert("&MESSAGE_CHOSEN", message));
            embed.WithDescription(selection);
            embed.WithColor(new Color(255, 0, 0));
            embed.WithThumbnailUrl(Context.User.GetAvatarUrl());

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }

        [Command("secret")]
        public async Task Secret(string message)
        {
            var found = false;

            foreach (var user in Context.Guild.Users)
            {
                if (user.Username.Equals(message, StringComparison.CurrentCultureIgnoreCase))
                {
                    var dmChannel = await Context.User.GetOrCreateDMChannelAsync();
                    await dmChannel.SendMessageAsync(Utilities.GetAlert("SECRET"));
                    found = true;
                }
            }

            if (!found) await Context.Channel.SendMessageAsync(Utilities.GetAlert("NOT_FOUND", message));
        }
    }
}
