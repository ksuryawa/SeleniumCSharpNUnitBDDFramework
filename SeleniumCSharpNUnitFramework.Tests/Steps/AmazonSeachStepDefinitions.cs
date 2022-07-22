using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using SeleniumCSharpNUnitFramework.Framework.Pages;
using SeleniumCSharpNUnitFramework.Framework.Utils;
using TechTalk.SpecFlow;

namespace SeleniumCSharpNUnitFramework.Tests.Steps;

[Binding]
public sealed class AmazonSeachStepDefinitions
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

    private readonly ScenarioContext _scenarioContext;
    private readonly AmazonSearchPage _amazonSearchPage;

    public AmazonSeachStepDefinitions(IWebDriver driver)
    {
        //_scenarioContext = scenarioContext;
        _amazonSearchPage = new AmazonSearchPage(driver);
    }

    [Given(@"I am on the Amazon home page")]
    public void GivenIAmOnTheAmazonHomePage()
    {
       // Console.WriteLine($"I am on the Amazon home page");
       _amazonSearchPage.GetPageTitle();
    }
     
    [When(@"I search for (.*)")]
   public void WhenISearchFor(string iPhone0)
    {
        _amazonSearchPage.SearchItem(iPhone0);
    }
     
    [Then(@"I should see (.*)")]
    public void ThenIShouldSee(string iPhone0)
    {
       // Console.WriteLine($"I should see {iPhone0}");
       _amazonSearchPage.GetPageTitle();
    }
    
   
        
    
}