using SteamDlcShopping.Core.Controllers;
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
        if (File.Exists("Updater.exe"))
        {
            Process.Start("Updater.exe");
            Application.Exit();
        }
        else
        {
            MessageBox.Show("Could not find Updater.exe. Please download the latest version manually.", "Steam DLC Shopping", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void LnkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => CoreController.OpenLink("https://github.com/DiogoABDias/SteamDlcShopping");
}