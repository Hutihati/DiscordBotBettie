using System;
using System.Collections.Generic;
using System.Linq;
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
            embed.WithTitle("Echoed message :smile:");
            embed.WithDescription(message);
            embed.WithColor(new Color(0, 255, 0));

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }

        [Command("roll")]
        public async Task Roll([Remainder]string message)
        {
            string[] options = message.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Random rand = new Random();
            string output = rand.Next(int.Parse(options[0]), int.Parse(options[1])+1).ToString();

            var embed = new EmbedBuilder();
            embed.WithTitle(Context.User.Username + " rolled:");
            embed.WithDescription(output);
            embed.WithColor(new Color(250, 135, 236));
            embed.WithThumbnailUrl(Context.User.GetAvatarUrl());

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }

        [Command("pickone")]
        public async Task PickOne([Remainder]string message)
        {
            string[] options = message.Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);

            Random rand = new Random();
            string selection = options[rand.Next(0, options.Length)];

            var embed = new EmbedBuilder();
            embed.WithTitle("From " + message + " i chose:");
            embed.WithDescription(selection);
            embed.WithColor(new Color(255, 0, 0));
            embed.WithThumbnailUrl(Context.User.GetAvatarUrl());

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
    }
}
