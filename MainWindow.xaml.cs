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
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Controls;
using System.Diagnostics;

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
        private bool instructionOn = false;
        private static int commonTime = 0;
        public int CommonTime { get { return commonTime; } set { commonTime = value; } }
        private bool runTimer = false;
        public bool RunTimer { get { return runTimer; } set { runTimer = value; } }
        private bool anyKeyPressed = false;
        public bool AnyKeyPressed { get { return anyKeyPressed; } set { anyKeyPressed = value; } }
        // End of Timer Variables
        private SoundPlayer soundPlayer = new SoundPlayer();

        public MainWindow()
        {
            InitializeComponent();
            this.SizeChanged += MainWindow_SizeChanged;

            soundOn = Properties.Settings.Default.SoundOn;
            checkSoundContent();
            this.Loaded += MainWindow_Loaded;
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);


            string language = System.Windows.Forms.InputLanguage.CurrentInputLanguage.Culture.Name;

            if (language != "ru-RU")
            {
                System.Windows.Forms.InputLanguage.CurrentInputLanguage = System.Windows.Forms.InputLanguage.FromCulture(new System.Globalization.CultureInfo("ru-RU"));
            }

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void resetSettings()
        {
            Properties.Settings.Default.InputText1 = 0;
            Properties.Settings.Default.InputText2 = 0;
            Properties.Settings.Default.InputText3 = 0;
            Properties.Settings.Default.Save();
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
                    else if (UtilController.PauseTime > 0 && UtilController.Rounds != 0)
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

                            if (UtilController.CommonRounds == 0 || UtilController.ThirtyMinutesPauseCountDown != 0)
                            {
                                UtilController.WorkTime = UtilController.WorkTime;
                                UtilController.PauseTime = UtilController.ThirtyMinutesPauseCountDown;
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
            try
            {
                if (Properties.Settings.Default.License == false)
                {
                    LoadView(ViewType.LicenseView);
                }
                else
                {
                    //LoadView(ViewType.StartConditionView);
                    LoadView(ViewType.StartConditionView);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Congratulation:" + ex.ToString());
            }

        }

        public void LoadView(ViewType typeView)
        {
            switch (typeView)
            {
                case ViewType.StartConditionView:
                    timeReset(Visibility.Hidden);
                    StartConditionView conditionViewStart = new StartConditionView(progress, this);
                    StartConditionViewModel startCond = new StartConditionViewModel(this);
                    conditionViewStart.DataContext = startCond;
                    this.OutputView.Content = conditionViewStart;
                    break;
                case ViewType.First:
                    timeReset(Visibility.Visible);
                    FirstUC viewF = new FirstUC(Properties.Settings.Default.CurrentInputTextName, this);
                    FirstView vmF = new FirstView(this);
                    viewF.DataContext = vmF;
                    this.OutputView.Content = viewF;

                    break;
                case ViewType.CongratulationView:
                    menuVisibility(Visibility.Visible);
                    timeReset(Visibility.Visible);
                    CongratulationWindow congratulationWindow = new CongratulationWindow(this,"inputText1");
                    congratulationWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    congratulationWindow.Owner = Application.Current.MainWindow;
                    congratulationWindow.Show();
                    break;
                case ViewType.LicenseView:
                    menuVisibility(Visibility.Hidden);
                    timeReset(Visibility.Hidden);
                    LicenseWindow lw = new LicenseWindow(this);
                    lw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    lw.Owner = Application.Current.MainWindow;
                    lw.Show();
                    break;
            }
        }

        private void setTime(int time)
        {
            if (time / 60 >= 10 && time % 60 >= 10)
            {
                if (UtilController.ActivateWorkOrPause == false)
                {
                    pauseLbl.Visibility = Visibility.Collapsed;
                    timerTxt.Content = string.Format("Время печатать 00:{0}:{1}", time / 60, time % 60); // 13: 50
                }
                else
                {
                    if (UtilController.CommonRounds == 0 || UtilController.ThirtyMinutesPauseCountDown != 0)
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
                    else if (UtilController.CommonRounds == 0 || UtilController.ThirtyMinutesPauseCountDown != 0)
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
                    if (UtilController.CommonRounds == 0 || UtilController.ThirtyMinutesPauseCountDown != 0)
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
                    if (UtilController.CommonRounds == 0 || UtilController.ThirtyMinutesPauseCountDown != 0)
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
                    if (UtilController.CommonRounds == 0 || UtilController.ThirtyMinutesPauseCountDown != 0)
                    {
                        UtilController.showPause(pauseLbl, "Отдых 30 минут");

                        time = UtilController.ThirtyMinutesPauseCountDown;

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
            FirstUC viewF = new FirstUC(Properties.Settings.Default.CurrentInputTextName, this);
            FirstView vmF = new FirstView(this);
            viewF.DataContext = vmF;
            this.OutputView.Content = viewF;
            this.runTimer = true;
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            SettingsView viewS = new SettingsView(this, this.Background);
            this.OutputView.Content = viewS;
        }

        private void Books_Click(object sender, RoutedEventArgs e)
        {
            BooksView viewS = new BooksView(this);
            this.OutputView.Content = viewS;
        }

        private void Settings_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_uc.PlacementTarget = Settings;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
        }

        // 0 - visible; 1 - hidden; 2 - collapsed
        private void menuVisibility(Visibility Visibility)
        {
            Home.Visibility = Visibility;
            Books.Visibility = Visibility;
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
            if (soundOn == true)
            {
                setSoundImageContent("soundOff", false);
            }
            else
            {
                setSoundImageContent("soundOn", true);
            }
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
            if (soundOn == true)
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

        private void instructionButton_Click(object sender, RoutedEventArgs e)
        {
            if (instructionOn == false)
            {
                instructionOn = true;
                instructionButton.Content = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri("pack://application:,,,/Resources/" + "instruction" + ".png")), VerticalAlignment = VerticalAlignment.Center };
                soundPlayer.Stream = Properties.Resources.instructionSound;
                soundPlayer.Play();
            }
            else
            {
                instructionOn = false;
                soundPlayer.Stop();
                instructionButton.Content = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri("pack://application:,,,/Resources/" + "instructionOff" + ".png")), VerticalAlignment = VerticalAlignment.Center };
            }
        }

        public void stopSound()
        {
            soundPlayer.Stop();
        }

        private List<Control> AllChildren(DependencyObject parent)
        {
            var list = new List<Control> { };
            for (int count = 0; count < VisualTreeHelper.GetChildrenCount(parent); count++)
            {
                var child = VisualTreeHelper.GetChild(parent, count);
                if (child is Control)
                {
                    list.Add(child as Control);
                }
                list.AddRange(AllChildren(child));
            }
            return list;
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var allChildren = AllChildren(this);
            var g = allChildren.Find(k => k.Name == "CurrentPresenter");
            if (g != null)
                g.RaiseEvent(e);

            scroll.Width = e.NewSize.Width;
            stackPanelDockTop.Width = e.NewSize.Width;
        }

        private void emailView_Click(object sender, RoutedEventArgs e)
        {
            EmailView view = new EmailView();
            view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            view.Owner = Application.Current.MainWindow;
            view.Show();
        }
    }
}
