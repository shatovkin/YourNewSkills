using NewSkills.Controller;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

            System.Windows.Media.Color colorBorder = new System.Windows.Media.Color();
            colorBorder = System.Windows.Media.Color.FromRgb(81, 106, 122);

            System.Windows.Media.Color colorBackground = new System.Windows.Media.Color();
            colorBackground = System.Windows.Media.Color.FromRgb(208 , 215, 218);

            this.ColorPickerBorder.SelectedColor = colorBorder;
            this.ColorPickerBackground.SelectedColor = colorBackground;


        }

        private void styleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.FontVariant = styleComboBox.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void typingTextComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.TypingText = typingTextComboBox.SelectedIndex;
            Properties.Settings.Default.CurrentInputTextName = returnTextName(typingTextComboBox.SelectedIndex);
            Properties.Settings.Default.Save();
        }

        private string returnTextName(int selectedIndex) {

            if (selectedIndex == 0)
            {
                return "inputText1";
            }
            else if (selectedIndex == 1)
            {
                return "inputText2";
            }
            else if (selectedIndex == 2) {
                return "inputText3";
            }
            else if (selectedIndex == 3)
            {
                return "inputText4";
            }
            else if (selectedIndex == 4)
            {
                return "inputText5";
            }
            else if (selectedIndex == 5)
            {
                return "inputText6";
            }
            return "inputText1"; 
        }


        private void styleComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            styleComboBox.SelectedIndex = Properties.Settings.Default.FontVariant;
        }

        private void typingTextComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            typingTextComboBox.SelectedIndex = Properties.Settings.Default.TypingText;
        }

        private void ColorPickerBackground_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color?> e)
        {
            try
            {
                SolidColorBrush sb = new SolidColorBrush(System.Windows.Media.Color.FromArgb(e.NewValue.Value.A, e.NewValue.Value.R,
                                           e.NewValue.Value.G, e.NewValue.Value.B));

                this.Background = sb;
                main.scroll.Background = sb;
                Properties.Settings.Default.BackgroundColor = e.NewValue.Value.R + "," + e.NewValue.Value.G + "," + e.NewValue.Value.B; 
                Properties.Settings.Default.Save();
            }
            catch (System.Exception)
            {
                throw;
            }
           
        }

        private void ColorPickerBorder_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color?> e)
        {
            try
            {
                SolidColorBrush sb = new SolidColorBrush(System.Windows.Media.Color.FromArgb(e.NewValue.Value.A, e.NewValue.Value.R,
                           e.NewValue.Value.G, e.NewValue.Value.B));

                main.leftBorder.Background = sb;
                main.rightBorder.Background = sb;
                main.topBorder.Background = sb;
                main.bottomBorder.Background = sb;

                Properties.Settings.Default.BorderColor = e.NewValue.Value.R + "," + e.NewValue.Value.G + "," + e.NewValue.Value.B;
                Properties.Settings.Default.Save();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
