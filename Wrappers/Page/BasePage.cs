﻿using OpenQA.Selenium;
using Wrappers.SeleniumFramework;
using Wrappers.Utils;

namespace Wrappers.Page
{
    public abstract class BasePage
    {
        public IWebDriver driver = BrowserUtils.Driver;

        private By ShopPageLocator = By.XPath("//a[text()='Shop']");
        public ButtonElement ShopPageButton => new ButtonElement(ShopPageLocator);

        public void GoToShopPage()
        {
            driver.FindElement(ShopPageLocator).Click();
        }
    }
}
