using MVVMRnDProject.Controls;
using MVVMRnDProject.External;
using MVVMRnDProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMRnDProject.Views
{
    /// <summary>
    /// Interaction logic for NetworkMapPage.xaml
    /// </summary>
    public partial class NetworkMapPage : Page
    {
        public NetworkMapPage(ConfigLoader configLoader)
        {
            InitializeComponent();

            //PortElementInit(configLoader.GetData());
        }

        private void PortElementInit(List<PortModel> ports)
        {
            PortElement portElement;
            foreach (PortModel port in ports)
            {
                portElement = (PortElement)this.FindName(port.PortName);

                if (portElement != null)
                {
                    portElement.NameField = port.PortName;
                    if (!string.IsNullOrWhiteSpace(port.Address))
                    {
                        portElement.IpField = port.Address;
                    }
                }
            }
        }
    }
}
