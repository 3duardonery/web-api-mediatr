using MediatR;

namespace APIMediatr.Domain.Commands
{
    public class CadastraPessoaCommand : IRequest<string>
    {
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public int Idade { get; set; }
    }
}
