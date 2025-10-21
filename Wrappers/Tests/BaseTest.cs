using Wrappers.Page;
using Wrappers.Utils;

namespace Wrappers.Tests
{
    public class BaseTest
    {
        StartPage startPage = new StartPage();

        [SetUp]
        public void Setup()
        {
            startPage.OpenPage();
        }

        [TearDown]
        public void Teardown()
        {
            BrowserUtils.Quit();
        }
    }
}
