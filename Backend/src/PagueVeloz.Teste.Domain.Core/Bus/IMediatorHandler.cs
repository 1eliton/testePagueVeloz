using System.Threading.Tasks;

namespace PagueVeloz.Teste.Domain.Core
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
        Task AddDomainNotification(string key, string erro);
    }
}