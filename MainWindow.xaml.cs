using System.Windows;
using System.Windows.Input;
using System.Windows.Controls.Primitives;
using System;
using NewSkills.ViewModel;
using NewSkills.View;
using System.Windows.Threading;
using NewSkills.Controller;
using System.Windows.Media.Imaging;
using System.Media;
using System.IO;

namespace NewSkills
{
    public interface IMainWindowsCodeBehind
    {
        /// <summary>
        /// Загрузка нужной View
        /// </summary>
        /// <param name="view">экземпляр UserControl</param>
        void LoadView(ViewType typeView);
    }

    /// <summary>
    /// Типы вьюшек для загрузки
    /// </summary>
    public enum ViewType
    {
        Main,
        First,
        Settings,
        LicenseView,
        StartConditionView,
        StartConditionViewFirst,
        CongratulationView
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindowsCodeBehind
    {
        // Timer Variables
        private DispatcherTimer timer;
        private bool soundOn = false;
        private static int commonTime = 0;
        public int CommonTime { get { return commonTime; } set { commonTime = value; } }
        private bool runTimer = false;
        public bool RunTimer { get { return runTimer; } set { runTimer = value; } }
        private bool anyKeyPressed = false;
        // End of Timer Variables

        public MainWindow()
        {
            InitializeComponent();
            checkSoundContent();
            this.Height = (System.Windows.SystemParameters.PrimaryScreenHeight);
            this.Width = (System.Windows.SystemParameters.PrimaryScreenWidth);
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            this.Loaded += MainWindow_Loaded;
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        // ежесекундый запуск метода, для таймера
        // тут высчитывается, должна ли работать пауза или печать
        private void Timer_Tick(object sender, EventArgs e)
        {
            commonTime++;

            if (RunTimer)
            {
                if (UtilController.BlockTextFieldAndTimer == false)
                {
                    if (UtilController.WorkTime > 0)
                    {
                        UtilController.ActivateWorkOrPause = false;
                        UtilController.WorkTime--;
                        setTime(UtilController.WorkTime);//1500
                    }
                    else if (UtilController.PauseTime > 0)
                    {
                        UtilController.ActivateWorkOrPause = true;
                        UtilController.PauseTime--;
                        setTime(UtilController.PauseTime);
                    }

                    if (UtilController.WorkTime == 0 && UtilController.PauseTime == 0 && UtilController.ActivateWorkOrPause == false)
                    {
                        UtilController.ActivateWorkOrPause = true;
                        UtilController.PauseTime = UtilController.AfterPauseTime;

                    }
                    else if (UtilController.WorkTime == 0 && UtilController.PauseTime == 0 && UtilController.ActivateWorkOrPause == true)
                    {
                        if (anyKeyPressed)
                        {
                            UtilController.WorkTime = UtilController.AfterWorkTime;
                            UtilController.ActivateWorkOrPause = false;
                            anyKeyPressed = false;

                            if (CommonTime > UtilController.MaxCommonTime)
                            {
                                UtilController.WorkTime = UtilController.WorkTime;
                                UtilController.PauseTime = UtilController.PauseAfterMaxCommonTime;
                            }
                        }
                    }

                    if (UtilController.PauseTime == 0)
                    {
                        pauseLbl.Content = "Нажмите любую клавишу";
                    }
                }
            }
        }

        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (UtilController.WorkTime == 0 && UtilController.PauseTime == 0 && UtilController.ActivateWorkOrPause == true)
            {
                anyKeyPressed = true;
            }
            else
            {
                anyKeyPressed = false;
            }

            if (e.Key == Key.Space)
            {
                anyKeyPressed = true;
            }
        }


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //загрузка вьюмодел для кнопок меню
            MenuViewModel vm = new MenuViewModel();
            //даем доступ к этому кодбихайнд
            vm.CodeBehind = this;
            //делаем эту вьюмодел контекстом данных
            this.DataContext = vm;

            if (Properties.Settings.Default.License == false)
            {
                LoadView(ViewType.LicenseView);
            }
            //загрузка стартовой View
            else
            {
                //LoadView(ViewType.StartConditionView);
                LoadView(ViewType.StartConditionView);
            }
        }

