using CoreAudioApi;

namespace WindowsVolumeOSD
{
    interface ISoundDevice
    {
        float Volume { get; set; }

        bool Muted { get; set; }

        void AddHandler(AudioEndpointVolumeNotificationDelegate handler);
    }
}
