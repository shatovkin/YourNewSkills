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
        bool btn7Bool = false;
        bool btn8Bool = false;
        bool btn9Bool = false;

        bool btn1Controll = true;
        bool btn2Controll = true;
        bool btn3Controll = true;
        bool btn4Controll = true;
        bool btn5Controll = true;
        bool btn6Controll = true;
        bool btn7Controll = true;
        bool btn8Controll = true;
        bool btn9Controll = true;

        Label progress;
        MainWindow mainWindow;

        public StartConditionView(Label progress, MainWindow mainWindow)
        {
            InitializeComponent();

            DataContext = this;
            this.DataContext = Application.Current.MainWindow;

            this.progress = progress;
            this.mainWindow = mainWindow;
            this.mainWindow.Home.Visibility = Visibility.Hidden;
            this.mainWindow.Books.Visibility = Visibility.Hidden;
            this.mainWindow.Settings.Visibility = Visibility.Hidden;

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


        private void BtnForward_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.stopSound(); // stop sound instruction
            mainWindow.instructionButton.Visibility = Visibility.Hidden;
            
            UtilController.WorkTime = UtilController.StartWorkTime;
            FirstUC viewF = new FirstUC("inputText",mainWindow);
            FirstViewModel vmF = new FirstViewModel(mainWindow);
            viewF.DataContext = vmF;

          
            mainWindow.OutputView.Content = viewF;
            mainWindow.timerTxt.Visibility = Visibility.Visible;
            mainWindow.Home.Visibility = Visibility.Visible;
            this.mainWindow.Books.Visibility = Visibility.Visible;
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
            if (btn1Controll == false && btn2Controll == false && btn3Controll == false && btn4Controll == false &&
                btn5Controll == false && btn6Controll == false && btn7Controll == false && btn8Controll == false && btn9Controll == false)
            {
                BtnForward.IsEnabled = true;
            }
            else
            {
                BtnForward.IsEnabled = false;
            }
        }

        public static readonly DependencyProperty ActHeightProperty =
           DependencyProperty.Register("ActHeight", typeof(double), typeof(StartConditionView), new
               PropertyMetadata(((double)0), new PropertyChangedCallback(OnActHeightChanged)));
        public static readonly DependencyProperty ActWidthProperty =
            DependencyProperty.Register("ActWidth", typeof(double), typeof(StartConditionView), new
                PropertyMetadata(((double)0), new PropertyChangedCallback(OnActWidthChanged)));


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

        private static void OnActHeightChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            StartConditionView StartConditionView_ = d as StartConditionView;
            StartConditionView_.OnActHeightChanged(e);
        }


        private static void OnActWidthChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            StartConditionView StartConditionView_ = d as StartConditionView;
            StartConditionView_.OnActWidthChanged(e);
        }


        private void OnActHeightChanged(DependencyPropertyChangedEventArgs e)
        {

        }
        private void OnActWidthChanged(DependencyPropertyChangedEventArgs e)
        {

        }

        private void StartConditionView_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            ActHeight = e.NewSize.Height;
            ActWidth = e.NewSize.Width;
        }
    }
    public static class ActualSizeBehavior
    {
        public static readonly DependencyProperty ActualSizeProperty =
            DependencyProperty.RegisterAttached("ActualSize",
                                                typeof(bool),
                                                typeof(ActualSizeBehavior),
                                                new UIPropertyMetadata(false, OnActualSizeChanged));
        public static bool GetActualSize(DependencyObject obj)
        {
            return (bool)obj.GetValue(ActualSizeProperty);
        }
        public static void SetActualSize(DependencyObject obj, bool value)
        {
            obj.SetValue(ActualSizeProperty, value);
        }
        private static void OnActualSizeChanged(DependencyObject dpo,
                                                DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = dpo as FrameworkElement;
            if ((bool)e.NewValue == true)
            {
                element.SizeChanged += element_SizeChanged;
            }
            else
            {
                element.SizeChanged -= element_SizeChanged;
            }
        }

        static void element_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            SetActualWidth(element, element.ActualWidth);
            SetActualHeight(element, element.ActualHeight);
        }

        private static readonly DependencyProperty ActualWidthProperty =
            DependencyProperty.RegisterAttached("ActualWidth", typeof(double), typeof(ActualSizeBehavior));
        public static void SetActualWidth(DependencyObject element, double value)
        {
            element.SetValue(ActualWidthProperty, value);
        }
        public static double GetActualWidth(DependencyObject element)
        {
            return (double)element.GetValue(ActualWidthProperty);
        }

        private static readonly DependencyProperty ActualHeightProperty =
            DependencyProperty.RegisterAttached("ActualHeight", typeof(double), typeof(ActualSizeBehavior));
        public static void SetActualHeight(DependencyObject element, double value)
        {
            element.SetValue(ActualHeightProperty, value);
        }
        public static double GetActualHeight(DependencyObject element)
        {
            return (double)element.GetValue(ActualHeightProperty);
        }
    }

    // Does a math equation on the bound value.
    // Use @VALUE in your mathEquation as a substitute for bound value
    // Operator order is parenthesis first, then Left-To-Right (no operator precedence)
    public class MathConverter
    {
        private static readonly char[] _allOperators = new[] { '+', '-', '*', '/', '%', '(', ')' };

        private static readonly List<string> _grouping = new List<string> { "(", ")" };
        private static readonly List<string> _operators = new List<string> { "+", "-", "*", "/", "%" };

        // Evaluates a mathematical string and keeps track of the results in a List<double> of numbers
        private void EvaluateMathString(ref string mathEquation, ref List<double> numbers, int index)
        {
            // Loop through each mathemtaical token in the equation
            string token = GetNextToken(mathEquation);

            while (token != string.Empty)
            {
                // Remove token from mathEquation
                mathEquation = mathEquation.Remove(0, token.Length);

                // If token is a grouping character, it affects program flow
                if (_grouping.Contains(token))
                {
                    switch (token)
                    {
                        case "(":
                            EvaluateMathString(ref mathEquation, ref numbers, index);
                            break;

                        case ")":
                            return;
                    }
                }

                // If token is an operator, do requested operation
                if (_operators.Contains(token))
                {
                    // If next token after operator is a parenthesis, call method recursively
                    string nextToken = GetNextToken(mathEquation);
                    if (nextToken == "(")
                    {
                        EvaluateMathString(ref mathEquation, ref numbers, index + 1);
                    }

                    // Verify that enough numbers exist in the List<double> to complete the operation
                    // and that the next token is either the number expected, or it was a ( meaning
                    // that this was called recursively and that the number changed
                    if (numbers.Count > (index + 1) &&
                        (double.Parse(nextToken) == numbers[index + 1] || nextToken == "("))
                    {
                        switch (token)
                        {
                            case "+":
                                numbers[index] = numbers[index] + numbers[index + 1];
                                break;
                            case "-":
                                numbers[index] = numbers[index] - numbers[index + 1];
                                break;
                            case "*":
                                numbers[index] = numbers[index] * numbers[index + 1];
                                break;
                            case "/":
                                numbers[index] = numbers[index] / numbers[index + 1];
                                break;
                            case "%":
                                numbers[index] = numbers[index] % numbers[index + 1];
                                break;
                        }
                        numbers.RemoveAt(index + 1);
                    }
                    else
                    {
                        // Handle Error - Next token is not the expected number
                        throw new FormatException("Next token is not the expected number");
                    }
                }

                token = GetNextToken(mathEquation);
            }
        }

        // Gets the next mathematical token in the equation
        private string GetNextToken(string mathEquation)
        {
            // If we're at the end of the equation, return string.empty
            if (mathEquation == string.Empty)
            {
                return string.Empty;
            }

            // Get next operator or numeric value in equation and return it
            string tmp = "";
            foreach (char c in mathEquation)
            {
                if (_allOperators.Contains(c))
                {
                    return (tmp == "" ? c.ToString() : tmp);
                }
                else
                {
                    tmp += c;
                }
            }

            return tmp;
        }
    }
}

