using SteamDlcShopping.App.Extensibility;

namespace SteamDlcShopping.App.Views
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            lblUsername = new Label();
            ptbAvatar = new PictureBox();
            btnLogin = new Button();
            btnCalculate = new Button();
            lsvGame = new ListViewPlus();
            colGame = new ColumnHeader();
            ColCost = new ColumnHeader();
            colDlcLeft = new ColumnHeader();
            colMaxDiscount = new ColumnHeader();
            lsvDlc = new ListViewPlus();
            colDlc = new ColumnHeader();
            colPrice = new ColumnHeader();
            colDiscount = new ColumnHeader();
            lblGameCount = new Label();
            lblDlcCount = new Label();
            btnLogout = new Button();
            txtGameSearch = new TextBox();
            grbLibrary = new GroupBox();
            chkFilterBlacklist = new CheckBox();
            lnkTooManyDlc = new LinkLabel();
            lblTooManyDlc = new Label();
            lblLibraryFullPrice = new Label();
            lblLibraryCurrentPrice = new Label();
            chkHideDlcOwned = new CheckBox();
            chkHideDlcNotOnSale = new CheckBox();
            chkHideGamesNotOnSale = new CheckBox();
            btnBlacklist = new Button();
            txtDlcSearch = new TextBox();
            smiSettings = new ToolStripMenuItem();
            smiBlacklist = new ToolStripMenuItem();
            smiFreeDlc = new ToolStripMenuItem();
            mnuMenu = new MenuStrip();
            smiAbout = new ToolStripMenuItem();
            btnRetryFailedGames = new Button();
            chkIgnoreBlacklist = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)ptbAvatar).BeginInit();
            grbLibrary.SuspendLayout();
            mnuMenu.SuspendLayout();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(82, 24);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(73, 15);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "lblUsername";
            // 
            // ptbAvatar
            // 
            ptbAvatar.InitialImage = (Image)resources.GetObject("ptbAvatar.InitialImage");
            ptbAvatar.Location = new Point(12, 27);
            ptbAvatar.Name = "ptbAvatar";
            ptbAvatar.Size = new Size(64, 64);
            ptbAvatar.TabIndex = 1;
            ptbAvatar.TabStop = false;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(82, 42);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += BtnLogin_Click;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(82, 68);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(75, 23);
            btnCalculate.TabIndex = 2;
            btnCalculate.Text = "Calculate";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += BtnCalculate_Click;
            // 
            // lsvGame
            // 
            lsvGame.Columns.AddRange(new ColumnHeader[] { colGame, ColCost, colDlcLeft, colMaxDiscount });
            lsvGame.Cursor = Cursors.Hand;
            lsvGame.FullRowSelect = true;
            lsvGame.GridLines = true;
            lsvGame.Location = new Point(6, 51);
            lsvGame.Name = "lsvGame";
            lsvGame.Size = new Size(681, 237);
            lsvGame.TabIndex = 3;
            lsvGame.UseCompatibleStateImageBehavior = false;
            lsvGame.View = View.Details;
            lsvGame.ColumnClick += LsvGame_ColumnClick;
            lsvGame.SelectedIndexChanged += LsvGame_SelectedIndexChanged;
            lsvGame.DoubleClick += LsvGame_DoubleClick;
            // 
            // colGame
            // 
            colGame.Text = "Game";
            colGame.Width = 420;
            // 
            // ColCost
            // 
            ColCost.Text = "Total Cost";
            ColCost.TextAlign = HorizontalAlignment.Right;
            ColCost.Width = 90;
            // 
            // colDlcLeft
            // 
            colDlcLeft.Text = "DLC Left";
            colDlcLeft.TextAlign = HorizontalAlignment.Right;
            colDlcLeft.Width = 70;
            // 
            // colMaxDiscount
            // 
            colMaxDiscount.Text = "Highest %";
            colMaxDiscount.TextAlign = HorizontalAlignment.Right;
            colMaxDiscount.Width = 80;
            // 
            // lsvDlc
            // 
            lsvDlc.Columns.AddRange(new ColumnHeader[] { colDlc, colPrice, colDiscount });
            lsvDlc.Cursor = Cursors.Hand;
            lsvDlc.FullRowSelect = true;
            lsvDlc.GridLines = true;
            lsvDlc.Location = new Point(6, 374);
            lsvDlc.MultiSelect = false;
            lsvDlc.Name = "lsvDlc";
            lsvDlc.Size = new Size(681, 237);
            lsvDlc.TabIndex = 8;
            lsvDlc.UseCompatibleStateImageBehavior = false;
            lsvDlc.View = View.Details;
            lsvDlc.ColumnClick += LsvDlc_ColumnClick;
            lsvDlc.MouseDoubleClick += LsvDlc_MouseDoubleClick;
            // 
            // colDlc
            // 
            colDlc.Text = "DLC";
            colDlc.Width = 490;
            // 
            // colPrice
            // 
            colPrice.Text = "Price";
            colPrice.TextAlign = HorizontalAlignment.Right;
            colPrice.Width = 90;
            // 
            // colDiscount
            // 
            colDiscount.Text = "Discount";
            colDiscount.TextAlign = HorizontalAlignment.Right;
            colDiscount.Width = 80;
            // 
            // lblGameCount
            // 
            lblGameCount.AutoSize = true;
            lblGameCount.Location = new Point(6, 298);
            lblGameCount.Name = "lblGameCount";
            lblGameCount.Size = new Size(84, 15);
            lblGameCount.TabIndex = 0;
            lblGameCount.Text = "lblGameCount";
            // 
            // lblDlcCount
            // 
            lblDlcCount.AutoSize = true;
            lblDlcCount.Location = new Point(6, 621);
            lblDlcCount.Name = "lblDlcCount";
            lblDlcCount.Size = new Size(70, 15);
            lblDlcCount.TabIndex = 0;
            lblDlcCount.Text = "lblDlcCount";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(82, 42);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 23);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += BtnLogout_Click;
            // 
            // txtGameSearch
            // 
            txtGameSearch.Location = new Point(6, 22);
            txtGameSearch.Name = "txtGameSearch";
            txtGameSearch.Size = new Size(200, 23);
            txtGameSearch.TabIndex = 1;
            txtGameSearch.TextChanged += LsvGame_FilterChanged;
            // 
            // grbLibrary
            // 
            grbLibrary.Controls.Add(chkFilterBlacklist);
            grbLibrary.Controls.Add(lnkTooManyDlc);
            grbLibrary.Controls.Add(lblTooManyDlc);
            grbLibrary.Controls.Add(lblLibraryFullPrice);
            grbLibrary.Controls.Add(lblLibraryCurrentPrice);
            grbLibrary.Controls.Add(chkHideDlcOwned);
            grbLibrary.Controls.Add(chkHideDlcNotOnSale);
            grbLibrary.Controls.Add(chkHideGamesNotOnSale);
            grbLibrary.Controls.Add(btnBlacklist);
            grbLibrary.Controls.Add(txtDlcSearch);
            grbLibrary.Controls.Add(txtGameSearch);
            grbLibrary.Controls.Add(lblGameCount);
            grbLibrary.Controls.Add(lblDlcCount);
            grbLibrary.Controls.Add(lsvGame);
            grbLibrary.Controls.Add(lsvDlc);
            grbLibrary.Location = new Point(12, 97);
            grbLibrary.Name = "grbLibrary";
            grbLibrary.Size = new Size(693, 642);
            grbLibrary.TabIndex = 4;
            grbLibrary.TabStop = false;
            grbLibrary.Text = "Library";
            // 
            // chkFilterBlacklist
            // 
            chkFilterBlacklist.AutoSize = true;
            chkFilterBlacklist.Location = new Point(368, 24);
            chkFilterBlacklist.Name = "chkFilterBlacklist";
            chkFilterBlacklist.Size = new Size(98, 19);
            chkFilterBlacklist.TabIndex = 10;
            chkFilterBlacklist.Text = "Filter blacklist";
            chkFilterBlacklist.UseVisualStyleBackColor = true;
            chkFilterBlacklist.Visible = false;
            chkFilterBlacklist.CheckedChanged += ChkFilterBlacklist_CheckedChanged;
            // 
            // lnkTooManyDlc
            // 
            lnkTooManyDlc.AutoSize = true;
            lnkTooManyDlc.Location = new Point(641, 621);
            lnkTooManyDlc.Name = "lnkTooManyDlc";
            lnkTooManyDlc.Size = new Size(30, 15);
            lnkTooManyDlc.TabIndex = 8;
            lnkTooManyDlc.TabStop = true;
            lnkTooManyDlc.Text = "here";
            lnkTooManyDlc.LinkClicked += LnkTooManyDlc_LinkClicked;
            // 
            // lblTooManyDlc
            // 
            lblTooManyDlc.AutoSize = true;
            lblTooManyDlc.Location = new Point(391, 621);
            lblTooManyDlc.Name = "lblTooManyDlc";
            lblTooManyDlc.Size = new Size(280, 15);
            lblTooManyDlc.TabIndex = 0;
            lblTooManyDlc.Text = "This game has over 200 DLC.  Check the full list here";
            // 
            // lblLibraryFullPrice
            // 
            lblLibraryFullPrice.AutoSize = true;
            lblLibraryFullPrice.Location = new Point(355, 298);
            lblLibraryFullPrice.Name = "lblLibraryFullPrice";
            lblLibraryFullPrice.Size = new Size(101, 15);
            lblLibraryFullPrice.TabIndex = 0;
            lblLibraryFullPrice.Text = "lblLibraryFullPrice";
            // 
            // lblLibraryCurrentPrice
            // 
            lblLibraryCurrentPrice.AutoSize = true;
            lblLibraryCurrentPrice.Location = new Point(212, 298);
            lblLibraryCurrentPrice.Name = "lblLibraryCurrentPrice";
            lblLibraryCurrentPrice.Size = new Size(122, 15);
            lblLibraryCurrentPrice.TabIndex = 0;
            lblLibraryCurrentPrice.Text = "lblLibraryCurrentPrice";
            // 
            // chkHideDlcOwned
            // 
            chkHideDlcOwned.AutoSize = true;
            chkHideDlcOwned.Location = new Point(355, 347);
            chkHideDlcOwned.Name = "chkHideDlcOwned";
            chkHideDlcOwned.Size = new Size(115, 19);
            chkHideDlcOwned.TabIndex = 7;
            chkHideDlcOwned.Text = "Hide DLC owned";
            chkHideDlcOwned.UseVisualStyleBackColor = true;
            chkHideDlcOwned.CheckedChanged += LsvDlc_FilterChanged;
            // 
            // chkHideDlcNotOnSale
            // 
            chkHideDlcNotOnSale.AutoSize = true;
            chkHideDlcNotOnSale.Location = new Point(212, 347);
            chkHideDlcNotOnSale.Name = "chkHideDlcNotOnSale";
            chkHideDlcNotOnSale.Size = new Size(137, 19);
            chkHideDlcNotOnSale.TabIndex = 6;
            chkHideDlcNotOnSale.Text = "Hide DLC not on sale";
            chkHideDlcNotOnSale.UseVisualStyleBackColor = true;
            chkHideDlcNotOnSale.CheckedChanged += LsvDlc_FilterChanged;
            // 
            // chkHideGamesNotOnSale
            // 
            chkHideGamesNotOnSale.AutoSize = true;
            chkHideGamesNotOnSale.Location = new Point(212, 24);
            chkHideGamesNotOnSale.Name = "chkHideGamesNotOnSale";
            chkHideGamesNotOnSale.Size = new Size(150, 19);
            chkHideGamesNotOnSale.TabIndex = 2;
            chkHideGamesNotOnSale.Text = "Hide games not on sale";
            chkHideGamesNotOnSale.UseVisualStyleBackColor = true;
            chkHideGamesNotOnSale.CheckedChanged += LsvGame_FilterChanged;
            // 
            // btnBlacklist
            // 
            btnBlacklist.Location = new Point(587, 294);
            btnBlacklist.Name = "btnBlacklist";
            btnBlacklist.Size = new Size(100, 23);
            btnBlacklist.TabIndex = 4;
            btnBlacklist.Text = "Add to Blacklist";
            btnBlacklist.UseVisualStyleBackColor = true;
            btnBlacklist.Click += BtnBlacklist_Click;
            // 
            // txtDlcSearch
            // 
            txtDlcSearch.Location = new Point(6, 345);
            txtDlcSearch.Name = "txtDlcSearch";
            txtDlcSearch.Size = new Size(200, 23);
            txtDlcSearch.TabIndex = 5;
            txtDlcSearch.TextChanged += LsvDlc_FilterChanged;
            // 
            // smiSettings
            // 
            smiSettings.Name = "smiSettings";
            smiSettings.Size = new Size(61, 20);
            smiSettings.Text = "Settings";
            smiSettings.Click += SmiSettings_Click;
            // 
            // smiBlacklist
            // 
            smiBlacklist.Name = "smiBlacklist";
            smiBlacklist.Size = new Size(62, 20);
            smiBlacklist.Text = "Blacklist";
            smiBlacklist.Click += SmiBlacklist_Click;
            // 
            // smiFreeDlc
            // 
            smiFreeDlc.Name = "smiFreeDlc";
            smiFreeDlc.Size = new Size(66, 20);
            smiFreeDlc.Text = "Free DLC";
            smiFreeDlc.Click += SmiFreeDlc_Click;
            smiFreeDlc.EnabledChanged += SmiFreeDlc_EnabledChanged;
            // 
            // mnuMenu
            // 
            mnuMenu.Items.AddRange(new ToolStripItem[] { smiSettings, smiBlacklist, smiFreeDlc, smiAbout });
            mnuMenu.Location = new Point(0, 0);
            mnuMenu.Name = "mnuMenu";
            mnuMenu.Size = new Size(717, 24);
            mnuMenu.TabIndex = 0;
            mnuMenu.Text = "menuStrip1";
            // 
            // smiAbout
            // 
            smiAbout.Name = "smiAbout";
            smiAbout.Size = new Size(52, 20);
            smiAbout.Text = "About";
            smiAbout.Click += SmiAbout_Click;
            // 
            // btnRetryFailedGames
            // 
            btnRetryFailedGames.Location = new Point(555, 68);
            btnRetryFailedGames.Name = "btnRetryFailedGames";
            btnRetryFailedGames.Size = new Size(150, 23);
            btnRetryFailedGames.TabIndex = 3;
            btnRetryFailedGames.Text = "btnRetryFailedGames";
            btnRetryFailedGames.UseVisualStyleBackColor = true;
            btnRetryFailedGames.Click += BtnRetryFailedGames_Click;
            // 
            // chkIgnoreBlacklist
            // 
            chkIgnoreBlacklist.AutoSize = true;
            chkIgnoreBlacklist.Location = new Point(172, 71);
            chkIgnoreBlacklist.Name = "chkIgnoreBlacklist";
            chkIgnoreBlacklist.Size = new Size(106, 19);
            chkIgnoreBlacklist.TabIndex = 9;
            chkIgnoreBlacklist.Text = "Ignore Blacklist";
            chkIgnoreBlacklist.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(717, 751);
            Controls.Add(chkIgnoreBlacklist);
            Controls.Add(btnRetryFailedGames);
            Controls.Add(mnuMenu);
            Controls.Add(btnLogin);
            Controls.Add(lblUsername);
            Controls.Add(btnLogout);
            Controls.Add(btnCalculate);
            Controls.Add(ptbAvatar);
            Controls.Add(grbLibrary);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = mnuMenu;
            MaximizeBox = false;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Steam DLC Shopping";
            Load += FrmMain_Load;
            Shown += FrmMain_Shown;
            ((System.ComponentModel.ISupportInitialize)ptbAvatar).EndInit();
            grbLibrary.ResumeLayout(false);
            grbLibrary.PerformLayout();
            mnuMenu.ResumeLayout(false);
            mnuMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private PictureBox ptbAvatar;
        private Button btnLogin;
        private Button btnCalculate;
        private ListViewPlus lsvGame;
        private ColumnHeader colGame;
        private ListViewPlus lsvDlc;
        private ColumnHeader colDlc;
        private ColumnHeader colPrice;
        private ColumnHeader colDiscount;
        private Label lblGameCount;
        private Label lblDlcCount;
        private Button btnLogout;
        private TextBox txtGameSearch;
        private ColumnHeader ColCost;
        private ColumnHeader colMaxDiscount;
        private GroupBox grbLibrary;
        private CheckBox chkHideGamesNotOnSale;
        private Label lblLibraryCurrentPrice;
        private Button btnBlacklist;
        private CheckBox chkHideDlcOwned;
        private TextBox txtDlcSearch;
        private ColumnHeader colDlcLeft;
        private Label lblTooManyDlc;
        private LinkLabel lnkTooManyDlc;
        private ToolStripMenuItem smiSettings;
        private ToolStripMenuItem smiBlacklist;
        private ToolStripMenuItem smiFreeDlc;
        private MenuStrip mnuMenu;
        private CheckBox chkHideDlcNotOnSale;
        private ToolStripMenuItem smiAbout;
        private Label lblLibraryFullPrice;
        private Button btnRetryFailedGames;
        private CheckBox chkIgnoreBlacklist;
        private CheckBox chkFilterBlacklist;
    }
}