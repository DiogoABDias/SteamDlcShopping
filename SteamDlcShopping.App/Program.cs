namespace SteamDlcShopping.App;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        if (string.IsNullOrWhiteSpace(Settings.Default.SteamApiKey))
        {
            Application.Run(new FrmSettings());
        }

        if (!string.IsNullOrWhiteSpace(Settings.Default.SteamApiKey))
        {
            Application.Run(new FrmMain());
        }

        Application.Exit();
    }
}