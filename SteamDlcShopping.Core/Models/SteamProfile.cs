namespace SteamDlcShopping.Core.Models;

internal class SteamProfile
{
    //Properties
    private const string _url = "https://steamcommunity.com/profiles";

    internal long Id { get; private set; }

    internal string? Username { get; private set; }

    internal string? AvatarUrl { get; private set; }

    //Constructor
    internal async Task LoadAsync(string steamLoginSecure)
    {
        if (string.IsNullOrWhiteSpace(steamLoginSecure))
        {
            return;
        }

        HttpClient httpClient;
        string xml;
        XmlDocument xmlDocument;
        XmlNode? xmlNode;

        //Id
        string steamId = WebUtility.UrlDecode(steamLoginSecure);
        int index = steamId.IndexOf('|', 0);

        if (index != -1)
        {
            steamId = steamId[..index];
        }

        Id = Convert.ToInt64(steamId);

        //Username
        httpClient = new();
        xml = await httpClient.GetStringAsync($"{_url}/{Id}/?xml=1");

        xmlDocument = new();
        xmlDocument.LoadXml(xml);

        xmlNode = xmlDocument.SelectSingleNode("//steamID");
        Username = xmlNode is not null ? WebUtility.HtmlDecode(xmlNode.InnerText) : null;

        //AvatarUrl
        httpClient = new();
        xml = await httpClient.GetStringAsync($"{_url}/{Id}/?xml=1");

        xmlDocument = new();
        xmlDocument.LoadXml(xml);

        xmlNode = xmlDocument.SelectSingleNode("//avatarMedium");
        AvatarUrl = xmlNode is not null ? WebUtility.HtmlDecode(xmlNode.InnerText) : null;
    }
}