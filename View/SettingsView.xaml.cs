using NewSkills.Controller;
using System.Windows;
using System.Windows.Controls;

namespace NewSkills.View
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        private MainWindow main; 

        public SettingsView(MainWindow main)
        {
            InitializeComponent();

            //Set Progress to 0 
            UtilController.ProgessInPerCent = "0";
            UtilController.EndSum = 0;

            main.Home.IsEnabled = true; 
            main.RunTimer = false;
            this.main = main; 

        }

        private void styleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.FontVariant = styleComboBox.SelectedIndex;
            Properties.Settings.Default.Save();
        }


        private void typingTextComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.TypingText = typingTextComboBox.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void styleComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            styleComboBox.SelectedIndex = Properties.Settings.Default.FontVariant;
        }

        private void typingTextComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            typingTextComboBox.SelectedIndex = Properties.Settings.Default.TypingText;
        }
    }
}
