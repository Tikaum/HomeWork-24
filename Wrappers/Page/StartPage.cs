using OpenQA.Selenium;
using Wrappers.Utils;

namespace Wrappers.Page
{
    public class StartPage : BasePage
    {
        public void OpenPage()
        {
            BrowserUtils.OpenPage("https://practice.automationtesting.in/my-account/");
        }

        public void GoToShopPage()
        {
            driver.Navigate().GoToUrl("https://practice.automationtesting.in/shop/");
        }
    }
}
