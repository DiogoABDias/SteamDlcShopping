namespace SteamDlcShopping.App.Views;

public partial class FrmBlacklist : Form
{
    public FrmBlacklist()
    {
        InitializeComponent();
        _blacklist = [];
    }

    //////////////////////////////////////// FORM ////////////////////////////////////////

    private async void FrmBlacklist_Load(object sender, EventArgs e)
    {
        lsbBlacklist.DisplayMember = "Name";

        await LoadBlacklistAsync();
        LoadListbox();
        SetupFields();
    }

    //////////////////////////////////////// LISTBOX ////////////////////////////////////////

    public List<GameBlacklistView> _blacklist;

    private async Task LoadBlacklistAsync()
    {
        await BlacklistController.LoadAsync();
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

    private void LsbBlacklist_SelectedIndexChanged(object sender, EventArgs e) => btnRemove.Enabled = lsbBlacklist.SelectedIndices.Count > 0;

    //////////////////////////////////////// FILTERS ////////////////////////////////////////

    private async void TxtBlacklistSearch_TextChanged(object sender, EventArgs e)
    {
        await LoadBlacklistAsync();
        LoadListbox();
        SetupFields();
    }

    private async void ChkHideAutoBlacklistedGames_CheckedChanged(object sender, EventArgs e)
    {
        await LoadBlacklistAsync();
        LoadListbox();
        SetupFields();
    }

    //////////////////////////////////////// BUTTONS ////////////////////////////////////////

    private async void BtnRemove_Click(object sender, EventArgs e)
    {
        List<int> unblacklist = [];

        foreach (object item in lsbBlacklist.SelectedItems)
        {
            GameBlacklistView game = (GameBlacklistView)item;
            unblacklist.Add(game.AppId);
        }

        if (unblacklist.Count != 0)
        {
            await BlacklistController.RemoveGamesAsync(unblacklist);

            await LoadBlacklistAsync();
            LoadListbox();
            SetupFields();
        }
    }

    private async void BtnClearAutoBlacklisted_Click(object sender, EventArgs e)
    {
        await BlacklistController.ClearAutoBlacklistAsync();

        await LoadBlacklistAsync();
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