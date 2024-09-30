using DotNetEnv;
using Prosoft.Company.Domain.Contracts;

namespace Prosoft.Company.Domain.Services;

public class ConfigManager : IConfigManager
{
    public ConfigManager()
    {
        Env.Load();
    }

    public string GetConnectionString()
    {
        string dbHost = Env.GetString("DB_HOST");
        string dbPort = Env.GetString("DB_PORT");
        string dbName = Env.GetString("DB_NAME");
        string dbUser = Env.GetString("DB_USER");
        string dbPassword = Env.GetString("DB_PASSWORD");

        return $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPassword};Include Error Detail=true;";
    }

    public string GetDatabaseConnectionString()
    {
        return Env.GetString("DB_NAME");
    }

    public string GetPasswordConnectionString()
    {
        return Env.GetString("DB_PASSWORD");
    }

    public string GetTestConnectionString()
    {
        return Env.GetString("TEST_CONNECTION");
    }

    public string GetUserConnectionString()
    {
        return Env.GetString("DB_USER");
    }
}
