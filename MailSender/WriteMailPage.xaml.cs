using Microsoft.Win32;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for WriteMailPage.xaml
    /// </summary>
    public partial class WriteMailPage : Page
    {
        bool receiverTB_has_focus = false;
        bool subjectTB_has_focus = false;
        bool messageTB_has_focus = false;

        string attachmentPath = string.Empty;
        Settings settings = new Settings();

        public WriteMailPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists("settings.xml"))
            {
                settings = XmlFileManager.XmlUserDataReader("settings.xml");
            }
        }

        //Textbox focus handler
        private void ReceiverTB_GotFocus(object sender, RoutedEventArgs e)
        {
            if(!receiverTB_has_focus)
            {
                ReceiverTB.Text = string.Empty;
                receiverTB_has_focus = true;
            }
        }

        private void SubjectTB_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!subjectTB_has_focus)
            {
                SubjectTB.Text = string.Empty;
                subjectTB_has_focus = true;
            }
        }

        private void MessageTB_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!messageTB_has_focus)
            {
                MessageTB.Text = string.Empty;
                messageTB_has_focus = true;
            }
        }


        //Button event handler
        private void AttachBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            attachmentPath = System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName);
            AttachFileTB.Text = openFileDialog.SafeFileName;
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string mail = "salut";
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("on mail");
                msg.To.Add(new MailAddress("to mail"));
                msg.Body = mail;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = false;
                client.Timeout = 10000;
                client.Credentials = new NetworkCredential("fpouhela@gmail.com", "william100");
                client.Send(msg);

                MessageBox.Show("Successfully Message Sent!");
                InitPage();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Message not sent because of:" + ex.ToString());
            }
        }

        private void InitPage()
        {
            receiverTB_has_focus = false;
            subjectTB_has_focus = false;
            ReceiverTB.Text = "Email@example.com...";
            SubjectTB.Text = "Subject...";
            AttachFileTB.Text = "Select your attachment...";
            MessageTB.Text = "Write Your Email Here...";
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            InitPage();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            attachmentPath = string.Empty;
            AttachFileTB.Text = "Select your attachment...";
        }
    }
}
