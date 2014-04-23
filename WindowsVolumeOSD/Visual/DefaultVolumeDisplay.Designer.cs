using System.Drawing;
using System.Windows.Forms;

namespace WindowsVolumeOSD.Visual
{
    public partial class DefaultVolumeDisplay
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
            this.volumeBar = new System.Windows.Forms.ProgressBar();
            this.SoundImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SoundImage)).BeginInit();
            this.SuspendLayout();
            // 
            // volumeBar
            // 
            this.volumeBar.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.volumeBar.ForeColor = System.Drawing.Color.Red;
            this.volumeBar.Location = new System.Drawing.Point(59, 9);
            this.volumeBar.Margin = new System.Windows.Forms.Padding(0);
            this.volumeBar.MarqueeAnimationSpeed = 0;
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Size = new System.Drawing.Size(220, 23);
            this.volumeBar.TabIndex = 0;
            // 
            // SoundImage
            // 
            this.SoundImage.Image = audio_volume_muted;
            this.SoundImage.Location = new System.Drawing.Point(0, -8);
            this.SoundImage.Name = "SoundImage";
            this.SoundImage.Size = new System.Drawing.Size(56, 50);
            this.SoundImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.SoundImage.TabIndex = 1;
            this.SoundImage.TabStop = false;
            // 
            // DefaultVolumeDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(288, 41);
            this.Controls.Add(this.SoundImage);
            this.Controls.Add(this.volumeBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DefaultVolumeDisplay";
            this.Opacity = 0.75D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Volume Popup";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.SoundImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar volumeBar;
        private PictureBox SoundImage;
    }
}