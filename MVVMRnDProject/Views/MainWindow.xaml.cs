using MVVMRnDProject.External;
using MVVMRnDProject.Resources;
using MVVMRnDProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //ConfigLoader.LoadData();

            InitializeComponent();
            this.DataContext = MainWindowViewModel.Instance();

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                UpdateLinkStatus(Constants.LINK_CONNECTED);
            }
            else
            {
                UpdateLinkStatus(Constants.LINK_DISCONNECTED);
            }

            NetworkChange.NetworkAvailabilityChanged += new NetworkAvailabilityChangedEventHandler(LinkStatusChanged);
        }

        private void LinkStatusChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            if (e.IsAvailable)
            {
                UpdateLinkStatus(Constants.LINK_CONNECTED);
            }
            else
            {
                UpdateLinkStatus(Constants.LINK_DISCONNECTED);
            }
        }

        private void UpdateLinkStatus(String status)
        {
            linkIndicator.Dispatcher.Invoke(new Action(() => linkIndicator.Background = Constants.LINK_STATUS_COLOR[status]));
            linkIndicator.Dispatcher.Invoke(new Action(() => linkIndicator.ToolTip = status));
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {

        }
    }
}
