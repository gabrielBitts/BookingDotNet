using BookingChallenge.Common;
using OpenQA.Selenium;
using System;

namespace BookingChallenge.PageObjects
{
    public static class SearchPageProperties
    {
        public static readonly By placeInput = By.CssSelector("input[type='search']");
        public static readonly By dateSelector = By.CssSelector("div[class*='dates-inner'] > div[class*='date-time']");
        public static readonly By calendar = By.CssSelector(".xp-calendar div[style*='display: block;']");
        public static By Schedule(string date)
        {
            return By.CssSelector($"div[data-bui-ref='calendar-content'] td[data-date='{date}']");
        }
        public static readonly By accommodationOccupancy = By.CssSelector("div[id*='inputs-container'][style*='block;']");
        public static readonly By homeSearchButton = By.CssSelector("button[type='submit'][class*='sb-searchbox']");
        public static readonly By adultsQtt = By.CssSelector("div[class*='field-adults'] span[data-bui-ref*='value']");
        public static readonly By decreaseAdults = By.CssSelector("div[class*='field-adults'] button[class*='subtract-button']");
        public static readonly By increaseAdults = By.CssSelector("div[class*='field-adults'] button[class*='add-button']");
        public static readonly By childrenQtt = By.CssSelector("div[class*='group-children'] span[data-bui-ref*='value']");
        public static readonly By decreaseChildren = By.CssSelector("div[class*='group-children'] button[class*='subtract-button']");
        public static readonly By increaseChildren = By.CssSelector("div[class*='group-children'] button[class*='add-button']");
        public static readonly By roomsQtt = By.CssSelector("div[class*='field-rooms'] span[data-bui-ref*='value']");
        public static readonly By decreaseRooms = By.CssSelector("div[class*='field-rooms'] button[class*='subtract-button']");
        public static readonly By increaseRooms = By.CssSelector("div[class*='field-rooms'] button[class*='add-button']");
    }

    public class SearchPageMethods
    {
        public SeleniumBase selenium;
        public SearchPageMethods(SeleniumBase seleniumBase)
        {
            selenium = seleniumBase;
        }

        public void InsertCity(string city)
        {
            selenium.Driver.FindElement(SearchPageProperties.placeInput).SendKeys(city);
        }
        /// <summary>
        /// Booking maximum total days to stay is 30
        /// </summary>
        /// <param name="time"></param>
        public void StayTime(int time)
        {
            Wait wait = new Wait(selenium);
            var today = DateTime.Today;
            string todayTime = today.ToString("yyyy-MM-dd");
            var stayTime = today.AddDays(time).ToString("yyyy-MM-dd");
            selenium.Driver.FindElement(SearchPageProperties.dateSelector).Click();
            wait.WaitClickable(SearchPageProperties.Schedule(stayTime));
            selenium.Driver.FindElement(SearchPageProperties.Schedule(todayTime)).Click();
            selenium.Driver.FindElement(SearchPageProperties.Schedule(stayTime)).Click();
        }
        /// <summary>
        /// This selector comes with two adults, zero children and one room selected by default (Adults, Children, Rooms)
        /// </summary>
        public void OccupancySelection(int adults, int children, int rooms)
        {
            Utils utils = new Utils(selenium);
            Wait wait = new Wait(selenium);
            utils.JavaScriptExecutor("document.querySelector(\"div[id*='inputs-container'][class*='inputs focussable']\").setAttribute('style', 'display:block;');");
            int totalAdults;
            int totalChildren;
            int totalRooms;
            string adultTotal = selenium.Driver.FindElement(SearchPageProperties.adultsQtt).Text;
            string childrenTotal = selenium.Driver.FindElement(SearchPageProperties.childrenQtt).Text;
            string roomTotal = selenium.Driver.FindElement(SearchPageProperties.roomsQtt).Text;
            totalAdults = Convert.ToInt32(adultTotal);
            totalChildren = Convert.ToInt32(childrenTotal);
            totalRooms = Convert.ToInt32(roomTotal);

            while (totalAdults < adults)
            {
                wait.WaitClickable(SearchPageProperties.increaseAdults);
                selenium.Driver.FindElement(SearchPageProperties.increaseAdults).Click();
                totalAdults++;
            }
            while(totalAdults > adults)
            {
                selenium.Driver.FindElement(SearchPageProperties.decreaseAdults).Click();
                totalAdults--;
            }
            while (totalChildren < children)
            {
                wait.WaitClickable(SearchPageProperties.increaseChildren);
                selenium.Driver.FindElement(SearchPageProperties.increaseChildren).Click();
                totalChildren++;
            }
            while(totalChildren > children) 
            {
                selenium.Driver.FindElement(SearchPageProperties.decreaseChildren).Click();
                totalChildren--;
            }
            while (totalRooms < rooms) { 
                selenium.Driver.FindElement(SearchPageProperties.increaseRooms).Click();
                totalRooms++;
            }
            while(totalRooms > rooms)
            {
                selenium.Driver.FindElement(SearchPageProperties.decreaseRooms).Click();
                totalRooms--;
            }
        }
        public void Search()
        {
            selenium.Driver.FindElement(SearchPageProperties.homeSearchButton).Click();
        }
    }
}
