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
        private By RemoveProductsLocator = By.CssSelector(".remove");     
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

        public void RemoveItemsFromCart()
        {
            int x = driver.FindElements(RemoveProductsLocator).Count();            
            while (x != 0)
            {
                driver.FindElements(RemoveProductsLocator)[0].Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(d => d.FindElements(RemoveProductsLocator).Count < x);
                x = driver.FindElements(RemoveProductsLocator).Count();
            }
        }

        public void PurchaseItems()
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
