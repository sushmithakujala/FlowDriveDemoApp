using System.Linq;
using NUnit.Framework;
namespace FlowDrive
{
    [TestFixture]
    class LoginTests:BaseTest
    {
        [SetUp]
        public void Setup()
        {
            //FlowDriveApp.app.Repl();
            FlowDriveApp.app.WaitForElement(c=>c.Marked("Please log in"));
        }

        [Test]
        public void Login_EmptyUsernameAndEmptyPassword_ShouldSeeLoginButtonAsDisabled()
        {
            LoginView loginView = new LoginView();
            loginView.TapLogin();
            Assert.IsTrue(!loginView.LoginButton.Enabled, "Cannot see login button as Disabled");
        }

        [Test]
        public void Login_EmptyUsernameAndValidPassword_ShouldSeeLoginButtonAsDisabled()
        {
            LoginView login = new LoginView();
            login.WithPassword("validPassword").FillDetails();
            login.TapLogin();
            Assert.IsTrue(!login.LoginButton.Enabled, "Cannot see login button as Disabled");
        }
        [Test]
        public void Login_ValidUsernameAndEmptyPassword_ShouldSeeLoginButtonAsDisabled()
        {
            LoginView login = new LoginView();
            login.WithUsername("validEmail@gmail.com").FillDetails();
            login.TapLogin();
            Assert.IsTrue(!login.LoginButton.Enabled, "Cannot see login button as Disabled");
        }
        [Test]
        public void Login_InValidUsernameAndInvalidPassword_ShouldSeeLoginButtonAsDisabled()
        {
            LoginView login = new LoginView();
            login.WithUsername("invalidusername").WithPassword("InvalidPassword").FillDetails();
            login.TapLogin();
            FlowDriveApp.app.WaitForElement(c => c.Id("alertTitle"));
            var alertMessageElement = FlowDriveApp.app.Query(c => c.Marked("Invalid e-mail address"));
            Assert.IsTrue(alertMessageElement.Any(), "Cannot see alert message 'Invalid e-mail address'");
        }
        [Test]
        public void Login_TypeUnregisteredUsername_ShouldSeeErrorMesssage()
        {
            LoginView login = new LoginView();
            login.WithUsername("Unregistered@email.com").WithPassword("validPassword").FillDetails();
            login.TapLogin();
            FlowDriveApp.app.WaitForElement(c => c.Id("alertTitle"));
            var alertMessageElement = FlowDriveApp.app.Query(c => c.Marked("User name/password not found. Are you registered?"));
            Assert.IsTrue(alertMessageElement.Any(), "Cannot see alert message 'User name/password not found. Are you registered?'");
        }
    }
}
