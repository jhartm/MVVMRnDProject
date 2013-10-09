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
        private string _pageTitle;
        private ObservableCollection<PortViewModel> _portList = null;
        private ObservableCollection<StepViewModel> _stepList = null;
        private PortViewModel _selectedPort;
        private StepViewModel _selectedStep;

        private DelegateCommand changeValue_Command;
        private DelegateCommand startPingTest_Command;
        #endregion

        #region Properties
        public string PageTitle
        {
            get
            {
                return _pageTitle;
            }
            set
            {
                _pageTitle = value;
                OnPropertyChanged("PageTitle");
            }
        }
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

        public ObservableCollection<StepViewModel> StepList
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

                SelectedStep = GetStep(_selectedPort.PortName);
            }
        }

        public StepViewModel SelectedStep
        {
            get
            {
                return _selectedStep;
            }
            set
            {
                _selectedStep = value;
                OnPropertyChanged("SelectedStep");
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
        public NetworkPageViewModel(string pageTitle, ObservableCollection<PortViewModel> portList)
        {
            PageTitle = pageTitle;

            PortList = portList;

            LoadScenario();
        }
        #endregion

        #region Methods
        private void LoadScenario()
        {
            _stepList = new ObservableCollection<StepViewModel>();

            foreach (PortViewModel port in PortList)
            {
                _stepList.Add(new StepViewModel(port.PortName));
            }
        }

        private StepViewModel GetStep(string portName)
        {
            foreach (StepViewModel step in StepList)
            {
                if (step.Target == portName)
                {
                    return step;
                }
            }

            return null;
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
                //port.Status = PingTask.Ping(port.PortName);

                GetStep(port.PortName).Status = PingTask.Ping(port.PortName);
            }
        }
        #endregion

    }
}
