namespace SeleniumCSharpNUnitFramework.Framework.Constants;

public class FrameworkConstants
{
   

    private FrameworkConstants()
    {
    }
    
    public static string ROOT_DIRECTORY{ get; set; } = Directory.GetCurrentDirectory();
    public static string CONFIG_FILE_PATH { get; set; } = ROOT_DIRECTORY + "//appsettings.json";
    public static string EXTENT_REPORT_FILE { get; set; } = "//ExtentReport.html";
    public static string REPORT_CONFIG_FILE{ get; set; } = ROOT_DIRECTORY + "//extent-config.xml";

}