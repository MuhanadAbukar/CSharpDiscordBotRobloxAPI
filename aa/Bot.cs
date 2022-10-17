using aa.Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Emzi0767.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aa
{
    public class Bot
    {
        public DiscordClient ?Client { get; private set; }
        public CommandsNextExtension ?Commands { get; private set; }
        public async Task RunAsync()
        {
            var json = string.Empty;
            using (var fs = File.OpenRead("config.json"))
            {
                using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                {
                    json = await sr.ReadToEndAsync().ConfigureAwait(false);
                }
            }

            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);
            var config = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                
            };
            Client = new DiscordClient(config);
            Client.MessageCreated += Respond;
            Client.Ready += OnClientReady;
            var commandConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableMentionPrefix = true,
                EnableDms = false
            };
            Commands = Client.UseCommandsNext(commandConfig);
            Commands.RegisterCommands<AOTPcommands>();
            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private async Task Respond(DiscordClient client, MessageCreateEventArgs e)
        {
            if (e.Message.ToString().ToLower().Contains("when")|| e.Message.ToString().ToLower().Contains("what")|| e.Message.ToString().ToLower().Contains("where")|| e.Message.ToString().ToLower().Contains("why")|| e.Message.ToString().ToLower().Contains("who"))
            {
                await e.Channel.SendMessageAsync("Only I know");
            }
        }

        private Task OnClientReady(DiscordClient client, ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
      
    }
}
