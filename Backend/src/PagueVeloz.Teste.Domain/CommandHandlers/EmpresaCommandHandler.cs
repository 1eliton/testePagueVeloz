using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PagueVeloz.Teste.Domain.CommandHandlers;
using PagueVeloz.Teste.Domain.Commands.Empresa;
using PagueVeloz.Teste.Domain.Core;
using PagueVeloz.Teste.Domain.Interfaces;

namespace PagueVeloz.Teste.Domain
{
    public class EmpresaCommandHandler : CommandHandler,
        IRequestHandler<CadastrarEmpresaCommand, bool>
    {

        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMediatorHandler _mediator;

        public EmpresaCommandHandler(IUnitOfWork uow,
            IMediatorHandler mediator,
            INotificationHandler<DomainNotification> notifications,
            IEmpresaRepository empresaRepository)
            : base(uow, mediator, notifications)
        {
            _empresaRepository = empresaRepository;
            _mediator = mediator;
        }

        public Task<bool> Handle(CadastrarEmpresaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    NotifyValidationErrors(request);
                    return Task.FromResult(false);
                }

                var empresa = new Empresa(request.NomeFantasia, request.Cnpj, request.Uf);
                _empresaRepository.Add(empresa);
                return Task.FromResult(Commit());
            }
            catch (Exception ex)
            {
                _mediator.AddDomainNotification(request.MessageType,
                    $"Falha ao cadastrar empresa. Motivo: {ex.Message}");

                return Task.FromResult(false);
            }
        }
    }
}