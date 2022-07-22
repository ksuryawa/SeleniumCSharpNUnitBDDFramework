namespace SeleniumCSharpNUnitFramework.Framework.NUnitConsole;

public interface IOverwriteConfigFromNUnitConsoleParams
{
    Browser? GetBrowserOverride();
    
    string GetEnvironmentOverride();
}