using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Ecommerce.Ui.Tests.Util
{
    /// <summary>
    ///     Configuração do driver para rodar cada teste no Chome e Firefox
    /// </summary>
    public class WebDriver
    {
        private IWebDriver _currentWebDriver;

        public IWebDriver Current
        {
            get
            {
                if (_currentWebDriver != null)
                    return _currentWebDriver;

                IWebDriver desiredCapabilities;

                switch (BrowserConfig)
                {
                    case "Chrome":
                        desiredCapabilities = new ChromeDriver();
                        break;
                    case "Firefox":
                        desiredCapabilities = new FirefoxDriver();
                        break;
                    default:
                        throw new NotSupportedException($"{BrowserConfig} nao suportado");
                }

                _currentWebDriver = desiredCapabilities;

                return desiredCapabilities;
            }
        }

        public WebDriverWait Wait => new WebDriverWait(Current, TimeSpan.FromSeconds(10));

        protected string BrowserConfig => ConfigurationManager.AppSettings["browser"];

        protected string EcommerceUrl => ConfigurationManager.AppSettings["ecommerceUrl"];

        public void Quit()
        {
            if (_currentWebDriver != null)
            {
                _currentWebDriver.Quit();
                _currentWebDriver.Dispose();
                _currentWebDriver = null;
            }
        }
    }
}