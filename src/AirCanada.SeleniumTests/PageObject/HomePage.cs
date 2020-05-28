using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;

namespace AirCanada.SeleniumTests.PageObject
{
    class HomePage
    {
        private IWebElement language;
        private IWebElement originCity;
        private IWebElement destinationCity;
        private IWebElement searchBtn;
        private IWebElement numberOfPassengerField;
        private ChromeDriver driver;


        public HomePage(ChromeDriver driver)
        {
            language = driver.FindElementById("enCAEdition");
            originCity = driver.FindElementById("origin_R_0");
            destinationCity = driver.FindElementById("destination_R_0");
            searchBtn = driver.FindElementByCssSelector(".search-active-magnet.btn.btn-primary");
            numberOfPassengerField = driver.FindElementById("passengersInputField");
            this.driver = driver;

        }
        internal void SelectLanguage()
        {
            language.Click();
        }

        internal void SelectOrigin(string origin)
        {
            originCity.SendKeys(origin);
            SelectFirstFligthOption();

        }

        private void SelectFirstFligthOption()
        {
            driver.FindElementsByClassName("location-result-city")
                .First()
                .Click();
        }

        internal void SelectDestination(string destination)
        {
            destinationCity.SendKeys(destination);
            SelectFirstFligthOption();
        }

        internal void SelectDates(DateTime checkIn, DateTime checkOut)
        {
            var comboDatePicker = driver.FindElementByCssSelector(".mat-bkmg-selected-dates-wrapper");
            comboDatePicker.Click();
            GetDayElement(checkIn).Click();
            GetDayElement(checkOut).Click();

            var selectDatesBtn = driver.FindElementById("calendarSelectActionBtn");
            selectDatesBtn.Click();

        }

        internal void Search()
        {
            searchBtn.Click();
        }

        private IWebElement GetDayElement(DateTime referenceDate)
        {

            var listOfDays = driver.FindElementsByClassName("table-block");
            int zeroBasedMonth = referenceDate.Month - 1;
            var dayElement = listOfDays
                .Where(day => day.GetAttribute("data-date") == referenceDate.Day.ToString() && day.GetAttribute("data-month") == zeroBasedMonth.ToString())
                .FirstOrDefault();

            var nextArrow = driver.FindElementByClassName("ui-datepicker-next");

            if (dayElement != null)
            {
                return dayElement;
            }
            else
            {
                nextArrow.Click();
                return GetDayElement(referenceDate);
            }
        }

        internal void CheckFlightStatus(string numberFlight)
        {
            var flightStatusField = driver.FindElementById("tab_magnet_title_5");
            flightStatusField.Click();

            var numberOfFlightToBeSearched = driver.FindElementById("status_by_number_flight");
            numberOfFlightToBeSearched.SendKeys(numberFlight);

            var searchStatusByNumberBtn = driver.FindElementById("btnStatusByNumberSearch");
            searchStatusByNumberBtn.Click();

        }

        internal bool HasStatusAvailable()
        {
            return driver.FindElementsByClassName("status-bar")
                .Any();
        }
        internal void SettingNumberOfAdultPassenger(int numberOfAdultPassengers)
        {
            numberOfPassengerField.Click();
            var addAddultBtn = driver.FindElementById("btnAdultCountAdd");
            var zeroCounter = 1;


            for (var i = 1; i <= (numberOfAdultPassengers - zeroCounter); i++)
            {
                addAddultBtn.Click();
            }
            var doneBtn = driver.FindElementById("flightPax_dn");
            doneBtn.Click();
        }

        internal void SettingNumberOfChildPassenger(int numberOfChildPassenger)
        {
            numberOfPassengerField.Click();

            var addChildBtn = driver.FindElementById("btnChildCountAdd");
            var zeroCounter = 1;

            for (var i = 1; i <= (numberOfChildPassenger - zeroCounter); i++)
            {
                addChildBtn.Click();
            }
            var doneBtn = driver.FindElementById("flightPax_dn");
            doneBtn.Click();
        }





    }


}