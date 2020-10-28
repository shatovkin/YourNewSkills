using NewSkills.Controller;
using NewSkills.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace NewSkills.View
{
    /// <summary>
    /// Interaction logic for StartConditionView.xaml
    /// </summary>
    public partial class StartConditionView : UserControl
    {
        bool btn1Bool = false;
        bool btn2Bool = false;
        bool btn3Bool = false;
        bool btn4Bool = false;
        bool btn5Bool = false;
        bool btn6Bool = false;


        bool btn1Controll = true;
        bool btn2Controll = true;
        bool btn3Controll = true;
        bool btn4Controll = true;
        bool btn5Controll = true;
        bool btn6Controll = true;


        Label progress;
        MainWindow mainWindow;

        public StartConditionView(Label progress, MainWindow mainWindow)
        {
            InitializeComponent();
            this.progress = progress;
            this.mainWindow = mainWindow;
            BtnForward.IsEnabled = false;
            double width = System.Windows.Application.Current.MainWindow.Width;
            this.MaxWidth = width;
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

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            if (btn6Bool == true)
            {
                btn6Bool = false;
                btn6Controll = true;
            }
            else
            {
                btn6Bool = true;
                btn6Controll = false;
            }
            checkSoundContent(btn6, btn6Bool);
            makeButtonActive();
        }

        private void BtnForward_Click(object sender, RoutedEventArgs e)
        {

            UtilController.WorkTime = UtilController.StartWorkTime;
            //this.Close();
            StartConditionViewTwo startCondTwo = new StartConditionViewTwo(mainWindow.progress, mainWindow);
            StartConditionViewModelTwo vmF = new StartConditionViewModelTwo(mainWindow);
            startCondTwo.DataContext = vmF;
            mainWindow.OutputView.Content = startCondTwo;
            mainWindow.CommonTime = 0;
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
            if (btn1Controll == false && btn2Controll == false && btn3Controll == false && btn4Controll == false &&
                btn5Controll == false && btn6Controll == false)
            {
                BtnForward.IsEnabled = true;
            }
            else
            {
                BtnForward.IsEnabled = false;
            }
        }
    }
}

