using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using NewSkills.ViewModel;
using NewSkills.Controller;
using System.IO;
using System.Windows.Media.Imaging;
using System.Media;
using System.Windows;
using static NewSkills.ViewModel.NextLetterService;

namespace NewSkills.View
{
    /// <summary>
    /// Interaction logic for FirstUC.xaml
    /// </summary>
    public partial class FirstUC : UserControl
    {
        MainWindow mainWindow;
        // Timer Variables
        private DispatcherTimer timer;
        // End of Timer Variables
        int fontVariantSettings;
        private StreamReaderController streamReaderController;
        public bool spaceButtonClicked = false;
        private int lastCaretIndex = 0;
        private string lastTypedText ="";
        private string inputText;
        NextLetterService nextLetterClass = new NextLetterService();
        NextLetterService.NextLetterWrapper nextLetterWrapper = new NextLetterService.NextLetterWrapper();

        private int fileLineNumber;
        private string[] wholeText;
        private int fileLength;
        private bool writeLetter = false;
        private int correctTextLenght = 0;
        private string fileName;
        SoundPlayer sp; 

        public FirstUC(string fileName, MainWindow mainWindow)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            mainWindow.Home.IsEnabled = false;
            mainWindow.instructionButton.Visibility = Visibility.Visible;
            mainWindow.soundButton.Visibility = Visibility.Visible;
            mainWindow.questionButton.Visibility = Visibility.Visible;
            mainWindow.menuVisibility(Visibility.Visible);

            mainWindow.stackPanelDockTop.Height = 650;
            mainWindow.stackPanelDockTop.VerticalAlignment = VerticalAlignment.Top;

            mainWindow.scroll.ScrollToHome();
            //mainWindow.restartButton.Visibility = Visibility.Visible;
            fontVariantSettings = Properties.Settings.Default.FontVariant;

            this.fileName = fileName;
            this.inputText = this.fileName;
            streamReaderController = new StreamReaderController(fileName);
            fileLineNumber = returnWriteLine(this.fileName);
            wholeText = streamReaderController.file;

            suggestionMessage.Text = nextLetterClass.getLetter(wholeText[fileLineNumber].First(), fontVariantSettings).letterDescription;
            image.Source = getImage(wholeText[fileLineNumber].First());

            fileLength = wholeText.Length;
            exampleText.Text = streamReaderController.file[fileLineNumber];

            mainWindow.progress.Content = UtilController.getProgressInPercent(fileLineNumber, fileLength).ToString();//считать проценты для прогресса
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        // cчитываем из памяти какая строка была последней при печати.
        private int returnWriteLine(string fileName)
        {
            if (fileName == "inputText1")
            {
                return Properties.Settings.Default.InputText1;
            }
            else if (fileName == "inputText2")
            {
                return Properties.Settings.Default.InputText2;
            }
            else if (fileName == "inputText3")
            {
                return Properties.Settings.Default.InputText3;
            }
            return 0;
        }

        //Записываем при смене строки, какая строка по счету
        private void writeStopLine(string fileName, int lineNumber)
        {
            if (fileName == "inputText1")
            {
                Properties.Settings.Default.InputText1 = lineNumber;
            }
            else if (fileName == "inputText2")
            {
                Properties.Settings.Default.InputText2 = lineNumber;
            }
            else if (fileName == "inputText3")
            {
                Properties.Settings.Default.InputText3 = lineNumber;
            }
            Properties.Settings.Default.Save();
        }

        // ежесекундый запуск метода, для таймера
        // тут высчитывается, должна ли работать пауза или печать
        private void Timer_Tick(object sender, EventArgs e)
        {
            //Спросить, нужно ли заблокировать рабочую область для паузы или нет
            if (UtilController.ActivateWorkOrPause == false && UtilController.BlockTextFieldAndTimer == false)
            {
                typingTextTxt.IsReadOnly = false;
                UtilController.DoSoundPause5 = true;
                UtilController.DoSoundPause30 = true;
            }
            else
            {
                typingTextTxt.IsReadOnly = true;

                if (UtilController.CommonRounds == 0 || UtilController.ThirtyMinutesPauseCountDown != 0)
                {
                    if (UtilController.ThirtyMinutesPauseCountDown == 0)
                    {
                        UtilController.ThirtyMinutesPauseCountDown = 1800;
                        UtilController.PauseTime = 1800;
                    }

                    UtilController.ThirtyMinutesPauseCountDown--;

                    if (UtilController.DoSoundPause30 == true)
                    {
                        UtilController.CommonRounds = UtilController.Rounds;
                        voiceMessages(Properties.Resources.audio_pereryv_30_minut_33_wav);
                        UtilController.DoSoundPause30 = false;
                    }
                }
                else
                {
                    if (UtilController.DoSoundPause5 == true)
                    {
                        UtilController.CommonRounds--;
                        UtilController.DoSoundPause5 = false;

                        if (UtilController.CommonRounds != 0)
                        {
                            voiceMessages(Properties.Resources.audio_pereryv_5_minut_32_wav);
                        }
                    }
                }
            }
        }

