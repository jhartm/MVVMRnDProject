using MVVMRnDProject.Helpers;
using MVVMRnDProject.Model;
using MVVMRnDProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMRnDProject.ViewModels
{
    public class DeviceViewModel : ObservableObject
    {
        private ObservableCollection<PortViewModel> _ports = null;

        public string DeviceName
        {
            get;
            set;
        }

        public MainWindowViewModel Container
        {
            get
            {
                return MainWindowViewModel.Instance();
            }
        }

        public ObservableCollection<PortViewModel> Ports
        {
            get
            {
                return GetPorts();
            }
            set
            {
                _ports = value;
                OnPropertyChanged("Ports");
            }
        }

        public DeviceViewModel(DeviceModel device)
        {
            DeviceName = device.DeviceName;
        }

        internal DeviceViewModel()
        {

        }


        internal ObservableCollection<PortViewModel> GetPorts()
        {
            _ports = new ObservableCollection<PortViewModel>();

            //TODO: iterate through list and add to view model collection
            //foreach(PortModel i in )
            //{
            //    PortViewModel port = new PortViewModel(i);
            //    port.Device = this;
            //    _ports.Add(port);
            //}

            return _ports;
        }
    }
}