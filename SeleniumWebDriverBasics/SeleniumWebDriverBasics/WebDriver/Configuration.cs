using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SeleniumWebDriverBasics.WebDriver
{
    public class Configuration
    {
        public static BrowserList.BrowserType currentBrowser;

        public static string GetEnvironmentVar(string var, string defaultValue) => ConfigurationManager.AppSettings[var] ?? defaultValue;
        public static int ElementTimeout => Convert.ToInt32(GetEnvironmentVar("ElementTimeout", ""));
        public static bool Browser => Enum.TryParse(GetEnvironmentVar("Browser", ""), out currentBrowser);
        public static string StartUrl => GetEnvironmentVar("StartUrl", "");
    }
}