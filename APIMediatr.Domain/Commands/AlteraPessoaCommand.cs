using MediatR;

namespace APIMediatr.Domain.Commands
{
    public class AlteraPessoaCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public int Idade { get; set; }
    }
}
