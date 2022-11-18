﻿using SteamDlcShopping.Core.Controllers;
using SteamDlcShopping.Core.ViewModels;
using SteamDlcShopping.Properties;

namespace SteamDlcShopping.Views
{
    public partial class FrmBlacklist : Form
    {
        public FrmBlacklist()
        {
            InitializeComponent();
            _blacklist = new();
        }

        //////////////////////////////////////// FORM ////////////////////////////////////////

        private void FrmBlacklist_Load(object sender, EventArgs e)
        {
            lsbBlacklist.DisplayMember = "Name";

            LoadBlacklist();
            LoadListbox();
            SetupFields();
        }

        //////////////////////////////////////// LISTBOX ////////////////////////////////////////

        public List<GameBlacklistView> _blacklist;

        private void LoadBlacklist()
        {
            BlacklistController.Load();
            _blacklist = BlacklistController.GetView(txtBlacklistSearch.Text, chkHideAutoBlacklistedGames.Checked);
        }

        private void LoadListbox()
        {
            lsbBlacklist.Items.Clear();

            lsbBlacklist.BeginUpdate();

            foreach (GameBlacklistView game in _blacklist)
            {
                lsbBlacklist.Items.Add(game);
            }

            lsbBlacklist.EndUpdate();
        }

        private void SetupFields()
        {
            lblGameCount.Text = _blacklist.Count > 0 ? $"Count: {_blacklist.Count}" : null;
            btnRemove.Enabled = false;
            btnClearAutoBlacklisted.Enabled = _blacklist.Any(x => x.AutoBlacklisted);
        }

        private void lsbBlacklist_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = lsbBlacklist.SelectedIndices.Count > 0;
        }

        //////////////////////////////////////// FILTERS ////////////////////////////////////////

        private void txtBlacklistSearch_TextChanged(object sender, EventArgs e)
        {
            LoadBlacklist();
            LoadListbox();
            SetupFields();
        }

        private void chkHideAutoBlacklistedGames_CheckedChanged(object sender, EventArgs e)
        {
            LoadBlacklist();
            LoadListbox();
            SetupFields();
        }

        //////////////////////////////////////// BUTTONS ////////////////////////////////////////

        private void btnRemove_Click(object sender, EventArgs e)
        {
            List<int> unblacklist = new();

            foreach (object item in lsbBlacklist.SelectedItems)
            {
                GameBlacklistView game = (GameBlacklistView)item;
                unblacklist.Add(game.AppId);
            }

            if (unblacklist.Any())
            {
                BlacklistController.RemoveGames(unblacklist);

                LoadBlacklist();
                LoadListbox();
                SetupFields();
            }
        }

        private void btnClearAutoBlacklisted_Click(object sender, EventArgs e)
        {
            BlacklistController.ClearAutoBlacklist();

            LoadBlacklist();
            LoadListbox();
            SetupFields();

            if (!Settings.Default.AutoBlacklist)
            {
                return;
            }

            switch (Settings.Default.AutoBlacklistReminder)
            {
                case 0:
                    Settings.Default.AutoBlacklistLastReminder = Settings.Default.AutoBlacklistLastReminder.AddDays(7);
                    break;
                case 1:
                    Settings.Default.AutoBlacklistLastReminder = Settings.Default.AutoBlacklistLastReminder.AddMonths(1);
                    break;
                case 2:
                    Settings.Default.AutoBlacklistLastReminder = Settings.Default.AutoBlacklistLastReminder.AddYears(1);
                    break;
            }

            Settings.Default.Save();
        }
    }
}