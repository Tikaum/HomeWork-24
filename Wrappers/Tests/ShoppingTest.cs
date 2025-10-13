using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wrappers.Builders;
using Wrappers.Page;
using Wrappers.Page.Forms;
using Wrappers.Utils;

namespace Wrappers.Tests
{
    public class ShoppingTest
    {
        StartPage startPage = new StartPage();               
        LoginForm loginForm = new LoginForm();

        [Test]
        public void ShoppingBayngTest()
        {
            startPage.OpenPage();
            var user = new UserBuilder()
                .WithName("test_user12345@gmail.com")
                .WithPassword("vszef#@$%#54456456")
                .Build();
            loginForm.LoginUser(user);
            startPage.GoToShopPage();


        }
    }
}
