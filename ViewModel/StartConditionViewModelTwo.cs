using System;
using System.ComponentModel;

namespace NewSkills.ViewModel
{
    class StartConditionViewModelTwo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //Fields
        private IMainWindowsCodeBehind _MainCodeBehind;

        //Conctructor
        public StartConditionViewModelTwo(IMainWindowsCodeBehind codeBehind)
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

