using Prosoft.Company.Domain.UseCases.AddCompany;
using Prosoft.Company.Domain.UseCases.DeleteCompany;
using Prosoft.Company.Domain.UseCases.GetAllCompany;
using Prosoft.Company.Domain.UseCases.GetByCnpjCompany;
using Prosoft.Company.Domain.UseCases.UpdateCompany;
using Prosoft.Company.IOC;

namespace Prosoft.Company.WF
{
    internal static class Program
    {
        public static IAddCompanyUseCase AddCompanyUseCase { get; private set; }
        public static IDeleteCompanyUseCase DeleteCompanyUseCase { get; private set; }
        public static IGetAllCompanyUseCase GetAllCompanyUseCase { get; private set; }
        public static IGetByCnpjCompanyUseCase GetByCnpjCompanyUseCase { get; private set; }
        public static IUpdateCompanyUseCase UpdateCompanyUseCase { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var container = DependencyInjector.Init(ConfigManagerType.EnvironmentFile);
            AddCompanyUseCase = container.GetInstance<IAddCompanyUseCase>();
            DeleteCompanyUseCase = container.GetInstance<IDeleteCompanyUseCase>();
            GetAllCompanyUseCase = container.GetInstance<IGetAllCompanyUseCase>();
            GetByCnpjCompanyUseCase = container.GetInstance<IGetByCnpjCompanyUseCase>();
            UpdateCompanyUseCase = container.GetInstance<IUpdateCompanyUseCase>();

            Application.Run(new frmMain());
        }
    }
}