using MVVMRnDProject.Helpers;
using System.Net;

namespace MVVMRnDProject.Model
{
    public class PortModel : ObservableObject
    {
        public string PortOwner { get; set; }
        public string PortName { get; set; }
        public IPAddress Address { get; set; }

        public PortModel(string portOwner, string portName, IPAddress address)
        {
            PortOwner = portOwner;
            PortName = portName;
            Address = address;
        }

    }
}
