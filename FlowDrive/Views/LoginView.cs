using System;
using System.Linq;
using Xamarin.UITest.Queries;

namespace FlowDrive
{
    public class LoginView
    {
        public Func<AppQuery, AppQuery> _usernameTexBoxQuery = c => c.Id("edit_text_email");
        public Func<AppQuery, AppQuery> _passwordTextBoxQuery = c => c.Id("edit_text_password");
        public Func<AppQuery, AppQuery> _loginButtonQuery = c => c.Id("btn_login");
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginView WithUsername(string username)
        {
            Username = username;
            return this;
        }
        public LoginView WithPassword(string password)
        {
            Password = password;
            return this;
        }

        public void FillDetails()
        {
            if (!string.IsNullOrEmpty(Username))
            {
                FlowDriveApp.app.ClearText(_usernameTexBoxQuery);
                FlowDriveApp.app.EnterText(_usernameTexBoxQuery, Username);
            }
            if (!string.IsNullOrEmpty(Password))
            {
                FlowDriveApp.app.ClearText(_passwordTextBoxQuery);
                FlowDriveApp.app.EnterText(_passwordTextBoxQuery, Password);
            }
        }
        public void TapLogin()
        {
            FlowDriveApp.app.Tap(_loginButtonQuery);
        }
        public AppResult LoginButton
        {
            get
            {
                return FlowDriveApp.app.Query(_loginButtonQuery).FirstOrDefault();
            }
        }
    }
}
