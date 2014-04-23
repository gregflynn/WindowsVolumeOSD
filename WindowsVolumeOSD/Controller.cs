using CoreAudioApi;
using System.Windows.Forms;
using WindowsVolumeOSD.Settings;
using WindowsVolumeOSD.Visual;

namespace WindowsVolumeOSD
{
    public partial class Controller : Form
    {
        /// <summary>
        /// Reference to the sound device
        /// </summary>
        private ISoundDevice _soundDevice;

        /// <summary>
        /// Represents the volume level we were at before a volume change event
        /// </summary>
        private float _currentVolume;

        /// <summary>
        /// The visual display of the volume level
        /// </summary>
        private IVolumeDisplay _display;

        public Controller()
        {
            InitializeComponent();
            this.Hide();

            // register our on volume change event handler
            _soundDevice = new SoundDevice();
            _soundDevice.AddHandler(new AudioEndpointVolumeNotificationDelegate(OnVolumeChange));
            _currentVolume = _soundDevice.Volume;

            // get a display from the factory
            _display = VisualFactory.GetDisplay();
            _display.UpdateVisuals(_currentVolume, _soundDevice.Muted);
        }

        /// <summary>
        /// Event Handler delegate for voume change event
        /// </summary>
        /// <param name="data"></param>
        internal void OnVolumeChange(AudioVolumeNotificationData data)
        {
            if (this.InvokeRequired)
            {
                Invoke(new AudioEndpointVolumeNotificationDelegate(OnVolumeChange), new object[] { data });
            }
            else
            {
                if (_currentVolume != data.MasterVolume)
                {
                    // we need to change the volume
                    int direction = (_currentVolume < data.MasterVolume) ? 1 : -1;
                    _soundDevice.Volume = _currentVolume + (SettingsContainer.VolumeStep * direction);
                    _currentVolume = _soundDevice.Volume;
                }

                _display.UpdateVisuals(_currentVolume, _soundDevice.Muted);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }
    }
}
