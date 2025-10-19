﻿using OpenQA.Selenium;

namespace Wrappers.SeleniumFramework
{
    public class InputElement : BaseElement
    {
        public InputElement(By locator, int timeOutSeconds = 10) : base(locator, timeOutSeconds) { }
    }
}
