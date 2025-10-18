using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Wrappers.Utils
{
    public class BrowserUtils
    {
        private static IWebDriver driver;

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    driver = Init();
                }
                return driver;
            }
        }

        private static IWebDriver Init()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            var driver = new ChromeDriver(options);
            // Устанавливаем неявное ожидание в 10 секунд
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            return driver;
        }

        public static void OpenPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void Quit()
        {
            driver?.Quit();
            driver = null;
        }
    }
}
