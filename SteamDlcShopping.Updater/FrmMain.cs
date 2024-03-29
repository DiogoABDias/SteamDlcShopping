using SteamDlcShopping.Core.Controllers;
using System.Diagnostics;

namespace SteamDlcShopping.Updater;

public partial class FrmMain : Form
{
    public FrmMain() => InitializeComponent();

    private async void FrmMain_Shown(object sender, EventArgs e)
    {
        try
        {
            lblProgress.Text = "Downloading the latest release...";

            string url = await CoreController.GetLatestVersionUrlAsync();
            using Stream stream = await new HttpClient().GetStreamAsync(url);
            using FileStream fileStream = new("SteamDlcShopping.exe", FileMode.OpenOrCreate);
            await stream.CopyToAsync(fileStream);
            fileStream.Close();

            lblProgress.ForeColor = Color.Green;
            lblProgress.Text = "SteamDlcShopping successfully updated!";

            string file = "SteamDlcShopping.exe";

            if (!File.Exists(file))
            {
                return;
            }

            await Task.Delay(5000);
            Process.Start(file);
            Close();
        }
        catch (Exception ex)
        {
            lblProgress.ForeColor = Color.Red;
            lblProgress.Text = $"An error was encountered updating SteamDlcShopping!{Environment.NewLine}Try downloading the latest version manually.";
            CoreController.LogException(ex);
        }
    }
}