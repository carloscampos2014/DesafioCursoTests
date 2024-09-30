using FluentValidation.Results;
using FluentValidation;
using Prosoft.Company.Domain.Entities;

namespace Prosoft.Company.Domain.Validators;

public class CompanyValidator : AbstractValidator<CompanyModel>
{
    public CompanyValidator()
    {
        RuleFor(r => r.Nome)
            .NotEmpty().WithMessage("Nome é obrigatário.")
            .Length(3, 100).WithMessage("O Nome deve ter entre 3 e 200 Letras.");

        RuleFor(r => r.Cnpj)
            .NotEmpty().WithMessage("CNPJ é obrigatário.")
            .IsValidCNPJ().WithMessage("CNPJ Inválido.");

        RuleFor(r => r.Endereco)
            .NotEmpty().WithMessage("Endereço é obrigatário.")
            .Length(3, 200).WithMessage("O Endereço deve ter entre 3 e 200 Letras.");

        RuleFor(e => e.Telefone)
            .NotEmpty().WithMessage("Telefone é obrigatório.")
            .Length(10, 11).WithMessage("Telefone Inválido.");

        RuleFor(r => r.Email)
            .NotEmpty().WithMessage("E-Mail é obrigatário.")
            .EmailAddress().WithMessage("E-Mail Inválido.");
    }

    public override ValidationResult Validate(ValidationContext<CompanyModel> context)
    {
        if (context == null || context.InstanceToValidate == null)
        {
            return new ValidationResult(new List<ValidationFailure> { new ValidationFailure(typeof(CompanyModel).Name, "O objeto empresa não pode ser nulo.") });
        }

        return base.Validate(context);
    }
}
