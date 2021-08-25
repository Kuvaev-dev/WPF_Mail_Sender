using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        Settings settings = new Settings();

        public SettingsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            InitSettings();
        }

        private void InitSettings()
        {
            if (File.Exists("settings.xml"))
            {
                settings = XmlFileManager.XmlUserDataReader("settings.xml");
                UsernameTB.Text = settings.Username.Trim();
                PasswordTB.Text = settings.Password.Trim();
                SmtpTB.Text = settings.Smtp.Trim();
                PortTB.Text = settings.Port.ToString();
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("settings.xml"))
            {
                settings.Username = UsernameTB.Text.Trim();
                settings.Password = PasswordTB.Text.Trim();
                settings.Smtp = SmtpTB.Text.Trim();
                settings.Port = int.Parse(PortTB.Text);

                XmlFileManager.XmlDataWriter(settings, "settings.xml");
                MessageBox.Show("Settings Saved successfull!");
            }
            else
            {
                MessageBox.Show("Settings File Not Found!");
            }
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            InitSettings();
        }
    }
}
