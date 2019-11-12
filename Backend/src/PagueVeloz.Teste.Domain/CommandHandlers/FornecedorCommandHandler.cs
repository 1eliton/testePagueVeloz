using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PagueVeloz.Teste.Domain.CommandHandlers;
using PagueVeloz.Teste.Domain.Commands;
using PagueVeloz.Teste.Domain.Core;
using PagueVeloz.Teste.Domain.Interfaces;

namespace PagueVeloz.Teste.Domain
{
    public class FornecedorCommandHandler : CommandHandler,
        IRequestHandler<VincularFornecedorEmpresaCommand, bool>
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMediatorHandler _mediator;

        public FornecedorCommandHandler(IUnitOfWork uow,
            IMediatorHandler mediator,
            INotificationHandler<DomainNotification> notifications, IEmpresaRepository empresaRepository)
            : base(uow, mediator, notifications)
        {
            _empresaRepository = empresaRepository;
            _mediator = mediator;
        }

        public Task<bool> Handle(VincularFornecedorEmpresaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    NotifyValidationErrors(request);
                    return Task.FromResult(false);
                }

                var empresa = _empresaRepository.GetByIdIncludeFornecedor(request.IdEmpresa);

                empresa.VincularFornecedor(new Fornecedor(empresa, request.Nome, request.Rg, request.DataNascimento, request.Documento, new Telefone(request.Telefone)));

                return Task.FromResult(Commit());
            }
            catch (Exception ex)
            {
                _mediator.AddDomainNotification(request.MessageType, ex.Message);
                return Task.FromResult(false);
            }
        }
    }
}