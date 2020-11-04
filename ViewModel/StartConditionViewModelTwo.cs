using System;
using System.ComponentModel;
using NewSkills.Controller;
using NewSkills.ViewModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Data;
using System.Collections.Generic;
using System.Globalization;

namespace NewSkills.ViewModel
{
    class StartConditionViewModelTwo : UserControl
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

