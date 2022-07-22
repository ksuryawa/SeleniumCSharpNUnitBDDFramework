using OpenQA.Selenium;

namespace SeleniumCSharpNUnitFramework.Framework.Utils;

public class ScreenShotUtils
{
    /**
    * Private constructor to avoid external instantiation
    */
    private ScreenShotUtils()
    {}

    public static string GetBase64Image(IWebDriver driver)
    {
        return ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
    }
}