        public void LoadView(ViewType typeView)
        {
            switch (typeView)
            {
                case ViewType.StartConditionView:
                    menuVisibility(Visibility.Hidden);
                    timeReset(Visibility.Hidden);
                    StartConditionView conditionViewStart = new StartConditionView(progress, this);
                    StartConditionViewModel startCond = new StartConditionViewModel(this);
                    conditionViewStart.DataContext = startCond;
                    this.OutputView.Content = conditionViewStart;
                    break;
                case ViewType.StartConditionViewFirst:
                    menuVisibility(Visibility.Hidden);
                    timeReset(Visibility.Hidden);
                    StarConditionalViewFirst conditionViewFirst = new StarConditionalViewFirst();
                    StartConditionViewModelFirst startCondFirst = new StartConditionViewModelFirst(this);
                    conditionViewFirst.DataContext = startCondFirst;
                    this.OutputView.Content = conditionViewFirst;
                    break;
                case ViewType.First:
                    menuVisibility(Visibility.Visible);
                    timeReset(Visibility.Visible);
                    FirstUC viewF = new FirstUC("inputText", progress, this);
                    FirstViewModel vmF = new FirstViewModel(this);
                    viewF.DataContext = vmF;
                    this.OutputView.Content = viewF;

                    break;
                case ViewType.Settings:
                    SettingsView viewS = new SettingsView(this);
                    this.OutputView.Content = viewS;
                    break;
                case ViewType.LicenseView:
                    menuVisibility(Visibility.Hidden);
                    timeReset(Visibility.Hidden);
                    LicenseWindow lw = new LicenseWindow(this);
                    lw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    lw.Owner = Application.Current.MainWindow;
                    lw.Show();
                    break;
                case ViewType.CongratulationView:
                    CongratulationWindow congratulationWindow = new CongratulationWindow(this);
                    congratulationWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    congratulationWindow.Owner = Application.Current.MainWindow;
                    congratulationWindow.Show();
                    congratulationWindow.loadVideo();
                    break;

            }
        }

        private void setTime(int time)
        {
            progress.Content = UtilController.ProgessInPerCent;

            if (time / 60 >= 10 && time % 60 >= 10)
            {
                if (UtilController.ActivateWorkOrPause == false)
                {
                    pauseLbl.Visibility = Visibility.Collapsed;
                    timerTxt.Content = string.Format("Время печатать 00:{0}:{1}", time / 60, time % 60); // 13: 50
                }
                else
                {
                    if (CommonTime > UtilController.MaxCommonTime)
                    {
                        UtilController.showPause(pauseLbl, "Отдых 30 минут");

                        if (time == 10)
                        {
                            voiceMessages(Properties.Resources.audio_zvuk_vokzala_31_wav);
                        }
                        else if (time == 1)
                        {
                            voiceMessages(Properties.Resources.audio_wavpereryv_zakonchen_34_wav);
                        }
                    }
                    else if (CommonTime < UtilController.MaxCommonTime)
                    {
                        UtilController.showPause(pauseLbl, "Отдых 5 минут");

                        if (time == 10)
                        {
                            voiceMessages(Properties.Resources.audio_zvuk_vokzala_31_wav);
                        }
                        else if (time == 1)
                        {
                            voiceMessages(Properties.Resources.audio_wavpereryv_zakonchen_34_wav);
                        }
                    }

                    timerTxt.Content = string.Format("Пауза 00:{0}:{1}", time / 60, time % 60); // 13:50

                }
            }
            else if (time / 60 >= 10 && time % 60 < 10)
            {
                if (UtilController.ActivateWorkOrPause == false)
                {
                    pauseLbl.Visibility = Visibility.Collapsed;
                    timerTxt.Content = string.Format("Время печатать 00:{0}:0{1}", time / 60, time % 60); // 13:05
                }
                else
                {
                    if (CommonTime > UtilController.MaxCommonTime)
                    {
                        UtilController.showPause(pauseLbl, "Отдых 30 минут");

                        if (time == 10)
                        {
                            voiceMessages(Properties.Resources.audio_zvuk_vokzala_31_wav);
                        }
                        else if (time == 1)
                        {
                            voiceMessages(Properties.Resources.audio_wavpereryv_zakonchen_34_wav);
                        }
                    }
                    else
                    {
                        UtilController.showPause(pauseLbl, "Отдых 5 минут");

                        if (time == 10)
                        {
                            voiceMessages(Properties.Resources.audio_zvuk_vokzala_31_wav);
                        }
                        else if (time == 1)
                        {
                            voiceMessages(Properties.Resources.audio_wavpereryv_zakonchen_34_wav);
                        }
                    }
                    timerTxt.Content = string.Format("Пауза 00:{0}:0{1}", time / 60, time % 60); // 13:05
                }
            }
            else if (time / 60 <= 10 && time % 60 >= 10)
            {
                if (UtilController.ActivateWorkOrPause == false)
                {
                    pauseLbl.Visibility = Visibility.Collapsed;
                    timerTxt.Content = string.Format("Время печатать 00:0{0}:{1}", time / 60, time % 60); // 09:59
                }
                else
                {
                    if (CommonTime > UtilController.MaxCommonTime)
                    {
                        UtilController.showPause(pauseLbl, "Отдых 30 минут");

                        if (time == 10)
                        {
                            voiceMessages(Properties.Resources.audio_zvuk_vokzala_31_wav);
                        }
                        else if (time == 1)
                        {
                            voiceMessages(Properties.Resources.audio_wavpereryv_zakonchen_34_wav);
                        }
                    }
                    else
                    {
                        UtilController.showPause(pauseLbl, "Отдых 5 минут");

                        if (time == 10)
                        {
                            voiceMessages(Properties.Resources.audio_zvuk_vokzala_31_wav);
                        }
                        else if (time == 1)
                        {
                            voiceMessages(Properties.Resources.audio_wavpereryv_zakonchen_34_wav);
                        }
                    }
                    timerTxt.Content = string.Format("Пауза 00:0{0}:{1}", time / 60, time % 60); // 09:59

                }
            }
            else if (time / 60 <= 10 && time % 60 < 10)
            {
                if (UtilController.ActivateWorkOrPause == false)
                {
                    pauseLbl.Visibility = Visibility.Collapsed;
                    timerTxt.Content = string.Format("Время печатать 00:0{0}:0{1}", time / 60, time % 60); // 11:05
                }
                else
                {
                    if (CommonTime > UtilController.MaxCommonTime)
                    {
                        UtilController.showPause(pauseLbl, "Отдых 30 минут");

                        if (time == 10)
                        {
                            voiceMessages(Properties.Resources.audio_zvuk_vokzala_31_wav);
                        }
                        else if (time == 1)
                        {
                            voiceMessages(Properties.Resources.audio_wavpereryv_zakonchen_34_wav);
                        }

                    }
                    else
                    {
                        UtilController.showPause(pauseLbl, "Отдых 5 минут");

                        if (time == 10)
                        {
                            voiceMessages(Properties.Resources.audio_zvuk_vokzala_31_wav);
                        }
                        else if (time == 1)
                        {
                            voiceMessages(Properties.Resources.audio_wavpereryv_zakonchen_34_wav);
                        }
                    }
                    timerTxt.Content = string.Format("Пауза 00:0{0}:0{1}", time / 60, time % 60); // 11:05
                }
            }
        }


