using OpenQA.Selenium;
using SeleniumWebDriverBasics.WebDriver;
using SeleniumWebDriverBasics.WebObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverBasics.Tests
{
    public abstract class BaseTest
    {
        private readonly HomePage homePage = new HomePage();
        private readonly LoginPage loginPage = new LoginPage();
        private readonly EmailPage emailPage = new EmailPage();
        protected string login = "katetest.selenium@yandex.com";
        protected string password = "testSelenium001";

        [SetUp]
        public void TestSetup()
        {
            Browser.GetInstance();
            Browser.NavigateTo();
            Browser.MaximizeWindow();

            homePage.ClickOnLoginButton();
            loginPage.Login(login, password);
            homePage.WaitForComposeLinkIsVisible();
        }

        [TearDown]
        public void CleanUp()
        {
            Browser.Driver.Close();
            Browser.Driver.Quit();
            Browser.Quit();
        }
    }
}
