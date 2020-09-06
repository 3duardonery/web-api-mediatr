using MediatR;

namespace APIMediatr.Domain.Notifications
{
    public class PessoaAlteradaNotification : INotification
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Sexo { get; set; }
        public bool IsEfetivado { get; set; }
    }

}
