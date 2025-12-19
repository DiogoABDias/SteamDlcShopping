using System.Diagnostics;

namespace SteamDlcShopping.App.Views;

public partial class FrmAbout : Form
{
    private string? _latestVersion;

    public FrmAbout() => InitializeComponent();

    private async void FrmAbout_Load(object sender, EventArgs e)
    {
        lblVersion.Text = Application.ProductVersion.Split('+')[0];
        _latestVersion = await CoreController.GetLatestVersionNameAsync(Application.ProductVersion);

        if (_latestVersion is null)
        {
            return;
        }

        lnkNewVersion.VisitedLinkColor = lnkNewVersion.LinkColor;
        lnkNewVersion.Visible = true;
    }

    private void LnkNewVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Settings.Default.UpdateIgnored = false;
        Settings.Default.Save();

        Process.Start("Updater.exe");
        Application.Exit();
    }

    private void LnkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => CoreController.OpenLink("https://github.com/DiogoABDias/SteamDlcShopping");
}