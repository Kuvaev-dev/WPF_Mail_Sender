namespace MailSender
{
    public class Settings
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _smtp;
        public string Smtp
        {
            get { return _smtp; }
            set { _smtp = value; }
        }

        private int _port;
        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }
    }
}
