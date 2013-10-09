using MVVMRnDProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMRnDProject.ViewModels
{
    public class StepViewModel : ObservableObject
    {
        #region Fields
        private string _target;
        private string _status;
        #endregion

        #region Properties
        public string Target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
            }
        }

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
        public StepViewModel(string target)
        {
            Target = target;
        }
        #endregion

        #region Methods

        #endregion
    }
}
