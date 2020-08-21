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
                        await e.Message.RespondAsync("Привет, " + e.Author.Username + ", ты сказал: " + e.Message.Content);
                    if (e.Message.Content.ToLower().StartsWith("?"))
                        await e.Message.RespondAsync("https://www.youtube.com/watch?v=Q5glfpSXUeE");
                    if (e.Message.Content.ToLower().StartsWith("!жрать"))
                        await e.Message.RespondAsync("https://www.youtube.com/watch?v=5wY6SyKBi5U");
                };

                await discord.ConnectAsync();
                await Task.Delay(-1);
            }
        }
    }
