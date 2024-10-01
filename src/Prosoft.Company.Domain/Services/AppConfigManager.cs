using System.Configuration;
using Prosoft.Company.Domain.Contracts;

namespace Prosoft.Company.Domain.Services;

public class AppConfigManager : IConfigManager
{
    public string GetConnectionString()
    {
        string dbHost = ConfigurationManager.AppSettings["DB_HOST"] ?? string.Empty;
        string dbPort = ConfigurationManager.AppSettings["DB_PORT"] ?? string.Empty;
        string dbName = ConfigurationManager.AppSettings["DB_NAME"] ?? string.Empty;
        string dbUser = ConfigurationManager.AppSettings["DB_USER"] ?? string.Empty;
        string dbPassword = ConfigurationManager.AppSettings["DB_PASSWORD"] ?? string.Empty;

        return $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPassword};Include Error Detail=true;";
    }

    public string GetDatabaseConnectionString()
    {
        return ConfigurationManager.AppSettings["DB_NAME"] ?? string.Empty;
    }

    public string GetPasswordConnectionString()
    {
        return ConfigurationManager.AppSettings["DB_PASSWORD"] ?? string.Empty;
    }

    public string GetTestConnectionString()
    {
        return ConfigurationManager.AppSettings["TEST_CONNECTION"] ?? string.Empty;
    }

    public string GetUserConnectionString()
    {
        return ConfigurationManager.AppSettings["DB_USER"] ?? string.Empty;
    }
}
