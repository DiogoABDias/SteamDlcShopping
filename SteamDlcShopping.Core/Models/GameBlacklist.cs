namespace SteamDlcShopping.Core.Models;

internal class GameBlacklist(int appId, string? name, bool autoBlacklisted)
{
    //Properties
    public int AppId { get; } = appId;

    public string? Name { get; } = name;

    public bool AutoBlacklisted { get; } = autoBlacklisted;
}