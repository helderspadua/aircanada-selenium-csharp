using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirCanada.SeleniumTests.PageObject
{
    class AeroplanPage
    {
        private ChromeDriver driver;
        private IWebElement continueBtn;

        public AeroplanPage(ChromeDriver driver)
        {
            this.driver = driver;
            continueBtn = driver.FindElementById("registrationContinue");

        }

        internal void InputAccountInformation(String newUserName, String newPassword)
        {
            var inputNewUserNameForSubscription = driver.FindElementById("NNE_emailAddress");
            var inputNewPasswordForSubscription = driver.FindElementById("NNE_password");
            var acceptTermsAndConditions = driver.FindElementByClassName("tnc-checkbox-label-plaintext");
            

            inputNewUserNameForSubscription.SendKeys(newUserName);
            inputNewPasswordForSubscription.SendKeys(newPassword);

            acceptTermsAndConditions.Click();
            
            continueBtn.Click();
            
        }

        internal void InputPersonalInformation(String referenceTitle, String referenceFirstName, String referenceMiddleName, String referenceLastName, String referenceDayOfBirth,
                                               String referenceMonthOfBirth, String referenceYearOfBirth, String referenceUserGender) {
            var title = driver.FindElementById("NNE_title");
            var selectElement = new SelectElement(title);
            selectElement.SelectByValue(referenceTitle);

            var firstName = driver.FindElementById("NNE_firstName");
            var middleName = driver.FindElementById("NNE_middleName");
            var lastName = driver.FindElementById("NNE_lastName");

            firstName.SendKeys(referenceFirstName);
            middleName.SendKeys(referenceMiddleName);
            lastName.SendKeys(referenceLastName);

            var dayOfUserBirth = driver.FindElementById("NNE_birthDate");
            selectElement = new SelectElement(dayOfUserBirth);
            selectElement.SelectByValue(referenceDayOfBirth);

            var monthOfUserBirth = driver.FindElementById("NNE_birthMonth");
            selectElement = new SelectElement(monthOfUserBirth);
            selectElement.SelectByValue(referenceMonthOfBirth);

            var yearOfUserBirth = driver.FindElementById("NNE_birthYear");
            selectElement = new SelectElement(yearOfUserBirth);
            selectElement.SelectByValue(referenceYearOfBirth);

            var userGender = driver.FindElementById("NNE_gender");
            selectElement = new SelectElement(userGender);
            selectElement.SelectByText(referenceUserGender);

            continueBtn.Click();
        }

        internal void IputContactInformation(String referenceAddress, String referencePhoneNumber)
        {
            var address = driver.FindElementById("NNE_streetName");
            address.SendKeys(referenceAddress);
            address.SendKeys(Keys.Tab);

            var phoneNumber = driver.FindElementById("NNE_contactNumber");
            phoneNumber.SendKeys(referencePhoneNumber);
            
        }
    }
}
