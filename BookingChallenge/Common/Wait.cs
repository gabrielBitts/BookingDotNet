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
        public SeleniumBase _seleniumBase;
        public Wait(SeleniumBase seleniumBase)
        {
            _seleniumBase = seleniumBase;
        }

        public void WaitVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(_seleniumBase.Driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }
        public void WaitClickable(By locator)
        {
            WebDriverWait wait = new WebDriverWait(_seleniumBase.Driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
        public void WaitInvisibility(By locator)
        {
            WebDriverWait wait = new WebDriverWait(_seleniumBase.Driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
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
