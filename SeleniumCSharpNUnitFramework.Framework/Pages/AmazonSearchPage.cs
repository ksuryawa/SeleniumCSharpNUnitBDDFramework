using OpenQA.Selenium;
using SeleniumCSharpNUnitFramework.Framework.Drivers;
using SeleniumCSharpNUnitFramework.Framework.Utils;

namespace SeleniumCSharpNUnitFramework.Framework.Pages;

public class AmazonSearchPage : BasePage
{
   private readonly IWebDriver _driver;
   
   
   public AmazonSearchPage(IWebDriver driver) : base(driver)
   {
      _driver= driver;
   }
   
   private readonly By _inputSeachBox = By.Id("twotabsearchtextbox");
   private readonly By _searchButton = By.XPath("//input[@value='Go']");
   
   public void SearchItem(string searchText)
   {
      _driver.SendKeys(_inputSeachBox,searchText);
      _driver.Click(_searchButton);
     
   }
   
   public string GetPageTitle()
   {
      return _driver.GetPageTitle();
   }
   
    
}