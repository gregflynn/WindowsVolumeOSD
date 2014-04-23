using CoreAudioApi;

namespace WindowsVolumeOSD
{
    class SoundDevice : ISoundDevice
    {
        /// <summary>
        /// Implements <see cref="ISoundDevice.Volume"/>
        /// </summary>
        public float Volume {
            get 
            {
                return _device.AudioEndpointVolume.MasterVolumeLevelScalar;
            }
            set
            {
                if (value < 0)
                {
                    _device.AudioEndpointVolume.MasterVolumeLevelScalar = 0;
                }
                else if (value > 1)
                {
                    _device.AudioEndpointVolume.MasterVolumeLevelScalar = 1;
                }
                else
                {
                    _device.AudioEndpointVolume.MasterVolumeLevelScalar = value;
                }
            }
        }

        /// <summary>
        /// Implements <see cref="ISoundDevice.Muted"/>
        /// </summary>
        public bool Muted
        {
            get
            {
                return _device.AudioEndpointVolume.Mute;
            }
            set
            {
                _device.AudioEndpointVolume.Mute = value;
            }
        }

        // device pointer we're working with
        private MMDevice _device;

        public SoundDevice()
        {
            // snag the default audio device from the OS
            _device = (new MMDeviceEnumerator()).GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
        }

        /// <summary>
        /// Implements <see cref="ISoundDevice.AddHandler"/>
        /// </summary>
        public void AddHandler(AudioEndpointVolumeNotificationDelegate handler)
        {
            _device.AudioEndpointVolume.OnVolumeNotification += handler;
        }
    }
}
