using OpenQA.Selenium;
using Wrappers.Utils;

namespace Wrappers.Page
{
    public abstract class BasePage
    {
        public IWebDriver driver = BrowserUtils.Driver;
    }
}
