using APIMediatr.Domain.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace APIMediatr.Domain.EventHanders
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
