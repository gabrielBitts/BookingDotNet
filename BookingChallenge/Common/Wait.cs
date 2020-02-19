using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BookingChallenge.Common
{
    public class Wait
    {
        private IWebDriver Driver { get; set; }

        public void WaitVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }
        public void WaitClicable(By locator)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
        public void WaitSeconds(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }
        public void WaitMiliseconds(int miliseconds)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(miliseconds));
        }
    }
}
