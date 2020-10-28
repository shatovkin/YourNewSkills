using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace NewSkills.View
{
    /// <summary>
    /// Interaction logic for StarConditionalViewFirst.xaml
    /// </summary>
    public partial class StarConditionalViewFirst : UserControl, IValueConverter
    {
        public StarConditionalViewFirst()
        {
            InitializeComponent();
            double height = System.Windows.Application.Current.MainWindow.Height;
            double width = System.Windows.Application.Current.MainWindow.Width;
            this.Height = height-150;
            this.Width = width-150;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return Int32.Parse(value.ToString()) - 200;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
