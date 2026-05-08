namespace SteamDlcShopping.App.Views
{
    partial class FrmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblSteamApiKey = new Label();
            txtSteamApiKey = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            pbtSteamApiKey = new PictureBox();
            lblGetSteamApiKey = new Label();
            lnkGetSteamApiKey = new LinkLabel();
            chkAutoBlacklist = new CheckBox();
            ptbSmartLoading = new PictureBox();
            lblReminder = new Label();
            ddlReminder = new ComboBox();
            ddlGameSort = new ComboBox();
            lblGameSort = new Label();
            ddlDlcSort = new ComboBox();
            lblDlcSort = new Label();
            chkUseMemeLoading = new CheckBox();
            ddlPageOpener = new ComboBox();
            lblPageOpener = new Label();
            chkCheckForUpdates = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pbtSteamApiKey).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ptbSmartLoading).BeginInit();
            SuspendLayout();
            // 
            // lblSteamApiKey
            // 
            lblSteamApiKey.AutoSize = true;
            lblSteamApiKey.Location = new Point(28, 15);
            lblSteamApiKey.Name = "lblSteamApiKey";
            lblSteamApiKey.Size = new Size(83, 15);
            lblSteamApiKey.TabIndex = 0;
            lblSteamApiKey.Text = "Steam API Key";
            // 
            // txtSteamApiKey
            // 
            txtSteamApiKey.Location = new Point(117, 12);
            txtSteamApiKey.Name = "txtSteamApiKey";
            txtSteamApiKey.Size = new Size(250, 23);
            txtSteamApiKey.TabIndex = 1;
            txtSteamApiKey.TextChanged += TxtSteamApiKey_TextChanged;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(236, 296);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(317, 296);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnCancel_Click;
            // 
            // pbtSteamApiKey
            // 
            pbtSteamApiKey.Location = new Point(12, 14);
            pbtSteamApiKey.Name = "pbtSteamApiKey";
            pbtSteamApiKey.Size = new Size(16, 16);
            pbtSteamApiKey.SizeMode = PictureBoxSizeMode.StretchImage;
            pbtSteamApiKey.TabIndex = 5;
            pbtSteamApiKey.TabStop = false;
            // 
            // lblGetSteamApiKey
            // 
            lblGetSteamApiKey.AutoSize = true;
            lblGetSteamApiKey.Location = new Point(210, 38);
            lblGetSteamApiKey.Name = "lblGetSteamApiKey";
            lblGetSteamApiKey.Size = new Size(131, 15);
            lblGetSteamApiKey.TabIndex = 0;
            lblGetSteamApiKey.Text = "Get your Steam API Key";
            // 
            // lnkGetSteamApiKey
            // 
            lnkGetSteamApiKey.AutoSize = true;
            lnkGetSteamApiKey.Location = new Point(337, 38);
            lnkGetSteamApiKey.Name = "lnkGetSteamApiKey";
            lnkGetSteamApiKey.Size = new Size(30, 15);
            lnkGetSteamApiKey.TabIndex = 2;
            lnkGetSteamApiKey.TabStop = true;
            lnkGetSteamApiKey.Text = "here";
            lnkGetSteamApiKey.LinkClicked += LnkGetSteamApiKey_LinkClicked;
            // 
            // chkAutoBlacklist
            // 
            chkAutoBlacklist.AutoSize = true;
            chkAutoBlacklist.CheckAlign = ContentAlignment.MiddleRight;
            chkAutoBlacklist.Location = new Point(28, 65);
            chkAutoBlacklist.Name = "chkAutoBlacklist";
            chkAutoBlacklist.Size = new Size(190, 19);
            chkAutoBlacklist.TabIndex = 3;
            chkAutoBlacklist.Text = "Auto Blacklist (Recommended)";
            chkAutoBlacklist.UseVisualStyleBackColor = true;
            chkAutoBlacklist.CheckedChanged += ChkAutoBlacklist_CheckedChanged;
            // 
            // ptbSmartLoading
            // 
            ptbSmartLoading.Location = new Point(12, 66);
            ptbSmartLoading.Name = "ptbSmartLoading";
            ptbSmartLoading.Size = new Size(16, 16);
            ptbSmartLoading.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbSmartLoading.TabIndex = 6;
            ptbSmartLoading.TabStop = false;
            // 
            // lblReminder
            // 
            lblReminder.AutoSize = true;
            lblReminder.Location = new Point(130, 93);
            lblReminder.Name = "lblReminder";
            lblReminder.Size = new Size(156, 15);
            lblReminder.TabIndex = 0;
            lblReminder.Text = "Reminder to clear every new";
            // 
            // ddlReminder
            // 
            ddlReminder.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlReminder.FormattingEnabled = true;
            ddlReminder.Items.AddRange(new object[] { "Week", "Month", "Year", "Big Bang" });
            ddlReminder.Location = new Point(292, 90);
            ddlReminder.Name = "ddlReminder";
            ddlReminder.Size = new Size(75, 23);
            ddlReminder.TabIndex = 4;
            // 
            // ddlGameSort
            // 
            ddlGameSort.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlGameSort.Items.AddRange(new object[] { "None", "Game ▲", "Game ▼", "Total Cost ▲", "Total Cost ▼", "DLC Left ▲", "DLC Left ▼", "Highest % ▲", "Highest % ▼" });
            ddlGameSort.Location = new Point(156, 128);
            ddlGameSort.Name = "ddlGameSort";
            ddlGameSort.Size = new Size(100, 23);
            ddlGameSort.TabIndex = 5;
            // 
            // lblGameSort
            // 
            lblGameSort.AutoSize = true;
            lblGameSort.Location = new Point(28, 131);
            lblGameSort.Name = "lblGameSort";
            lblGameSort.Size = new Size(122, 15);
            lblGameSort.TabIndex = 0;
            lblGameSort.Text = "Games default sort by";
            // 
            // ddlDlcSort
            // 
            ddlDlcSort.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlDlcSort.Items.AddRange(new object[] { "None", "DLC ▲", "DLC ▼", "Price ▲", "Price ▼", "Discount ▲", "Discount ▼" });
            ddlDlcSort.Location = new Point(156, 166);
            ddlDlcSort.Name = "ddlDlcSort";
            ddlDlcSort.Size = new Size(100, 23);
            ddlDlcSort.TabIndex = 6;
            // 
            // lblDlcSort
            // 
            lblDlcSort.AutoSize = true;
            lblDlcSort.Location = new Point(28, 169);
            lblDlcSort.Name = "lblDlcSort";
            lblDlcSort.Size = new Size(108, 15);
            lblDlcSort.TabIndex = 0;
            lblDlcSort.Text = "DLC default sort by";
            // 
            // chkUseMemeLoading
            // 
            chkUseMemeLoading.AutoSize = true;
            chkUseMemeLoading.CheckAlign = ContentAlignment.MiddleRight;
            chkUseMemeLoading.Location = new Point(28, 243);
            chkUseMemeLoading.Name = "chkUseMemeLoading";
            chkUseMemeLoading.Size = new Size(182, 19);
            chkUseMemeLoading.TabIndex = 8;
            chkUseMemeLoading.Text = "Use meme loading animation";
            chkUseMemeLoading.UseVisualStyleBackColor = true;
            chkUseMemeLoading.CheckedChanged += ChkAutoBlacklist_CheckedChanged;
            // 
            // ddlPageOpener
            // 
            ddlPageOpener.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlPageOpener.Items.AddRange(new object[] { "Web Browser", "Steam Client" });
            ddlPageOpener.Location = new Point(156, 205);
            ddlPageOpener.Name = "ddlPageOpener";
            ddlPageOpener.Size = new Size(100, 23);
            ddlPageOpener.TabIndex = 7;
            // 
            // lblPageOpener
            // 
            lblPageOpener.AutoSize = true;
            lblPageOpener.Location = new Point(28, 208);
            lblPageOpener.Name = "lblPageOpener";
            lblPageOpener.Size = new Size(96, 15);
            lblPageOpener.TabIndex = 0;
            lblPageOpener.Text = "Open pages with";
            // 
            // chkCheckForUpdates
            // 
            chkCheckForUpdates.AutoSize = true;
            chkCheckForUpdates.CheckAlign = ContentAlignment.MiddleRight;
            chkCheckForUpdates.Location = new Point(28, 268);
            chkCheckForUpdates.Name = "chkCheckForUpdates";
            chkCheckForUpdates.Size = new Size(179, 19);
            chkCheckForUpdates.TabIndex = 11;
            chkCheckForUpdates.Text = "Check for updates on startup";
            chkCheckForUpdates.UseVisualStyleBackColor = true;
            // 
            // FrmSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 331);
            Controls.Add(chkCheckForUpdates);
            Controls.Add(ddlPageOpener);
            Controls.Add(lblPageOpener);
            Controls.Add(ddlDlcSort);
            Controls.Add(lblDlcSort);
            Controls.Add(ddlGameSort);
            Controls.Add(lblGameSort);
            Controls.Add(ddlReminder);
            Controls.Add(lblReminder);
            Controls.Add(lnkGetSteamApiKey);
            Controls.Add(lblGetSteamApiKey);
            Controls.Add(ptbSmartLoading);
            Controls.Add(pbtSteamApiKey);
            Controls.Add(chkUseMemeLoading);
            Controls.Add(chkAutoBlacklist);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtSteamApiKey);
            Controls.Add(lblSteamApiKey);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmSettings";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            Load += FrmSettings_Load;
            ((System.ComponentModel.ISupportInitialize)pbtSteamApiKey).EndInit();
            ((System.ComponentModel.ISupportInitialize)ptbSmartLoading).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSteamApiKey;
        private TextBox txtSteamApiKey;
        private Button btnSave;
        private Button btnCancel;
        private PictureBox pbtSteamApiKey;
        private Label lblGetSteamApiKey;
        private LinkLabel lnkGetSteamApiKey;
        private CheckBox chkAutoBlacklist;
        private PictureBox ptbSmartLoading;
        private Label lblReminder;
        private ComboBox ddlReminder;
        private ComboBox ddlGameSort;
        private Label lblGameSort;
        private ComboBox ddlDlcSort;
        private Label lblDlcSort;
        private CheckBox chkUseMemeLoading;
        private ComboBox ddlPageOpener;
        private Label lblPageOpener;
        private CheckBox chkCheckForUpdates;
    }
}