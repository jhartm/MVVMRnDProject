using MVVMRnDProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMRnDProject.Model
{
    public class DeviceModel
    {
        public string DeviceName { get; set; }

        public DeviceModel(string deviceName)
        {
            DeviceName = deviceName;
        }
    }
}
