namespace SteamDlcShopping.App.Extensibility
{
    partial class UcLoad
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
            if (disposing && (components is not null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PtbLoading = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PtbLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbLoading
            // 
            this.PtbLoading.Image = global::SteamDlcShopping.App.Properties.Resources.loadingDefault;
            this.PtbLoading.Location = new System.Drawing.Point(228, 184);
            this.PtbLoading.Name = "ptbLoading";
            this.PtbLoading.Size = new System.Drawing.Size(287, 141);
            this.PtbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PtbLoading.TabIndex = 1;
            this.PtbLoading.TabStop = false;
            // 
            // ucLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PtbLoading);
            this.Name = "ucLoad";
            this.Size = new System.Drawing.Size(743, 509);
            this.Load += new System.EventHandler(this.UcLoad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PtbLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox PtbLoading;
    }
}
