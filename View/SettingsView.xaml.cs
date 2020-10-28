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
            successImage.Visibility = Visibility.Collapsed;
            this.main = main; 
        }

        private void saveSettings_Click(object sender, RoutedEventArgs e)
        {
            int selectedComboBoxValue = styleComboBox.SelectedIndex;

            //Set Progress to 0 
            UtilController.ProgessInPerCent = "0";
            UtilController.EndSum = 0; 

            Properties.Settings.Default.FontVariant = selectedComboBoxValue;
            Properties.Settings.Default.Save();
            successImage.Visibility = Visibility.Visible;
            
        }

        private void styleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (successImage != null) {
                successImage.Visibility = Visibility.Collapsed;
            }
        }

        private void styleComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            styleComboBox.SelectedIndex = Properties.Settings.Default.FontVariant;
           
        }
    }
}
