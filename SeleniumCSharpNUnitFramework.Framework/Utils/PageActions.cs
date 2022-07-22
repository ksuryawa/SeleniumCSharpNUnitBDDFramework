using OpenQA.Selenium;

namespace SeleniumCSharpNUnitFramework.Framework.Utils;

public static class PageActions
{
    public static void Click(this IWebDriver driver,By element)
    {
        driver.FindElement(element).Click();
    }
    
    public static void SendKeys(this IWebDriver driver,By element, string text)
    {
        driver.FindElement(element).SendKeys(text);
    }
    
    public static string GetPageTitle(this IWebDriver driver)
    {
        return driver.Title;
    }
}