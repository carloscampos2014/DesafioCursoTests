using FluentValidation;
using Prosoft.Company.Domain.Contracts;
using Prosoft.Company.Domain.Entities;

namespace Prosoft.Company.Domain.UseCases.UpdateCompany;

public class UpdateCompanyUseCase : IUpdateCompanyUseCase
{
    private readonly IValidator<CompanyModel> _empresasModelValidator;
    private readonly ICompanyRepository _empresasRepository;

    public UpdateCompanyUseCase(IValidator<CompanyModel> empresasModelValidator, ICompanyRepository empresasRepository)
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

            var companyCadastrada = _empresasRepository.GetById(model.Id);
            if (companyCadastrada == null)
            {
                throw new InvalidOperationException("Empresa não Cadastrada.");
            }

            if (companyCadastrada.Cnpj != model.Cnpj)
            {
                throw new InvalidOperationException("Não é permitido alteração de CNPJ.");
            }

            var resultUpdate = _empresasRepository.Update(model);

            return new ResultModel()
            {
                Sucesso = resultUpdate,
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
