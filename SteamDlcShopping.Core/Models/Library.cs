using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace SteamDlcShopping.Core.Models;

internal class Library
{
    //Fields
    private readonly long _steamId;

    //Properties
    internal List<int>? DynamicStore { get; private set; }

    internal List<Game>? Games { get; private set; }

    internal long? TotalCurrentPrice => Games?.Sum(x => x.DlcTotalCurrentPrice);

    internal long? TotalFullPrice => Games?.Sum(x => x.DlcTotalFullPrice);

    //Constructor
    internal Library(long steamId) => _steamId = steamId;

    //Methods
    internal async Task LoadDynamicStoreAsync(string sessionId, string steamLoginSecure)
    {
        HttpResponseMessage response;
        Uri uri = new("https://store.steampowered.com/dynamicstore/userdata/");

        using HttpClientHandler handler = new();
        handler.CookieContainer = new();
        handler.CookieContainer.Add(uri, new Cookie("sessionid", sessionId));
        handler.CookieContainer.Add(uri, new Cookie("steamLoginSecure", steamLoginSecure));

        HttpClient client = new(handler);
        response = await client.GetAsync(uri);

        string html = await response.Content.ReadAsStringAsync();

        if (html.Contains("<H1>Access Denied</H1>"))
        {
            DynamicStore = null;
            return;
        }

        JObject jObject = JObject.Parse(html);
        DynamicStore = JsonConvert.DeserializeObject<List<int>>($"{jObject["rgOwnedApps"]}");
    }

    internal async Task LoadGamesAsync(string steamApiKey)
    {
        HttpClient httpClient = new();

        string response = await httpClient.GetStringAsync($"https://api.steampowered.com/IPlayerService/GetOwnedGames/v1/?key={steamApiKey}&steamid={_steamId}&include_appinfo=true");

        JObject jObject = JObject.Parse(response);

        Games = JsonConvert.DeserializeObject<List<Game>>($"{jObject["response"]?["games"]}");
    }

    internal async Task LoadGamesDlcAsync()
    {
        if (Games is null)
        {
            return;
        }

        await Parallel.ForEachAsync(Games, async (game, _) => await game.LoadDlcAsync());
    }

    internal async Task RetryFailedGamesAsync()
    {
        if (Games is null)
        {
            return;
        }

        await Parallel.ForEachAsync(Games.Where(x => x.FailedFetch), async (game, _) => await game.LoadDlcAsync());
    }

    internal void ApplyBlacklist(List<int> appIds)
    {
        if (Games is null)
        {
            return;
        }

        Games.RemoveAll(x => appIds.Contains(x.AppId));
    }
}