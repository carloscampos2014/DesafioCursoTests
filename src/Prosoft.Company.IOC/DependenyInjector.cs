using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using FluentValidation;
using Prosoft.Company.Domain.Contracts;
using Prosoft.Company.Domain.Entities;
using Prosoft.Company.Domain.Services;
using Prosoft.Company.Domain.UseCases.AddCompany;
using Prosoft.Company.Domain.UseCases.DeleteCompany;
using Prosoft.Company.Domain.UseCases.GetAllCompany;
using Prosoft.Company.Domain.UseCases.GetByCnpjCompany;
using Prosoft.Company.Domain.UseCases.UpdateCompany;
using Prosoft.Company.Domain.Validators;
using Prosoft.Company.Repositories;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Prosoft.Company.IOC;

public static class DependencyInjector
{
    public static Container Init(ConfigManagerType configManagerType)
    {
        var container = new Container();

        switch (configManagerType)
        {
            case ConfigManagerType.EnvironmentFile:
                container.Register<IConfigManager, ConfigManager>();
                break;
            case ConfigManagerType.ApplicationConfig:
                container.Register<IConfigManager, AppConfigManager>();
                break;
        }

        container.Register<IDbConnectionFactory, DbConnectionFactory>();
        container.Register<ICompanyRepository, CompanyRepository>();
        container.Register<IValidator<CompanyModel>, CompanyValidator>();
        container.Register<IAddCompanyUseCase, AddCompanyUseCase>();
        container.Register<IDeleteCompanyUseCase, DeleteCompanyUseCase>();
        container.Register<IGetAllCompanyUseCase, GetAllCompanyUseCase>();
        container.Register<IGetByCnpjCompanyUseCase, GetByCnpjCompanyUseCase>();
        container.Register<IUpdateCompanyUseCase, UpdateCompanyUseCase>();

        return container;
    }
}
