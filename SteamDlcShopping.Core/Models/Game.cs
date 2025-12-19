namespace SteamDlcShopping.Core.Models;

internal class Game(int appId = default, string? name = default)
{
    //Properties
    internal int AppId { get; } = appId;

    internal string? Name { get; } = name;

    internal long? DlcTotalCurrentPrice { get; private set; }

    internal long? DlcTotalFullPrice { get; private set; }

    internal int DlcLeft { get; private set; }

    internal int DlcHighestPercentage { get; private set; }

    internal bool HasTooManyDlc { get; set; }

    internal bool FailedFetch { get; private set; }

    internal List<Dlc> DlcList { get; private set; } = [];

    //Methods
    internal async Task LoadDlcAsync()
    {
        Uri uri = new("https://store.steampowered.com");

        using HttpClientHandler handler = new();
        handler.CookieContainer = new();
        handler.CookieContainer.Add(uri, new Cookie("birthtime", HttpUtility.UrlEncode("birthtime=0; path=/; max-age=315360000")));

        HttpClient httpClient = new(handler);
        string response;

        using HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"{uri.OriginalString}/app/{AppId}");
        using HttpContent content = httpResponseMessage.Content;
        response = await content.ReadAsStringAsync();

        if (response.Contains("<H1>Access Denied</H1>"))
        {
            FailedFetch = true;
            return;
        }

        FailedFetch = false;

        //The html dlc area was not found
        if (!response.Contains("gameAreaDLCSection"))
        {
            return;
        }

        if (response.Contains("game_area_dlc_excluded_by_preferences"))
        {
            HasTooManyDlc = true;
        }

        HtmlDocument htmlDoc = new();
        htmlDoc.LoadHtml(response);

        //The html parse failed
        if (htmlDoc.DocumentNode is null)
        {
            return;
        }

        HtmlNode dlcBrowse = htmlDoc.DocumentNode.SelectSingleNode("//span[contains(@class, 'note')]");

        //The node selection found no results
        if (dlcBrowse is null)
        {
            return;
        }

        int from = dlcBrowse.InnerText.IndexOf('(') + 1;
        int to = dlcBrowse.InnerText.LastIndexOf(')');

        if (int.TryParse(dlcBrowse.InnerText[from..to], out int count))
        {
            HasTooManyDlc = count > 200;
        }

        HtmlNodeCollection dlcList = htmlDoc.DocumentNode.SelectNodes("//a[contains(@class, 'game_area_dlc_row')]");

        //The node selection found no results
        if (dlcList is null || dlcList.Count == 0)
        {
            return;
        }

        DlcList = [];

        foreach (HtmlNode node in dlcList)
        {
            HtmlNode priceNode = node.SelectSingleNode("./div[@class='game_area_dlc_price']");

            string appId = node.Attributes["data-ds-appid"].Value;
            string? name = WebUtility.HtmlDecode(node.SelectSingleNode("./div[@class='game_area_dlc_name']")?.InnerText?.Trim());
            string? price = priceNode.InnerText.Trim();

            string? originalPrice = priceNode.SelectSingleNode(".//div[@class='discount_original_price']")?.InnerText?.Trim();
            string? salePrice = priceNode.SelectSingleNode(".//div[@class='discount_final_price']")?.InnerText?.Trim();
            string? salePercentage = priceNode.SelectSingleNode(".//div[@class='discount_pct']")?.InnerText?.Trim();

            bool isFree = false;
            bool isAvailable = true;
            Sale? sale = null;

            long iPrice = 0;

            switch (price.ToLower())
            {
                case "free":
                    isFree = true;
                    break;
                case "n/a":
                    isAvailable = false;
                    break;
                default:
                    //Dlc is currently on sale
                    if (!string.IsNullOrWhiteSpace(salePrice) && !string.IsNullOrWhiteSpace(salePercentage))
                    {
                        price = originalPrice;
                        int iSalePercentage = Convert.ToInt32(salePercentage[1..^1]);

                        long iSalePrice = Currency.TemplateToPrice(salePrice);

                        sale = new(iSalePercentage, iSalePrice);
                    }

                    iPrice = Currency.TemplateToPrice(price ?? "");

                    break;
            }

            Dlc dlc = new(Convert.ToInt32(appId), name, iPrice, sale, isAvailable, isFree);
            DlcList.Add(dlc);
        }
    }

    internal void CalculateDlcMetrics()
    {
        DlcTotalCurrentPrice = 0;
        DlcTotalFullPrice = 0;
        DlcLeft = 0;
        DlcHighestPercentage = 0;

        foreach (Dlc dlc in DlcList)
        {
            if (dlc.IsOwned)
            {
                continue;
            }

            DlcLeft++;

            DlcTotalFullPrice += dlc.Price;

            if (dlc.Sale is null)
            {
                DlcTotalCurrentPrice += dlc.Price;
                continue;
            }

            DlcTotalCurrentPrice += dlc.Sale.Price;

            if (dlc.Sale?.Percentage > DlcHighestPercentage)
            {
                DlcHighestPercentage = dlc.Sale.Percentage;
            }
        }
    }
}