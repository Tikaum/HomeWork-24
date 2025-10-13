using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wrappers.Utils;

namespace Wrappers.Tests
{
    public class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [TearDown]
        public void Teardown()
        {
            BrowserUtils.Quit();
        }
    }
}
