using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using SeleniumCSharpNUnitFramework.Framework.Constants;

namespace SeleniumCSharpNUnitFramework.Framework.Reports;

public class ExtentReport
{
    private static ExtentReports extent;
    
    public static void InitReport()
    {
       var htmlReporter = new ExtentHtmlReporter(FrameworkConstants.ROOT_DIRECTORY);
        extent = new ExtentReports();
        extent.AttachReporter(htmlReporter);
        
        htmlReporter.Config.Theme = Theme.Dark;
        htmlReporter.Config.DocumentTitle = "SeleniumCSharpNUnitFramework";
        htmlReporter.Config.ReportName = "SeleniumCSharpNUnitFramework Report";
    }
    
    public static void TearDownReport()
    {
        extent.Flush();
    }
    
    /*public static void CreateTest(ExtentTest test)
    {
        extent.CreateTest(test);
    }*/
}