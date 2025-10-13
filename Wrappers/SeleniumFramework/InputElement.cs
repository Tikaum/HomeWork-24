using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrappers.SeleniumFramework
{
    public class InputElement : BaseElement
    {
        public InputElement(By locator, int timeOutSeconds = 10) : base(locator, timeOutSeconds) { }
    }
}
