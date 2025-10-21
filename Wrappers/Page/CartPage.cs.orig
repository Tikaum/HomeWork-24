using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Wrappers.SeleniumFramework;
using static System.String;

namespace Wrappers.Page
{
    public class CartPage:BasePage
    {
        private string ProductNameLocatorFormat = "//a[contains(text(),'{0}')]";
        private string ProductPriceLocatorFormat = "//a[contains(text(),'{0}')]/following::td[@class=('product-price')]/span";
        private By RemoveAllProductsLocator = By.CssSelector(".remove");     
        private string RemoveSpecificProductLocatorFormat = "//td/a[text()='{0}']/parent::td/preceding-sibling::td/a[@title='Remove this item']";
        private By PurchaseItemLocator = By.XPath("//a[contains(text(), 'Proceed to Checkout')]");
        private By IsCartPageLocator = By.XPath("//h2[text()='Basket Totals']");

        public ButtonElement PurchaseItem => new ButtonElement(PurchaseItemLocator);        

        public string GetProductNameInCart(string ItemName)
        {
            return driver.FindElement(By.XPath(Format(ProductNameLocatorFormat, ItemName))).Text;
        }

        public string GetPriceOfProductInCart(string ItemName)
        {
            return driver.FindElement(By.XPath(Format(ProductPriceLocatorFormat, ItemName))).Text;
        }

        public void RemoveAllItemsFromCart()
        {
            int x = driver.FindElements(RemoveAllProductsLocator).Count();            
            while (x != 0)
            {
                driver.FindElements(RemoveAllProductsLocator)[0].Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(d => d.FindElements(RemoveAllProductsLocator).Count < x);
                x = driver.FindElements(RemoveAllProductsLocator).Count();
            }
        }

        public void RemoveSpecificItemFromCart(string ItemName)
        {
            driver.FindElement(By.XPath(Format(RemoveSpecificProductLocatorFormat, ItemName))).Click();
        }

        public void PurchaseItemsClick()
        {
            PurchaseItem.ClickElement();
        }

        public bool IsUserOnCartPage()
        {
            if (driver.FindElements(IsCartPageLocator).Count() != 0)
            {
                return true;
            }
            else return false;
        }
    }
}