        //сравнить два текста, при изменени текста в поле ввода
        private void typingTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                do
                {
                    string typingText = this.typingTextTxt.Text.Trim().Replace(" ", "|");
                    string sampleText = this.exampleText.Text.Trim().Replace(" ", "|");

                    if ((lastCaretIndex > this.typingTextTxt.CaretIndex) && typingTextTxt.Text.Length != 0)
                    {
                        this.typingTextTxt.Text = lastTypedText;
                        this.typingTextTxt.CaretIndex = lastCaretIndex;

                        char nextLetterToShow = nextLetter(typingText, sampleText);

                        if (nextLetterToShow.ToString() != "|")
                        {
                            nextLetterWrapper = nextLetterClass.getLetter(nextLetterToShow, fontVariantSettings);

                        }
                        //If sound "On" play sounds
                        if (Properties.Settings.Default.SoundOn)
                        {
                            voiceMessages(nextLetterWrapper.voicePath);
                        }
                        else
                    {
                        if (typingText.Length > sampleText.Length)
                        {
                            string typingText2 = this.typingTextTxt.Text;
                            this.typingTextTxt.Text = typingText2.Substring(0, sampleText.Length - 1);
                            this.typingTextTxt.CaretIndex = sampleText.Length - 1;
                        }

                        if (spaceButtonClicked == true)
                        {
                            typingText = typingText + "|";
                        }

                        if (typingText.Length <= sampleText.Length)
                        {
                            if (!getCurrentLetter(typingText.Length, typingText, sampleText))
                            {
                                writeLetter = false;
                                this.typingTextTxt.Text = typingText.Substring(0, typingText.Length - 1).Replace("|", " ");//обрезать последнюю букву, если возникла ошибка
                                if (UtilController.BlockTextFieldAndTimer != true)
                                {
                                    this.typingTextTxt.IsReadOnly = true;
                                    this.typingTextTxt.CaretIndex = correctTextLenght; //Поставить курсор на последнее место
                                }
                            }
                            else
                            {
                                char lastLetter = lastLetterBeforeClickSpace(typingText); // to detect the space direction left or right
                                char nextLetterToShow = nextLetter(typingText, sampleText);

                                if (nextLetterToShow.ToString() != "|")
                                {
                                    nextLetterWrapper = nextLetterClass.getLetter(nextLetterToShow, fontVariantSettings);
                                    string message = nextLetterWrapper.letterDescription;
                                    popUpToRightCase(message); // set text to "Подсказки"

                                    //If sound "On" play sounds
                                    if (Properties.Settings.Default.SoundOn)
                                    {
                                        voiceMessages(nextLetterWrapper.voicePath);
                                    }

                                    image.Source = getImage(nextLetterToShow);
                                    this.typingTextTxt.Text.Replace("|", " ");
                                }
                                else if (nextLetterToShow.ToString() == "|" && writeLetter == true)
                                {
                                    popUpToClickSpace(lastLetter);
                                    this.typingTextTxt.Text.Replace("|", " ");
                                }
                            }
                        }

                        if (typingText.Length == sampleText.Length && (typingText == sampleText))
                        {
                            fileLineNumber++;

                            if (getCurrentLetter(typingText.Length, typingText, sampleText))
                            {
                                if (fileLineNumber != wholeText.Length)
                                {
                                    if (fileLineNumber <= wholeText.Length - 1)
                                    {
                                        this.exampleText.Text = wholeText[fileLineNumber];
                                    }

                                    this.typingTextTxt.Text = "";

                                    writeStopLine(fileName, fileLineNumber);
                                    this.mainWindow.progress.Content = UtilController.getProgressInPercent(fileLineNumber, fileLength).ToString();//считать проценты для прогресса
                                }
                                else
                                {
                                    try
                                    {
                                        stopSound(sp);
                                        mainWindow.RunTimer = false;
                                        mainWindow.progress.Content = UtilController.getProgressInPercent(fileLineNumber, fileLength);
                                        CongratulationWindow congratulationWindow = new CongratulationWindow(mainWindow, fileName);
                                        congratulationWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                                        congratulationWindow.Owner = Application.Current.MainWindow;
                                        congratulationWindow.Show();
                                    }
                                    catch (Exception er)
                                    {
                                        MessageBox.Show("test" + er.ToString());
                                    }
                                }
                            }
                            else
                            {
                                this.typingTextTxt.Text = typingText.Substring(0, typingText.Length - 1).Replace("|", " "); // обрезать последнюю букву, если возникла ошибка
                                this.typingTextTxt.Select(typingTextTxt.Text.Length, typingTextTxt.Text.Length); //Поставить курсор на последнее место
                            }
                        }
                        lastCaretIndex = this.typingTextTxt.CaretIndex;
                        lastTypedText = this.typingTextTxt.Text;
                    }
                } while (fileLength == 0);
            }
            catch (Exception exception)
            {
                MessageBox.Equals(exception, exception);
            }
        }

        private void stopSound(SoundPlayer sp)
        {
            if (sp != null) {
                sp.Stop();
            }
        }

