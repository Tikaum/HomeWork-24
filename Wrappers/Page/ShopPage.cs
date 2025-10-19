using OpenQA.Selenium;
using Wrappers.SeleniumFramework;
using static System.String;

namespace Wrappers.Page
{
    public class ShopPage : BasePage
    {
        CartPage cartPage = new CartPage();

        private readonly string ButtonAddToCartLocatorFormat = "//h3[contains(text(),'{0}')]/following::a[text()='Add to basket']";
        private readonly string PriceOfAddedItimToCartLocatorFormat = "//h3[contains(text(),'{0}')]/following::span[@class='price']/span";
        private readonly By CartButtonLocator = By.CssSelector("a[title='View your shopping cart']");
        private readonly By CartEmptyButtonLocator = By.CssSelector("a[title='Start shopping']");
        
        public ButtonElement CartButton => new ButtonElement(CartButtonLocator);

        public void AddItemFromNameToCart(string ItemName)
        {            
            driver.FindElement(By.XPath(Format(ButtonAddToCartLocatorFormat, ItemName))).Click();
        }

        public string GetPriceOfItemInShop (string ItemName)
        {
           return driver.FindElement(By.XPath(Format(PriceOfAddedItimToCartLocatorFormat, ItemName))).Text;
        }

        public void GoToCart()
        {            
            CartButton.ClickElement();
        }        
    }
}
