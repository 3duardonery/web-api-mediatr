using MediatR;

namespace APIMediatr.Domain.Notifications
{
    public class PessoaCriadaNotification : INotification
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Sexo { get; set; }
    }

}
