using System;
using Discord;
using DSharpPlus;
using System.Threading.Tasks;
using TokenType = DSharpPlus.TokenType;

namespace DisBotTry1
{
	public class Program
	{
            static DiscordClient discord;

            static void Main(string[] args)
            {
                MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
            }

            static async Task MainAsync(string[] args)
            {
                discord = new DiscordClient(new DiscordConfiguration
                {
                    Token =  "NzQ2MDI4NTU2MDE3OTkxNzUw.Xz6XPA.DRKCpUWy70FBD2VlwJH9BltK6 - 8" ,
                    TokenType = TokenType.Bot
                });

                discord.MessageCreated += async e =>
                {
                    string message = e.Message.Content;
                    if (e.Message.Content.ToLower().StartsWith("$"))
                        await e.Message.RespondAsync("Привет" + e.Message.Author + "ты сказал" + e.Message.Content);
                };

                await discord.ConnectAsync();
                await Task.Delay(-1);
            }
        }
    }
