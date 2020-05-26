using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirCanada.SeleniumTests.PageObject
{
    class SearchPage
    {

        private ChromeDriver driver;

        public SearchPage(ChromeDriver driver)
        {
            this.driver = driver;

        }
        internal bool HasAvailableFlights()
        {
            var listOfFlights = driver.FindElementsByTagName("flight-row");

            return listOfFlights.Any();
        }

    }
}
