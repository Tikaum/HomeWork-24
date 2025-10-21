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
            Assert.Multiple(() =>
            {
                Assert.That(registrationForm.RegistrationUser(user), Is.True, "Registration failed, the Registration button is unavailable");
                Assert.That(registrationForm.RegistrationUserSuccess(), Is.True, "Registration failed, transition to the next page did not occur");
            });
        }        
    }
}
