using System;
using System.Threading.Tasks;
using MediatR;
using PagueVeloz.Teste.Domain.Core;
using PagueVeloz.Teste.Domain.Interfaces;

namespace PagueVeloz.Teste.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            try
            {
                if (_notifications.HasNotifications()) return false;
                if (_uow.Commit()) return true;

                _bus.RaiseEvent(new DomainNotification("Commit", "Falha ao salvar as alterações."));
                return false;
            }
            catch (Exception ex)
            {
                _bus.RaiseEvent(new DomainNotification("Commit", $"Falha ao salvar as alterações. Motivo: \n {ex.InnerException?.Message}"));
                return false;
            }

        }

        /// <summary>
        /// Efetua o despacho de eventos de domínio no contexto através do MediaTR.
        /// <para>
        /// É necessário que os Events tenham os seus EventHandlers.
        /// É importante saber que os eventos são despachados antes do SaveChanges() do contexto.
        /// </para>
        /// </summary>
        public Task<bool> CommitAsync()
        {
            try
            {
                if (_notifications.HasNotifications()) return Task.FromResult(false);
                if (_uow.Commit()) return Task.FromResult(true);

                _bus.RaiseEvent(new DomainNotification("Commit", "Falha ao salvar as alterações."));
                return Task.FromResult(false);
            }
            catch (Exception ex)
            {
                _bus.RaiseEvent(new DomainNotification("Commit", $"Falha ao salvar as alterações. Motivo: \n {ex.InnerException?.Message}"));
                return Task.FromResult(false);
            }

        }


    }
}