using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirCanada.SeleniumTests.Driver
{
    class DriverFactory
    {
        public static ChromeDriver BuildDriver()
        {
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.aircanada.com/ca/en/aco/home.html#/");

            return driver;
        }
    }
}
