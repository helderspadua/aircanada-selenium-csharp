using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Linq;

namespace AirCanada.SeleniumTests.Tests
{
    internal class LogInPage
    {
        private ChromeDriver driver;

        private IWebElement signInBtn;
        private IWebElement userNameLocator;
        private IWebElement passwordLocator;
        
        public LogInPage(ChromeDriver driver)
        {
            signInBtn = driver.FindElementById("skip_userNav");
            this.driver = driver;

        }

        internal void AccessLoginArea()
        {
            
            Actions action = new Actions(driver);
            action.MoveToElement(signInBtn).Perform();

            driver.FindElement(By.XPath("//*[@id='userLoginLinksWrapper']/div/ul/li[1]/a")).Click();


            
        }
        internal void InputUserName(string userName)
        {
            userNameLocator = driver.FindElementById("formField_username");
            userNameLocator.SendKeys(userName);
        }

        internal void InputPassword(string password)
        {
            passwordLocator = driver.FindElementById("formField_password");
            passwordLocator.SendKeys(password);
        }

        internal void ClickLogInBtn()
        {
            var loginBtn = driver.FindElementsByCssSelector(".btn.btn-lg.btn-primary");
            var referenceClassName = "btn btn-lg btn-primary btn-action btn-disabled";

            var btnLogIn = loginBtn
                .Where(btn => btn.GetAttribute("class") != "btn btn-lg btn-primary btn-action btn-disabled")
                .FirstOrDefault();

            btnLogIn.Click();

        }

        internal Boolean? ResponseErrorExists()
        {
            var erroMessage = driver.FindElementsById("beResponseError");


            return erroMessage.Any();
        }

        
        internal void ClickJoinAeroplanBtn()
        {
            var joinAeroplanBtn = driver.FindElementById("JoinAeroplanButton");
            joinAeroplanBtn.Click();
        }
    }
}