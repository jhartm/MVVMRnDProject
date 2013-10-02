using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MVVMRnDProject.Resources
{
    public class Constants
    {
        public const string LINK_DEFAULT = "Default";
        public const string LINK_CONNECTED = "Link Detected";
        public const string LINK_DISCONNECTED = "No link detected";

        public static Dictionary<String, SolidColorBrush> LINK_STATUS_COLOR = new Dictionary<String, SolidColorBrush>
        {
            {LINK_DEFAULT, new SolidColorBrush(Colors.Gray)},
            {LINK_DISCONNECTED,    new SolidColorBrush(Colors.Red)},
            {LINK_CONNECTED, new SolidColorBrush(Colors.Green)},
        };
    }
}
