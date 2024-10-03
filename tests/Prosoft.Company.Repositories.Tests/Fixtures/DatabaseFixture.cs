using Bogus;
using Bogus.Extensions.Brazil;
using Dapper;
using Prosoft.Company.Domain.Contracts;
using Prosoft.Company.Domain.Entities;
using Prosoft.Company.Domain.Services;
using Xunit;

namespace Prosoft.Company.Repositories.Tests.Fixtures;

public class DatabaseFixture : IDisposable
{
    private readonly IConfigManager _configManager;
    private readonly IDbConnectionFactory _connectionFactory;

    public IDbConnectionFactory ConnectionFactory => _connectionFactory;

    public DatabaseFixture()
    {
        _configManager = new ConfigManager();
        _connectionFactory = new DbConnectionFactory(_configManager);
        SetupEnvironment();
    }

    public CompanyModel CreateModel()
    {
        var faker = new Faker<CompanyModel>("pt_BR")
            .RuleFor(e => e.Id, f => f.Random.Guid())
            .RuleFor(e => e.Nome, f => f.Company.CompanyName())
            .RuleFor(e => e.Cnpj, f => f.Company.Cnpj(false))
            .RuleFor(e => e.Endereco, f => f.Address.FullAddress())
            .RuleFor(e => e.Telefone, f => f.Phone.PhoneNumber("###########"))
            .RuleFor(e => e.Email, f => f.Internet.Email());
        return faker.Generate();
    }

    public void AddModel(CompanyModel model)
    {
        using (var connection = _connectionFactory.CreateConnection())
        {
            connection.Open();
            string sql = @"INSERT INTO geral.empresas(Id, Nome, Cnpj, Endereco, Telefone, Email)
                              VALUES(@Id, @Nome, @Cnpj, @Endereco, @Telefone, @Email) ";
            var parameters = new {
                model.Id,
                model.Nome,
                model.Cnpj,
                model.Endereco,
                model.Telefone,
                model.Email,
            };

            connection.Execute(sql, parameters);
        }
    }

    public void RemoveModel()
    {
        using (var connection = _connectionFactory.CreateConnection())
        {
            connection.Open();
            connection.Execute("DELETE FROM geral.empresas");
        }
    }

    private void SetupEnvironment()
    {
        var userName = _configManager.GetUserConnectionString();
        var userPassword = _configManager.GetPasswordConnectionString();
        var dbName = _configManager.GetDatabaseConnectionString();

        using (var connection = _connectionFactory.CreateConnectionTest())
        {
            try
            {
                connection.Open();

                if (dbName.ToLower() != "postgres")
                {
                    var dbExists = connection.QuerySingleOrDefault<int?>(
                        "SELECT 1 FROM pg_database WHERE datname = @dbName;",
                        new { dbName });
                    if (!dbExists.HasValue)
                    {
                        connection.Execute($"CREATE DATABASE {dbName};");
                    }
                }

                if (userName.ToLower() != "postgres")
                {
                    var userExists = connection.QuerySingleOrDefault<int?>(
                        "SELECT 1 FROM pg_roles WHERE rolname = @userName;",
                        new { userName });
                    if (!userExists.HasValue)
                    {
                        connection.Execute($"CREATE ROLE {userName} LOGIN PASSWORD '{userPassword}';");
                    }
                }

                connection.Execute($"GRANT CONNECT ON DATABASE {dbName} TO {userName};");
                connection.Execute($"GRANT ALL PRIVILEGES ON DATABASE {dbName} TO {userName};");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao configurar o ambiente: {ex.Message}");
            }
        }

        using (var connection = _connectionFactory.CreateConnection())
        {
            connection.Open();
            var createTableScriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "CreateTable.Sql");
            connection.Execute(File.ReadAllText(createTableScriptPath).Replace("@userName", userName));
        }
    }

    private void RemoveEnvironment()
    {
        var userName = _configManager.GetUserConnectionString();
        var dbName = _configManager.GetDatabaseConnectionString();

        using (var connection = _connectionFactory.CreateConnectionTest())
        {
            try
            {
                connection.Open();
                connection.Execute($"SELECT pg_terminate_backend(pid) FROM pg_stat_activity WHERE datname = '{dbName}' AND pid <> pg_backend_pid();");
                Thread.Sleep(1000);

                if (dbName.ToLower() != "postgres")
                {
                    connection.Execute($"DROP DATABASE IF EXISTS {dbName};");
                }

                if (userName.ToLower() != "postgres")
                {
                    connection.Execute($"DROP ROLE IF EXISTS {userName};");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }
    }

    public void Dispose()
    {
        RemoveEnvironment();
    }
}

[CollectionDefinition("Database")]
public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
{
    // Essa classe não contém código, serve apenas como ponto de definição.
}
