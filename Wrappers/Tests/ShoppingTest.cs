using Wrappers.Builders;
using Wrappers.Page;
using Wrappers.Page.Forms;

namespace Wrappers.Tests
{
    public class ShoppingTest:BaseTest
    {
        StartPage startPage = new StartPage();               
        LoginForm loginForm = new LoginForm();
        ShopPage shopPage = new ShopPage();
        CartPage cartPage = new CartPage();
        RegNewUser regNewUser = new RegNewUser();
        OrderForm orderForm = new OrderForm();
        OrderReceivedPage orderReceivedPage = new OrderReceivedPage();

        [Test]
        public void ShoppingBuyingTest()
        {
            string userEmail = "test_user12345@gmail.com";
            string userPass = "vszef#@$%#54456456";
            string itemName = "HTML5 WebApp Develpment";
            string usersWord = "Abrakadabra";
            string usersDigits = "123456";
            string textOfOrderReceived = "Thank you. Your order has been received.";
                        
            var user = new UserBuilder()
                .WithName(userEmail)
                .WithPassword(userPass)
                .Build();
            loginForm.LoginUser(user);
            Assert.That(startPage.IsUserEnter(userEmail), Is.True, "The user was unable to log in.");
            startPage.CleanCart();
            startPage.GoToShopPage();
            Assert.That(shopPage.IsUserOnShopPage, Is.True, "The user did not go to the shop page");
            shopPage.AddItemFromNameToCart(itemName);
            string price = shopPage.GetPriceOfItemInShop(itemName);
            shopPage.GoToCart();
            Assert.That(cartPage.IsUserOnCartPage, Is.True, "The user did not go to the cart page");
            cartPage.GetPriceOfProductInCart(itemName);
            cartPage.GetProductNameInCart(itemName);
            Assert.Multiple(() =>
            {
                Assert.That(itemName, Is.EqualTo(cartPage.GetProductNameInCart(itemName)), "The product names do not match");
                Assert.That(price, Is.EqualTo(cartPage.GetPriceOfProductInCart(itemName)), "The prices of the goods do not match");
            });
            cartPage.PurchaseItems();
            Assert.That(orderForm.IsUserOnOrderPage, Is.True, "The user did not go to the order page");
            user = new UserBuilder()
                .WithFirstName(usersWord)
                .WithLasttName(usersWord)
                .WithPhone(usersDigits)
                .WithAdress1(usersWord)
                .WithCity(usersWord)
                .WithPostcod(usersDigits).BuildForOrder();
            orderForm.FillingOutOrder(user);
            orderForm.GetProductNameInOrder();
            orderForm.GetPriceOfProductInOrder();
            Assert.Multiple(() =>
            {
                Assert.That(orderForm.GetProductNameInOrder(), Does.Contain(itemName), "The product name in order do not match");
                Assert.That(price, Is.EqualTo(orderForm.GetPriceOfProductInOrder()), "The price in order of the product do not match");
            });
            orderForm.PlaceOrder();
            Assert.That(orderReceivedPage.IsUserOnOrderReceivedPage, Is.True, "The user did not go to the order received page");
            var infoOfReceived = orderReceivedPage.GetOrderReceivedInfo();
            Assert.Multiple(() =>
            {
                Assert.That(infoOfReceived[0].Text, Is.EqualTo(textOfOrderReceived), "The text on the order confirmation page does not match");
                Assert.That(infoOfReceived[0].Name, Is.EqualTo(itemName), "The product name do not match");
                Assert.That(infoOfReceived[0].Price, Is.EqualTo(price), "The price of the product do not match");
                Assert.That(infoOfReceived[0].Email, Is.EqualTo(userEmail), "The e-mail of the user do not match");
                Assert.That(infoOfReceived[0].Telephone, Is.EqualTo(usersDigits), "The telephone of the user do not match");
            });
        }
    }
}
