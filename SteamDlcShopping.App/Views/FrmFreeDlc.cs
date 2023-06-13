﻿using SteamDlcShopping.App.Properties;
using SteamDlcShopping.Core.Controllers;
using System.Diagnostics;

namespace SteamDlcShopping.App.Views
{
    public partial class FrmFreeDlc : Form
    {
        public FrmFreeDlc()
        {
            InitializeComponent();
        }

        //////////////////////////////////////// FORM ////////////////////////////////////////

        private void FrmFreeDlc_Load(object sender, EventArgs e)
        {
            lsbDlc.DisplayMember = "Value";
            lsbDlc.ValueMember = "Key";

            Dictionary<int, string> dlcList = LibraryController.GetFreeDlc();

            lsbDlc.BeginUpdate();

            foreach (KeyValuePair<int, string> item in dlcList)
            {
                lsbDlc.Items.Add(item);
            }

            lsbDlc.EndUpdate();
        }

        //////////////////////////////////////// LISTBOX ////////////////////////////////////////

        private void LsbDlc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsbDlc.SelectedItem is null)
            {
                return;
            }

            KeyValuePair<int, string> item = (KeyValuePair<int, string>)lsbDlc.SelectedItem;

            String argumentUrl = $"https://store.steampowered.com/app/{item.Key}";

            if (Settings.Default.OpenPageWithSteam)
            {
                argumentUrl = $"steam://openurl/{argumentUrl}";
            }

            Process process = new()
            {
                StartInfo = new()
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    FileName = "cmd.exe",
                    Arguments = $"/c start {argumentUrl}"
                }
            };

            process.Start();
        }

        // Testing github actions
    }
}