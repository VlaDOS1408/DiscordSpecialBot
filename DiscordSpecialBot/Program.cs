using Discord;
using Discord.WebSocket;

namespace DiscordSpecialBot
{
    internal class Program
    {
        private readonly static DiscordSocketClient _client = new();

        private readonly static int _indexOfTokenInLaunchArgs = 0;

        private static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                throw new Exception("Please specify the bot token in the launch arguments.");
            }

            _client.Log += Log;

            await _client.LoginAsync(TokenType.Bot, args[_indexOfTokenInLaunchArgs]);

            await _client.StartAsync();
        }

        private static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
