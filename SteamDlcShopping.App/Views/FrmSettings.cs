using SteamDlcShopping.App.Properties;
using System.Diagnostics;

namespace SteamDlcShopping.App.Views
{
    public partial class FrmSettings : Form
    {
        readonly ErrorProvider _erpSteamApiKey;

        public FrmSettings()
        {
            InitializeComponent();
            _erpSteamApiKey = new();
        }

        //////////////////////////////////////// FORM ////////////////////////////////////////

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            //Controls
            txtSteamApiKey.Text = Settings.Default.SteamApiKey;
            chkAutoBlacklist.Checked = Settings.Default.AutoBlacklist;

            lblReminder.Enabled = chkAutoBlacklist.Checked;
            ddlReminder.Enabled = chkAutoBlacklist.Checked;

            ddlReminder.SelectedIndex = Settings.Default.AutoBlacklistReminder switch
            {
                -1 => 1,
                _ => Settings.Default.AutoBlacklistReminder
            };

            ddlGameSort.SelectedIndex = Settings.Default.GameSortColumn == -1 ? 0 : Settings.Default.GameSortColumn * 2 + 1 + Convert.ToInt32(Settings.Default.GameSortDescending);
            ddlDlcSort.SelectedIndex = Settings.Default.DlcSortColumn == -1 ? 0 : Settings.Default.DlcSortColumn * 2 + 1 + Convert.ToInt32(Settings.Default.DlcSortDescending);
			ddlPageOpener.SelectedIndex = Settings.Default.OpenPageWithSteam ? 1 : 0;

			chkUseMemeLoading.Checked = Settings.Default.UseMemeLoading;

            //Errors
            _erpSteamApiKey.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            _erpSteamApiKey.SetIconAlignment(txtSteamApiKey, ErrorIconAlignment.MiddleRight);
            _erpSteamApiKey.SetIconPadding(txtSteamApiKey, 5);

            //Help icons
            pbtSteamApiKey.Image = SystemIcons.Information.ToBitmap();
            ptbSmartLoading.Image = SystemIcons.Information.ToBitmap();

            //Tooltips
            ToolTip toolTip = new();
            toolTip.SetToolTip(pbtSteamApiKey, "This key is required in order to retrieve the owned games information.");
            toolTip.SetToolTip(ptbSmartLoading, "Improves loading times by automatically blacklisting games without DLC after the first time they were loaded.");
        }

        //////////////////////////////////////// STEAM API KEY ////////////////////////////////////////

        private void TxtSteamApiKey_TextChanged(object sender, EventArgs e)
        {
            _erpSteamApiKey.Clear();
        }

        private void LnkGetSteamApiKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process process = new()
            {
                StartInfo = new()
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    FileName = "cmd.exe",
                    Arguments = "/c start https://steamcommunity.com/dev/apikey"
                }
            };

            process.Start();
        }

        //////////////////////////////////////// AUTO BLACKLIST ////////////////////////////////////////

        private void ChkAutoBlacklist_CheckedChanged(object sender, EventArgs e)
        {
            lblReminder.Enabled = chkAutoBlacklist.Checked;
            ddlReminder.Enabled = chkAutoBlacklist.Checked;
        }

        //////////////////////////////////////// BUTTONS ////////////////////////////////////////

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSteamApiKey.Text))
            {
                _erpSteamApiKey.SetError(txtSteamApiKey, "Steam API Key is required!");
                return;
            }

            if (Settings.Default.AutoBlacklistReminder != ddlReminder.SelectedIndex)
            {
                Settings.Default.AutoBlacklistLastReminder = DateTime.Now.Date;
            }

            Settings.Default.SteamApiKey = txtSteamApiKey.Text;
            Settings.Default.AutoBlacklist = chkAutoBlacklist.Checked;
            Settings.Default.AutoBlacklistReminder = ddlReminder.SelectedIndex;
            Settings.Default.GameSortColumn = ddlGameSort.SelectedIndex == 0 ? -1 : (ddlGameSort.SelectedIndex - 1) / 2;
            Settings.Default.GameSortDescending = ddlGameSort.SelectedIndex % 2 == 0;
            Settings.Default.DlcSortColumn = ddlDlcSort.SelectedIndex == 0 ? -1 : (ddlDlcSort.SelectedIndex - 1) / 2;
            Settings.Default.DlcSortDescending = ddlDlcSort.SelectedIndex % 2 == 0;
            Settings.Default.OpenPageWithSteam = ddlPageOpener.SelectedIndex == 1;
            Settings.Default.UseMemeLoading = chkUseMemeLoading.Checked;
            Settings.Default.Save();

            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}