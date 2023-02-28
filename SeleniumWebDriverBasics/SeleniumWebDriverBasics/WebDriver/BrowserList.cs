using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverBasics.WebDriver
{
    public abstract class BrowserList
    {
        public enum BrowserType
        {
            Firefox,
            Chrome,
            remoteFirefox,
            remoteChrome
        }
    }
}
