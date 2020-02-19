using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingChallenge.Common
{
    public class Utils
    {
        public SeleniumBase _seleniumBase;
        public Utils(SeleniumBase seleniumBase)
        {
            _seleniumBase = seleniumBase;
        }
        private readonly Random random = new Random();

        public void JavaScriptExecutor(string script)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_seleniumBase.Driver;
            executor.ExecuteScript(script);
        }
        public int GetRandomIndex(int min, int max)
        {
            var index = random.Next(min, max);
            return index;
        }
    }
}
