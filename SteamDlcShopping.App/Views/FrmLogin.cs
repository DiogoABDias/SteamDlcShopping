using System.ComponentModel;

namespace SteamDlcShopping.App.Views;

public partial class FrmLogin : Form
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool AccessDenied { get; set; }

    public FrmLogin() => InitializeComponent();

    //////////////////////////////////////// FORM ////////////////////////////////////////

    private void FrmLogin_Load(object sender, EventArgs e)
    {
        UcLoad ucLoad = new()
        {
            Name = "ucLoad",
            Location = new Point(0, 0)
        };

        Controls.Add(ucLoad);
    }

    private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
    {
        webLogin.Stop();
        webLogin.Dispose();
    }

    //////////////////////////////////////// WEBVIEW2 ////////////////////////////////////////

    private void WebLogin_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
    {
        webLogin.CoreWebView2.CookieManager.DeleteAllCookies();
        webLogin.CoreWebView2.Settings.AreDevToolsEnabled = false;
        webLogin.CoreWebView2.DOMContentLoaded += WebLogin_CoreWebView2_DOMContentLoadedAsync;
    }

    private void WebLogin_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
    {
        if (e.Uri.Contains("HelpWithLoginInfo"))
        {
            e.Cancel = true;
        }

        if (e.Uri == "https://store.steampowered.com/")
        {
            webLogin.Visible = false;
        }
    }

    private async void WebLogin_CoreWebView2_DOMContentLoadedAsync(object? sender, CoreWebView2DOMContentLoadedEventArgs e)
    {
        if (webLogin.Source.AbsoluteUri == "https://store.steampowered.com/login")
        {
            Thread.Sleep(1000);

            await webLogin.CoreWebView2.ExecuteScriptAsync("document.getElementsByClassName('responsive_header')[0].remove();");
            await webLogin.CoreWebView2.ExecuteScriptAsync("document.getElementsByClassName('login_bottom_row')[0].remove();");
            await webLogin.CoreWebView2.ExecuteScriptAsync("document.querySelectorAll(\"a[class^='_']\")[0].remove()");
            await webLogin.CoreWebView2.ExecuteScriptAsync("document.querySelectorAll(\"a[class^='_']\")[0].parentElement.remove()");
            await webLogin.CoreWebView2.ExecuteScriptAsync("document.body.style.overflow = 'hidden';");
            await webLogin.CoreWebView2.ExecuteScriptAsync("document.getElementsByClassName('page_content')[0].scrollIntoView({behavior: 'auto',block: 'center',inline: 'center'});");

            string html = await webLogin.ExecuteScriptAsync("document.documentElement.outerHTML");
            HtmlDocument htmlDocument = new();
            htmlDocument.LoadHtml(html);

            if (htmlDocument.DocumentNode.OuterHtml.Contains("Access Denied"))
            {
                AccessDenied = true;
                Close();
            }

            webLogin.Visible = true;
        }
    }

    private async void WebLogin_NavigationCompletedAsync(object sender, CoreWebView2NavigationCompletedEventArgs e)
    {
        if (webLogin.Source.AbsoluteUri == "https://store.steampowered.com/")
        {
            List<CoreWebView2Cookie> cookies = await webLogin.CoreWebView2.CookieManager.GetCookiesAsync("https://store.steampowered.com/");

            Settings.Default.SessionId = GetCookieValue(cookies, "sessionid");
            Settings.Default.SteamLoginSecure = GetCookieValue(cookies, "steamLoginSecure");
            Settings.Default.Save();

            Close();
        }
    }

    //////////////////////////////////////// METHODS ////////////////////////////////////////

    private static string? GetCookieValue(List<CoreWebView2Cookie> cookies, string name)
    {
        foreach (CoreWebView2Cookie cookie in cookies)
        {
            if (cookie.Name == name)
            {
                return cookie.Value;
            }
        }

        return null;
    }
}