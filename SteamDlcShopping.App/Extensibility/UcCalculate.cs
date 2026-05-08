using SteamDlcShopping.App.Properties;

namespace SteamDlcShopping.App.Extensibility;

public partial class UcCalculate : UserControl
{
    public UcCalculate() => InitializeComponent();

    private void UcLoading_Load(object sender, EventArgs e)
    {
        Control? control = Parent?.Controls["grbLibrary"];

        if (control is not null)
        {
            Size = new Size(control.ClientSize.Width, control.ClientSize.Height);
        }

        ptbLoading.Left = (ClientSize.Width - ptbLoading.Width) / 2;
        ptbLoading.Top = (ClientSize.Height - ptbLoading.Height) / 2;
        ptbLoading.Image = Settings.Default.UseMemeLoading ? Resources.loadingMeme : Resources.loadingDefault;
    }
}