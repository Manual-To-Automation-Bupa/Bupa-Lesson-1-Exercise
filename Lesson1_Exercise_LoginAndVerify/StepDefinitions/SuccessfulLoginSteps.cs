using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Lesson1_Exercise_LoginAndVerify.StepDefinitions
{
    [Binding]
    public class SuccessfulLoginSteps
    {
        private readonly IWebDriver _driver;

        public SuccessfulLoginSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"I am on ""(.*)""")]
        public void GivenIAmOnBStackDemo(string url)
        {
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
        }

        [When(@"I login with the correct username ""(.*)"" using the correct password ""(.*)""")]
        public void WhenIEnterCorrectLoginDetails(string username, string password)
        {
            IWebElement usernameField = _driver.FindElement(By.Id("username"));
            usernameField.SendKeys(username);

            IWebElement passwordField = _driver.FindElement(By.Id("password"));
            passwordField.SendKeys(password);

            IWebElement loginButton = _driver.FindElement(By.Id("submit"));
            loginButton.Click();
        }

        [Then(@"I should be successfully logged in")]
        public void ThenLoginSuccessful()
        {
            Assert.IsTrue(_driver.FindElement(By.ClassName("post-title")).Displayed);
            Assert.AreEqual(_driver.FindElement(By.ClassName("post-title")).Text, "Logged In Successfully");
            Assert.IsTrue(_driver.Url.Equals("https://practicetestautomation.com/logged-in-successfully/"));
        }
    }
}
