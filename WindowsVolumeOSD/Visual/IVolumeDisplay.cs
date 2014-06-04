namespace WindowsVolumeOSD.Visual
{
    interface IVolumeDisplay
    {
        /// <summary>
        /// Tells the IVolumeDisplay derivative to update its visual display to the given volume level
        /// and muted state
        /// </summary>
        /// <param name="volumePct">Volume percentage in decimal format, [0,1] such that 0.5 = 50%</param>
        /// <param name="muted">true if the volume has been muted, false otherwise</param>
        void UpdateVisuals(float volumePct, bool muted);
    }
}
