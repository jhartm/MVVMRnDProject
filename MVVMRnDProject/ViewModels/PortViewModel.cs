using MVVMRnDProject.Helpers;
using MVVMRnDProject.Model;
using MVVMRnDProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMRnDProject.ViewModel
{
    public class PortViewModel : ObservableObject
    {
        public DeviceViewModel Device { get; set; }

        public string PortOwner { get; set; }
        public string PortName { get; set; }
        public IPAddress Address { get; set; }

        internal PortViewModel(PortModel port)
        {
            PortOwner = port.PortOwner;
            PortName = port.PortName;
            Address = port.Address;
        }

        internal PortViewModel()
        {

        }


    }
}