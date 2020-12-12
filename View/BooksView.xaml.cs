using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows;
using System.Windows.Documents;
using System;
using NewSkills.Controller;
using System.Net;
using System.Xml;

namespace NewSkills.View
{
    /// <summary>
    /// Interaction logic for BooksView.xaml
    /// </summary>
    public partial class BooksView : UserControl
    {
        private MainWindow main; 
        public BooksView(MainWindow main)
        {
            InitializeComponent();
            this.main = main;

            if (Properties.Settings.Default.StartConditionsAchieved == true){
                Properties.Settings.Default.Save();
                main.Home.Visibility = Visibility.Visible;
                main.Home.IsEnabled = true;
            }
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // for .NET Core you need to add UseShellExecute = true
            // see https://docs.microsoft.com/dotnet/api/system.diagnostics.processstartinfo.useshellexecute#property-value
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
            
        }

        private void Hyperlink_Click_1(object sender, RoutedEventArgs e)
        {
            hype1.NavigateUri = new Uri(getHyperLink("1"));
        }

        private void Hyperlink_Click_2(object sender, RoutedEventArgs e)
        {
            hype2.NavigateUri = new Uri(getHyperLink("2"));
        }

        private void Hyperlink_Click_3(object sender, RoutedEventArgs e)
        {
            hype3.NavigateUri = new Uri(getHyperLink("3"));
        }

        private string getHyperLink(string bookNumber) {
            LicenseServiceController licenseController = new LicenseServiceController();
            string link =  licenseController.getBookHyperLink(bookNumber);
            return link;
        }
    }
}
