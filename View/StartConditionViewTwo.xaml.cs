using NewSkills.Controller;
using NewSkills.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace NewSkills.View
{
    /// <summary>
    /// Interaction logic for StartConditionView.xaml
    /// </summary>
    public partial class StartConditionViewTwo : UserControl
    {

        bool btn7Bool = false;
        bool btn8Bool = false;
        bool btn9Bool = false;

        bool btn7Controll = true;
        bool btn8Controll = true;
        bool btn9Controll = true;

        Label progress;
        MainWindow mainWindow;

        public StartConditionViewTwo(Label progress, MainWindow mainWindow)
        {
            InitializeComponent();
            this.progress = progress;
            this.mainWindow = mainWindow;
            ToFirstViewBtn.IsEnabled = false;
            double width = System.Windows.Application.Current.MainWindow.Width;
            this.MaxWidth = width;
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            if (btn7Bool == true)
            {
                btn7Bool = false;
                btn7Controll = true;
            }
            else
            {
                btn7Bool = true;
                btn7Controll = false;
            }
            checkSoundContent(btn7, btn7Bool);
            makeButtonActive();
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            if (btn8Bool == true)
            {
                btn8Bool = false;
                btn8Controll = true;
            }
            else
            {
                btn8Bool = true;
                btn8Controll = false;
            }
            checkSoundContent(btn8, btn8Bool);
            makeButtonActive();
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            if (btn9Bool == true)
            {
                btn9Bool = false;
                btn9Controll = true;
            }
            else
            {
                btn9Bool = true;
                btn9Controll = false;
            }
            checkSoundContent(btn9, btn9Bool);
            makeButtonActive();
        }

        private void ToFirstView_Click(object sender, RoutedEventArgs e)
        {
            UtilController.WorkTime = UtilController.StartWorkTime;
            FirstUC viewF = new FirstUC("inputText", mainWindow);
            FirstViewModel vmF = new FirstViewModel(mainWindow);
            viewF.DataContext = vmF;
            mainWindow.OutputView.Content = viewF;
            mainWindow.timerTxt.Visibility = Visibility.Visible;
            mainWindow.Home.Visibility = Visibility.Visible;
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
            if (btn7Controll == false && btn8Controll == false && btn9Controll == false)
            {
                ToFirstViewBtn.IsEnabled = true;
            }
            else
            {
                ToFirstViewBtn.IsEnabled = false;
            }
        }

        public static readonly DependencyProperty ActHeightProperty =
           DependencyProperty.Register("ActHeight", typeof(double), typeof(StartConditionViewTwo), new
               PropertyMetadata(((double)0), new PropertyChangedCallback(OnActHeightChanged)));
        public static readonly DependencyProperty ActWidthProperty =
            DependencyProperty.Register("ActWidth", typeof(double), typeof(StartConditionViewTwo), new
                PropertyMetadata(((double)0), new PropertyChangedCallback(OnActWidthChanged)));

        private static void OnActHeightChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            StartConditionViewTwo StartConditionView_ = d as StartConditionViewTwo;
            StartConditionView_.OnActHeightChanged(e);
        }


        private static void OnActWidthChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            StartConditionViewTwo StartConditionView_ = d as StartConditionViewTwo;
            StartConditionView_.OnActWidthChanged(e);
        }


        private void OnActHeightChanged(DependencyPropertyChangedEventArgs e)
        {

        }
        private void OnActWidthChanged(DependencyPropertyChangedEventArgs e)
        {

        }

        public double ActHeight
        {
            get { return (double)GetValue(ActHeightProperty); }
            set { SetValue(ActHeightProperty, value); }
        }
        public double ActWidth
        {
            get { return (double)GetValue(ActWidthProperty); }
            set { SetValue(ActWidthProperty, value); }
        }

        private void StartConditionView_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            ActHeight = e.NewSize.Height;
            ActWidth = e.NewSize.Width;
        }
    }
}

