using MVVMRnDProject.Helpers;
using MVVMRnDProject.Tasks;
using MVVMRnDProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMRnDProject.ViewModels
{
    public class NetworkPageViewModel : ObservableObject
    {
        #region Fields
        private ObservableCollection<PortViewModel> _portList = null;
        private ObservableCollection<ScenarioViewModel> _stepList = null;
        private PortViewModel _selectedPort;

        private DelegateCommand changeValue_Command;
        private DelegateCommand startPingTest_Command;
        #endregion

        #region Properties
        public ObservableCollection<PortViewModel> PortList
        {
            get
            {
                return _portList;
            }
            private set
            {
                _portList = value;
                OnPropertyChanged("PortList");
            }
        }

        public ObservableCollection<ScenarioViewModel> StepList
        {
            get
            {
                return _stepList;
            }
            set
            {
                _stepList = value;
                OnPropertyChanged("StepList");
            }
        }

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

        public ICommand ChangeValue_Command
        {
            get
            {
                if (changeValue_Command == null)
                {
                    changeValue_Command = new DelegateCommand(ChangeValue);
                }
                return changeValue_Command;
            }
        }

        public ICommand StartPingTest_Command
        {
            get
            {
                if (startPingTest_Command == null)
                {
                    startPingTest_Command = new DelegateCommand(StartPingTest);
                }
                return startPingTest_Command;
            }
        }
        #endregion

        #region Constructor
        public NetworkPageViewModel(ObservableCollection<PortViewModel> portList)
        {
            PortList = portList;

            LoadScenario();
        }
        #endregion

        #region Methods
        private void LoadScenario()
        {

        }

        public void ChangeValue(object obj)
        {
            PortList[5].Status = "Some test status";
            //PortList.Add(new PortViewModel(new Model.PortModel("Test Device", "testPort0", "1.1.1.1")));
        }

        public void StartPingTest(object obj)
        {
            foreach (PortViewModel port in PortList)
            {
                port.Status = PingTask.Ping(port.PortName);
                Console.WriteLine(port.PortName + ": " + port.Status);
            }
        }
        #endregion

    }
}
