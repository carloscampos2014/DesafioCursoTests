using Dapper;
using Prosoft.Company.Domain.Contracts;
using Prosoft.Company.Domain.Entities;

namespace Prosoft.Company.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public CompanyRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public bool Add(CompanyModel model)
    {
        if (model == null)
        {
            return false;
        }

        using (var connection = _connectionFactory.CreateConnection())
        {
            string sql = @"INSERT INTO geral.empresas(Id, Nome, Cnpj, Endereco, Telefone, Email)
                           VALUES(@Id, @Nome, @Cnpj, @Endereco, @Telefone, @Email);";
            var parameters = new {
                model.Id,
                model.Nome,
                model.Cnpj,
                model.Endereco,
                model.Telefone,
                model.Email,
            };

            return connection.Execute(sql, parameters) > 0;
        }
    }

    public bool Delete(Guid id)
    {
        using (var connection = _connectionFactory.CreateConnection())
        {
            string sql = "DELETE FROM geral.empresas WHERE Id = @Id";
            var parameters = new { Id = id };

            return connection.Execute(sql, parameters) > 0;
        }
    }

    public IEnumerable<CompanyModel> GetAll()
    {
        using (var connection = _connectionFactory.CreateConnection())
        {
            string sql = "SELECT Id, Nome, Cnpj, Endereco, Telefone, Email, DataCriacao, DataAtualizacao FROM geral.empresas ORDER BY Nome";
            return connection.Query<CompanyModel>(sql);
        }
    }

    public CompanyModel? GetByCnpj(string cnpj)
    {
        if (string.IsNullOrEmpty(cnpj))
        {
            return null;
        }

        using (var connection = _connectionFactory.CreateConnection())
        {
            string sql = "SELECT Id, Nome, Cnpj, Endereco, Telefone, Email, DataCriacao, DataAtualizacao FROM geral.empresas WHERE Cnpj = @Cnpj";
            var parameters = new { Cnpj = cnpj };

            return connection.QueryFirstOrDefault<CompanyModel>(sql, parameters);
        }
    }

    public CompanyModel? GetById(Guid id)
    {
        using (var connection = _connectionFactory.CreateConnection())
        {
            string sql = "SELECT Id, Nome, Cnpj, Endereco, Telefone, Email, DataCriacao, DataAtualizacao FROM geral.empresas WHERE Id = @Id";
            var parameters = new { Id = id };

            return connection.QueryFirstOrDefault<CompanyModel>(sql, parameters);
        }
    }

    public bool Update(CompanyModel model)
    {
        if (model == null)
        {
            return false;
        }

        using (var connection = _connectionFactory.CreateConnection())
        {
            string sql = @"UPDATE geral.empresas SET
                           Nome = @Nome, 
                           Cnpj = @Cnpj,
                           Endereco = @Endereco,
                           Telefone = @Telefone,
                           Email = @Email,
                           DataAtualizacao = CURRENT_TIMESTAMP
                           WHERE Id = @Id";
            var parameters = new {
                model.Nome,
                model.Cnpj,
                model.Endereco,
                model.Telefone,
                model.Email,
                model.Id,
            };

            return connection.Execute(sql, parameters) > 0;
        }
    }
}
