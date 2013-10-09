using MVVMRnDProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMRnDProject.ViewModels
{
    public class ScenarioViewModel : ObservableObject
    {
        #region Fields
        private string _status;
        #endregion

        #region Properties
        public string PortName { get; set; }

        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }
        #endregion

        #region Constructor
        public ScenarioViewModel()
        {

        }
        #endregion

        #region Methods

        #endregion
    }
}
