using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Net.Mail;
using System.Windows.Documents;
using NewSkills.Controller;
using System;
using System.Windows.Media;
using System.Windows.Input;
using System.Management;

namespace NewSkills.View
{
    /// <summary>
    /// Interaction logic for EmailView.xaml
    /// </summary>
    public partial class EmailView : Window
    {
        public List<Attachment> docuListBox = new List<Attachment>();
        private string cpuId;
        private string emailTheme = ""; 

        public EmailView()
        {
            InitializeComponent();
        }

        private void sendEmailButton_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            emailNotification();
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
            this.Close();
        }

        private bool isEMailValid(string email)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(email);
        }

        public void emailNotification()
        {
            MailMessage mail = new MailMessage();
            SmtpClient smptServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("ynstyping@gmail.com");
            mail.To.Add("yournewskillsteam@gmail.com");
            mail.Subject = "Тема:"+emailTheme.Split(':')[1] + " | Имя: " + EmailName.Text +" | CpuId: "+ getCPUId();
            mail.Body = "Имя: " + EmailName.Text +"\nМайл:"+ EmailAddressTxt.Text + "\nId процессора: "+ getCPUId()+ "\n\n"+StringFromRichTextBox(EmailBody);

            foreach (var attachment in docuListBox)
            {
                mail.Attachments.Add(attachment);
            }

            smptServer.Port = 587;
            smptServer.Credentials = new System.Net.NetworkCredential("ynstyping@gmail.com", "jkl;7890");
            smptServer.EnableSsl = true;
            smptServer.Send(mail);
        }

        string StringFromRichTextBox(System.Windows.Controls.RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                rtb.Document.ContentStart,
                rtb.Document.ContentEnd);
            return textRange.Text;
        }

        private void addDocument_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            //openFileDialog.Filter = "Text files (*.txt)|*.txt|*.txt|All files (*.*)|*.*";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.ShowDialog();

            int filesCounter = 0;
            foreach (string filename in openFileDialog.FileNames)
            {
                filesCounter++;
                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(filename);
                docuListBox.Add(attachment);
            }

            if (filesCounter == 1) {
                fileCounterTxt.Visibility = Visibility.Visible;
                fileCounterTxt.Content = "Добавлено: " + filesCounter + " файл";
            }else if (filesCounter > 1 && filesCounter < 5)
            {
                fileCounterTxt.Visibility = Visibility.Visible;
                fileCounterTxt.Content = "Добавлено: " + filesCounter + " файла";
            }
            else {
                fileCounterTxt.Visibility = Visibility.Visible;
                fileCounterTxt.Content = "Добавлено: " + filesCounter + " файлов";
            }
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!isEMailValid(EmailAddressTxt.Text))
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString("#ff0000");
                EmailAddressTxt.BorderBrush = brush;
            }
            else
            {
                var converter = new BrushConverter();
                var brush = (Brush)converter.ConvertFromString("#bfbfbf");
                EmailAddressTxt.BorderBrush = brush;
            }
        }

        private string getCPUId()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select ProcessorId from Win32_Processor");
            foreach (ManagementObject mj in searcher.Get())
            {
                cpuId = System.Convert.ToString(mj["ProcessorId"]);
            }

            return cpuId;
        }

        private void emailThemeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            emailTheme =  EmailTheme.SelectedValue.ToString();
        }
    }
}
