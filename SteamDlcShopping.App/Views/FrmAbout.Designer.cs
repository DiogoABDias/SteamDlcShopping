namespace SteamDlcShopping.App.Views
{
    partial class FrmAbout
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
            lblAbout = new Label();
            lnkAbout = new LinkLabel();
            lblVersion = new Label();
            lnkNewVersion = new LinkLabel();
            SuspendLayout();
            // 
            // lblAbout
            // 
            lblAbout.AutoSize = true;
            lblAbout.Location = new Point(12, 9);
            lblAbout.Name = "lblAbout";
            lblAbout.Size = new Size(207, 15);
            lblAbout.TabIndex = 0;
            lblAbout.Text = "Originally developed by DiogoABDias.";
            // 
            // lnkAbout
            // 
            lnkAbout.AutoSize = true;
            lnkAbout.Location = new Point(174, 37);
            lnkAbout.Name = "lnkAbout";
            lnkAbout.Size = new Size(45, 15);
            lnkAbout.TabIndex = 2;
            lnkAbout.TabStop = true;
            lnkAbout.Text = "GitHub";
            lnkAbout.LinkClicked += LnkAbout_LinkClicked;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(12, 37);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(55, 15);
            lblVersion.TabIndex = 0;
            lblVersion.Text = "v99.99.99";
            // 
            // lnkNewVersion
            // 
            lnkNewVersion.AutoSize = true;
            lnkNewVersion.Location = new Point(73, 37);
            lnkNewVersion.Name = "lnkNewVersion";
            lnkNewVersion.Size = new Size(75, 15);
            lnkNewVersion.TabIndex = 1;
            lnkNewVersion.TabStop = true;
            lnkNewVersion.Text = "New version!";
            lnkNewVersion.Visible = false;
            lnkNewVersion.LinkClicked += LnkNewVersion_LinkClicked;
            // 
            // FrmAbout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(234, 61);
            Controls.Add(lnkNewVersion);
            Controls.Add(lblVersion);
            Controls.Add(lnkAbout);
            Controls.Add(lblAbout);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAbout";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "About";
            Load += FrmAbout_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAbout;
        private LinkLabel lnkAbout;
        private Label lblVersion;
        private LinkLabel lnkNewVersion;
    }
}