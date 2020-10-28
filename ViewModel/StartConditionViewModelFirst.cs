using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSkills.ViewModel
{
    class StartConditionViewModelFirst : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //Fields
        private IMainWindowsCodeBehind _MainCodeBehind;

        //Conctructor
        public StartConditionViewModelFirst (IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
        }

        //Properties

        /// <summary>
        /// Введенная строка в TextBox create 
        /// </summary>
        private string _InputText;
        public string InputText
        {
            get { return _InputText; }
            set
            {
                _InputText = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(InputText)));
            }
        }        
    }
}

