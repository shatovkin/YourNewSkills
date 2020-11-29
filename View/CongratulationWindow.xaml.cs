using NewSkills.Controller;
using NewSkills.ViewModel;
using System.Windows;


namespace NewSkills.View
{
    /// <summary>
    /// Interaction logic for CongratulationWindow.xaml
    /// </summary>
    public partial class CongratulationWindow : Window
    {
        MainWindow mainWindow;
        private string fileName; 

        public CongratulationWindow(MainWindow mainWindow,string fileName)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.fileName = fileName;
        }

        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainWindow.CommonTime = 0;
            mainWindow.RunTimer = true; 
            
            resetTextVariant(fileName);
            FirstUC viewF = new FirstUC(Properties.Settings.Default.CurrentInputTextName, mainWindow);
            FirstView vmF = new FirstView(mainWindow);
            viewF.DataContext = vmF;
            mainWindow.OutputView.Content = viewF;
            e.Cancel = false; // кнопка больше не закрывает форму
                             // а тут теперь указываем что она делает    
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
