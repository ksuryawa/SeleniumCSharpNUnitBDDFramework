using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumCSharpNUnitFramework.Framework.Drivers;

namespace SeleniumCSharpNUnitFramework.Framework.Pages;

public abstract class BasePage
{
   protected IWebDriver _driver;
   
   protected BasePage(IWebDriver driver)
   {
      _driver = driver;
   }

}