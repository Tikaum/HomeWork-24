using OpenQA.Selenium;
using Wrappers.Models;
using Wrappers.SeleniumFramework;

namespace Wrappers.Page.Forms
{
    public class OrderForm:BasePage
    {
        private By FirstNameLocator = By.Id("billing_first_name");
        private By LastNameLocator = By.Id("billing_last_name");
        private By PhoneLocator = By.Id("billing_phone");
        private By Adress1Locator = By.Id("billing_address_1");
        private By CityLocator = By.Id("billing_city");
        private By PostcodLocator = By.Id("billing_postcode");
        private By PlaceOrderButtonLocator = By.Id("place_order");

        public InputElement FirstName => new InputElement(FirstNameLocator);
        public InputElement LastName => new InputElement(LastNameLocator);
        public InputElement Phone => new InputElement(PhoneLocator);
        public InputElement Adress1 => new InputElement(Adress1Locator);
        public InputElement City => new InputElement(CityLocator);
        public InputElement Postcod => new InputElement(PostcodLocator);
        public ButtonElement PlaceOrderButton => new ButtonElement(PlaceOrderButtonLocator);

        public void FillingOutOrder(User user)
        {
            FirstName.SetUpText(user.FirstName);
            LastName.SetUpText(user.LastName);
            Phone.SetUpText(user.Phone);
            Adress1.SetUpText(user.Adress1);
            City.SetUpTextWithOutClear(user.City);
            Postcod.SetUpText(user.Postcod);
            PlaceOrderButton.ClickIfEnabled();
        }


    }
}
