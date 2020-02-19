using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace BookingChallenge
{
    public class SeleniumBase : IDisposable
    {
        private IWebDriver Driver { get; set; }
        private readonly string baseUrl = "https://www.booking.com/index.html?label=gen173nr-1DCAEoggI46AdIM1gEaCCIAQGYAS24ARfIAQzYAQPoAQGIAgGoAgO4AqGosvIFwAIB&sid" +
                                          "=a5dd0c2ab029f6e45418c16c555f3b6e&lang=en-us&sb_price_type=total&soz=1&lang_click=top;cdl=pt-br;lang_changed=1";
        
        protected SeleniumBase()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");
            Driver = new ChromeDriver(chromeOptions);
        }
        protected void BookingNavigate()
        {
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
