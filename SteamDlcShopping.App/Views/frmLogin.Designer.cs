namespace SteamDlcShopping.App.Views
{
    partial class FrmLogin
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
            webLogin = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)webLogin).BeginInit();
            SuspendLayout();
            // 
            // webLogin
            // 
            webLogin.AllowExternalDrop = true;
            webLogin.CreationProperties = null;
            webLogin.DefaultBackgroundColor = Color.White;
            webLogin.Location = new Point(0, 0);
            webLogin.Name = "webLogin";
            webLogin.Size = new Size(847, 625);
            webLogin.Source = new Uri("https://store.steampowered.com/login", UriKind.Absolute);
            webLogin.TabIndex = 1;
            webLogin.Visible = false;
            webLogin.ZoomFactor = 1D;
            webLogin.CoreWebView2InitializationCompleted += WebLogin_CoreWebView2InitializationCompleted;
            webLogin.NavigationStarting += WebLogin_NavigationStarting;
            webLogin.NavigationCompleted += WebLogin_NavigationCompletedAsync;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(847, 625);
            Controls.Add(webLogin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLogin";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login to Steam";
            FormClosing += FrmLogin_FormClosing;
            Load += FrmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)webLogin).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webLogin;
    }
}