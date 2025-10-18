using Wrappers.Builders;
using Wrappers.Page;
using Wrappers.Page.Forms;

namespace Wrappers.Tests
{
    public class ShoppingTest
    {
        StartPage startPage = new StartPage();               
        LoginForm loginForm = new LoginForm();
        ShopPage shopPage = new ShopPage();
        CartPage cartPage = new CartPage();
        RegNewUser regNewUser = new RegNewUser();

        [Test]
        public void ShoppingBuyingTest()
        {
            string itemName = "HTML5 WebApp Develpment";
            startPage.OpenPage();
            //startPage.RegistrationNewUser();
            var user = new UserBuilder()
                .WithName("test_user12345@gmail.com")
                .WithPassword("vszef#@$%#54456456")
                .Build();
            loginForm.LoginUser(user);
            startPage.GoToShopPage();
            shopPage.AddItemFromNameToCart(itemName);
            string price = shopPage.GetPriceOfItemInShop(itemName);
            shopPage.GoToCart();
            cartPage.GetPriceOfItemInCart();
            cartPage.GetItemName();
            Assert.Multiple(() =>
            {
                Assert.That(itemName, Is.EqualTo(cartPage.GetItemName()), "The product names do not match");
                Assert.That(price, Is.EqualTo(cartPage.GetPriceOfItemInCart()), "The prices of the goods do not match");
            });
            cartPage.PurchaseItems();
        }
    }
}
