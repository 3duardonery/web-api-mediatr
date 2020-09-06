using APIMediatr.Api.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIMediatr.Api.EventHanders
{
    public class LogEventHandler :
        INotificationHandler<PessoaCriadaNotification>,
        INotificationHandler<PessoaAlteradaNotification>,
        INotificationHandler<PessoaExcluidaNotification>,
        INotificationHandler<ErroNotification>
    {
        public Task Handle(ErroNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(
                () => Console.WriteLine($"Erro ${notification.Excecao}"));
        }

        public Task Handle(PessoaExcluidaNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(
                () => Console.WriteLine($"Pessoa deletada com sucesso: {notification.Id}"));
        }

        public Task Handle(PessoaAlteradaNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(
                () => Console.WriteLine($"Pessoa alterada com sucesso: {notification.Id}"));
        }

        public Task Handle(PessoaCriadaNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(
                () => Console.WriteLine($"Pessoa criada com sucesso: {notification.Id}"));
        }
    }
}
