using AirCanada.SeleniumTests.Driver;
using AirCanada.SeleniumTests.PageObject;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace AirCanada.SeleniumTests.Tests
{
    class HomePageTests
    {
        private ChromeDriver driver;
        private HomePage homePage;

        [SetUp]
        public void SetUp()
        {
            this.driver = DriverFactory.BuildDriver();
            homePage = new HomePage(driver);
            homePage.SelectLanguage();
        }
        [Test]
        [TestCase("YYZ", "LGA", 2, 1)]
        public void WhenSearchingFlightsShouldSeeAvailableFlights(string origin, string destination, int numberOfAdultPassengers, int numberOfChildPassengers)
        {

            var searchPage = new SearchPage(driver);

            homePage.SelectOrigin(origin);
            homePage.SelectDestination(destination);
            homePage.SettingNumberOfAdultPassenger(numberOfAdultPassengers);
            homePage.SettingNumberOfChildPassenger(numberOfChildPassengers);
            homePage.SelectDates(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(30));
            homePage.Search();

            searchPage.HasAvailableFlights().Should().BeTrue();
        }

        [Test]
        [TestCase("test@test.com", "1234567!")]
        public void GivenInvalidUserandWrongPassword_WhenLogIn_ThenShouldFail(String userName, String password)
        {

            var logInPage = new LogInPage(driver);

            logInPage.AccessLoginArea();
            logInPage.InputUserName(userName);
            logInPage.InputPassword(password);
            logInPage.ClickLogInBtn();

            logInPage.ResponseErrorExists().Should().BeTrue();


        }

        [Test]
        [TestCase("helderdf@gmail.com", "Test12345!", "Dr", "Helder", "Silva de", "Padua", "08", "11", "1988", "Male", "2 Atlas Avenue", "6476871498")]
        public void SubscribingAtAeroplanSystem(String newUserName, String newPassword, String title, String firstName, String middleName, String lastName,
                                                String dayOfBirth, String monthOfBirth, String yearOfBirth, String userGender, String address, String phoneNumber)
        {
            var logInPage = new LogInPage(driver);


            logInPage.AccessLoginArea();
            logInPage.ClickJoinAeroplanBtn();
            var aeroplanPage = new AeroplanPage(driver);
            aeroplanPage.InputAccountInformation(newUserName, newPassword);
            aeroplanPage.InputPersonalInformation(title, firstName, middleName, lastName, dayOfBirth, monthOfBirth, yearOfBirth, userGender);
            aeroplanPage.IputContactInformation(address, phoneNumber);

        }
        [Test]
        [TestCase("702")]
        public void GivenFligthNumber_WhenCheckingTheFligthStatus_ThenShouldSeeFligthStatus
            (String numberFlight) {

            homePage.CheckFlightStatus(numberFlight);

            homePage.HasStatusAvailable().Should().BeTrue();
        }


        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}