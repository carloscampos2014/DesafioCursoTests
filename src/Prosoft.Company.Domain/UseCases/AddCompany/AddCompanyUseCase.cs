using FluentValidation;
using Prosoft.Company.Domain.Contracts;
using Prosoft.Company.Domain.Entities;

namespace Prosoft.Company.Domain.UseCases.AddCompany;

public class AddCompanyUseCase : IAddCompanyUseCase
{
    private readonly IValidator<CompanyModel> _empresasModelValidator;
    private readonly ICompanyRepository _empresasRepository;

    public AddCompanyUseCase(
        IValidator<CompanyModel> empresasModelValidator,
        ICompanyRepository empresasRepository)
    {
        _empresasModelValidator = empresasModelValidator;
        _empresasRepository = empresasRepository;
    }

    public ResultModel Execute(CompanyModel model)
    {
        try
        {
            var resultValidation = _empresasModelValidator.Validate(model);
            if (!resultValidation.IsValid)
            {
                throw new InvalidOperationException($"Erro Validação: {string.Join('|', resultValidation.Errors.Select(erro => erro.ErrorMessage))}");
            }

            var cnpjCadastrado = _empresasRepository.GetByCnpj(model.Cnpj);
            if (cnpjCadastrado != null)
            {
                throw new InvalidOperationException($"Já existe um empresa cadastrada com esse CNPJ ({model.Cnpj})");
            }

            var resultAdd = _empresasRepository.Add(model);

            return new ResultModel()
            {
                Sucesso = resultAdd,
                Empresa = model,
            };
        }
        catch (Exception ex)
        {
            return new ResultModel()
            {
                MensagemErro = ex.Message,
            };
        }
    }
}
