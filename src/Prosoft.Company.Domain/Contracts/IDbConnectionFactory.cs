using System.Data;

namespace Prosoft.Company.Domain.Contracts;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();

    IDbConnection CreateConnectionTest();
}
