using ClientesApp.Domain.Interfaces.Repository;
using ClientesApp.Domain.Interfaces.Services;
using ClientesApp.Domain.Services;
using ClientesApp.Infra.Data.Repositories;

namespace ClientesApp.Api.Configurations
{
    /// <summary>
    ///Classe para configuração as injeções de dependencia do projeto
    /// </summary>
    public class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(IServiceCollection services)
        {
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
        }
    }
}
