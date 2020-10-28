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
using System.Reflection;
using System.Drawing;
using System.Windows.Interop;
using System.Windows.Media;
using NewSkills.View;

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
        private string inputText;
        private Label progressLabel;

        NextLetterService nextLetterClass = new NextLetterService();
        NextLetterService.NextLetterWrapper nextLetterWrapper = new NextLetterService.NextLetterWrapper();

        private int fileLine = 1;
        private string[] wholeText;
        private int fileLength;
        private bool writeLetter = false;
        private int correctTextLenght = 0;

        public FirstUC(string fileName, Label progressLabel, MainWindow mainWindow)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            this.progressLabel = progressLabel;
            fontVariantSettings = Properties.Settings.Default.FontVariant;
            this.inputText = fileName;
            streamReaderController = new StreamReaderController(fileName);
            wholeText = streamReaderController.file;
            fileLength = wholeText.Length;
            exampleText.Text = streamReaderController.file[0];
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
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

                if (mainWindow.CommonTime < UtilController.MaxCommonTime)
                {
                    if (UtilController.DoSoundPause5 == true)
                    {
                        voiceMessages(Properties.Resources.audio_pereryv_5_minut_32_wav);
                        UtilController.DoSoundPause5 = false;
                    }
                }
                else
                {
                    if (UtilController.DoSoundPause30 == true)
                    {
                        voiceMessages(Properties.Resources.audio_pereryv_30_minut_33_wav);
                        UtilController.DoSoundPause30 = false;
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

                    if (spaceButtonClicked == true)
                    {
                        typingText = typingText + "|";
                    }

                    if (typingText.Length < sampleText.Length)
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

                            UtilController.getProgressInPercent(typingText, StreamReaderController.WholeSampleText, false);//считать проценты для прогресса

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


                                image.Source = getImagePathFromProperty(nextLetterClass.getPicture(nextLetterToShow)); ;

                                this.typingTextTxt.Text.Replace("|", " ");
                            }
                            else if (nextLetterToShow.ToString() == "|" && writeLetter == true)
                            {
                                popUpToClickSpace(lastLetter);
                                this.typingTextTxt.Text.Replace("|", " ");
                            }
                        }
                    }

                    if (typingText.Length == sampleText.Length)
                    {
                        if (getCurrentLetter(typingText.Length, typingText, sampleText))
                        {
                            if (fileLine != wholeText.Length)
                            {
                                if (fileLine <= wholeText.Length - 1)
                                {
                                    this.exampleText.Text = wholeText[fileLine];
                                }

                                this.typingTextTxt.Text = "";
                                fileLine++;
                                fileLength--;
                            }
                            else
                            {
                                UtilController.BlockTextFieldAndTimer = true;
                                this.typingTextTxt.IsReadOnly = true;
                                progressLabel.Content = "100";
                                mainWindow.LoadView(ViewType.CongratulationView);
                            }
                        }
                        else
                        {
                            this.typingTextTxt.Text = typingText.Substring(0, typingText.Length - 1).Replace("|", " "); // обрезать последнюю букву, если возникла ошибка
                            this.typingTextTxt.Select(typingTextTxt.Text.Length, typingTextTxt.Text.Length); //Поставить курсор на последнее место
                        }
                    }

                } while (fileLength == 0);
            }
            catch (Exception exception)
            {
                MessageBox.Equals(exception, exception);
                // streamReaderController.writeLogs(this.GetType().Name, exception);
            }
        }

        private char lastLetterBeforeClickSpace(string typingText)
        {
            if (typingText.Length >= 3)
            {
                return typingText.Substring(typingText.Length - 3).ToCharArray()[0];
            }
            return 'ß';
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
            catch (Exception e)
            {
                MessageBox.Equals(e, e);
                if (typingTextLenght == -1)
                {
                    correctTextLenght = typingTextLenght + 1;
                    writeLetter = true;
                    return true;
                }
                else
                {
                    //streamReaderController.writeLogs(this.GetType().Name, e);
                    writeLetter = false;
                    return false;
                }
            }
        }

        //*определить следующюю букву по тексту
        //*и вернуть эту букву.
        private char nextLetter(string inputText, string sampleText)
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
                    exampleText.Text = streamReaderController.file[1];
                }
            }
            return '*';
        }

        private void previewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                this.typingTextTxt.Focus();
            }

            if (e.Key == Key.Space)
            {
                spaceButtonClicked = true;
            }
            else
            {
                spaceButtonClicked = false;
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
            image.Source = getImagePathFromProperty(Properties.Resources.letter_space);

            if (fontVariantSettings == 0)
            {
                if (lastLetterSpaceDirectionDescription.directionDescription == "LeftSpace")
                {
                    suggestionMessage.Text = " Пробел «space» – левой нулевым на месте";
                    if (Properties.Settings.Default.SoundOn)
                    {
                        voiceMessages(Properties.Resources.audio_Probel_levoj11_wav);
                    }
                    this.typingTextTxt.Focus();
                }
                else
                {
                    suggestionMessage.Text = " Пробел «space» – правой нулевым на месте";
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
                    suggestionMessage.Text = " Пробел «space» – левой большим на месте";
                    if (Properties.Settings.Default.SoundOn)
                    {
                        voiceMessages(Properties.Resources.audio_Probel_levoj21_wav);

                    }
                    this.typingTextTxt.Focus();
                }
                else
                {
                    suggestionMessage.Text = " Пробел «space» – правой большим на месте";
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
            SoundPlayer sp = new SoundPlayer();
            sp.Stream = resourcesPath;
            sp.Play();
        }


        private BitmapSource getImagePathFromProperty(Bitmap resource)
        {
            Bitmap bitmap = new System.Drawing.Bitmap(resource);//it is in the memory now
            return Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
