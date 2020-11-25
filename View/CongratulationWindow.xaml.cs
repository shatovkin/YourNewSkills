using System.Windows;


namespace NewSkills.View
{
    /// <summary>
    /// Interaction logic for CongratulationWindow.xaml
    /// </summary>
    public partial class CongratulationWindow : Window
    {
        MainWindow mainWindow;

        public CongratulationWindow(MainWindow mainWindow,string fileName)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;

            resetTextVariant(fileName);
        }

        private void resetTextVariant(string fileName)
        {
            if (fileName == "inputText1")
            {
                Properties.Settings.Default.InputText1 = 0;
            }
            else if (fileName == "inputText2")
            {
                Properties.Settings.Default.InputText2 = 0;
            }
            else if (fileName == "inputText3")
            {
                Properties.Settings.Default.InputText3 = 0;
            }
            Properties.Settings.Default.Save();
        }
    }
}
