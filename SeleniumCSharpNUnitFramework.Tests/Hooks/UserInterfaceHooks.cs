using System;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumCSharpNUnitFramework.Framework.Drivers;
using SeleniumCSharpNUnitFramework.Framework.Utils;
using TechTalk.SpecFlow;
[assembly:Parallelizable(ParallelScope.Fixtures)]

namespace SeleniumCSharpNUnitFramework.Tests.Hooks
{
    [Binding]
    public class UserInterfaceHooks
    {
       
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;

        public UserInterfaceHooks(ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            _scenarioContext = scenarioContext;
            _objectContainer = objectContainer;
        }
       
        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = DriverFactory.GetDriver(JsonUtils.ReadJson("browser"));
            _driver.Manage().Window.Maximize();
            _driver.Url = JsonUtils.ReadJson("url");
            _objectContainer.RegisterInstanceAs(_driver);
            
        }
        
        [AfterScenario]
        public void AfterScenario()
        {
           _driver.Dispose();
        }
        
      
        
       
        
    }
}