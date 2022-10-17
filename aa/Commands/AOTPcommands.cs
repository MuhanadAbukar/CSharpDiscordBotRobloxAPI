using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
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
        public string name { get; set; }
        public string type { get; set; }
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
        public string name { get; set; }
        public string description { get; set; }
        public bool isArchived { get; set; }
        public long rootPlaceId { get; set; }
        public bool isActive { get; set; }
        public string privacyType { get; set; }
        public string creatorType { get; set; }
        public int creatorTargetId { get; set; }
        public string creatorName { get; set; }
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
        public string? MachineAddress { get; set; }
        public int ServerPort { get; set; }
        public Serverconnection[]? ServerConnections { get; set; }
        public bool DirectServerReturn { get; set; }
        public string? PingUrl { get; set; }
        public int PingInterval { get; set; }
        public string? UserName { get; set; }
        public string? DisplayName { get; set; }
        public bool SeleniumTestMode { get; set; }
        public long UserId { get; set; }
        public string? RobloxLocale { get; set; }
        public string? GameLocale { get; set; }
        public bool SuperSafeChat { get; set; }
        public bool FlexibleChatEnabled { get; set; }
        public string? CharacterAppearance { get; set; }
        public string? ClientTicket { get; set; }
        public string? GameId { get; set; }
        public long PlaceId { get; set; }
        public string? BaseUrl { get; set; }
        public string? ChatStyle { get; set; }
        public int CreatorId { get; set; }
        public string? CreatorTypeEnum { get; set; }
        public string? MembershipType { get; set; }
        public int AccountAge { get; set; }
        public string? CookieStoreFirstTimePlayKey { get; set; }
        public string? CookieStoreFiveMinutePlayKey { get; set; }
        public bool CookieStoreEnabled { get; set; }
        public bool IsUnknownOrUnder13 { get; set; }
        public string? GameChatType { get; set; }
        public string? SessionId { get; set; }
        public string? AnalyticsSessionId { get; set; }
        public int DataCenterId { get; set; }
        public long UniverseId { get; set; }
        public int FollowUserId { get; set; }
        public long characterAppearanceId { get; set; }
        public string? CountryCode { get; set; }
        public string? RandomSeed1 { get; set; }
        public string? ClientPublicKeyData { get; set; }
        public string? RccVersion { get; set; }
        public string? ChannelName { get; set; }
    }

    public class Serverconnection
    {
        public string? Address { get; set; }
        public int Port { get; set; }
    }




    static class Whitelisted
    {
        /*
         * whitelisted.Add("568374878500159490"); // hanad
            whitelisted.Add("904498859013718016"); // zaxar
            whitelisted.Add("814985597730291713"); // joe biden
            whitelisted.Add("377904721425334272"); // putin
            whitelisted.Add("652106591189073932"); // hakates
            whitelisted.Add("339928400418308096"); // ooga
         */
        public static string Whitelisted1 = "396306180626055170,568374878500159490,904498859013718016,814985597730291713,377904721425334272,652106591189073932,339928400418308096";

    }
    internal class AOTPcommands : BaseCommandModule
    {


        public string cookie2 = "";
        public string universe = "";
        public bool lockmodeactive = false;
        public string password2 = "";
        public bool locked = true;
        [Command("universes")]
        public async Task universe1(CommandContext ctx)
        {
            var embed1234 = new DiscordEmbedBuilder()
            {
                Title = "T:A\nAOT:P\nShinobi Project\nBudokai\nShitden\nAOT:FC",
            };
            await ctx.Channel.SendMessageAsync(embed: embed1234).ConfigureAwait(false);
        }
        [Command("stats")]
        public async Task stats(CommandContext ctx, string npcOrPlr, double str, double dex, double con, double wil, double mnd, double spi)
        {
            if (npcOrPlr.ToLower() == "npc" || npcOrPlr.ToLower() == "mob")
            {
                str = (str / 97) * 100;
                dex = (dex / 97) * 100;
                con = (con / 97) * 100;
                wil = (wil / 97) * 100;
                mnd = (mnd / 97) * 100;
                spi = (spi / 97) * 100;
                str = Math.Ceiling(str);
                dex = Math.Ceiling(dex);
                con = Math.Ceiling(con);
                wil = Math.Ceiling(wil);
                mnd = Math.Ceiling(mnd);
                spi = Math.Ceiling(spi);

                var embed1234 = new DiscordEmbedBuilder()
                {
                    Title = "Old stats",
                    Description = "STR: " + str + "\n DEX: " + dex + "\n CON: " + con + "\n WIL: " + wil + "\n MND: " + mnd + "\n SPI: " + spi
                };
                await ctx.Channel.SendMessageAsync(embed: embed1234).ConfigureAwait(false);


            }
            else if (npcOrPlr.ToLower() == "plr" || npcOrPlr.ToLower() == "player")
            {
                str = (str / 95) * 100;
                dex = (dex / 95) * 100;
                con = (con / 95) * 100;
                wil = (wil / 95) * 100;
                mnd = (mnd / 95) * 100;
                spi = (spi / 95) * 100;
                str = Math.Ceiling(str);
                dex = Math.Ceiling(dex);
                con = Math.Ceiling(con);
                wil = Math.Ceiling(wil);
                mnd = Math.Ceiling(mnd);
                spi = Math.Ceiling(spi);
                var embed1234 = new DiscordEmbedBuilder()
                {
                    Title = "Old stats",
                    Description = "STR: " + str + "\n DEX: " + dex + "\n CON: " + con + "\n WIL: " + wil + "\n MND: " + mnd + "\n SPI: " + spi
                };
                await ctx.Channel.SendMessageAsync(embed: embed1234).ConfigureAwait(false);


            }
        }
        [Command("setpassword")]
        public async Task setPassword(CommandContext ctx, string password)
        {
            if (lockmodeactive)
            {

                var embed1234 = new DiscordEmbedBuilder()
                {
                    Title = "turning off lock mode and executing command ",
                };
                lockmodeactive = false;
                await ctx.Channel.SendMessageAsync(embed: embed1234).ConfigureAwait(false);
            }
            else
            {
                var id = ctx.User.Id.ToString();
                var xd = Whitelisted.Whitelisted1.Split(',');
                if (Array.IndexOf(xd, id) != -1)
                {
                    password2 = password;
                    await ctx.Channel.SendMessageAsync("set password as: " + password).ConfigureAwait(false);
                }
                else
                {
                    await ctx.Channel.SendMessageAsync("You are not whitelisted").ConfigureAwait(false);
                }
            }


        }
        [Command("lock")]
        public async Task lockBot(CommandContext ctx)
        {
            if (lockmodeactive)
            {

                var embed1234 = new DiscordEmbedBuilder()
                {
                    Title = "turning off lock mode and executing command ",
                };
                lockmodeactive = false;
                await ctx.Channel.SendMessageAsync(embed: embed1234).ConfigureAwait(false);
            }
            else if (Array.IndexOf(Whitelisted.Whitelisted1.Split(','), ctx.User.Id.ToString()) != -1)
            {
                locked = true;
                var embed1234 = new DiscordEmbedBuilder()
                {
                    Title = "I have been chained",
                };
                await ctx.Channel.SendMessageAsync(embed: embed1234).ConfigureAwait(false);

            }
            else if (Array.IndexOf(Whitelisted.Whitelisted1.Split(','), ctx.User.Id.ToString()) == -1)
            {
                await ctx.Channel.SendMessageAsync("You are not a seed giver").ConfigureAwait(false);
            }

        }
        [Command("universe")]
        public async Task setUniverse(CommandContext ctx, string poop)
        {
            if (lockmodeactive)
            {

                var embed1234 = new DiscordEmbedBuilder()
                {
                    Title = "turning off lock mode and executing command ",
                };
                lockmodeactive = false;
                await ctx.Channel.SendMessageAsync(embed: embed1234).ConfigureAwait(false);
            }
            if (locked && Array.IndexOf(Whitelisted.Whitelisted1.Split(','), ctx.User.Id.ToString()) == -1)
            {

                await ctx.Channel.SendMessageAsync("You cannot utilize my abilities while I am chained.").ConfigureAwait(false);
                return;
            }
            if (poop.ToLower() == "aotp")
            {
                universe = "2179520157";
                await ctx.Channel.SendMessageAsync("Set universe as `2179520157`, AOT:P").ConfigureAwait(false);
            }
            else if (poop.ToLower() == "ta" || poop.ToLower() == "t:a")
            {
                universe = "2990436683";
                await ctx.Channel.SendMessageAsync("Set universe as `2990436683`, T:A").ConfigureAwait(false);

            }
            else if (poop.ToLower() == "naruto" || poop.ToLower() == "sp")
            {
                universe = "1529230014";
                await ctx.Channel.SendMessageAsync("Set universe as `2990436683`, Shinobi Project").ConfigureAwait(false);
            }
            else if (poop.ToLower() == "budokai")
            {
                universe = "3027710332";
                await ctx.Channel.SendMessageAsync("Set universe as `3027710332`, Budokai").ConfigureAwait(false);
            }
            else if (poop.ToLower() == "shinden" || poop.ToLower() == "shitden")
            {
                universe = "2585519150";
                await ctx.Channel.SendMessageAsync("Set universe as `2585519150`, Shitden").ConfigureAwait(false);

            }
            else if (poop.ToLower() == "aotfc")
            {
                universe = "2121834014";
                await ctx.Channel.SendMessageAsync("Set universe as `2121834014`, False Chance").ConfigureAwait(false);
            }



        }
        [Command("password")]
        public async Task pasward(CommandContext ctx, string pass)
        {
            if (pass == password2)
            {
                locked = false;
                await ctx.Channel.SendMessageAsync("lock mode deactivated").ConfigureAwait(false);
            }
            else
            {
                await ctx.Channel.SendMessageAsync("wrong password").ConfigureAwait(false);

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
            Console.WriteLine("ok");

            var cookieValue = cookie2;
            var url = "https://gamejoin.roblox.com/v1/join-game-instance";
            var _client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var json = "{\"placeId\": " + placeId + ", \"isTeleport\": false, \"gameId\": " + $"\"{jobid}\"" + ", \"gameJoinAttemptId\":" + $"\"{jobid}\"" + ",\"browserTrackerId\": 0}";
            string roblosecurity = cookieValue;
            CookieContainer cookies = new CookieContainer();
            cookies.Add(new Cookie(".ROBLOSECURITY", roblosecurity, "/", "roblox.com"));
            HttpClient httpClient = new HttpClient(new HttpClientHandler() { CookieContainer = cookies });
            HttpResponseMessage firstResponse = await httpClient.PostAsync("https://auth.roblox.com", null);
            var x = firstResponse.Headers.GetValues("x-csrf-token").First();
            request.Content = new StringContent(json); request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json"); request.Headers.Add("Cookie", $".ROBLOSECURITY={cookieValue}; path =/; domain =.roblox.com;"); request.Headers.Add("Referer", $"https://www.roblox.com/games/{placeId}/"); request.Headers.Add("Origin", "https://www.roblox.com"); request.Headers.Add("User-Agent", "Roblox/WinInet"); request.Headers.Add("x-csrf-token", x);
            Console.WriteLine("ok");
            var resp2 = await _client.SendAsync(request);
            var serv = JsonSerializer.Deserialize<ServerInfo>(resp2.Content.ReadAsStringAsync().Result.ToString());
            var ip2 = serv.joinScript.MachineAddress;
            var port = serv.joinScript.ServerPort;
            var embed132 = new DiscordEmbedBuilder()
            {
                Title = "Server information",
                Description = $"IP: {ip2}\n Port: {port}",
            };
            await ctx.Channel.SendMessageAsync(embed: embed132);
        }
        [Command("cookie")]
        [CooldownAttribute(1, 3, bucketType: CooldownBucketType.User)]
        public async Task setCookie(CommandContext ctx, string cook)
        {
            if (locked && Array.IndexOf(Whitelisted.Whitelisted1.Split(','), ctx.User.Id.ToString()) == -1)
            {
                await ctx.Channel.SendMessageAsync("You cannot utilize my abilities while I am chained.").ConfigureAwait(false);
                return;
            }
            cookie2 = cook;
            await ctx.Channel.SendMessageAsync("ok").ConfigureAwait(false);
        }
        [Command("printcookie")]
        public async Task send(CommandContext ctx)
        {
            if (locked && Array.IndexOf(Whitelisted.Whitelisted1.Split(','), ctx.User.Id.ToString()) == -1)
            {
                await ctx.Channel.SendMessageAsync("You cannot utilize my abilities while I am chained.").ConfigureAwait(false);
                return;
            }
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
            var zs = await _client.GetStringAsync(url);
            var DATA = JsonSerializer.Deserialize<PlacesInfo>(zs);

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
                        jobid += $"\n{j.id} | **{j.playing} / {j.maxPlayers}**sent";
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
