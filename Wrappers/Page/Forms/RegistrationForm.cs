using OpenQA.Selenium;
using Wrappers.Models;
using Wrappers.SeleniumFramework;

namespace Wrappers.Page.Forms
{
    public class RegistrationForm : BasePage
    {
        private By RegFieldUserLocator = By.Id("reg_email");
        private By PasswordFieldUserLocator = By.Id("reg_password");
        private By RegButtonLocator = By.Name("register");

        public InputElement RegFieldUserInput => new InputElement(RegFieldUserLocator);
        public InputElement PasswordFieldUserInput => new InputElement(PasswordFieldUserLocator);
        public InputElement RegButtonInput => new InputElement(RegButtonLocator);

        public void RegistrationUser(User user)
        {
            RegFieldUserInput.SetUpText(user.UserName);
            PasswordFieldUserInput.SetUpText(user.Password);
            RegButtonInput.ClickElement();            
        }

        public bool RegistrationUserSuccess()
        {            
            return RegButtonInput.IsElementNotDisplayed();
        }


    }
}
