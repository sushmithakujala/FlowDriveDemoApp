using System;
using System.Linq;
using Xamarin.UITest.Queries;
namespace FlowDrive
{
    public class UserRegistrationView
    {
        public Func<AppQuery, AppQuery> _firsnameTexBoxQuery = c => c.Id("edit_text_first_name");
        public Func<AppQuery, AppQuery> _surnameTextQuery = c => c.Id("edit_text_surname");
        public Func<AppQuery, AppQuery> _emailTextBoxQuery = c => c.Id("edit_text_email");
        public Func<AppQuery, AppQuery> _dateOfBirthQuery = c => c.Id("edit_text_date_of_birth");
        public Func<AppQuery, AppQuery> _companyQuery = c => c.Id("edit_text_company_name");
        public Func<AppQuery, AppQuery> _postcode = c => c.Id("edit_text_postcode");
        public Func<AppQuery, AppQuery> _passwordQuery = c => c.Id("edit_text_password");
        public Func<AppQuery, AppQuery> _confirmPasswordQuery = c => c.Id("edit_text_confirm_password");
        public Func<AppQuery, AppQuery> _submitQuery = c => c.Id("button_register");

        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Postcode { get; set; }

        public UserRegistrationView WithFirstname(string firstname)
        {
            this.Firstname = firstname;
            return this;
        }
        public UserRegistrationView WithSurname(string surname)
        {
            Surname = surname;
            return this;
        }
        public UserRegistrationView WithEmail(string email)
        {
            Email = email;
            return this;
        }
        public UserRegistrationView WithCompany(string company)
        {
            Company = company;
            return this;
        }
        public UserRegistrationView WithPassword(string password)
        {
            Password = password;
            return this;
        }
        public UserRegistrationView WithConfirmPassword(string confirmPassword)
        {
            ConfirmPassword = confirmPassword;
            return this;
        }
        public UserRegistrationView WithPostcode(string postcode)
        {
            Postcode = postcode;
            return this;
        }
        public void FillDetails()
        {
            if (!string.IsNullOrEmpty(Firstname))
            {
                FlowDriveApp.app.EnterText(_firsnameTexBoxQuery, Firstname);
            }
            if (!string.IsNullOrEmpty(Surname))
            {
                FlowDriveApp.app.EnterText(_surnameTextQuery, Surname);
            }
            if (!string.IsNullOrEmpty(Email))
            {
                FlowDriveApp.app.EnterText(_emailTextBoxQuery, Email);
            }
            if (!string.IsNullOrEmpty(Postcode))
            {
                FlowDriveApp.app.EnterText(_postcode, Postcode);
            }
            if (!string.IsNullOrEmpty(Company))
            {
                FlowDriveApp.app.EnterText(_companyQuery, Company);
            }
            if (!string.IsNullOrEmpty(Password))
            {
                FlowDriveApp.app.DismissKeyboard();
                FlowDriveApp.app.Tap(_passwordQuery);
                FlowDriveApp.app.EnterText(_passwordQuery, Password);
            }
            if (!string.IsNullOrEmpty(ConfirmPassword))
            {
                FlowDriveApp.app.DismissKeyboard();
                FlowDriveApp.app.Tap(_confirmPasswordQuery);
                FlowDriveApp.app.EnterText(_confirmPasswordQuery, ConfirmPassword);
            }
        }
        public void TapSubmit()
        {
            FlowDriveApp.app.Tap(_submitQuery);
        }
        public AppResult SubmitButton
        {
            get
            {
                return FlowDriveApp.app.Query(_submitQuery).FirstOrDefault();
            }
        }
    }
}
