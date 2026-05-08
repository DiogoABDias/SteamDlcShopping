using Microsoft.Web.WebView2.Core;
using SteamDlcShopping.App.Extensibility;
using SteamDlcShopping.App.Properties;
using System.ComponentModel;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

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
            Thread.Sleep(500);

            //Remove header, menu and footer
            await webLogin.CoreWebView2.ExecuteScriptAsync("Array.from(document.getElementsByClassName('responsive_header')).forEach(x => { x.remove() });");
            await webLogin.CoreWebView2.ExecuteScriptAsync("Array.from(document.querySelectorAll(\"div[data-featuretarget^='store-menu-v']\")).forEach(x => { x.remove() });");
            await webLogin.CoreWebView2.ExecuteScriptAsync("Array.from(document.getElementsByClassName('login_bottom_row')).forEach(x => { x.remove() });");

            //Remove form links
            await webLogin.CoreWebView2.ExecuteScriptAsync("document.querySelectorAll(\"a[href*='wizard']\")[0].remove();");
            await webLogin.CoreWebView2.ExecuteScriptAsync("document.querySelectorAll(\"a[href*='/mobile']\")[0].parentElement.remove();");

            //Remove cookie popup
            await webLogin.CoreWebView2.ExecuteScriptAsync("document.getElementById('cookiePrefPopup').remove();");

            //Remove paddings
            await webLogin.CoreWebView2.ExecuteScriptAsync("Array.from(document.getElementsByClassName('responsive_page_content')).forEach(x => { x.style.padding = '0px' });");
            await webLogin.CoreWebView2.ExecuteScriptAsync("document.getElementById('responsive_page_template_content').style.padding = '0px';");

            //Disable scrolling
            await webLogin.CoreWebView2.ExecuteScriptAsync("document.body.style.overflow = 'hidden';");

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
        else
        {
            webLogin.GoBack();
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