        private char lastLetterBeforeClickSpace(string typingText)
        {
            if (typingText.Length > 1)
            {
                return typingText.Substring(typingText.Length - 1).ToCharArray()[0];
            }
            else
            {
                return typingText.ToCharArray()[0];
            }
        }

        //**сравнить строку с входящим текстом **/
        //И если текст был введён правильный, вернуть "bool"
        private bool getCurrentLetter(int typingTextLenght, string inputText, string sampleText)
        {
            try
            {
                if (typingTextLenght >= 0)
                {
                    string typingText = inputText;

                    typingTextLenght = typingTextLenght - 1;

                    char[] chartsOfTypingText = typingText.ToCharArray();

                    char[] chartsOfExampleText = sampleText.ToCharArray();

                    char typingLastLetter = chartsOfTypingText[typingTextLenght];

                    char exampleLastLetter = chartsOfExampleText[typingTextLenght];

                    if (typingLastLetter == exampleLastLetter)
                    {
                        correctTextLenght = typingTextLenght + 1;
                        writeLetter = true;
                        return true;
                    }
                    else
                    {
                        writeLetter = false;
                        return false;
                    }
                }
                else
                {
                    writeLetter = false;
                    return false;
                }
            }
            catch (Exception)
            {
                if (typingTextLenght == -1)
                {
                    correctTextLenght = typingTextLenght + 1;
                    writeLetter = true;
                    return true;
                }
                else
                {
                    writeLetter = false;
                    return false;
                }
            }
        }

        //*определить следующюю букву по тексту
        //*и вернуть эту букву.
        private char nextLetter(string inputText, string sampleText)
        {
            try
            {
                if (inputText.Substring(0, inputText.Length) == sampleText.Substring(0, inputText.Length))
                {
                    if (inputText.Length < sampleText.Length)
                    {
                        char[] letter = sampleText.ToArray();
                        char toTypingLetter = letter[inputText.Length];
                        return toTypingLetter;
                    }
                    else
                    {
                        if (fileLineNumber < fileLength)
                        {
                            exampleText.Text = streamReaderController.file[fileLineNumber];
                        }

                        if (fileLineNumber == fileLength)
                        {
                            mainWindow.RunTimer = false;
                            mainWindow.progress.Content = "100";

                        }
                        return streamReaderController.file[fileLineNumber+1].First();
                    }
                }
                return '*';
            }
            catch (Exception e)
            {
                return '*';
            }
        }

        private void previewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                spaceButtonClicked = true;
            }
            else
            {
                spaceButtonClicked = false;
            }

            if (UtilController.WorkTime == 0 && UtilController.PauseTime == 0 && UtilController.ActivateWorkOrPause == true)
            {
                mainWindow.AnyKeyPressed = true;
            }

            if (e.Key == Key.Tab) {
                e.Handled = true;
                base.OnKeyDown(e);
            }
        }

        private void popUpToRightCase(string message)
        {
            suggestionMessage.Text = message;
            this.typingTextTxt.Focus();
        }

        private void popUpToClickSpace(char lastLetter)
        {
            NextLetterService.NextLetterWrapper lastLetterSpaceDirectionDescription = nextLetterClass.getLetter(lastLetter, fontVariantSettings);

            image.Source = getImage('|');

            if (fontVariantSettings == 0)
            {
                if (lastLetterSpaceDirectionDescription.directionDescription == "LeftSpace")
                {
                    suggestionMessage.Text = " Пробел – левой нулевым на месте";
                    if (Properties.Settings.Default.SoundOn)
                    {
                        voiceMessages(Properties.Resources.audio_Probel_levoj11_wav);
                    }
                    this.typingTextTxt.Focus();
                }
                else
                {
                    suggestionMessage.Text = " Пробел – правой нулевым на месте";
                    if (Properties.Settings.Default.SoundOn)
                    {
                        voiceMessages(Properties.Resources.audio_Probel_pravoj11_wav);
                    }
                    this.typingTextTxt.Focus();
                }
            }

            if (fontVariantSettings == 1)
            {
                if (lastLetterSpaceDirectionDescription.directionDescription == "LeftSpace")
                {
                    suggestionMessage.Text = " Пробел – левой большим на месте";
                    if (Properties.Settings.Default.SoundOn)
                    {
                        voiceMessages(Properties.Resources.audio_Probel_levoj21_wav);
                    }
                    this.typingTextTxt.Focus();
                }
                else
                {
                    suggestionMessage.Text = " Пробел – правой большим на месте";
                    if (Properties.Settings.Default.SoundOn)
                    {
                        voiceMessages(Properties.Resources.audio_Probel_pravoj21_wav);
                    }
                    this.typingTextTxt.Focus();
                }
            }
        }

        private void voiceMessages(UnmanagedMemoryStream resourcesPath)
        {
            sp = new SoundPlayer();
            sp.Stream = resourcesPath;
            sp.Play();
        }

        private BitmapSource getImage(char lastLetter)
        {
            BitmapSource bs = NextLetterService.LoadedImages.Find(x => x.letter == lastLetter).imageSource;
            return bs;
        }
    }
}
