using System;
using System.IO;
using System.Text;
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
            StreamReader fs = new StreamReader("Token.txt");
            string s = "";
            s = fs.ReadLine();
            discord = new DiscordClient(new DiscordConfiguration
                {
                    Token = s,
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
                    if (e.Message.Content.ToLower().StartsWith("!подскажи билд"))
                        await e.Message.RespondAsync("@Дракон, тебя спрашивают!");
                    if (e.Message.Content.StartsWith("ГГГ пидоры!"))
                        await e.Message.RespondAsync("Пидоры ебаные!");
                };

                await discord.ConnectAsync();
                await Task.Delay(-1);
            }
        }
    }
