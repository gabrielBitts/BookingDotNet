using BookingChallenge.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookingChallenge.Tests
{
    [TestClass]
    public class Search : SeleniumBase
    {
        [TestMethod]
        [TestCategory("Booking - Rating Filter")]
        public void FindFiveStarsHotel()
        {
            SearchPageMethods searchMethods = new SearchPageMethods(this);
            ResultPageMethods resultPageMethods = new ResultPageMethods(this);

            searchMethods.InsertCity("Limerick");
            searchMethods.StayTime(30);
            searchMethods.OccupancySelection(2, 0, 1);
            searchMethods.Search();
            resultPageMethods.SortByStars(1);
            Assert.IsTrue(Driver.PageSource.Contains("The Savoy Hotel"));
        }

        [TestMethod]
        [TestCategory("Booking - Rating Filter")]
        public void DontFindFiveStarsHotel()
        {
            SearchPageMethods searchMethods = new SearchPageMethods(this);
            ResultPageMethods resultPageMethods = new ResultPageMethods(this);

            searchMethods.InsertCity("Limerick");
            searchMethods.StayTime(30);
            searchMethods.OccupancySelection(2, 0, 1);
            searchMethods.Search();
            resultPageMethods.SortByStars(1);
            Assert.IsFalse(Driver.PageSource.Contains("George Limerick Hotel"));
        }

        [TestMethod]
        [TestCategory("Booking - Sauna Filter")]
        public void FindHotelThatHasSauna()
        {
            SearchPageMethods searchMethods = new SearchPageMethods(this);
            ResultPageMethods resultPageMethods = new ResultPageMethods(this);

            searchMethods.InsertCity("Limerick");
            searchMethods.StayTime(30);
            searchMethods.OccupancySelection(2, 0, 1);
            searchMethods.Search();
            resultPageMethods.FilterHotelsThatHaveSauna();
            Assert.IsTrue(Driver.PageSource.Contains("Bunratty Castle"));
        }

        [TestMethod]
        [TestCategory("Booking - Sauna Filter")]
        public void DontFindTheHotelThatHasSauna()
        {
            SearchPageMethods searchMethods = new SearchPageMethods(this);
            ResultPageMethods resultPageMethods = new ResultPageMethods(this);

            searchMethods.InsertCity("Limerick");
            searchMethods.StayTime(30);
            searchMethods.OccupancySelection(2, 0, 1);
            searchMethods.Search();
            resultPageMethods.FilterHotelsThatHaveSauna();
            Assert.IsFalse(Driver.PageSource.Contains("George Limerick Hotel"));
        }
    }
}
