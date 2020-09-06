using MediatR;

namespace APIMediatr.Domain.Notifications
{
    public class PessoaExcluidaNotification : INotification
    {
        public string Id { get; set; }
        public bool IsEfetivado { get; set; }
    }

}
