namespace SteamDlcShopping.Core;

internal static class Currency
{
    //Properties
    internal static string Template { get; private set; }

    internal static NumberFormatInfo Format { get; private set; }

    //Constructor
    static Currency()
    {
        Template = string.Empty;
        Format = new()
        {
            NumberGroupSeparator = "",
            NumberDecimalDigits = 0
        };
    }

    //Methods
    internal static async Task SetCurrencyAsync()
    {
        Uri uri = new("https://store.steampowered.com");
        HttpClient httpClient = new();
        string response;

        using HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"{uri.OriginalString}/bundle/232");
        using HttpContent content = httpResponseMessage.Content;
        response = await content.ReadAsStringAsync();

        HtmlDocument htmlDoc = new();
        htmlDoc.LoadHtml(response);

        if (htmlDoc.DocumentNode.OuterHtml.Contains("<H1>Access Denied</H1>"))
        {
            return;
        }

        //The html parse failed
        if (htmlDoc.DocumentNode is null)
        {
            return;
        }

        HtmlNode priceNode;
        priceNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='price bundle_final_package_price']");

        string textPrice = priceNode.InnerText.Trim();
        int remainingDigits = textPrice.Count(char.IsDigit);
        int firstDigit = -1;
        int lastDigit = -1;
        int index = -1;
        List<char> separators = [];

        foreach (char character in textPrice)
        {
            index++;

            if (!char.IsDigit(character))
            {
                if (firstDigit != -1)
                {
                    separators.Add(character);
                }

                continue;
            }

            if (firstDigit == -1)
            {
                firstDigit = index;
            }

            lastDigit = index;
            remainingDigits--;

            if (remainingDigits == 0)
            {
                break;
            }
        }

        string value = textPrice[firstDigit..(lastDigit + 1)];

        Template = textPrice.Replace(value, "<price>");

        if (separators.Count != 0)
        {
            if (separators.Count > 1)
            {
                Format.NumberGroupSeparator = separators[0].ToString();
            }

            Format.NumberDecimalSeparator = separators.Last().ToString();
            Format.NumberDecimalDigits = lastDigit - value.IndexOf(separators.Last());
        }
    }

    internal static string PriceToTemplate(long price)
    {
        string result;

        double dPrice = price / Math.Pow(10, Format.NumberDecimalDigits);
        string textPrice = string.Format(Format, "{0:N}", dPrice);
        result = Template.Replace("<price>", textPrice);

        return result;
    }

    internal static long TemplateToPrice(string price)
    {
        long result = 0;

        if (price == string.Empty)
        {
            return result;
        }

        int startIndex = Template.IndexOf('<');
        int endIndex = Template.IndexOf('>') + 1;

        string startText = Template[..startIndex];
        string endText = Template[endIndex..];

        //Formatting of rounded values with -- on the decimal part
        price = (price ?? "").Replace('-', '0');

        if (startText != string.Empty)
        {
            price = price.Replace(startText, "");
        }

        if (endText != string.Empty)
        {
            price = price.Replace(endText, "");
        }

        if (!double.TryParse(price, NumberStyles.Any, Format, out double dPrice))
        {
            return result;
        }

        result = Convert.ToInt64(dPrice * Math.Pow(10, Format.NumberDecimalDigits));

        return result;
    }
}