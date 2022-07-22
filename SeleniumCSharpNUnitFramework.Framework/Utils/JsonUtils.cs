using Microsoft.Extensions.Configuration;
using SeleniumCSharpNUnitFramework.Framework.Constants;

namespace SeleniumCSharpNUnitFramework.Framework.Utils;

public class JsonUtils
{

    /**
 * Private constructor to avoid external instantiation
 */
    private JsonUtils()
    {
    }
    public static string ReadJson(string key)
    {
        var environmentName =
            Environment.GetEnvironmentVariable("ENVIRONMENT");

        Console.WriteLine($"Environment: {environmentName}");
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false)
            .AddJsonFile($"appsettings.{environmentName}.json", true)
            .Build();
        
        return config.GetSection(key).Value;
    }
    
}