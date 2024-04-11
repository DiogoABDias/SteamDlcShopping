using Octokit;

namespace SteamDlcShopping.Core.Controllers;

public static class CoreController
{
    public static async Task<string?> GetLatestVersionNameAsync(string currentVersion)
    {
        GitHubClient client = new(new ProductHeaderValue("SteamDlcShopping"));
        Release release = await client.Repository.Release.GetLatest("DiogoABDias", "SteamDlcShopping");

        Version latestGitHubVersion = new(release.TagName[1..]);
        Version localVersion = new(currentVersion.Split('+')[0]);
        int versionComparison = localVersion.CompareTo(latestGitHubVersion);

        return versionComparison < 0 ? release.Name : null;
    }

    public static async Task<string> GetLatestVersionUrlAsync()
    {
        GitHubClient client = new(new ProductHeaderValue("SteamDlcShopping"));
        Release release = await client.Repository.Release.GetLatest("DiogoABDias", "SteamDlcShopping");

        return release.Assets[0].BrowserDownloadUrl;
    }

    public static void OpenLink(string url)
    {
        Process process = new()
        {
            StartInfo = new()
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                FileName = "cmd.exe",
                Arguments = $"/c start {url}"
            }
        };

        process.Start();
    }

    public static void LogException(Exception exception) => Log.Fatal(exception);
}