using OpenQA.Selenium;
using Wrappers.Utils;

namespace Wrappers.Page
{
    public abstract class BasePage
    {
        public IWebDriver driver = BrowserUtils.Driver;

        private By ShopPageLocator = By.XPath("//a[text()='Shop']");

        public void GoToShopPage()
        {
            driver.FindElement(ShopPageLocator).Click();
        }
    }
}
