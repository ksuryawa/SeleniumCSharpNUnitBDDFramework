using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V102.Schema;
using OpenQA.Selenium.Safari;
using WebDriverManager.DriverConfigs.Impl;


namespace SeleniumCSharpNUnitFramework.Framework.Drivers;

public class DriverFactory
{
    private DriverFactory()
    {
    }

    public static IWebDriver GetDriver(string browser)
    {
        IWebDriver driver = null;

        if(browser.Equals("Chrome",StringComparison.InvariantCultureIgnoreCase))
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
        }

        return driver;

    }
    
    
}