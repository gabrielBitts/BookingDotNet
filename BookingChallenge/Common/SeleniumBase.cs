using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace BookingChallenge
{
    public class SeleniumBase : IDisposable
    {
        public IWebDriver Driver { get; set; }
        private readonly string baseUrl = "https://www.booking.com/";
        
        protected SeleniumBase()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");
            Driver = new ChromeDriver(chromeOptions);
            Driver.Navigate().GoToUrl(baseUrl);
        }
        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
