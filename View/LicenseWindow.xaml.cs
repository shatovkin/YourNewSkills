﻿using System.Windows;
using System.Windows.Controls;
using NewSkills.Controller;
using System.Management;
using System.Net;
using System.Xml;
using System.IO;
using System.Windows.Input;
using System.Text.RegularExpressions;


namespace NewSkills.View
{
    /// <summary>
    /// Interaction logic for LicenseWindow.xaml
    /// </summary>
    public partial class LicenseWindow : Window
    {
        private MainWindow mainWindow;
        private static int inputLength = 4;
        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        public static object ManagementObjectServer { get; private set; }

        public LicenseWindow(MainWindow mainWindow)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            GetCPUId();
        }

        private void licenseCodeOne_ChangeEvent(object sender, TextChangedEventArgs e)
        {
            if (licenseCode1.Text.Length == inputLength)
            {
                licenseCode2.Focus();
            }
        }

        private void licenseCodeTwo_ChangeEvent(object sender, TextChangedEventArgs e)
        {
            if (licenseCode2.Text.Length == inputLength)
            {
                licenseCode3.Focus();
            }
        }

        private void licenseCodeThree_ChangeEvent(object sender, TextChangedEventArgs e)
        {
            if (licenseCode3.Text.Length == inputLength)
            {
                licenseCode4.Focus();
            }
        }


        private void licenseCodeFore_ChangeEvent(object sender, TextChangedEventArgs e)
        {
            if (licenseCode1.Text.Length == inputLength && licenseCode2.Text.Length == inputLength && licenseCode3.Text.Length == inputLength && licenseCode4.Text.Length == inputLength)
            {
                activationButton.IsEnabled = true;
            }
        }

        private void sendRequest_ActivationButton(object sender, RoutedEventArgs e)
        {

            string licenseCode = licenseCode1.Text + "-" + licenseCode2.Text + "-" + licenseCode3.Text + "-" + licenseCode4.Text;

            if (checkInternetConnection())
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait; // set the cursor to loading spinner
                LicenseServiceController licenseController = new LicenseServiceController();
                int licenseNumber = licenseController.getLincenceRequest(licenseCode);
                LicenseRequest request = getRequest(licenseCode, GetCPUId());

                if (licenseNumber == request.ExcerciseNumber && request.LicenseExistence)
                {
                    this.Hide();
                    mainWindow.LoadView(ViewType.StartConditionView);
                    mainWindow.menuVisibility(Visibility.Visible);
                    Properties.Settings.Default.License = true;
                    Properties.Settings.Default.LicenseKey = licenseCode;
                    Properties.Settings.Default.Save();
                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow; // set the cursor back to arrow
                }
                else
                {
                    activationButton.IsEnabled = true;
                    messageLabel.Visibility = Visibility.Visible;
                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow; // set the cursor back to arrow
                }
            }
            else
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow; // set the cursor back to arrow
                messageLabel.Content = "Подключитесь к интернету для проверки ключа";
                messageLabel.Visibility = Visibility.Visible;
            }
        }

        public static string GetCPUId()
        {
            string cpuId = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select ProcessorId from Win32_Processor");
            foreach (ManagementObject mj in searcher.Get())
            {
                cpuId = System.Convert.ToString(mj["ProcessorId"]);
            }
            return cpuId;
        }

        public static LicenseRequest getRequest(string licenseCode, string cpu)
        {
            try
            {
                //Create a request and get Response in a xml
                WebClient webClient = new WebClient();
                webClient.QueryString.Add("licenseNumber", licenseCode);
                webClient.QueryString.Add("cpuId", cpu);
                var result = webClient.DownloadString("http://autorization.yournewskills.ru/LicenseService.asmx/getLincenseAndCPURequest");

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(result);

                var excerciseNumber = xmlDoc.GetElementsByTagName("ExcerciseNumber")[0].InnerText;
                var licenseExistence = xmlDoc.GetElementsByTagName("LicenseExistence")[0].InnerText;

               
                LicenseRequest licenseRequest = new LicenseRequest();
                licenseRequest.LicenseExistence = bool.Parse(licenseExistence);
                licenseRequest.ExcerciseNumber = int.Parse(excerciseNumber);
                return licenseRequest;
            }
            catch (WebException e)
            {
                string pageContent = new StreamReader(e.Response.GetResponseStream()).ReadToEnd().ToString();
                return new LicenseRequest();
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private static bool checkInternetConnection()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }

        public class LicenseRequest
        {
            public int ExcerciseNumber { get; set; }
            public bool LicenseExistence { get; set; }
        }
    }
}
