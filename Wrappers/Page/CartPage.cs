using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Wrappers.SeleniumFramework;

namespace Wrappers.Page
{
    public class CartPage:BasePage
    {
        private By ProductNameLocator = By.XPath("//td[@class=('product-name')]/a");
        private By ProductPriceLocator = By.XPath("//td[@class=('product-price')]/span");
        private By RemoveProductsLocator = By.CssSelector(".remove");     
        private By PurchaseItemLocator = By.XPath("//a[contains(text(), 'Proceed to Checkout')]");        
        public InfoElement ProductName => new InfoElement(ProductNameLocator);
        public InfoElement ProductPrice => new InfoElement(ProductPriceLocator);
        public ButtonElement PurchaseItem => new ButtonElement(PurchaseItemLocator);

        public string GetProductNameInCart()
        {
            return ProductName.GetText();             
        }

        public string GetPriceOfProductInCart()
        {
            return ProductPrice.GetText();
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




    }
}
