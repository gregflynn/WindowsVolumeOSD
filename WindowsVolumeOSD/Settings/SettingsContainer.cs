using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsVolumeOSD.Settings
{
    public class SettingsContainer
    {
        /// <summary>
        /// How much volume percent to change by when receiving a volume change event
        /// </summary>
        public static float VolumeStep { get { return 0.1f; } }


    }
}
