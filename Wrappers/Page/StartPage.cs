using OpenQA.Selenium;
using Wrappers.Builders;
using Wrappers.Page.Forms;
using Wrappers.SeleniumFramework;
using Wrappers.Utils;

namespace Wrappers.Page
{
    public class StartPage : BasePage
    {
        CartPage cartPage = new CartPage();
        Generator randomGenerator = new Generator();
        RegistrationForm registrationForm = new RegistrationForm();

        private readonly By CartNotEmptyButtonLocator = By.CssSelector("a[title='View your shopping cart']");
        private readonly By HelloUserLocator = By.XPath("//p[contains(text(), 'Hello')]/strong");
        InfoElement CartNotEmptyButton => new InfoElement(CartNotEmptyButtonLocator);
        InfoElement HelloUser => new InfoElement(HelloUserLocator);

        public void OpenPage()
        {
            BrowserUtils.OpenPage("https://practice.automationtesting.in/my-account/");
        }

        public void RegistrationNewUser()
        {
            string UserName = randomGenerator.RandomEmail();
            string Password = randomGenerator.RandomPass();
            var user = new UserBuilder()
            .WithName(UserName)
            .WithPassword(Password)
            .Build();
            registrationForm.RegistrationUser(user);
        }

        public void CleanCart()
        {            
            if (driver.FindElements(CartNotEmptyButtonLocator).Count() != 0)
            {
                CartNotEmptyButton.ClickElement();                
                cartPage.RemoveAllItemsFromCart();                
            }
        }

        public bool IsUserEnter(string useremail)
        {
            string userNameSet = useremail.Split('@')[0];
            string userNameGet = HelloUser.GetText();
            if (userNameSet == userNameGet)
            {
                return true;
            }
            else return false;
        }
    }
}
