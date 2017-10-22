using NUnit.Framework;
using System;
using Xamarin.UITest.Queries;
namespace FlowDrive
{
    [TestFixture]
    public class UserRegistrationTests : BaseTest
    {
        [SetUp]
        public void setup()
        {
            FlowDriveApp.app.WaitForElement(c => c.Id("text_view_create_account"));
            Func<AppQuery, AppQuery> createAccountQuery = c => c.Id("text_view_create_account");
            FlowDriveApp.app.Tap(createAccountQuery);
        }
        [Test]
        public void UserRegistration_FillAllDetailsExceptDateOfBirth_ShouldSeeSubmitButtonAsDisabled()
        {
            UserRegistrationView userRegistration = new UserRegistrationView();
            FlowDriveApp.app.WaitForElement(userRegistration._firsnameTexBoxQuery);
            userRegistration
                .WithFirstname("firstname")
                .WithSurname("surname")
                .WithEmail("email@email.com")
                .WithCompany("companyname")
                .WithPassword("password")
                .WithPostcode("ls6 2hl")
                .WithConfirmPassword("password")
                .FillDetails();

            //Checking if Submit button is disabled 
            Assert.IsTrue(!userRegistration.SubmitButton.Enabled ,"Failed: Cannot see submit button as Disabled");
        }

        [TearDown]
        public void TearDown()
        {
        }

        //Can do many possible scenarios using the above model with ease.
    }
}