using NewSkills.View;
using NewSkills.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NewSkills
{
    /// <summary>
    /// Interaction logic for MessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        private MainWindow main;
      
        public CustomMessageBox(string messageText, string confirmButtonText, string cancelButtonText, MainWindow main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            main.timeReset(Visibility.Visible);
            main.menuVisibility(Visibility.Visible);
            FirstUC viewF = new FirstUC(Properties.Settings.Default.CurrentInputTextName, main);
            FirstView vmF = new FirstView(main);
            viewF.DataContext = vmF;
            main.OutputView.Content = viewF;
            this.Close();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
