using MVVMRnDProject.Helpers;
using System;
using System.Net;

namespace MVVMRnDProject.Model
{
    public class PortModel : ObservableObject
    {
        public string PortOwner { get; set; }
        public string PortName { get; set; }
        public string Address { get; set; }

        public PortModel(string portOwner, string portName, string address)
        {
            PortOwner = portOwner;
            PortName = portName;
            Address = address;
        }

        public static PortModel CreatePort(string portOwner, string portName, string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                return new PortModel(portOwner, portName, null);
            }

            return new PortModel(portOwner, portName, address);
        }

        public void Print()
        {
            Console.WriteLine(PortOwner + " | " + PortName + " | " + Address);
        }
    }
}
