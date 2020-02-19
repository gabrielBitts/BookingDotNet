using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingChallenge.Common
{
    public class Utils
    {
        private IWebDriver Driver { get; set; }
        private Random random = new Random();

        public void JavaScriptExecutor(string script)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript(script);
        }
        public int GetRandomIndex(int min, int max)
        {
            var index = random.Next(min, max);
            return index;
        }
    }
}
