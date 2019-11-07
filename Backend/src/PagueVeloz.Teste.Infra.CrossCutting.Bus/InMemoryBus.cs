using System.Threading.Tasks;
using MediatR;
using PagueVeloz.Teste.Domain.Core;

namespace PagueVeloz.Teste.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            return _mediator.Publish(@event);
        }

        public Task AddDomainNotification(string key, string erro)
        {
            return RaiseEvent(new DomainNotification(key, erro));
        }
    }
}