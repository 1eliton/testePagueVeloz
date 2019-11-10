using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PagueVeloz.Teste.Application;
using PagueVeloz.Teste.Domain;
using PagueVeloz.Teste.Domain.Commands;
using PagueVeloz.Teste.Domain.Commands.Empresa;
using PagueVeloz.Teste.Domain.Core;
using PagueVeloz.Teste.Domain.Interfaces;
using PagueVeloz.Teste.Infra.CrossCutting.Bus;
using PagueVeloz.Teste.Infra.Data;

namespace PagueVeloz.Teste.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IEmpresaAppService, EmpresaAppService>();

            //Domain
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();

            //Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //Domain - Commands
            services.AddScoped<IRequestHandler<CadastrarEmpresaCommand, bool>, EmpresaCommandHandler>();

            services.AddScoped<IRequestHandler<VincularFornecedorEmpresaCommand, bool>, FornecedorCommandHandler>();


            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<PagueVelozContext>();
        }
    }
}