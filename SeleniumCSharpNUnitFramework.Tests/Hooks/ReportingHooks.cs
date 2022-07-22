using System.Reflection;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V101.Network;
using SeleniumCSharpNUnitFramework.Framework.Constants;
using SeleniumCSharpNUnitFramework.Framework.Reports;
using SeleniumCSharpNUnitFramework.Framework.Utils;
using WebDriverManager.Helpers;

namespace SeleniumCSharpNUnitFramework.Tests.Hooks;

[Binding]
public class ReportingHooks
{
   private readonly ScenarioContext _scenarioContext;
    
    private const string ExtentReportFileName = "extent-result";
    
    [ThreadStatic]
    private static ExtentTest featureName;
    [ThreadStatic]
    private static ExtentTest scenario;
    private static ExtentReports extent;  
    
    private static string reportPath;
    
    public ReportingHooks(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        _featureContext = featureContext;
        _scenarioContext = scenarioContext;
    }
    
    
    [BeforeTestRun]
    public static void InitializeReport()
    {
        var dirInfo = new DirectoryInfo(Path.Combine(FrameworkConstants.ROOT_DIRECTORY));
       var parentDir = dirInfo.Parent.FullName;

       var folderPath = Path.Combine(parentDir, ExtentReportFileName);

       //TODO: Add code to clear existing folder
       
       TrustTokenOperationDoneEventArgs:
       if (!Directory.Exists(folderPath))
       {
           Directory.CreateDirectory(folderPath);
       }
       
       reportPath=folderPath + "\\ExtentReport.html";
       
        var htmlReporter = new ExtentV3HtmlReporter(reportPath);
        htmlReporter.Config.Theme = Theme.Dark;
        htmlReporter.Config.DocumentTitle = "SeleniumCSharpNUnitFramework";
        htmlReporter.Config.ReportName = "SeleniumCSharpNUnitFramework Report";
        htmlReporter.LoadConfig(FrameworkConstants.REPORT_CONFIG_FILE);
        extent = new ExtentReports();
        extent.AttachReporter(htmlReporter);
        
       
    }
    
   [AfterStep]
    public void InsertReportingSteps()
    {
        var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
        var stepText = _scenarioContext.StepContext.StepInfo.Text;
        var driver = _scenarioContext.ScenarioContainer.Resolve<IWebDriver>();

        if (_scenarioContext.TestError == null)
        {
            if(stepType== "Given")
            {
                scenario.CreateNode<Given>(stepText);
            }
            else if(stepType == "When")
            {
                scenario.CreateNode<When>(stepText);
            }
            else if(stepType == "Then")
            {
                scenario.CreateNode<Then>(stepText);
            }
            else if(stepType == "And")
            {
                scenario.CreateNode<And>(stepText);
            }
            else if(stepType == "But")
            {
                scenario.CreateNode<But>(stepText);
            }
        }
        else if (_scenarioContext.TestError != null)
        {
            if (stepType == "Given")
            {
                scenario.CreateNode<Given>(stepText)
                    .Fail(_scenarioContext.TestError.Message,MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShotUtils.GetBase64Image(driver)).Build());
            }
        }
    }
    
    [BeforeFeature]
    public static void BeforeFeature(FeatureContext featurecontext)
    {           
        featureName = extent.CreateTest(featurecontext.FeatureInfo.Title);
    }
    
    [BeforeScenario]
    public void BeforeScenario()
    {
        scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        scenario.AssignCategory(_scenarioContext.ScenarioInfo.Tags);
    }
    
    [AfterScenario]
    public void AfterScenario()
    {
        extent.Flush();
    }
    
    [AfterTestRun(Order = 999)]
    public static void TearDownReport()
    {
        extent.Flush();
        Console.WriteLine($"Report is generated at {reportPath}");
        System.Diagnostics.Process.Start(reportPath);
    }
    
    
}