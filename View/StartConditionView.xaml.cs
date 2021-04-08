using NewSkills.Controller;
using NewSkills.ViewModel;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Data;
using System.Collections.Generic;
using System.Globalization;
using System.Media;
using System.Windows.Navigation;
using System.Diagnostics;

namespace NewSkills.View
{
    /// <summary>
    /// Interaction logic for StartConditionView.xaml
    /// </summary>
    public partial class StartConditionView : UserControl
    {

        private bool btn1Bool = false;
        private bool btn2Bool = false;
        private bool btn3Bool = false;
        private bool btn4Bool = false;
        private bool btn5Bool = false;
       
        private bool btn1Controll = true;
        private bool btn2Controll = true;
        private bool btn3Controll = true;
        private bool btn4Controll = true;
        private bool btn5Controll = true;
      
        private bool instructionOn = false;
        Label progress;
        MainWindow mainWindow;
        private SoundPlayer soundPlayer = new SoundPlayer();

        public StartConditionView(Label progress, MainWindow mainWindow)
        {
            InitializeComponent();

            DataContext = this;
            mainWindow.instructionButton.Visibility = Visibility.Hidden;
           
            this.DataContext = Application.Current.MainWindow;

            this.progress = progress;
            this.mainWindow = mainWindow;
            this.mainWindow.soundButton.Visibility = Visibility.Hidden;

            BtnForward.IsEnabled = false;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (btn1Bool == true)
            {
                btn1Bool = false;
                btn1Controll = true;
            }
            else
            {
                btn1Bool = true;
                btn1Controll = false;
            }
            checkSoundContent(btn1, btn1Bool);
            makeButtonActive();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {

            if (btn2Bool == true)
            {
                btn2Bool = false;
                btn2Controll = true;
            }
            else
            {
                btn2Bool = true;
                btn2Controll = false;
            }
            checkSoundContent(btn2, btn2Bool);
            makeButtonActive();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {

            if (btn3Bool == true)
            {
                btn3Bool = false;
                btn3Controll = true;
            }
            else
            {
                btn3Bool = true;
                btn3Controll = false;
            }
            checkSoundContent(btn3, btn3Bool);
            makeButtonActive();
        }



        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            if (btn4Bool == true)
            {
                btn4Bool = false;
                btn4Controll = true;
            }
            else
            {
                btn4Bool = true;
                btn4Controll = false;
            }
            checkSoundContent(btn4, btn4Bool);
            makeButtonActive();
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            if (btn5Bool == true)
            {
                btn5Bool = false;
                btn5Controll = true;
            }
            else
            {
                btn5Bool = true;
                btn5Controll = false;
            }
            checkSoundContent(btn5, btn5Bool);
            makeButtonActive();
        }

      

        private void BtnForward_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.stopSound(); // stop sound instruction
            mainWindow.instructionButton.Visibility = Visibility.Hidden;

            Properties.Settings.Default.StartConditionsAchieved = true;
            Properties.Settings.Default.Save();

            UtilController.WorkTime = UtilController.StartWorkTime;
            FirstUC viewF = new FirstUC(Properties.Settings.Default.CurrentInputTextName, mainWindow);
            FirstView vmF = new FirstView(mainWindow);
            viewF.DataContext = vmF;

          
            mainWindow.OutputView.Content = viewF;
            mainWindow.timerTxt.Visibility = Visibility.Visible;
            mainWindow.Home.Visibility = Visibility.Visible;
            mainWindow.Home.IsEnabled = false;

            mainWindow.Settings.Visibility = Visibility.Visible;
            mainWindow.CommonTime = 0;
            mainWindow.RunTimer = true;
        }


        private void setSoundImageContent(Button button, string imageName)
        {
            button.Content = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri("pack://application:,,,/Resources/" + imageName + ".png")), VerticalAlignment = VerticalAlignment.Center };
        }

        private void checkSoundContent(Button button, bool buttonActive)
        {

            if (buttonActive == false)
            {
                setSoundImageContent(button, "checkBoxInActive");
            }
            else
            {
                setSoundImageContent(button, "checkBoxActive");
            }
        }

        public void makeButtonActive()
        {
            if (btn1Controll == false && btn2Controll == false && btn3Controll == false && btn4Controll == false && btn5Controll == false)
            {
                BtnForward.IsEnabled = true;
            }
            else
            {
                BtnForward.IsEnabled = false;
            }
        }

        private void instructionButton_Click(object sender, RoutedEventArgs e)
        {
            if (instructionOn == false)
            {
                instructionOn = true;
                instructionButton.Content = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri("pack://application:,,,/Resources/" + "instruction" + ".png")), VerticalAlignment = VerticalAlignment.Center };
                soundPlayer.Stream = Properties.Resources.audio_instruciya_wav;
                soundPlayer.Play();
            }
            else
            {
                instructionOn = false;
                soundPlayer.Stop();
                instructionButton.Content = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri("pack://application:,,,/Resources/" + "instructionOff" + ".png")), VerticalAlignment = VerticalAlignment.Center };
            }
        }
        

        private void Hyperlink_Click_1(object sender, RoutedEventArgs e) {
            hype1.NavigateUri = new Uri(getHyperLink("1"));
        }

        private string getHyperLink(string bookNumber)
        {
            LicenseServiceController licenseController = new LicenseServiceController();
            string link = licenseController.getBookHyperLink(bookNumber);
            return link;
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // for .NET Core you need to add UseShellExecute = true
            // see https://docs.microsoft.com/dotnet/api/system.diagnostics.processstartinfo.useshellexecute#property-value
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;

        }
    }
}

