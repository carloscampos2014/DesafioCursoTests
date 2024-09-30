namespace Prosoft.Company.Domain.Entities;

public class ResultModel
{
    public bool Sucesso { get; set; } = false;

    public string MensagemErro { get; set; } = string.Empty;

    public CompanyModel Empresa { get; set; } = new CompanyModel();

    public IEnumerable<CompanyModel> Empresas { get; set; } = new List<CompanyModel>();
}
