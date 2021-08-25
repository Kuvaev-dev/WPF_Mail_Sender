using System;
using System.Windows;
using System.Windows.Media;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WriteMailPage writeMailPage = new WriteMailPage();
        SettingsPage settingsPage = new SettingsPage();
        InboxPage inboxPage = new InboxPage();
        OutboxPage outboxPage = new OutboxPage();
        Color mycolor1 = Color.FromRgb(237, 246, 253);
        Color mycolor2 = Color.FromRgb(98, 182, 228);

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = inboxPage;
            InboxBtn.Background = new SolidColorBrush(mycolor1);
        }

        private void SettingBtn_Click(object sender, RoutedEventArgs e)
        {           
            SettingBtn.Background = new SolidColorBrush(mycolor1);
            WriteMailBtn.Background = new SolidColorBrush(mycolor2);
            OutBoxMailBtn.Background = new SolidColorBrush(mycolor2);
            InboxBtn.Background = new SolidColorBrush(mycolor2);

            MainFrame.Navigate(settingsPage);
        }

        private void InboxBtn_Click(object sender, RoutedEventArgs e)
        {
            SettingBtn.Background = new SolidColorBrush(mycolor2);
            WriteMailBtn.Background = new SolidColorBrush(mycolor2);
            OutBoxMailBtn.Background = new SolidColorBrush(mycolor2);
            InboxBtn.Background = new SolidColorBrush(mycolor1);

            MainFrame.Navigate(inboxPage);
        }

        private void WriteMailBtn_Click(object sender, RoutedEventArgs e)
        {
            SettingBtn.Background = new SolidColorBrush(mycolor2);
            WriteMailBtn.Background = new SolidColorBrush(mycolor1);
            OutBoxMailBtn.Background = new SolidColorBrush(mycolor2);
            InboxBtn.Background = new SolidColorBrush(mycolor2);

            MainFrame.Navigate(writeMailPage);
        }

        private void OutBoxMailBtn_Click(object sender, RoutedEventArgs e)
        {
            SettingBtn.Background = new SolidColorBrush(mycolor2);
            WriteMailBtn.Background = new SolidColorBrush(mycolor2);
            OutBoxMailBtn.Background = new SolidColorBrush(mycolor1);
            InboxBtn.Background = new SolidColorBrush(mycolor2);

            MainFrame.Navigate(outboxPage);
        }

        private void QuitBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