        private void Home_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_uc.PlacementTarget = Home;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            //Header.PopupText.Text = "Печать";
        }

        private void Home_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_uc.Visibility = Visibility.Collapsed;
            popup_uc.IsOpen = false;
        }

        private void Profile_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_uc.Visibility = Visibility.Collapsed;
            popup_uc.IsOpen = false;
        }

        private void Settings_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_uc.Visibility = Visibility.Collapsed;
            popup_uc.IsOpen = false;
        }



        private void Home_Click(object sender, RoutedEventArgs e)
        {
            FirstUC viewF = new FirstUC("inputText", progress, this);
            FirstViewModel vmF = new FirstViewModel(this);
            viewF.DataContext = vmF;
            this.OutputView.Content = viewF;
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            SettingsView viewS = new SettingsView(this);
            this.OutputView.Content = viewS;
        }

        private void Settings_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_uc.PlacementTarget = Settings;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            //Header.PopupText.Text = "Настройки";
        }

        // 0 - visible; 1 - hidden; 2 - collapsed
        private void menuVisibility(Visibility Visibility)
        {
            Home.Visibility = Visibility;
            // Profile.Visibility = Visibility;
            Settings.Visibility = Visibility;
        }

        private void timeReset(Visibility visibility)
        {
            if (visibility == Visibility.Hidden)
            {
                timerTxt.Visibility = Visibility.Hidden;
            }
            else
            {
                UtilController.WorkTime = UtilController.AfterPauseTime;
                timerTxt.Visibility = Visibility.Visible;
            }
        }

        private void soundButton_Click(object sender, RoutedEventArgs e)
        {
            checkSoundContent();
        }


        private void setSoundImageContent(string soundOnUri, bool soundResourceSetting)
        {
            soundButton.Content = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri("pack://application:,,,/Resources/" + soundOnUri + ".png")), VerticalAlignment = VerticalAlignment.Center };
            soundOn = soundResourceSetting;
            Properties.Settings.Default.SoundOn = soundResourceSetting;
            Properties.Settings.Default.Save();
        }

        private void checkSoundContent()
        {

            if (soundOn == false)
            {
                setSoundImageContent("soundOn", true);
            }
            else
            {
                setSoundImageContent("soundOff", false);
            }
        }

        private void voiceMessages(UnmanagedMemoryStream resourcesPath)
        {
            SoundPlayer sp = new SoundPlayer();
            sp.Stream = resourcesPath;
            sp.Play();
        }

    }
}
