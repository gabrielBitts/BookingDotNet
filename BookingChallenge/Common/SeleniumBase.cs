using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace BookingChallenge
{
    public class SeleniumBase : IDisposable
    {
        public IWebDriver Driver { get; set; }
        public TestContext TestContext { get; set; }
        private readonly string baseUrl = "https://www.booking.com/";

        protected SeleniumBase()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");
            Driver = new ChromeDriver(chromeOptions);
            Driver.Navigate().GoToUrl(baseUrl);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            var testName = TestContext.TestName;
            Screenshot ss = ((ITakesScreenshot)Driver).GetScreenshot();
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string folderName = Path.Combine(projectPath, "Screenshots");
            Directory.CreateDirectory(folderName);

            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
                ss.SaveAsFile($"{folderName}\\{testName} - {DateTime.Now.ToString("dddd, dd MMMM yyyy HH-mm-ss")}.png", ScreenshotImageFormat.Png);
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
