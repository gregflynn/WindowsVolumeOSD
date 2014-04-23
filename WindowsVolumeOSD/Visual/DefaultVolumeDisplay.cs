using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsVolumeOSD.Extensions;

namespace WindowsVolumeOSD.Visual
{
    public partial class DefaultVolumeDisplay : Form, IVolumeDisplay
    {
        /// <summary>
        /// The opacity of the frame when fully shown
        /// </summary>
        private float _shownOpacity = 0.8f;

        /// <summary>
        /// Timer to control fading out the frame
        /// </summary>
        private Timer _fadeOutTimer = new Timer() { Interval = 10 };

        /// <summary>
        /// Timer to delay the start of the fade out of the frame
        /// </summary>
        private Timer _delayedFadeTimer = new Timer() { Interval = 500 };

        public DefaultVolumeDisplay()
        {
            InitializeComponent();
            
            // setup the location on the screen
            int x = (Screen.PrimaryScreen.WorkingArea.Right / 2) - (Width / 2); // centered
            int y = (Screen.PrimaryScreen.WorkingArea.Bottom / 4) * 3; // bottom quarter
            Location = new Point(x, y);

            // setup delayed fade out
            _delayedFadeTimer.Tick += new EventHandler((sender, args) =>
                {
                    _fadeOutTimer.Enabled = true;
                    _delayedFadeTimer.Enabled = false;
                });

            // setup fade out
            _fadeOutTimer.Tick += new EventHandler((sender, args) =>
                {
                    Opacity -= 0.008;
                    if (Opacity <= 0)
                    {
                        Hide();
                        _fadeOutTimer.Enabled = false;
                    }
                });
        }

        /// <summary>
        /// Implements <see cref="IVolumeDisplay.UpdateVisuals"/>
        /// </summary>
        public void UpdateVisuals(float volumePct, bool muted)
        {
            this.InvokeIfRequired(() => 
                {
                    UpdateIcon(volumePct, muted);
                    UpdateBar(volumePct);
                    ShowVisuals(volumePct, muted);
                });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="volumePct"></param>
        /// <param name="muted"></param>
        internal void UpdateIcon(float volumePct, bool muted)
        {
            if (muted)
            {
                // well make it the muted image, this ain't rocket science
                SoundImage.Image = DefaultVolumeDisplay.audio_volume_muted;
            }
            else
            {
                if (volumePct < 0.3)
                {
                    SoundImage.Image = audio_volume_low;
                }
                else if (volumePct < 0.7)
                {
                    SoundImage.Image = audio_volume_medium;
                }
                else
                {
                    SoundImage.Image = audio_volume_high;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="volumePct"></param>
        internal void UpdateBar(float volumePct)
        {
            int targetPct = (int) (volumePct * 100);
            if (targetPct > volumeBar.Value)
            {
                // we need to do a dirty hack to make the windows progess bar not suck
                volumeBar.Value = targetPct;
                volumeBar.Value = targetPct - 1;
            }
            volumeBar.Value = targetPct;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="percent"></param>
        /// <param name="muted"></param>
        internal void ShowVisuals(float percent, bool muted)
        {
            // now display this new wonderful information to the masses!
            _delayedFadeTimer.Enabled = _fadeOutTimer.Enabled = false; // destroy all the timers!
            this.Opacity = _shownOpacity;
            this.Show();
            _delayedFadeTimer.Enabled = true;
        }
    }
}
