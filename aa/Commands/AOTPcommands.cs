using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace aa.Commands {

    static class Whitelisted {
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
    internal class AOTPcommands: BaseCommandModule {

        public string cookie2 = "";
        public string universe = "";
        public bool lockmodeactive = false;
        public string password2 = "";
        public bool locked = true;
        [Command("universes")]
         async Task universe1(CommandContext ctx) {
          var embed1234 = new DiscordEmbedBuilder() {
            Title = "T:A\nAOT:P\nShinobi Project\nBudokai\nShitden\nAOT:FC",
          };
          await ctx.Channel.SendMessageAsync(embed: embed1234).ConfigureAwait(false);
        }

        [Command("setpassword")]
         async Task setPassword(CommandContext ctx, string password) {
            if (lockmodeactive) {

              var embed1234 = new DiscordEmbedBuilder() {
                Title = "turning off lock mode and executing command ",
              };
              lockmodeactive = false;
              await ctx.Channel.SendMessageAsync(embed: embed1234).ConfigureAwait(false);
            } else {
              var Userid = ctx.User.Id.ToString();
              var whitelistedUsers = Whitelisted.Whitelisted1.Split(',');
              if (Array.IndexOf(whitelistedUsers, Userid) != -1) {
                password2 = password;
                await ctx.Channel.SendMessageAsync("set password as: " + password).ConfigureAwait(false);
              } else {
                await ctx.Channel.SendMessageAsync("You are not whitelisted").ConfigureAwait(false);
              }
            }

          }
          [Command("lock")]
         async Task lockBot(CommandContext ctx) {
            var Userid = ctx.User.Id.ToString();
            var whitelistedUsers = Whitelisted.Whitelisted1.Split(',');
            if (lockmodeactive) {

              var LockModeEmbed = new DiscordEmbedBuilder() {
                Title = "turning off lock mode and executing command ",
              };
              lockmodeactive = false;
              await ctx.Channel.SendMessageAsync(embed: LockModeEmbed).ConfigureAwait(false);
            } else if (Array.IndexOf(whitelistedUsers, Userid) != -1) {
              locked = true;
              var LockModeEmbed = new DiscordEmbedBuilder() {
                Title = "I have been chained",
              };
              await ctx.Channel.SendMessageAsync(embed: LockModeEmbed).ConfigureAwait(false);

            } else if (Array.IndexOf(whitelistedUsers, Userid) == -1) {
              await ctx.Channel.SendMessageAsync("You are not an admin, therefore you can't unlock the bot").ConfigureAwait(false);
            }

          }
          [Command("universe")]
         async Task setUniverse(CommandContext ctx, string universeId) {
            var Userid = ctx.User.Id.ToString();
            var whitelistedUsers = Whitelisted.Whitelisted1.Split(',');
            if (lockmodeactive) {

              var TurnoffLockmodeEmbed = new DiscordEmbedBuilder() {
                Title = "turning off lock mode and executing command ",
              };
              lockmodeactive = false;
              await ctx.Channel.SendMessageAsync(embed: TurnoffLockmodeEmbed).ConfigureAwait(false);
            }
            if (locked && Array.IndexOf(whitelistedUsers, Userid) == -1) {

              await ctx.Channel.SendMessageAsync("You cannot utilize my abilities while I am chained.").ConfigureAwait(false);
              return;
            }
            if (universeId.ToLower() == "aotp") {
              universe = "2179520157";
              await ctx.Channel.SendMessageAsync("Set universe as `2179520157`, AOT:P").ConfigureAwait(false);
            } else if (universeId.ToLower() == "ta" || universeId.ToLower() == "t:a") {
              universe = "2990436683";
              await ctx.Channel.SendMessageAsync("Set universe as `2990436683`, T:A").ConfigureAwait(false);

            } else if (universeId.ToLower() == "naruto" || universeId.ToLower() == "sp") {
              universe = "1529230014";
              await ctx.Channel.SendMessageAsync("Set universe as `2990436683`, Shinobi Project").ConfigureAwait(false);
            } else if (universeId.ToLower() == "budokai") {
              universe = "3027710332";
              await ctx.Channel.SendMessageAsync("Set universe as `3027710332`, Budokai").ConfigureAwait(false);
            } else if (universeId.ToLower() == "shinden" || universeId.ToLower() == "shitden") {
              universe = "2585519150";
              await ctx.Channel.SendMessageAsync("Set universe as `2585519150`, Shitden").ConfigureAwait(false);

            } else if (universeId.ToLower() == "aotfc") {
              universe = "2121834014";
              await ctx.Channel.SendMessageAsync("Set universe as `2121834014`, False Chance").ConfigureAwait(false);
            }

          }
          [Command("password")]
         async Task pasward(CommandContext ctx, string pass) {
          if (pass == password2) {
            locked = false;
            await ctx.Channel.SendMessageAsync("lock mode deactivated").ConfigureAwait(false);
          } else {
            await ctx.Channel.SendMessageAsync("wrong password").ConfigureAwait(false);

          }
        }

        [Command("getip")]
        [Cooldown(1, 3, bucketType: CooldownBucketType.User)]
         async Task getip(CommandContext ctx, string placeId, string jobid) {

            var Userid = ctx.User.Id.ToString();
            var whitelistedUsers = Whitelisted.Whitelisted1.Split(',');
            if (lockmodeactive) {

              var lockmodeEmbed = new DiscordEmbedBuilder() {
                Title = "turning off lock mode and executing command ",
              };
              lockmodeactive = false;
              await ctx.Channel.SendMessageAsync(embed: lockmodeEmbed).ConfigureAwait(false);
            }
            if (locked && Array.IndexOf(whitelistedUsers, Userid) == -1) {
              await ctx.Channel.SendMessageAsync("You cannot utilize my abilities while I am chained.").ConfigureAwait(false);
              return;
            }
            if (cookie2.Length == 0) {
              await ctx.Channel.SendMessageAsync("no cookie").ConfigureAwait(false);
              return;
            }
            var cookieValue = cookie2;
            var url = "https://gamejoin.roblox.com/v1/join-game-instance";
            var _client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var json = "{\"placeId\": " + placeId + ", \"isTeleport\": false, \"gameId\": " + $"\"{jobid}\"" + ", \"gameJoinAttemptId\":" + $"\"{jobid}\"" + ",\"browserTrackerId\": 0}";
            string roblosecurity = cookieValue;
            CookieContainer cookies = new CookieContainer();
            cookies.Add(new Cookie(".ROBLOSECURITY", roblosecurity, "/", "roblox.com"));
            HttpClient httpClient = new HttpClient(new HttpClientHandler() {

              CookieContainer = cookies

            });

            HttpResponseMessage firstResponse = await httpClient.PostAsync("https://auth.roblox.com", null);
            var x = firstResponse.Headers.GetValues("x-csrf-token").First();
            request.Content = new StringContent(json);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            request.Headers.Add("Cookie", $".ROBLOSECURITY={cookieValue}; path =/; domain =.roblox.com;");
            request.Headers.Add("Referer", $"https://www.roblox.com/games/{placeId}/");
            request.Headers.Add("Origin", "https://www.roblox.com");
            request.Headers.Add("User-Agent", "Roblox/WinInet");
            request.Headers.Add("x-csrf-token", x);
            var resp2 = await _client.SendAsync(request);
            var REAL = resp2.Content.ReadAsStringAsync().Result.Split(',');
            string resl = "";
            string Name = "";
            foreach(string xd2 in REAL) {
              if (xd2.StartsWith("\"MachineAddress\"")) {
                var ip = xd2.Replace("\"MachineAddress\":", "");
                resl += "IP: \n" + ip.Replace("\"", "") + "\n";

              } else if (xd2.StartsWith("\"ServerPort\"")) {
                async Task getip(CommandContext ctx, string placeId, string jobid) {

                    var Userid = ctx.User.Id.ToString();
                    var whitelistedUsers = Whitelisted.Whitelisted1.Split(',');

                    if (lockmodeactive) {

                      var lockmodeEmbed = new DiscordEmbedBuilder() {
                        Title = "turning off lock mode and executing command ",
                      };
                      lockmodeactive = false;
                      await ctx.Channel.SendMessageAsync(embed: lockmodeEmbed).ConfigureAwait(false);
                    }
                    if (locked && Array.IndexOf(whitelistedUsers, Userid) == -1) {
                      await ctx.Channel.SendMessageAsync("You cannot utilize my abilities while I am chained.").ConfigureAwait(false);
                      return;
                    }
                    if (cookie2.Length == 0) {
                      await ctx.Channel.SendMessageAsync("no cookie").ConfigureAwait(false);
                      return;
                    }
                    var cookieValue = cookie2;
                    var url = "https://gamejoin.roblox.com/v1/join-game-instance";
                    var _client = new HttpClient();
                    var request = new HttpRequestMessage(HttpMethod.Post, url);
                    var json = "{\"placeId\": " + placeId + ", \"isTeleport\": false, \"gameId\": " + $"\"{jobid}\"" + ", \"gameJoinAttemptId\":" + $"\"{jobid}\"" + ",\"browserTrackerId\": 0}";
                    string roblosecurity = cookieValue;
                    CookieContainer cookies = new CookieContainer();
                    cookies.Add(new Cookie(".ROBLOSECURITY", roblosecurity, "/", "roblox.com"));
                    HttpClient httpClient = new HttpClient(new HttpClientHandler() {
                      CookieContainer = cookies
                    });
                    HttpResponseMessage firstResponse = await httpClient.PostAsync("https://auth.roblox.com", null);
                    var xcrsfToken = firstResponse.Headers.GetValues("x-csrf-token").First();
                    request.Content = new StringContent(json);
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    request.Headers.Add("Cookie", $".ROBLOSECURITY={cookieValue}; path =/; domain =.roblox.com;");
                    request.Headers.Add("Referer", $"https://www.roblox.com/games/{placeId}/");
                    request.Headers.Add("Origin", "https://www.roblox.com");
                    request.Headers.Add("User-Agent", "Roblox/WinInet");
                    request.Headers.Add("x-csrf-token", xcrsfToken);
                    var response2 = await _client.SendAsync(request);
                    var Data = response2.Content.ReadAsStringAsync().Result.Split(',');
                    string output = "";
                    string Name = "";
                    foreach(string node in Data) {
                      if (node.StartsWith("\"MachineAddress\"")) {
                        var ip = node.Replace("\"MachineAddress\":", "");
                        output += "IP: \n" + ip.Replace("\"", "") + "\n";

                      } else if (node.StartsWith("\"ServerPort\"")) {
                        Console.WriteLine("Port: \n" + node.Replace("\"ServerPort\":", ""));
                        output += "Port: \n" + node.Replace("\"ServerPort\":", "") + "\n";
                      } else if (node.StartsWith("\\\"PlaceId")) {
                        var id = node.Split(":")[1];
                        Console.WriteLine(id);
                        var _client2 = new HttpClient();
                        var universe2 = await _client2.GetStringAsync($"https://api.roblox.com/universes/get-universe-containing-place?placeid={id}");
                        System.Threading.Thread.Sleep(1000);
                        universe2 = universe.Replace("\"UniverseId\":", "");
                        var BlacklistUniverse = await _client2.GetStringAsync($"https://develop.roblox.com/v1/universes/{universe2}");
                        System.Threading.Thread.Sleep(1000);
                        var jsonBlackList = node.Split(',');
                        var blacklist = "";
                        foreach(string nodesBlackList in jsonBlackList) {
                          if (nodesBlackList.StartsWith("\"creatorName\"")) {
                            blacklist = nodesBlackList.Replace("\"creatorName\":", "");
                          }
                        }
                        var json2 = await _client2.GetStringAsync($"https://api.roblox.com/Marketplace/ProductInfo?assetId={id}");
                        System.Threading.Thread.Sleep(1000);
                        var data2 = json2.Split(',');
                        foreach(string nodes2 in data2) {
                          if (nodes2.StartsWith("\"Name\"") && nodes2.Replace("\"Name\":", "") != blacklist) {
                            Name = nodes2.Replace("\"Name\":", "");
                          }
                        }
                        Console.WriteLine(Name);
                      }
                    }
                    var ServerInfoEmbed = new DiscordEmbedBuilder() {
                      Title = Name.Replace("\"", "") + " server",
                        Description = output,
                    };
                    await ctx.Channel.SendMessageAsync(embed: ServerInfoEmbed);
                  }
                  [Command("cookie")]
                  [CooldownAttribute(1, 3, bucketType: CooldownBucketType.User)]
                async Task setCookie(CommandContext ctx, string cook) {
                    var Userid = ctx.User.Id.ToString();
                    var whitelistedUsers = Whitelisted.Whitelisted1.Split(',');
                    if (locked && Array.IndexOf(whitelistedUsers, Userid) == -1) {
                      await ctx.Channel.SendMessageAsync("The bot is currently on lockdown.").ConfigureAwait(false);
                      return;
                    }
                    cookie2 = cook;
                    await ctx.Channel.SendMessageAsync("set cookie as " + cookie2).ConfigureAwait(false);
                  }
                  [Command("printcookie")]
                async Task send(CommandContext ctx) {
                  var Userid = ctx.User.Id.ToString();
                  var whitelistedUsers = Whitelisted.Whitelisted1.Split(',');
                  if (locked && Array.IndexOf(whitelistedUsers, Userid) == -1) {
                    await ctx.Channel.SendMessageAsync("The bot is currently on lockdown.").ConfigureAwait(false);
                    return;
                  }
                  if (cookie2.Length == 0) {
                    await ctx.Channel.SendMessageAsync("no cookie set").ConfigureAwait(false);

                  } else {
                    await ctx.Channel.SendMessageAsync("Cookie is: " + cookie2).ConfigureAwait(false);

                  }
                }

                [Command("listservers")]
                [CooldownAttribute(1, 3, bucketType: CooldownBucketType.Channel)]
                async Task GetPlrCountUniverse(CommandContext ctx) {
                    var Userid = ctx.User.Id.ToString();
                    var whitelistedUsers = Whitelisted.Whitelisted1.Split(',');
                    if (locked && Array.IndexOf(whitelistedUsers, Userid) == -1) {
                      await ctx.Channel.SendMessageAsync("You cannot utilize my abilities while I am chained.").ConfigureAwait(false);
                      return;
                    }
                    if (lockmodeactive) {

                      var embed1234 = new DiscordEmbedBuilder() {
                        Title = "turning off lock mode and executing command ",
                      };
                      lockmodeactive = false;
                      await ctx.Channel.SendMessageAsync(embed: embed1234).ConfigureAwait(false);
                    }
                    DiscordGuild guild = ctx.Guild;
                    if (guild.Id.ToString() != "983099098762723439" && guild.Id.ToString() != "870737507686420510" || guild.Id.ToString() != "870737507686420510" && guild.Id.ToString() != "983099098762723439") {
                      Console.WriteLine(guild.Id + " " + guild.Name + " " + guild.Owner + " " + guild.OwnerId);
                      await guild.LeaveAsync();
                    };
                    var time = DateTime.Now;
                    if (universe.Length == 0) {
                      var embed1234 = new DiscordEmbedBuilder() {
                        Title = "Invalid check, no universe",
                      };
                      await ctx.Channel.SendMessageAsync(embed: embed1234).ConfigureAwait(false);
                      return;
                    }
                    var embed12 = new DiscordEmbedBuilder() {
                      Title = "Starting check at " + DateTime.Now.ToShortTimeString() + " GMT +2",
                    };
                    await ctx.Channel.SendMessageAsync(embed: embed12).ConfigureAwait(false);

                    var blacklist = "";
                    var url = $"https://develop.roblox.com/v1/universes/{universe}/places?sortOrder=Asc&limit=100";
                    HttpClient z = new HttpClient();
                    var xd = await z.GetStringAsync($"https://develop.roblox.com/v1/universes/{universe}");
                    var sd2 = xd.Split(',');
                    foreach(string b in sd2) {
                      if (b.StartsWith("\"creatorName\"")) {
                        blacklist = b.Replace("\"creatorName\":", "");
                      }
                    }
                    var zs = await z.GetStringAsync(url);
                    var split = zs.Split(',');
                    for (int i = 0; i < split.Length; i++) {
                      if (split[i].StartsWith("{\"id\":")) {
                        var id = split[i].Replace("{\"id\":", "");
                        var id2 = await z.GetStringAsync($"https://api.roblox.com/Marketplace/ProductInfo?assetId={id}");
                        System.Threading.Thread.Sleep(1500);
                        var spl = id2.Split(',');
                        string Name = "";
                        foreach(string z23 in spl) {
                          if (z23.StartsWith("\"Name\"") && z23.Replace("\"Name\":", "") != blacklist) {
                            Name = z23.Replace("\"Name\":", "");
                          }
                        }
                        var lll = await z.GetStringAsync($"https://games.roblox.com/v1/games/{id}/servers/Public?limit=100");
                        var lll2 = lll.Split(',');
                        var JobId = "\n";
                        var Players = "";
                        var max = "";
                        int total = 0;
                        var real2 = "";
                        foreach(string z123 in lll2) {
                          real2 += z123;
                          if (z123.StartsWith("\"data\":[{\"id\":\"")) {
                            var real = z123.Replace("\"data\":[{\"id\":\"", "");
                            JobId += real + " | ";
                          } else if (z123.StartsWith("{\"id\":\"")) {
                            var real = z123.Replace("{\"id\":\"", "");
                            JobId += real + " | ";
                          } else if (z123.StartsWith("\"playing\"")) {
                            Players = z123.Replace("\"playing\":", "");
                            total += int.Parse(Players);
                            JobId += "**" + Players + "/" + max + "\n" + "**";
                          } else if (z123.StartsWith("\"maxPlayers\"")) {
                            max = z123.Replace("\"maxPlayers\":", "");

                          }

                        }
                        var embed = new DiscordEmbedBuilder() {
                          Title = Name,
                            Description = "PlayerCount: " + total + "\n\nJobId(s):\n " + JobId.Replace("\"", "") + "\n Link: https://www.roblox.com/games/" + id + "\n PlaceId: " + id,
                        };
                        if (Players.Length > 0) {
                          await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
                        } else if (Name.StartsWith("\"Trainee Camp [Wall Si")) {
                          Console.WriteLine(real2 + " " + Name);
                          await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
                        } else {
                          Console.WriteLine("no playercount for place: " + Name);
                        }

                      }

                    }

                    var embed1 = new DiscordEmbedBuilder() {
                      Title = "Finished, took " + (DateTime.Now - time).TotalSeconds + " seconds",
                    };
                    await ctx.Channel.SendMessageAsync(embed: embed1).ConfigureAwait(false);

                  }
                  [Command("total")]
                  [CooldownAttribute(1, 3, bucketType: CooldownBucketType.User)]
                async Task totalUniverse(CommandContext ctx) {
                  var Userid = ctx.User.Id.ToString();
                  var whitelistedUsers = Whitelisted.Whitelisted1.Split(',');
                  if (locked && Array.IndexOf(whitelistedUsers, Userid) == -1) {
                    await ctx.Channel.SendMessageAsync("You cannot utilize my abilities while I am chained.").ConfigureAwait(false);
                    return;
                  }
                  if (lockmodeactive) {

                    var embed1234 = new DiscordEmbedBuilder() {
                      Title = "turning off lock mode and executing command ",
                    };
                    lockmodeactive = false;
                    await ctx.Channel.SendMessageAsync(embed: embed1234).ConfigureAwait(false);
                  }
                  var time = DateTime.Now;
                  var url = $"https://games.roblox.com/v1/games?universeIds={universe}";
                  if (universe.Length == 0) {
                    var embed1234 = new DiscordEmbedBuilder() {
                      Title = "Invalid check, no universe",
                    };
                    await ctx.Channel.SendMessageAsync(embed: embed1234).ConfigureAwait(false);
                  }
                  HttpClient z = new HttpClient();
                  var zs = await z.GetStringAsync(url);
                  var split = zs.Split(',');
                  foreach(string s in split) {
                    if (s.StartsWith("\"playi")) {
                      var x = s.Replace("\"playing\":", "");
                      var embed132 = new DiscordEmbedBuilder() {
                        Title = "Active",
                          Description = x,
                      };
                      await ctx.Channel.SendMessageAsync(embed: embed132).ConfigureAwait(false);
                      break;
                    }
                  }

                }

              }
            }
            }
        }
    }
