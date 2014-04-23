namespace WindowsVolumeOSD.Visual
{
    class VisualFactory
    {
        public static IVolumeDisplay GetDisplay()
        {
            return new DefaultVolumeDisplay();
        }
    }
}
