using SeleniumCSharpNUnitFramework.Framework.NUnitConsole;

namespace SeleniumCSharpNUnitFramework.Framework.Config;

internal interface ITestRunConfigFactory
{
    ITestRunConfig Create();
}
public class TestRunConfigFactory : ITestRunConfigFactory
{
    private readonly IOverwriteConfigFromNUnitConsoleParams _overwriteConfigFromNUnitConsoleParams;
    public ITestRunConfig Create()
    {
        throw new NotImplementedException();
    }
}