using Microsoft.Extensions.Configuration;
using Prosoft.Company.Domain.Contracts;

namespace Prosoft.Company.Domain.Services;

public class AppConfigManager : IConfigManager
{
    private readonly IConfiguration _configuration;
    
    public AppConfigManager()
    {
        _configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
    }

    public string GetConnectionString()
    {
        string dbHost = System.Configuration.ConfigurationManager.AppSettings["DB_HOST"] ?? 
            _configuration["AppSettings:DB_HOST"] ?? string.Empty;
        string dbPort = System.Configuration.ConfigurationManager.AppSettings["DB_PORT"] ??
            _configuration["AppSettings:DB_PORT"] ?? string.Empty;
        string dbName = System.Configuration.ConfigurationManager.AppSettings["DB_NAME"] ??
            _configuration["AppSettings:DB_NAME"] ?? string.Empty;
        string dbUser = System.Configuration.ConfigurationManager.AppSettings["DB_USER"] ??
            _configuration["AppSettings:DB_USER"] ?? string.Empty;
        string dbPassword = System.Configuration.ConfigurationManager.AppSettings["DB_PASSWORD"] ??
            _configuration["AppSettings:DB_PASSWORD"] ?? string.Empty;
        
        return $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPassword};Include Error Detail=true;";
    }

    public string GetDatabaseConnectionString()
    {
        return System.Configuration.ConfigurationManager.AppSettings["DB_NAME"] ??
            _configuration["AppSettings:DB_NAME"] ?? string.Empty;
    }

    public string GetPasswordConnectionString()
    {
        return System.Configuration.ConfigurationManager.AppSettings["DB_PASSWORD"] ??
            _configuration["AppSettings:DB_PASSWORD"] ?? string.Empty;
    }

    public string GetTestConnectionString()
    {
        return System.Configuration.ConfigurationManager.AppSettings["TEST_CONNECTION"] ??
            _configuration["AppSettings:TEST_CONNECTION"] ?? string.Empty;
    }

    public string GetUserConnectionString()
    {
        return System.Configuration.ConfigurationManager.AppSettings["DB_USER"] ??
            _configuration["AppSettings:DB_USER"] ?? string.Empty;
    }
}
