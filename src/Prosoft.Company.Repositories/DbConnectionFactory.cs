using Prosoft.Company.Domain.Contracts;
using System.Data;

namespace Prosoft.Company.Repositories;
public class DbConnectionFactory : IDbConnectionFactory
{
    private readonly IConfigManager _configManager;

    public DbConnectionFactory(IConfigManager configManager)
    {
        _configManager = configManager;
    }

    public IDbConnection CreateConnection()
    {
        return new Npgsql.NpgsqlConnection(_configManager.GetConnectionString());
    }

    public IDbConnection CreateConnectionTest()
    {
        return new Npgsql.NpgsqlConnection(_configManager.GetTestConnectionString());
    }
}
