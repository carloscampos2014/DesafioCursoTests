namespace Prosoft.Company.Domain.Contracts;
public interface IConfigManager
{
    string GetConnectionString();

    string GetTestConnectionString();

    string GetUserConnectionString();

    string GetPasswordConnectionString();

    string GetDatabaseConnectionString();
}
