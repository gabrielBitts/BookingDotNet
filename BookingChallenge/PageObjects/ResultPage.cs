using BookingChallenge.Common;
using OpenQA.Selenium;

namespace BookingChallenge.PageObjects
{
    public class ResultPageProperties
    {
        public static readonly By sauna = By.CssSelector("a[data-id='popular_activities-10']");
        public static readonly By sorting = By.CssSelector("#sort_by li:nth-child(5) > a");
        public static readonly By loadingBody = By.CssSelector("div[class*='container'] div[class*='loading']");
        public static readonly By fiveStars = By.CssSelector("span[class*='title-badges'] i[title*='5-star']");
        public static By Stars(int starsArray) 
        { 
            return By.CssSelector($".sort_option_sublist li:nth-child({starsArray})"); 
        }
    }
    public class ResultPageMethods
    {
        public SeleniumBase seleniumBase;

        public ResultPageMethods(SeleniumBase _seleniumBase)
        {
            seleniumBase = _seleniumBase;
        }

        /// <summary>
        /// Sorting by stars, starsArray "1" sorts by 5 to 1 and starsArray "2" sorts by 1 to 5
        /// </summary>
        /// <param name="starsArray"></param>
        public void SortByStars(int starsArray)
        {
            Wait wait = new Wait(seleniumBase);
            wait.WaitClickable(ResultPageProperties.sorting);
            seleniumBase.Driver.FindElement(ResultPageProperties.sorting).Click();
            wait.WaitClickable(ResultPageProperties.Stars(starsArray));
            seleniumBase.Driver.FindElement(ResultPageProperties.Stars(starsArray)).Click();
            wait.WaitVisible(ResultPageProperties.loadingBody);
            wait.WaitInvisibility(ResultPageProperties.loadingBody);
        }
        public void FilterHotelsThatHaveSauna()
        {
            Wait wait = new Wait(seleniumBase);
            wait.WaitClickable(ResultPageProperties.sauna);
            seleniumBase.Driver.FindElement(ResultPageProperties.sauna).Click();
            wait.WaitVisible(ResultPageProperties.loadingBody);
            wait.WaitInvisibility(ResultPageProperties.loadingBody);
        }
    }
}
