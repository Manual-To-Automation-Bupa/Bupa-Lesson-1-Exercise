using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MyNamespace
{
    [Binding]
    public class FailedLoginSteps
    {
        private readonly IWebDriver _driver;

        public FailedLoginSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"I navigate to the ""(.*)"" page")]
        public void GivenINavigateToThePage(string url)
        {
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
            Console.WriteLine(url);
        }

        [When(@"I login with incorrect details")]
        public void WhenILoginWithIncorrectDetails()
        {
            IWebElement usernameField = _driver.FindElement(By.CssSelector("#username"));
            usernameField.SendKeys("wronguser");

            IWebElement passwordField = _driver.FindElement(By.CssSelector("#password"));
            passwordField.SendKeys("Password123");

            IWebElement submitButton = _driver.FindElement(By.CssSelector("#submit"));
            submitButton.Click();
        }

        [Then(@"The login is failed")]
        public void ThenTheLoginIsFailed()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(c => c.FindElement(By.CssSelector("#error")).Displayed);
            _driver.FindElement(By.CssSelector("#error")).Displayed.Should().BeTrue();
        }
    }
}