namespace SteamDlcShopping.Core.Models;

internal class Blacklist
{
    //Properties
    internal List<GameBlacklist>? Games { get; private set; }

    //Methods
    internal async Task LoadAsync(long steamId)
    {
        if (!File.Exists($"{steamId}.txt"))
        {
            return;
        }

        string content = await File.ReadAllTextAsync($"{steamId}.txt");
        Games = JsonConvert.DeserializeObject<List<GameBlacklist>>(content);
    }

    internal async Task SaveAsync(long steamId)
    {
        if (Games is null)
        {
            return;
        }

        string content = JsonConvert.SerializeObject(Games);
        await File.WriteAllTextAsync($"{steamId}.txt", content);
    }

    internal void AddGame(int appId, string name, bool autoBlacklisted = true)
    {
        Games ??= [];

        if (Games.Any(x => x.AppId == appId))
        {
            return;
        }

        GameBlacklist gameBlacklist = new(appId, name, autoBlacklisted);
        Games.Add(gameBlacklist);
    }

    internal void RemoveGame(int appId)
    {
        if (Games is null)
        {
            return;
        }

        if (!Games.Any(x => x.AppId == appId))
        {
            return;
        }

        int index = Games.FindIndex(x => x.AppId == appId);
        Games.RemoveAt(index);
    }
}