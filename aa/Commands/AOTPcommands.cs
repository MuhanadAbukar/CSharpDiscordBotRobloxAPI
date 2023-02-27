using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace aa.Commands
{


    public class UniversePlaces
    {
        public Datum45[]? data { get; set; }
    }

    public class Datum45
    {
        public long id { get; set; }
        public long rootPlaceId { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? sourceName { get; set; }
        public string? sourceDescription { get; set; }
        public Creator? creator { get; set; }
        public object? price { get; set; }
        public string[]? allowedGearGenres { get; set; }
        public object[]? allowedGearCategories { get; set; }
        public bool? isGenreEnforced { get; set; }
        public bool? copyingAllowed { get; set; }
        public int playing { get; set; }
        public int visits { get; set; }
        public int maxPlayers { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public bool studioAccessToApisAllowed { get; set; }
        public bool createVipServersAllowed { get; set; }
        public string? universeAvatarType { get; set; }
        public string? genre { get; set; }
        public bool isAllGenre { get; set; }
        public bool isFavoritedByUser { get; set; }
        public int favoritedCount { get; set; }
    }

    public class Creator
    {
        public int id { get; set; }
        public string ?name { get; set; }
        public string ?type { get; set; }
        public bool isRNVAccount { get; set; }
        public bool hasVerifiedBadge { get; set; }
    }

    public class PlayersInPlace
    {
        public object? previousPageCursor { get; set; }
        public object? nextPageCursor { get; set; }
        public Datum2[]? data { get; set; }
    }

    public class Datum2
    {
        public string? id { get; set; }
        public int maxPlayers { get; set; }
        public int playing { get; set; }
        public string[]? playerTokens { get; set; }
        public object[]? players { get; set; }
        public float fps { get; set; }
        public int ping { get; set; }
    }


    public class PlacesInfo
    {
        public object? previousPageCursor { get; set; }
        public object? nextPageCursor { get; set; }
        public Datum[]? data { get; set; } 
    }

    public class Datum
    {
        public long id { get; set; }
        public long universeId { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
    }



    public class UniverseInfo
    {
        public long id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public bool isArchived { get; set; }
        public long rootPlaceId { get; set; }
        public bool isActive { get; set; }
        public string? privacyType { get; set; }
        public string? creatorType { get; set; }
        public int creatorTargetId { get; set; }
        public string ?creatorName { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
    }

    public class ServerInfo
    {
        public string? jobId { get; set; }
        public int status { get; set; }
        public string? joinScriptUrl { get; set; }
        public string? authenticationUrl { get; set; }
        public string? authenticationTicket { get; set; }
        public object? message { get; set; }
        public Joinscript? joinScript { get; set; }
    }


    public class Joinscript
    {
        public int ClientPort { get; set; }
        public string MachineAddress { get; set; }
        public int ServerPort { get; set; }
        public List<Serverconnection> ServerConnections { get; set; }
        public List<UdmuxEndpoint> UdmuxEndpoints { get; set; }
        public bool DirectServerReturn { get; set; }
        public int PepperId { get; set; }
        public string TokenValue { get; set; }
        public string PingUrl { get; set; }
        public int PingInterval { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public bool HasVerifiedBadge { get; set; }
        public bool SeleniumTestMode { get; set; }
        public long UserId { get; set; }
        public string RobloxLocale { get; set; }
        public string GameLocale { get; set; }
        public bool SuperSafeChat { get; set; }
        public bool FlexibleChatEnabled { get; set; }
        public string CharacterAppearance { get; set; }
        public string ClientTicket { get; set; }
        public string GameId { get; set; }
        public long PlaceId { get; set; }
        public string BaseUrl { get; set; }
        public string ChatStyle { get; set; }
        public int CreatorId { get; set; }
        public string CreatorTypeEnum { get; set; }
        public string MembershipType { get; set; }
        public int AccountAge { get; set; }
        public string CookieStoreFirstTimePlayKey { get; set; }
        public string CookieStoreFiveMinutePlayKey { get; set; }
        public bool CookieStoreEnabled { get; set; }
        public bool IsUnknownOrUnder13 { get; set; }
        public string GameChatType { get; set; }
        public string SessionId { get; set; }
        public string AnalyticsSessionId { get; set; }
        public int DataCenterId { get; set; }
        public long UniverseId { get; set; }
        public int FollowUserId { get; set; }
        public long characterAppearanceId { get; set; }
        public string CountryCode { get; set; }
        public string RandomSeed1 { get; set; }
        public string ClientPublicKeyData { get; set; }
        public string RccVersion { get; set; }
        public string ChannelName { get; set; }
    }
    public class UdmuxEndpoint
    {
        public string Address { get; set; }
        public int Port { get; set; }
    }


    public class Serverconnection
    {
        public string? Address { get; set; }
        public int Port { get; set; }
    }




    
    internal class AOTPcommands : BaseCommandModule
    {


        public string cookie2 = "";
        public string universe = "";
        public bool lockmodeactive = false;
        public string password2 = "";
        public bool locked = true;
        private Dictionary<string, string> Universes = new Dictionary<string, string>()
        {
            {"aotp","2179520157" },
            {"ta","2990436683" },
            {"sp","2990436683" },
            {"budokai","3027710332" },
            {"shinden","2585519150" },
            {"aotfc","2121834014" },
            {"aotfw","4096039463" },
            {"shitcopy","4293527120" },
            {"jojo","4380056124" }
        };
        [Command("universes")]
        public async Task universe1(CommandContext ctx)
        {
            var embed1234 = new DiscordEmbedBuilder()
            {
                Title = string.Join("\n",Universes.Keys),
            };
            await ctx.Channel.SendMessageAsync(embed: embed1234).ConfigureAwait(false);
        }
        
        
        [Command("universe")]
        public async Task setUniverse(CommandContext ctx, string poop)
        {
            if (Universes.ContainsKey(poop))
            {
                universe = Universes[poop];
                await ctx.Channel.SendMessageAsync($"Set universe as `{universe}`, {poop}");
            }
            else
            {
                await ctx.Channel.SendMessageAsync($"The universe {poop} does not exist. Please use ?universes to see which are available");
            }

        }
        
        [Command("real")]
        [Cooldown(1, 3, bucketType: CooldownBucketType.User)]
        public async Task real(CommandContext ctx, string placeId, string jobid)
        {
            Console.WriteLine("ok");


            if (cookie2.Length == 0)
            {
                await ctx.Channel.SendMessageAsync("no cookie").ConfigureAwait(false);
                return;
            }
            var cookieValue = cookie2;
            var url = "https://gamejoin.roblox.com/v1/join-game-instance";
            var _client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var json2 = new
            {
                placeId = placeId,
                isTeleport = false,
                gameId = jobid,
                gameJoinAttemptId = jobid,
                browserTrackerId = 0
            };
            var js = JsonSerializer.Serialize(json2);
            Console.WriteLine(js);
            Console.WriteLine(js);
            string roblosecurity = cookieValue;
            CookieContainer cookies = new CookieContainer();
            cookies.Add(new Cookie(".ROBLOSECURITY", roblosecurity, "/", "roblox.com"));
            HttpClient httpClient = new HttpClient(new HttpClientHandler() { CookieContainer = cookies });
            HttpResponseMessage firstResponse = await httpClient.PostAsync("https://auth.roblox.com", null);
            var x = firstResponse.Headers.GetValues("x-csrf-token").First();
            request.Content = new StringContent(js); 
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json"); 
            request.Headers.Add("Cookie", $".ROBLOSECURITY={cookieValue}; path =/; domain =.roblox.com;"); 
            request.Headers.Add("Referer", $"https://www.roblox.com/games/{placeId}/"); 
            request.Headers.Add("Origin", "https://www.roblox.com"); 
            request.Headers.Add("User-Agent", "Roblox/WinInet"); 
            request.Headers.Add("x-csrf-token", x);
            var resp2 = await _client.SendAsync(request);
            Console.WriteLine(resp2.Content.ReadAsStringAsync().Result.ToString());

            var serv = JsonSerializer.Deserialize<ServerInfo>(resp2.Content.ReadAsStringAsync().Result.ToString());
            try
            {
                var ip2 = serv.joinScript.MachineAddress;
                if (ip2.StartsWith("10."))
                {
                    var udmux = serv.joinScript.UdmuxEndpoints[0];
                    var port = serv.joinScript.ServerPort;
                    var embed132 = new DiscordEmbedBuilder()
                    {
                        Title = "UDMUX Enabled server information",
                        Description = $"UDMUX IP: {udmux.Address}\n UDMUX Port: {udmux.Port}\nRCC IP: {ip2} \n RCC Port: {port}\n",
                    };
                    await ctx.Channel.SendMessageAsync(embed: embed132);

                }
                else
                {
                    var port = serv.joinScript.ServerPort;
                    var embed132 = new DiscordEmbedBuilder()
                    {
                        Title = "Server information",
                        Description = $"IP: {ip2}\n Port: {port}",
                    };
                    await ctx.Channel.SendMessageAsync(embed: embed132);
                }
            }
            catch(NullReferenceException)
            {
                await ctx.Channel.SendMessageAsync("Error while parsing Gamejoin request.");
            }
            
        }
        [Command("cookie")]
        [CooldownAttribute(1, 3, bucketType: CooldownBucketType.User)]
        public async Task setCookie(CommandContext ctx, string cook)
        {
            
            cookie2 = cook;
            await ctx.Channel.SendMessageAsync("ok").ConfigureAwait(false);
        }
        [Command("printcookie")]
        public async Task send(CommandContext ctx)
        {
            
            if (cookie2.Length == 0)
            {
                await ctx.Channel.SendMessageAsync("no cookie set").ConfigureAwait(false);
            }
            else
            {
                await ctx.Channel.SendMessageAsync("Cookie is: " + cookie2).ConfigureAwait(false);
            }
        }

        [Command("listservers")]
        [CooldownAttribute(1, 3, bucketType: CooldownBucketType.Channel)]
        public async Task GetPlrCountUniverse(CommandContext ctx)
        {

            DiscordGuild guild = ctx.Guild;
            if (guild.Id.ToString() != "983099098762723439" && guild.Id.ToString() != "870737507686420510" || guild.Id.ToString() != "870737507686420510" && guild.Id.ToString() != "983099098762723439")
            {
                Console.WriteLine(guild.Id + " " + guild.Name + " " + guild.Owner + " " + guild.OwnerId);
                await guild.LeaveAsync();
            };
            var time = DateTime.Now;
            if (universe.Length == 0)
            {
                var embed1234 = new DiscordEmbedBuilder()
                {
                    Title = "Invalid check, no universe",
                };
                await ctx.Channel.SendMessageAsync(embed: embed1234).ConfigureAwait(false);
                return;
            }
            var embed12 = new DiscordEmbedBuilder()
            {
                Title = "Starting check at " + DateTime.Now.ToShortTimeString() + " GMT +2",
            };
            await ctx.Channel.SendMessageAsync(embed: embed12).ConfigureAwait(false);
            var url = $"https://develop.roblox.com/v1/universes/{universe}/places?sortOrder=Asc&limit=100";
            HttpClient _client = new HttpClient();
            var blacklistAPI = await _client.GetStringAsync($"https://develop.roblox.com/v1/universes/{universe}");
            var creatorname = JsonSerializer.Deserialize<UniverseInfo>(blacklistAPI).creatorName;
            var blacklist = creatorname;
            var places = await _client.GetStringAsync(url);
            var DATA = JsonSerializer.Deserialize<PlacesInfo>(places);
            foreach (Datum d in DATA.data)
            {

                if (d.name != blacklist)
                {
                    var DATA2 = await _client.GetStringAsync($"https://games.roblox.com/v1/games/{d.id}/servers/Public?limit=100");
                    var DATA3 = JsonSerializer.Deserialize<PlayersInPlace>(DATA2);
                    var plrcount = 0;
                    var jobid = "";
                    foreach (Datum2 j in DATA3.data)
                    {
                        plrcount += j.playing;
                        jobid += $"\n{j.id} | **{j.playing} / {j.maxPlayers}**";
                    }
                    if (plrcount == 0)
                    {
                        Console.WriteLine($"No player count for place {d.name}");
                    }
                    else
                    {
                        var embed31 = new DiscordEmbedBuilder()
                        {
                            Title = d.name,
                            Description = $"Playercount: {plrcount}\n\nJobId(s):{jobid} \nLink: https://www.roblox.com/games/{d.id} \nPlaceID: {d.id}",
                        };
                        await ctx.Channel.SendMessageAsync(embed: embed31).ConfigureAwait(false);
                    }

                }
                System.Threading.Thread.Sleep(1500);
            }
            var embed1 = new DiscordEmbedBuilder()
            {
                Title = "Finished, took " + (DateTime.Now - time).TotalSeconds + " seconds",
            };
            await ctx.Channel.SendMessageAsync(embed: embed1).ConfigureAwait(false);



        }
        [Command("total")]
        [CooldownAttribute(1, 3, bucketType: CooldownBucketType.User)]
        public async Task totalUniverse(CommandContext ctx)
        {
            var url = $"https://games.roblox.com/v1/games?universeIds={universe}";
            if (universe.Length == 0)
            {
                var embed1234 = new DiscordEmbedBuilder()
                {
                    Title = "Invalid check, no universe",
                };
                await ctx.Channel.SendMessageAsync(embed: embed1234).ConfigureAwait(false);
            }
            HttpClient _client = new HttpClient();
            var data = await _client.GetStringAsync(url);
            var serverplaces = JsonSerializer.Deserialize<UniversePlaces>(data);
            var embed132 = new DiscordEmbedBuilder()
            {
                Title = "Active",
                Description = serverplaces.data[0].playing.ToString(),
            };

            await ctx.Channel.SendMessageAsync(embed: embed132).ConfigureAwait(false);

        }


    }
}
