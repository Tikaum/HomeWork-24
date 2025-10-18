using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrappers.Page.Forms
{
    public class CheckoutForm:BasePage
    {
        private By FirstNameLocator = By.Id("billing_first_name");
        private By LastNameLocator = By.Id("billing_last_name");
        private By PhoneLocator = By.Id("billing_phone");
        private By Adress1Locator = By.Id("billing_address_1");
        private By CityLocator = By.Id("billing_city_field");
        private By PostcodLocator = By.Id("billing_postcode_field");
        


    }
}
