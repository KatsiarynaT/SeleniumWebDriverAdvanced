using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumWebDriverBasics.WebObjects;

namespace SeleniumWebDriverBasics.WebDriver
{
    public class Browser
    {
        public static IWebDriver Driver { get; private set; }
        private static Browser currentInstance;

        private Browser()
        {
            Driver = BrowserFactory.GetDriver(Configuration.currentBrowser, Configuration.ElementTimeout);
        }

        public static Browser GetInstance() => currentInstance ?? (currentInstance = new Browser());

        public static void NavigateTo()
        {
            IJavaScriptExecutor executor = Driver as IJavaScriptExecutor;
            executor.ExecuteScript("window.location=arguments[0]", Configuration.StartUrl);
        }

        public static void MaximizeWindow()
        {
            Driver.Manage().Window.Maximize();
        }

        public static void Quit()
        {
            Driver = null;
            currentInstance = null;
        }
    }
}