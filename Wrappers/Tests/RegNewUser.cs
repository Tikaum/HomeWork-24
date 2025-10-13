using Wrappers.Builders;
using Wrappers.Page;
using Wrappers.Page.Forms;
using Wrappers.Utils;

namespace Wrappers.Tests
{
    public class RegNewUser : BaseTest
    {
        StartPage startPage = new StartPage();
        Generator randomGenerator = new Generator();
        RegistrationForm registrationForm = new RegistrationForm();

        [Test]
        public void RegistrationNewUser()
        {
            startPage.OpenPage();
            string UserName = randomGenerator.RandomEmail();
            string Password = randomGenerator.RandomPass();
            var user = new UserBuilder()
            .WithName(UserName)
            .WithPassword(Password)
            .Build();
            registrationForm.RegistrationUser(user);
            registrationForm.RegistrationUserSuccess();
            Assert.That(registrationForm.RegistrationUserSuccess(), Is.True, "Registration failed");
        }        
    }
}
