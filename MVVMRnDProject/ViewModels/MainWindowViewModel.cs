using MVVMRnDProject.External;
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
        readonly ConfigLoader _configLoader;
        private NetworkMapPage _mapPage;
        private TestPage _testPage;
        private TestPage _testPage2;

        private string _contentHeader;

        private string _testText = "Enter Text Here";
        private bool _testBool;
        private SolidColorBrush _testColor = new SolidColorBrush(Colors.Gray);

        private static MainWindowViewModel _instance;
        //private XmlDataProvider _dataProvider;
        private PortViewModel _selectedPort = null;
        private DeviceViewModel _selectedDevice = null;
        private ObservableCollection<DeviceViewModel> _deviceList = null;
        private ObservableCollection<PortViewModel> _portList = null;
        private DelegateCommand openFile_MenuCommand;
        private DelegateCommand exit_MenuCommand;
        private DelegateCommand writeData_MenuCommand;

        private Page _currentPage;
        //private NetworkMapPage _uc1Page = new NetworkMapPage();
        //private NetworkMapPage _uc2Page = new NetworkMapPage();
        //private NetworkMapPage _uc3Page = new NetworkMapPage();

        private bool _isOpen;
        private DelegateCommand loadPage_Command;
        private DelegateCommand loadTestPage_Command;
        #endregion

        #region Properties
        public string ContentHeader
        {
            get
            {
                return _contentHeader;
            }
            set
            {
                _contentHeader = value;
                OnPropertyChanged("ContentHeader");
            }
        }
        public string TestText
        {
            get
            {
                return _testText;
            }
            set
            {
                _testText = value;
                OnPropertyChanged("TestText");
            }
        }

        public bool TestBool
        {
            get
            {
                return _testBool;
            }
            set
            {
                _testBool = value;
                OnPropertyChanged("TestBool");
                if (value)
                {
                    TestColor = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    TestColor = new SolidColorBrush(Colors.Red);
                }
            }
        }

        public SolidColorBrush TestColor
        {
            get
            {
                return _testColor;
            }
            set
            {
                _testColor = value;
                OnPropertyChanged("TestColor");
            }
        }

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

        public PortViewModel SelectedPort
        {
            get
            {
                return _selectedPort;
            }
            set
            {
                _selectedPort = value;
                OnPropertyChanged("SelectedPort");
            }
        }

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

        public ObservableCollection<PortViewModel> PortList
        {
            get
            {
                return GetPorts();
            }
            set
            {
                _portList = value;
                OnPropertyChanged("PortList");
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
                if (_currentPage != value)
                {
                    _currentPage = value;
                    OnPropertyChanged("CurrentPage");

                    SetHeader(_currentPage);
                }
            }
        }

        public NetworkMapPage MapPage
        {
            get
            {
                return _mapPage;
            }
            private set
            {
                _mapPage = value;
            }
        }

        public TestPage TestPage
        {
            get
            {
                return _testPage;
            }
            set
            {
                _testPage = value;
            }
        }

        public TestPage TestPage2
        {
            get
            {
                return _testPage2;
            }
            set
            {
                _testPage2 = value;
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

        //Testing only, delete later
        public ICommand WriteData_MenuCommand
        {
            get
            {
                if (writeData_MenuCommand == null)
                {
                    writeData_MenuCommand = new DelegateCommand(WriteData);
                }
                return writeData_MenuCommand;
            }
        }

        public ICommand LoadPage_Command
        {
            get
            {
                if (loadPage_Command == null)
                {
                    loadPage_Command = new DelegateCommand(LoadPage);
                }
                return loadPage_Command;
            }
        }

        public ICommand LoadTestPage_Command
        {
            get
            {
                if (loadTestPage_Command == null)
                {
                    loadTestPage_Command = new DelegateCommand(LoadTestPage);
                }
                return loadTestPage_Command;
            }
        }
        #endregion

        #region Constructor
        private MainWindowViewModel()
        {
            _configLoader = new ConfigLoader();
            this.DeviceList = GetDevices();
            this.PortList = GetPorts();
            MapPage = new NetworkMapPage(_configLoader);
            MapPage.DataContext = this;
            TestPage = new TestPage();
            TestPage.DataContext = new NetworkPageViewModel("Test Page", this.PortList);
            TestPage2 = new TestPage();
            TestPage2.DataContext = new NetworkPageViewModel("Test Page 2", this.PortList);
            
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

        internal ObservableCollection<PortViewModel> GetPorts()
        {
            if (_portList == null)
            {
                _portList = new ObservableCollection<PortViewModel>();
            }

            _portList.Clear();

            foreach (PortModel port in _configLoader.GetData())
            {
                _portList.Add(new PortViewModel(port));
            }

            return _portList;
        }

        private void SetHeader(Page page)
        {
            ContentHeader = page.Title;
        }

        public void OpenFile(object obj)
        {
            MessageBox.Show("OpenFile dialog open");
        }

        public void Exit(object obj)
        {
            Application.Current.Shutdown();
        }

        public void LoadPage(object obj)
        {
            Console.WriteLine("COMMAND: load page");
            CurrentPage = MapPage;
        }

        public void LoadTestPage(object obj)
        {
            if (obj.ToString() == "1")
            {
                CurrentPage = TestPage;
            }
            else
            {
                CurrentPage = TestPage2;
            }
        }

        //This stub is for testing only. Delete later
        public void WriteData(object obj)
        {
            //foreach (PortModel port in _configLoader.GetData())
            //{
            //    port.Print();
            //}

            foreach (PortViewModel port in PortList)
            {
                port.Print();
            }
        }
        #endregion
    }
}
