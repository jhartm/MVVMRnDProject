using MVVMRnDProject.Helpers;
using MVVMRnDProject.Model;
using MVVMRnDProject.Resources;
using MVVMRnDProject.ViewModel;
using MVVMRnDProject.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace MVVMRnDProject.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        #region Fields
        private static MainWindowViewModel _instance;
        //private XmlDataProvider _dataProvider;
        private DeviceViewModel _selectedDevice = null;
        private ObservableCollection<DeviceViewModel> _deviceList = null;
        private DelegateCommand openFile_MenuCommand;
        private DelegateCommand exit_MenuCommand;

        private Page _currentPage;
        private NetworkMapPage _uc1Page = new NetworkMapPage();
        private NetworkMapPage _uc2Page = new NetworkMapPage();
        private NetworkMapPage _uc3Page = new NetworkMapPage();

        private bool _isOpen;
        private DelegateCommand loadPage_Command;
        #endregion

        #region Properties
        //public XmlDataProvider DataProvider
        //{
        //    get
        //    {
        //        String file = Directory.GetCurrentDirectory() + @"\TestFile.xml";
        //        _dataProvider = new XmlDataProvider()
        //        {
        //            Source = new Uri(file, UriKind.Absolute),
        //            XPath = "HostConfig/Device"
        //        };

        //        return _dataProvider;
        //    }
        //}

        public DeviceViewModel SelectedDevice
        {
            get
            {
                return _selectedDevice;
            }
            set
            {
                _selectedDevice = value;
                OnPropertyChanged("SelectedDevice");
            }
        }

        public ObservableCollection<DeviceViewModel> DeviceList
        {
            get
            {
                return GetDevices();
            }
            set
            {
                _deviceList = value;
                OnPropertyChanged("DeviceList");
            }
        }

        public Page CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }
            set
            {
                _isOpen = value;
                OnPropertyChanged("IsOpen");
                LoadPage();
            }
        }

        public ICommand OpenFile_MenuCommand
        {
            get
            {
                if (openFile_MenuCommand == null)
                {
                    openFile_MenuCommand = new DelegateCommand(OpenFile);
                }
                return openFile_MenuCommand;
            }
        }

        public ICommand Exit_MenuCommand
        {
            get
            {
                if (exit_MenuCommand == null)
                {
                    exit_MenuCommand = new DelegateCommand(Exit);
                }
                return exit_MenuCommand;
            }
        }

        //public ICommand LoadPage_Command
        //{
        //    get
        //    {
        //        if (loadPage_Command == null)
        //        {
        //            loadPage_Command = new DelegateCommand(LoadPage);
        //        }
        //        return loadPage_Command;
        //    }
        //}
        #endregion

        #region Constructor
        private MainWindowViewModel()
        {
            this.DeviceList = GetDevices();
        }

        public static MainWindowViewModel Instance()
        {
            if (_instance == null)
            {
                _instance = new MainWindowViewModel();
            }

            return _instance;
        }
        #endregion

        #region Methods
        internal ObservableCollection<DeviceViewModel> GetDevices()
        {
            if (_deviceList == null)
            {
                _deviceList = new ObservableCollection<DeviceViewModel>();
            }

            _deviceList.Clear();

            //TODO: Add devices from data source
            //foreach(DeviceModel i in /*Device List Data*/)
            //{
            //    DeviceViewModel device = new DeviceViewModel(i);
            //    _deviceList.Add(device);
            //}

            return _deviceList;
        }

        public void OpenFile(object obj)
        {
            MessageBox.Show("OpenFile dialog open");
        }

        public void Exit(object obj)
        {
            Application.Current.Shutdown();
        }

        public void LoadPage()
        {
            Console.WriteLine("COMMAND: load page");
        }
        #endregion

    }
}
